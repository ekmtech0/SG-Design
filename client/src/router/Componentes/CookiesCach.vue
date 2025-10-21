<template>
  <transition name="fade">
    <div
      v-if="showBanner"
      class="fixed bottom-4 left-1/2 transform -translate-x-1/2 w-[90%] md:w-3/4 lg:w-1/2 bg-preto2 border border-gray-700 rounded-xl p-4 md:p-6 flex flex-col md:flex-row items-center justify-between shadow-lg z-50"
    >
      <!-- Texto -->
      <p class="text-gray-300 text-sm md:text-base mb-2 md:mb-0 md:mr-4 text-center md:text-left">
        Usamos cookies e caches para melhorar a tua experiência no SG Design. Ao continuar a navegar, concordas com a nossa
        <span class="text-amarelo font-semibold cursor-pointer hover:underline" @click="abrirPolitica">
          Política de Privacidade
        </span>.
      </p>

      <!-- Botões -->
      <div class="flex space-x-3 justify-center md:justify-end">
        <button
          @click="rejeitarCookies"
          class="bg-gray-600 text-gray-200 px-3 py-2 rounded-lg hover:bg-gray-500 transition"
        >
          Rejeitar
        </button>
        <button
          @click="aceitarCookies"
          class="bg-amarelo text-preto px-3 py-2 rounded-lg font-semibold hover:bg-yellow-600 transition"
        >
          Aceitar
        </button>
      </div>
    </div>
  </transition>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
const router = useRouter();

const showBanner = ref(true);

// Checa se o usuário já aceitou os cookies
onMounted(() => {
  if (localStorage.getItem('sgdesign_cookies_accepted')) {
    showBanner.value = false;
  }
});

function aceitarCookies() {
  localStorage.setItem('sgdesign_cookies_accepted', 'true');
  showBanner.value = false;
}

function rejeitarCookies() {
  localStorage.setItem('sgdesign_cookies_accepted', 'false');
  showBanner.value = false;
}

function abrirPolitica() {
  router.push('/politica-privacidade');
}
</script>

<style scoped>
/* Animação suave do banner */
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
