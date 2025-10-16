<template>
  <div class="">
    <button
      @click="onPrimaryClick"
      class="flex items-center  justify-center w-12 h-12 rounded-full bg-white shadow hover:shadow-md transition-transform duration-150 transform hover:scale-110"
      :disabled="!googleReady"
      title="Login com Google"
    >
      <img src="/google.png" alt="Google Logo" class="w-6 h-6" />
    </button>

    <!-- container usado como fallback para renderButton se prompt falhar -->
    <div id="g_id_button_container" style="display:none;"></div>
  </div>
</template>

<script setup>
import { ref, onMounted, onBeforeUnmount } from "vue";
import { useRouter } from "vue-router";

const CLIENT_ID = "353535077307-nqv0s4rge8nh5d3a9eklcoacdijk61hf.apps.googleusercontent.com";
const googleReady = ref(false);
const router = useRouter();
let sdkScript = null;
let tokenClient = null;
let codeClient = null;
let promptInProgress = false;

// novos refs/variáveis para gerenciar id/access token e sincronização
const lastIdToken = ref(null);
const lastAccessToken = ref(null);
let _idResolve = null;
let _idReject = null;

function waitForIdToken(timeout = 8000) {
  if (lastIdToken.value) return Promise.resolve(lastIdToken.value);
  return new Promise((resolve, reject) => {
    _idResolve = resolve;
    _idReject = reject;
    setTimeout(() => {
      _idResolve = null;
      _idReject = null;
      reject(new Error("timeout waiting for id_token"));
    }, timeout);
  });
}

// Recebe o ID Token (One Tap / prompt)
function handleCredentialResponse(response) {
  const idToken = response?.credential;
  console.log("ID Token do Google:", idToken);
  lastIdToken.value = idToken;
  if (_idResolve) {
    _idResolve(idToken);
    _idResolve = null;
    _idReject = null;
  }
  // Exemplo: enviar ao backend
  // axios.post("/auth/google", { id_token: idToken }).then(...).catch(...);
}

// Callback para quando se obtiver um access token via oauth2.initTokenClient (fallback popup)
function handleAccessTokenResponse(tokenResponse) {
  console.log("Resposta OAuth (access token):", tokenResponse);
  lastAccessToken.value = tokenResponse?.access_token ?? null;

  // Se você já tem id_token (via One Tap), pode enviar ambos ao backend:
  // axios.post("/auth/google", { id_token: lastIdToken.value, access_token: lastAccessToken.value }).then(...)

  // Se preferir usar fluxo de código (recomendado para trocar no servidor e obter id_token seguro),
  // use initCodeClient e envie o code para o backend para troca.
}

// Inicializa Google Identity Services e (opcional) Token Client para fallback popup
function initializeGoogleLogin() {
  if (window.google && window.google.accounts) {
    // initialize for One Tap / prompt
    try {
      window.google.accounts.id.initialize({
        client_id: CLIENT_ID,
        callback: handleCredentialResponse,
        auto_select: false, // evita seleção automática inesperada
      });
    } catch (e) {
      console.warn("Erro ao inicializar google.accounts.id:", e);
    }

    // tenta criar token client (popup) como alternativa (se desejar pegar access_token)
    try {
      if (window.google.accounts.oauth2 && window.google.accounts.oauth2.initTokenClient) {
        tokenClient = window.google.accounts.oauth2.initTokenClient({
          client_id: CLIENT_ID,
          scope: "openid email profile",
          callback: handleAccessTokenResponse,
        });
      }
    } catch (e) {
      // tokenClient pode não existir em todos os ambientes
      console.info("tokenClient não disponível:", e);
      tokenClient = null;
    }

    try {
      if (window.google.accounts.oauth2 && window.google.accounts.oauth2.initCodeClient) {
        codeClient = window.google.accounts.oauth2.initCodeClient({
          client_id: CLIENT_ID,
          scope: "openid email profile",
          ux_mode: "popup",
          callback: (resp) => {
            // resp.code -> envie isso ao backend para trocar por tokens (inclui id_token)
            console.log("authorization code recebido:", resp?.code);
            // Exemplo mínimo: enviar ao backend
            fetch("/auth/google/code", {
              method: "POST",
              headers: { "Content-Type": "application/json" },
              body: JSON.stringify({ code: resp?.code }),
            }).then(r => r.json()).then(data => {
              console.log("tokens do backend:", data);
              // data deve incluir id_token (JWT) e access_token conforme exchange no servidor
            }).catch(e => console.error("erro enviando code ao backend:", e));
          },
        });
      }
    } catch (e) {
      console.info("codeClient não disponível:", e);
      codeClient = null;
    }

    googleReady.value = true;
  } else {
    // espera e tenta novamente
    setTimeout(initializeGoogleLogin, 100);
  }
}

// Função que chama o prompt e trata "moment" notifications e erros (incluindo AbortError)
async function callPromptWithListener() {
  if (!window.google || !window.google.accounts || !window.google.accounts.id) return;

  // evita chamadas concorrentes
  if (promptInProgress) return;
  promptInProgress = true;

  try {
    window.google.accounts.id.prompt((moment) => {
      // trata os diferentes momentos (getNotDisplayedReason / getSkippedReason / getDismissedReason)
      try {
        if (moment.isNotDisplayed && moment.isNotDisplayed()) {
          console.log("Prompt não exibido:", moment.getNotDisplayedReason?.());
        } else if (moment.isSkipped && moment.isSkipped()) {
          console.log("Prompt pulado:", moment.getSkippedReason?.());
        } else if (moment.isDismissed && moment.isDismissed()) {
          console.log("Prompt dispensado:", moment.getDismissedReason?.());
        } else {
          console.log("Prompt exibido / credencial retornada.");
        }
      } catch (e) {
        console.log("Notificação do prompt recebida (formato inesperado).", e);
      }
    });
  } catch (err) {
    // Trata AbortError e outros
    if (err && err.name === "AbortError") {
      console.warn("Prompt abortado pelo navegador (AbortError). Renderizando fallback do botão do Google.");
      renderFallbackButton();
    } else {
      console.error("Erro ao chamar google.accounts.id.prompt():", err);
      renderFallbackButton();
    }
  } finally {
    promptInProgress = false;
  }
}

// Renderiza o botão oficial do Google como fallback e exibe no DOM
function renderFallbackButton() {
  try {
    const container = document.getElementById("g_id_button_container");
    if (!container) return;
    if (window.google && window.google.accounts && window.google.accounts.id && container) {
      // limpa container antes de renderizar
      container.innerHTML = "";
      window.google.accounts.id.renderButton(container, {
        theme: "outline",
        size: "large",
      });
      container.style.display = "block";
    }
  } catch (e) {
    console.error("Erro ao renderizar botão fallback:", e);
  }
}

// Ação principal do botão: tenta prompt; se não disponível, usa tokenClient (popup) ou renderButton fallback
async function onPrimaryClick() {
  if (!googleReady.value) return;

  // tenta prompt (pode entregar id_token via One Tap)
  callPromptWithListener();

  // se você precisa do id_token no backend de forma confiável, solicite o authorization code
  // dentro do clique do usuário para evitar bloqueio de popup
  if (codeClient) {
    try {
      codeClient.requestCode(); // abrirá popup e callback acima receberá resp.code
      return;
    } catch (e) {
      console.warn("Falha ao abrir popup de code (provavelmente bloqueado):", e);
      renderFallbackButton();
      return;
    }
  }

  // fallback: se não tiver codeClient, tentar tokenClient (retorna access_token apenas)
  if (tokenClient) {
    try {
      tokenClient.requestAccessToken({ prompt: "consent" });
      return;
    } catch (e) {
      console.warn("Falha ao abrir popup de token:", e);
      renderFallbackButton();
      return;
    }
  }

  // Se não há tokenClient disponível, aguardamos um curto período pelo id_token vindo do prompt
  try {
    const id = await waitForIdToken(5000);
    console.log("id_token obtido após prompt:", !!id);
    // envie id ao backend: axios.post("/auth/google", { id_token: id })
  } catch (err) {
    console.warn("Não foi obtido id_token pelo prompt. Usando botão de fallback / fluxo de código.", err);
    // Abre fluxo de authorization code também precisa ser chamado direto no clique.
    try {
      if (window.google.accounts.oauth2 && window.google.accounts.oauth2.initCodeClient) {
        // inicializa um button de fallback para user gesture — evitar chamar requestCode() aqui se já passou o gesto
        renderFallbackButton();
      } else {
        renderFallbackButton();
      }
    } catch (e) {
      console.error("Erro ao preparar fallback:", e);
      renderFallbackButton();
    }
  }
}

function loadGsiScript() {
  return new Promise((resolve, reject) => {
    if (document.getElementById("google-identity-services")) {
      resolve();
      return;
    }
    sdkScript = document.createElement("script");
    sdkScript.src = "https://accounts.google.com/gsi/client";
    sdkScript.id = "google-identity-services";
    sdkScript.async = true;
    sdkScript.defer = true;
    sdkScript.onload = () => resolve();
    sdkScript.onerror = (e) => reject(e);
    document.head.appendChild(sdkScript);
  });
}

onMounted(async () => {
  try {
    await loadGsiScript();
    initializeGoogleLogin();
    // tenta exibir prompt automaticamente (One Tap) ao montar — captura AbortError e faz fallback
    callPromptWithListener();
  } catch (e) {
    console.error("Falha ao carregar GSI script:", e);
    renderFallbackButton();
  }
});

onBeforeUnmount(() => {
  if (sdkScript && sdkScript.parentNode) sdkScript.parentNode.removeChild(sdkScript);
  if (_idReject) {
    _idReject(new Error("component unmounted"));
    _idResolve = null;
    _idReject = null;
  }
});
</script>

<style scoped>
button:hover {
  cursor: pointer;
}
</style>
