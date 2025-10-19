<template>
  <!-- Página Completa: Todos os Comentários -->
  <div class="min-h-screen bg-preto text-white">
    <!-- Header da Página -->
    <header class="bg-preto2 border-b border-b-preto2 px-6 py-4">
      <div class="max-w-6xl mx-auto flex items-center justify-between">
        <div class="flex items-center space-x-4">
          <button @click="$router.go(-1)" class="text-amarelo hover:text-white transition-colors">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
            </svg>
          </button>
          <h1 class="text- md:text-3xl font-bold font-montserrat">Todos os Comentários</h1>
        </div>
        <div class="text-sm text-gray-400">
          {{ testemunhos.length }} comentários
        </div>
      </div>
    </header>

    <!-- Conteúdo Principal -->
    <main class="max-w-6xl mx-auto px-6 py-8">
      <!-- Seção de Lista de Comentários -->
      <section class="mb-12">
        <div class="grid gap-6 md:grid-cols-1 lg:grid-cols-2">
          <article
            class="bg-preto2 rounded-xl shadow-md p-6 border border-gray-700 hover:shadow-lg transition-shadow"
            v-for="testemunho in testemunhos"
            :key="testemunho.id"
          >
            <div class="flex items-start space-x-4 mb-4">
              <div class="h-12 w-12 bg-amarelo rounded-full overflow-hidden flex-shrink-0">
                <img :src="testemunho.userPhotoUrl" class="object-cover w-full h-full" alt="Foto do comentador" />
              </div>
              <div class="flex-1 min-w-0">
                <h3 class="font-bold font-montserrat text-white truncate">{{ testemunho.userName }}</h3>
                <p class="text-sm text-amarelo font-light font-montserrat">Programmer</p>
                <p class="text-xs text-gray-400 mt-1">{{ testemunho.timeAgo }}</p>
              </div>
            </div>
            <p class="text-gray-300 leading-relaxed">"{{  testemunho.content }}"</p>
            <div class="flex items-center space-x-4 mt-4 pt-4 border-t border-gray-700">
              <button class="text-gray-400 hover:text-amarelo transition-colors flex items-center space-x-1 text-sm">
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z" />
                </svg>
                <span>Curtir ({{ testemunho.likesCount }})</span>
              </button>
            </div>
          </article>
        </div>

        <!-- Paginação (se houver mais comentários) -->
        <div class="flex justify-center mt-8 space-x-2">
          <button class="px-4 py-2 bg-preto2 border border-gray-700 rounded-lg text-gray-400 hover:bg-amarelo hover:text-preto transition-colors">Anterior</button>
          <button
            class="px-4 py-2 bg-amarelo text-preto rounded-lg font-semibold"
            v-for="(testemunho, index) in testemunhos"
            :key="index"
          >{{ index + 1 }}</button>
          <button class="px-4 py-2 bg-preto2 border border-gray-700 rounded-lg text-gray-400 hover:bg-amarelo hover:text-preto transition-colors">Próximo</button>
        </div>
      </section>
      
    </main>
    
  </div>

  <!-- Select & Foto -->
  <div class="flex items-end space-x-4 p-6 mt-12 lg:mt-16">
    <select
      id="role-select"
      aria-label="Profissão"
      class="p-2 lg:p-4 rounded-xl bg-preto2 border border-gray-700 text-white focus:outline-none focus:ring-2 focus:ring-amarelo"
    >
      <option value="" disabled>Profissão</option>
      <option>Programador</option>
      <option>Designer Gráfico</option>
      <option>Analista</option>
      <option>Gerente de Projeto</option>
      <option>Gestor de Marketing</option>
      <option>Mecânico</option>
      <option>Empreendedor</option>
      <option>Doutor</option>
      <option>Enfermeiro</option>
      <option>Professor</option>
      <option>Outro</option>
    </select>
    <div>
      <div class="h-12 w-12 bg-gray-600 rounded-3xl text-sm text-center flex items-center justify-center">Foto</div>
    </div>
  </div>

  <!-- Comentário + botão que abre o modal de login -->
  <section class="flex items-end ">
    <div class="w-full rounded-xl border-gray-700 p-6">
      <div class="max-w-6xl mx-auto flex items-center space-x-4 ">
        <input
          type="text"
          placeholder="Deixe seu comentário..."
          class="flex-1 p-3 lg:p-4 rounded-2xl bg-preto2 border border-gray-700 text-white focus:outline-none focus:ring-2 focus:ring-amarelo "
          readonly
          @focus="openLogin"    
        />

        <!-- botão que abre o modal de login -->
        <button @click="openLogin" aria-label="Comentar" class="h-10 w-10 flex items-center justify-center rounded-full text-amarelo hover:text-white">
          <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" viewBox="0 0 16 16" class="h-8 text-amarelo" fill="currentColor" >
            <g fill="" fill-rule="evenodd" >
              <path d="M15.854.146a.5.5 0 0 1 .11.54l-2.8 7a.5.5 0 1 1-.928-.372l1.895-4.738l-7.494 7.494l1.376 2.162a.5.5 0 1 1-.844.537l-1.531-2.407L.643 7.184a.75.75 0 0 1 .124-1.33L15.314.037a.5.5 0 0 1 .54.11ZM5.93 9.363l7.494-7.494L1.591 6.602l4.339 2.76Z"/>
              <path d="M12.5 16a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7m.354-5.354a.5.5 0 0 0-.722.016l-1.149 1.25a.5.5 0 1 0 .737.676l.28-.305V14a.5.5 0 0 0 1 0v-1.793l.396.397a.5.5 0 0 0 .708-.708l-1.25-1.25Z"/>
            </g>
          </svg>
        </button>
      </div>
    </div>
  </section>

  <google-component-test/>

  <!-- Modal de Login (invisível por padrão, aparece sobrepondo tudo) -->
  <div
    v-if="showLoginModal"
    class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-60"
    @click.self="closeLogin"
    aria-modal="true"
    role="dialog"
  >
    <div class="bg-preto2 rounded-xl w-full max-w-3xl p-6 relative">
      <!-- botão de fechar -->
      <button @click="closeLogin" class="absolute top-4 right-4 text-gray-300 hover:text-amarelo">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"/>
        </svg>
      </button>

      <!-- Componente de Login embutido no modal -->
      <LoginPage />
    </div>
  </div>
</template>

<script setup>
import GoogleComponentTest from './GoogleComponentTest.vue';
import { ref, onMounted, onBeforeUnmount } from 'vue';
import api from '@/Request';
import LoginPage from './LoginPage.vue';

const testemunhos = ref([]);
const showLoginModal = ref(false);

onMounted(() => {
  fetchTestemunhos();
  // opcional: fechar modal com Esc
  window.addEventListener('keydown', onKeydown);
});

onBeforeUnmount(() => {
  window.removeEventListener('keydown', onKeydown);
});

async function fetchTestemunhos() {
  try {
    const response = await api.get('/comments/Listar');
    testemunhos.value = response.data;
    console.log("Testemunhos carregados:", testemunhos.value);
  } catch (error) {
    console.error("Erro ao buscar testemunhos:", error);
  }
}

function openLogin() {
  showLoginModal.value = true;
}

function closeLogin() {
  showLoginModal.value = false;
}

function onKeydown(e) {
  if (e.key === 'Escape' && showLoginModal.value) closeLogin();
}
</script>

<style scoped>
/* Mantive Tailwind para a maioria dos estilos; ajuste conforme necessário */
</style>