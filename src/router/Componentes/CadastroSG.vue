<template>
  <section
    class="fixed inset-0 z-50 flex justify-center items-center bg-black/60 "
  >
    <div
      class="relative w-full max-w-[360px] sm:max-w-sm bg-preto2 p-6 rounded-2xl shadow-lg text-gray-300"
    >

     <!-- Botão Fechar (adicionado: visível e acima de tudo) -->
      <button
        @click="emit('closeRegister')"
        aria-label="Fechar"
        class="absolute top-3 right-3 text-gray-300 hover:text-amarelo focus:outline-none focus:ring-2 focus:ring-amarelo rounded z-50"
      >
        <!-- ícone X (SVG) -->
        <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
          <path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 011.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd" />
        </svg>
      </button>
      <!-- Logo -->
      <div class="flex flex-col items-center">
        <img src="/public/Logo web.png" alt="Logo SG" class="h-8" />
        <h2 class="text-base mt-2">Cria tua conta ✨</h2>
      </div>

      <!-- Formulário -->
      <form class="mt-6 space-y-4" @submit.prevent="cadastrar">
        <!-- Nome -->
        <div>
          <label class="block text-sm text-gray-200 mb-1">Nome Completo</label>
          <input
            type="text"
            class="w-full px-3 py-2 rounded-xl bg-preto border border-gray-600 text-sm focus:ring-2 focus:ring-amarelo focus:outline-none"
            placeholder="Digite seu nome"
          />
        </div>

        <!-- Email -->
        <div>
          <label class="block text-sm text-gray-200 mb-1">Email</label>
          <input
            type="email"
            class="w-full px-3 py-2 rounded-xl bg-preto border border-gray-600 text-sm focus:ring-2 focus:ring-amarelo focus:outline-none"
            placeholder="Digite seu email"
          />
        </div>

        <!-- Senhas -->
        <div class="flex flex-col gap-4">
          <div>
            <label class="block text-sm text-gray-200 mb-1">Senha</label>
            <input
              type="password"
              class="w-full px-3 py-2 rounded-xl bg-preto border border-gray-600 text-sm focus:ring-2 focus:ring-amarelo focus:outline-none"
              placeholder="Digite sua senha"
            />
          </div>
          <div>
            <label class="block text-sm text-gray-200 mb-1">Confirmar Senha</label>
            <input
              type="password"
              class="w-full px-3 py-2 rounded-xl bg-preto border border-gray-600 text-sm focus:ring-2 focus:ring-amarelo focus:outline-none"
              placeholder="Repita sua senha"
            />
          </div>
        </div>

        <!-- Botão Criar Conta -->
        <button
          type="submit"
          class="w-full bg-amarelo text-preto font-semibold py-2 rounded-xl hover:bg-yellow-600 transition"
        >
          Criar Conta
        </button>
      </form>

      <!-- Link para Login -->
      <p class="text-center text-sm text-gray-400 mt-4">
        Já tens uma conta?
        <a @click="voltarParaLogin" class="text-amarelo hover:underline cursor-pointer">Entrar agora</a>
      </p>
    </div>
  </section>
</template>


<script setup>


import { useRouter } from 'vue-router'; 
const router = useRouter();
const emit = defineEmits(['closeRegister', 'openLogin','openEmailVerification']);

async function cadastrar() {
  // Aqui você valida senha, confirmaSenha, email, etc
  emit('openEmailVerification') // Chama o modal de verificação
  emit('closeRegister') // Fecha o modal de cadastro
}

function voltarParaLogin() {
  emit('closeRegister'); // fecha modal de cadastro
  emit('openLogin');     // abre modal de login
}

function irPara(path) {
  router.push(path);
}
</script>
