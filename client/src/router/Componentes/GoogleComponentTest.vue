<template>
  <div>
    <!-- Botão oficial do Google -->
    <div id="g_id_signin"></div>
  </div>
</template>

<script setup>
import { onMounted } from "vue";
import api from "@/Request";

const CLIENT_ID = "353535077307-nqv0s4rge8nh5d3a9eklcoacdijk61hf.apps.googleusercontent.com";

// Callback que recebe o id_token
async function handleCredentialResponse(response) {
  const idToken = response?.credential;
  console.log("ID Token:", idToken);
  // Aqui você envia para o backend:
  // fetch("/auth/google", { method: "POST", body: JSON.stringify({ id_token: idToken }) })

    try{
        var res = await api.post("/google?IdToken=" + idToken);
        console.log("Resposta do backend:", res.data.accessToken);
        localStorage.setItem("accessToken", res.data.accessToken);
    }
    catch(err){
      console.error("Erro no login:", err);
    }

    // localStorage.setItem("token", res.data.accessToken);
  
    window.location.reload();

}

function decodeJwt(token) {
  const base64Url = token.split('.')[1]; // pega a parte do payload
  const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  const jsonPayload = decodeURIComponent(
    atob(base64)
      .split('')
      .map(c => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
      .join('')
  );
  return JSON.parse(jsonPayload);
}

function loadGsiScript() {
  return new Promise((resolve, reject) => {
    if (document.getElementById("google-identity-services")) {
      resolve();
      return;
    }
    const script = document.createElement("script");
    script.src = "https://accounts.google.com/gsi/client";
    script.id = "google-identity-services";
    script.async = true;
    script.defer = true;
    script.onload = resolve;
    script.onerror = reject;
    document.head.appendChild(script);
  });
}

onMounted(async () => {
  await loadGsiScript();

  // Inicializa o Google Identity Services
  window.google.accounts.id.initialize({
    client_id: CLIENT_ID,
    callback: handleCredentialResponse,
  });

  // Renderiza o botão oficial
  window.google.accounts.id.renderButton(
    document.getElementById("g_id_signin"),
    { theme: "outline", size: "large" }
  );

  // Opcional: tenta exibir One Tap automaticamente
  window.google.accounts.id.prompt();
});
</script>
