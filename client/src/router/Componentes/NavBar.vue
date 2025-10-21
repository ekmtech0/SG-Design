<script setup>
import { useRouter } from 'vue-router';
const router = useRouter() // Instancia do roteador
import { ref } from "vue";
import { RouterLink } from 'vue-router';
import LoginPage from './LoginPage.vue';
import { onMounted } from 'vue';
import { useAuthStore } from '@/Stores/Auth';

const authStore = useAuthStore();
const showLoginModal = ref(false);
const menuAberto = ref(false);
const fecharMenu = () => {
  menuAberto.value = false;
};

onMounted(async () => {
  await authStore.checkAuth();
  // console.log('User is logged in:', authStore.isLogge);
});

function openLogin() {
  showLoginModal.value = true;
}

function closeLogin() {
  showLoginModal.value = false;
}

import CadastroSG from './CadastroSG.vue';
import VerficacaoEmail from './VerficacaoEmail.vue';
const showRegisterModal = ref(false);


// fechar Cadastro
function closeRegister() {
  showRegisterModal.value = false;
}

// abrir Cadastro quando vier evento do Login
function openRegister() {
  showLoginModal.value = false;
  showRegisterModal.value = true;
}

function openLoginFromRegister() {
  showRegisterModal.value = false;
  showLoginModal.value = true;
}

function openLoginFromVerification() {
  showEmailVerificationModal.value = false
  showLoginModal.value = true
}

const showEmailVerificationModal = ref(false)

function openEmailVerification() {
  showRegisterModal.value = false
  showLoginModal.value = false
  showEmailVerificationModal.value = true
}

function closeEmailVerification() {
  showEmailVerificationModal.value = false
}

</script>
<style scoped>
/* Animação do Sidebar */
.slide-enter-active,
.slide-leave-active {
  transition: transform 0.35s ease, opacity 0.3s ease;
}
.slide-enter-from {
  transform: translateX(100%);
  opacity: 0;
}
.slide-enter-to {
  transform: translateX(0);
  opacity: 1;
}
.slide-leave-from {
  transform: translateX(0);
  opacity: 1;
}
.slide-leave-to {
  transform: translateX(100%);
  opacity: 0;
}
</style>
<template>
  <header
    class="fixed top-0 left-0 w-full z-50 bg-preto2 shadow-md "
  >
    <div
      class="max-w-7xl mx-auto flex items-center  px-6 lg:px-16 h-20 lg:h-24 justify-between"
    >
      <!-- LOGO -->
      <div class="flex items-center  gap-2 lg:gap-3">
        <img src="/public/Logo web.png" alt="Logo" class="h-7 w-auto lg:h-10" />
       <div class="flex flex-col lg:space-y-1 pt-2">
         <img src="/public/Design.png" alt="Logo" class="h-3.5 w-auto lg:h-4" />
        <span class="text-xs text-gray-300">Angola</span>
       </div>
      </div>

    
      <!-- NAV DESKTOP -->
      <nav class="hidden lg:flex items-center space-x-10 text-white text-base tracking-wide">
        <RouterLink to="/" class="hover:text-amarelo transition">Home</RouterLink>
        <RouterLink to="/#servicos" class="hover:text-amarelo transition">Serviços</RouterLink>
        <RouterLink to="/#sobre" class="hover:text-amarelo transition">Sobre</RouterLink>
        <RouterLink to="/projectos-servicos" class="hover:text-amarelo transition">Projetos</RouterLink>
        <RouterLink
          to="/#contactos"
          class="bg-amarelo px-4 py-2 rounded-full hover:bg-yellow-500 text-black transition"
        >
          Contactos
        </RouterLink>
      </nav>


      <!-- Entrar Login -->
  <div class="">
  <button class="hover:text-amarelo lg:bg-amarelo lg:rounded-full  font-bold lg:text-black lg:px-4 lg:py-2" @click="openLogin()"
  v-if="!authStore.isLogged"
  >Entrar
</button>
<img :src="authStore.userData?.photoUrl" alt="Foto de Perfil" class="h-8 w-8 rounded-full ml-2" v-if="authStore.isLogged"/>

</div>


      <!-- BOTÃO HAMBÚRGUER -->
      <button
        @click="menuAberto = !menuAberto"
        class="lg:hidden flex flex-col justify-center items-center space-y-1 focus:outline-none"
      >
        <span
          :class="[
            'block h-0.5 w-6 bg-white transition-all duration-300',
            menuAberto ? 'rotate-45 translate-y-1.5' : '',
          ]"
        ></span>
        <span
          :class="[
            'block h-0.5 w-6 bg-white transition-all duration-300',
            menuAberto ? 'opacity-0' : '',
          ]"
        ></span>
        <span
          :class="[
            'block h-0.5 w-6 bg-white transition-all duration-300',
            menuAberto ? '-rotate-45 -translate-y-1.5' : '',
          ]"
        ></span>
      </button>
    </div>
    <!-- SIDEBAR MOBILE -->
    <transition name="slide" class="bg-preto2">
      <aside
      v-if="menuAberto"
      class="fixed top-0 right-0 h-full w-72 bg-preto2 text-white shadow-2xl z-50 flex flex-col"
      >
      <!-- Cabeçalho -->
      <div class="flex items-center justify-between p-6 border-b border-white/10">
        <h2 class="text-xl font-semibold tracking-wide text-amarelo">Menu</h2>
        <button
        @click="menuAberto = false"
        class="text-gray-400 hover:text-white text-3xl transition"
        >
        &times;
        </button>
      </div>

      <!-- Links -->
      <nav class="flex flex-col p-6 space-y-4 text-lg font-medium flex-grow justify-start">
        <RouterLink
        to="/"
        class="relative group py-2 pl-3 transition"
        @click="fecharMenu"
        >
        <span
          class="absolute left-0 top-0 bottom-0 w-0.5 bg-amarelo scale-y-0 group-hover:scale-y-100 transition-transform origin-top"
        ></span>
        <span class="group-hover:text-amarelo transition">Home</span>
        </RouterLink>

        <RouterLink
        to="/#servicos"
        class="relative group py-2 pl-3 transition"
        @click="fecharMenu"
        >
        <span
          class="absolute left-0 top-0 bottom-0 w-0.5 bg-amarelo scale-y-0 group-hover:scale-y-100 transition-transform origin-top"
        ></span>
        <span class="group-hover:text-amarelo transition">Serviços</span>
        </RouterLink>

        <RouterLink
        to="/#sobre"
        class="relative group py-2 pl-3 transition"
        @click="fecharMenu"
        >
        <span
          class="absolute left-0 top-0 bottom-0 w-0.5 bg-amarelo scale-y-0 group-hover:scale-y-100 transition-transform origin-top"
        ></span>
        <span class="group-hover:text-amarelo transition">Sobre</span>
        </RouterLink>

        <RouterLink
        to="/projectos-servicos"
        class="relative group py-2 pl-3 transition"
        @click="fecharMenu"
        >
        <span
          class="absolute left-0 top-0 bottom-0 w-0.5 bg-amarelo scale-y-0 group-hover:scale-y-100 transition-transform origin-top"
        ></span>
        <span class="group-hover:text-amarelo transition">Projetos</span>
        </RouterLink>

        <RouterLink
        to="/#contactos"
        class="relative py-2 pl-3 bg-amarelo text-white text-center rounded-full hover:bg-yellow-500 transition"
        @click="fecharMenu"
        >
        Contactos
        </RouterLink>
      </nav>

      <!-- Rodapé -->
      <div class="p-6 border-t border-white/10 text-sm text-gray-400">
        © {{ new Date().getFullYear() }} SG Design. Todos os direitos reservados.
      </div>
      </aside>
    </transition>

    <!-- BACKDROP -->
    <div
      v-if="menuAberto"
      @click="menuAberto = false"
      class="fixed inset-0 bg-black bg-opacity-50 z-30 transition"
    ></div>

    
  </header>
  
  <!-- Modal de Login (invisível por padrão, aparece sobrepondo tudo) -->
  <div
    v-if="showLoginModal"
    class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-60"
    @click.self="closeLogin"
    aria-modal="true"
    role="dialog"
  >
      <!-- botão de fechar -->
      <button @click="closeLogin" class="absolute top-4 right-4 text-gray-300 hover:text-amarelo">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"/>
        </svg>
      </button>

      <!-- Componente de Login embutido no modal -->
      <LoginPage @openRegister="openRegister" @closeLogin="closeLogin "/>
  </div>


  <!-- Modal de Cadastro -->

    <div
    v-if="showRegisterModal"
    class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-60 "
    @click.self="closeRegister"
    aria-modal="true"
    role="dialog"
  >
      
      <!-- botão de fechar -->
      <button @click="closeRegister" class="absolute top-4 right-4 text-gray-300 hover:text-amarelo">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"/>
        </svg>
      </button>

      <!-- Componente de Login embutido no modal -->
      <CadastroSG 
  @closeRegister="closeRegister" 
  @openLogin="openLoginFromRegister" 
  @openEmailVerification="openEmailVerification" 
/>

  </div>


<!-- Modal de Verificação de E-maile -->
  <div
    v-if="showEmailVerificationModal"
    class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-60 "
    @click.self="closeEmailVerification"
    aria-modal="true"
    role="dialog"
  >
      
      <!-- botão de fechar -->
      <button @click="closeEmailVerification" class="absolute top-4 right-4 text-gray-300 hover:text-amarelo">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"/>
        </svg>
      </button>

      <!-- Componente de Login embutido no modal -->
      <VerficacaoEmail  @closeEmailVerification="closeEmailVerification"   @openLogin="openLoginFromVerification"   />
  </div>
</template>