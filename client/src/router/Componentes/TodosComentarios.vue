<template>
  <!-- Página Completa: Todos os Comentários -->
  <div class="min-h-screen bg-preto text-white">
    <!-- Header da Página -->
    <header class="bg-preto2 border-b border-b-preto2 px-6 py-4">
      <div class="max-w-6xl mx-auto flex items-center justify-between">
        <div class="flex items-center space-x-4">
          <button @click="$router.go(-1)" class="text-amarelo hover:text-white transition-colors">
            <!-- Ícone de voltar (use um SVG ou ícone de biblioteca como Heroicons) -->
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

          <!-- Comentário 3 -->
          <article class="bg-preto2 rounded-xl shadow-md p-6 border border-gray-700 hover:shadow-lg transition-shadow"
            v-for="testemunho in testemunhos" :key="testemunho.id"
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
          <button class="px-4 py-2 bg-amarelo text-preto rounded-lg font-semibold"
            v-for="(testemunho, index) in testemunhos" :key="index"
          >{{ index + 1 }}</button>
          <button class="px-4 py-2 bg-preto2 border border-gray-700 rounded-lg text-gray-400 hover:bg-amarelo hover:text-preto transition-colors">Próximo</button>
        </div>
      </section>

      <!-- Seção para Adicionar Novo Comentário -->
      <!-- <section class="bg-preto2 rounded-xl shadow-md p-6 border border-gray-700">
        <h2 class="text-xl font-bold font-montserrat mb-6">Deixe seu Comentário</h2>
        <form @submit.prevent="submitComment" class="space-y-6">
          <!-- Upload de Foto (Opcional)
          <div class="flex items-center space-x-4">
            <div class="h-12 w-12 bg-gray-600 rounded-full overflow-hidden flex items-center justify-center cursor-pointer hover:bg-gray-500 transition-colors">
              <input type="file" @change="handleImageUpload" class="hidden" id="avatar-upload" accept="image/*" />
              <label for="avatar-upload" class="cursor-pointer">
                <svg class="w-6 h-6 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 9a2 2 0 012-2h.93a2 2 0 001.664-.89l.812-1.22A2 2 0 0110.07 4h3.86a2 2 0 011.664.89l.812 1.22A2 2 0 0018.07 7H19a2 2 0 012 2v9a2 2 0 01-2 2H5a2 2 0 01-2-2V9z" />
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 13a3 3 0 11-6 0 3 3 0 016 0z" />
                </svg>
              </label>
            </div>
            <div class="flex-1">
              <img v-if="newComment.avatar" :src="newComment.avatar" class="h-12 w-12 object-cover rounded-full" alt="Preview" />
            </div>
          </div>

          Nome e Cargo 
          <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label for="name" class="block text-sm font-medium text-gray-300 mb-2">Nome</label>
              <input
                v-model="newComment.name"
                type="text"
                id="name"
                class="w-full px-4 py-3 bg-gray-800 border border-gray-600 rounded-lg text-white placeholder-gray-400 focus:outline-none focus:ring-2 focus:ring-amarelo focus:border-transparent"
                placeholder="Seu nome"
                required
              />
            </div>
            <div>
              <label for="role" class="block text-sm font-medium text-gray-300 mb-2">Cargo/Profissão</label>
              <input
                v-model="newComment.role"
                type="text"
                id="role"
                class="w-full px-4 py-3 bg-gray-800 border border-gray-600 rounded-lg text-white placeholder-gray-400 focus:outline-none focus:ring-2 focus:ring-amarelo focus:border-transparent"
                placeholder="Ex: Programador"
                required
              />
            </div>
          </div>

           Mensagem
          <div>
            <label for="message" class="block text-sm font-medium text-gray-300 mb-2">Seu Comentário</label>
            <textarea
              v-model="newComment.message"
              id="message"
              rows="4"
              class="w-full px-4 py-3 bg-gray-800 border border-gray-600 rounded-lg text-white placeholder-gray-400 focus:outline-none focus:ring-2 focus:ring-amarelo focus:border-transparent resize-none"
              placeholder="Compartilhe sua experiência..."
              required
            ></textarea>
          </div>

          Botão Enviar
          <button
            type="submit"
            class="w-full md:w-auto bg-amarelo text-preto px-8 py-3 rounded-lg font-semibold font-montserrat hover:bg-yellow-400 transition-colors focus:outline-none focus:ring-2 focus:ring-amarelo focus:ring-offset-2 focus:ring-offset-preto"
          >
            Enviar Comentário
          </button>
        </form>
      </section> -->
    </main>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '@/Request';

const testemunhos = ref([]);

onMounted(() => {
  fetchTestemunhos();
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

// // Estado do novo comentário
// const newComment = ref({
//   name: '',
//   role: '',
//   message: '',
//   avatar: null
// });

// // Upload da imagem
// function handleImageUpload(event) {
//   const file = event.target.files[0];
//   if (file) {
//     newComment.value.avatar = URL.createObjectURL(file);
//   }
// }

// // Submissão do comentário
// function submitComment() {
//   if (newComment.value.name && newComment.value.role && newComment.value.message) {
//     testemunhos.value.unshift({
//       ...newComment.value,
//       id: Date.now(),
//       date: 'Agora',
//       likes: 0,
//       avatar: newComment.value.avatar || null
//     });

//     // Resetar formulário
//     newComment.value = { name: '', role: '', message: '', avatar: null };
//     document.getElementById('avatar-upload').value = '';

//     alert('Comentário enviado com sucesso!');
//   }
// }
</script>
 

<style scoped>
/* Estilos adicionais se necessário, mas Tailwind cobre a maioria */
</style>