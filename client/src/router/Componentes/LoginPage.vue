<template>
     <section class="pt-20 px-4 md:px-8 lg:px-16 border-t-preto2 border-b-preto2 flex justify-center items-center min-h-screen ">
  <div
    class="bg-preto2 rounded-2xl p-6 md:p-10 w-full max-w-sm sm:max-w-md lg:max-w-lg flex flex-col items-center text-gray-400 shadow-lg"
  >
    <!-- Logo -->
    <div class="text-center flex flex-col items-center pt-2">
      <img src="/public/Logo web.png" alt="Logo SG Design" class="h-8 sm:h-10" />
      <h2 class="text-sm sm:text-base text-gray-400 mt-2">Bem-vindo de volta 👋</h2>
    </div>

    <!-- Formulário -->
    <form action="" class="w-full mt-6 space-y-4">
      <div>
        <label for="email" class="block text-sm font-medium text-gray-200 mb-1">Email</label>
        <input
          type="email"
          id="email"
          placeholder="Digite seu email"
          class="w-full px-3 py-2 bg-preto2 border border-gray-600 rounded-xl text-gray-200 focus:outline-none focus:ring-2 focus:ring-amarelo focus:border-amarelo transition"
        />
      </div>

      <div>
        <label for="password" class="block text-sm font-medium text-gray-200 mb-1">Senha</label>
        <input
          type="password"
          id="password"
          placeholder="Digite sua senha"
          class="w-full px-3 py-2 bg-preto2 border border-gray-600 rounded-xl text-gray-200 focus:outline-none focus:ring-2 focus:ring-amarelo focus:border-amarelo transition"
        />
      </div>

      <div class="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-2 sm:gap-0 mt-2">
        <label class="flex items-center space-x-2 text-sm">
          <input type="checkbox" class="accent-amarelo" />
          <span>Lembrar-me</span>
        </label>
        <a href="#" class="text-sm text-amarelo hover:underline">Esqueceu sua senha?</a>
      </div>

      <button
        type="submit"
        class="w-full bg-amarelo text-preto font-semibold py-2 px-4 rounded-md hover:bg-yellow-600 transition-colors duration-300 mt-4"
      >
        Entrar
      </button>
    </form>

    <!-- Divisor -->
    <div class="flex items-center justify-center space-x-3 mt-6 w-full">
      <div class="w-1/5 border-t border-gray-700"></div>
      <p class="text-gray-500 text-sm whitespace-nowrap">ou entra com</p>
      <div class="w-1/5 border-t border-gray-700"></div>
    </div>

    <!-- Login Social -->
    <div class="flex flex-col sm:flex-row items-center justify-center gap-3 sm:gap-4 mt-4 w-full">
      <button
        class="flex items-center justify-center gap-2 border border-gray-700 px-4 py-2 rounded-xl w-full sm:w-auto hover:bg-[#2a2a2a] transition-all"
      >
        <img src="https://www.svgrepo.com/show/475656/google-color.svg" alt="Google" class="w-5 h-5" />
        <span class="text-sm font-medium">Google</span>
      </button>

      <button
        class="flex items-center justify-center gap-2 border border-gray-700 px-4 py-2 rounded-xl w-full sm:w-auto hover:bg-[#2a2a2a] transition-all"
      >
        <img src="https://www.svgrepo.com/show/475647/facebook-color.svg" alt="Facebook" class="w-5 h-5" />
        <span class="text-sm font-medium">Facebook</span>
      </button>
    </div>

    <!-- Termos -->
    <p class="text-center text-xs text-gray-500 mt-6 px-4 leading-relaxed">
      Ao entrar, concordas com os
      <a  class="text-amarelo hover:underline cursor-pointer" @click="irPara('/TermosUso')">Termos de Uso</a>
      e a
      <a  class="text-amarelo hover:underline cursor-pointer" @click="irPara('/PoliticaPrivacidade')" >Política de Privacidade</a>.
    </p>

    <!-- Cadastro -->
    <p class="text-center text-sm text-gray-400 mt-4">
      Ainda não tens conta?
      <a  class="text-yellow-400 hover:underline font-medium" @click="abrirCadastro" >Criar conta</a>
    </p>

    

  </div>
</section>

</template>

<script setup>
import { useRouter } from 'vue-router'; 
import CadastroSG from './CadastroSG.vue';
import { ref } from 'vue';
const router = useRouter();
const emit = defineEmits(['openRegister', 'closeLogin']);

function irPara(path) {
  router.push(path)
}

function abrirCadastro() {
  emit('openRegister'); // avisa o componente pai para abrir o modal de cadastro
}

function fecharLogin() {
  emit('closeLogin'); // avisa para fechar modal
}

const showLoginModal = ref(false);

function openLogin() {
  showLoginModal.value = true;
}

function closeLogin() {
  showLoginModal.value = false;
}

</script>