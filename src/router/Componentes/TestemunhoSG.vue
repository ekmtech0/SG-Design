<script setup>
import { useRouter } from 'vue-router';
import api from '@/Request';
import WhatsApp from './WhatsApp.vue';
import { ref, onMounted } from "vue";
const router = useRouter() // Instancia do roteador
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

function irPara(path) {
  router.push(path)
}
</script>


<template>
  <WhatsApp/>
     <!-- Testemunhos -->
  <section class=" text-white px-6 py-12">
    <div class="max-w-6xl mx-auto grid md:grid-cols-2 gap-8 items-center">
      <h2 class="text-2xl md:text-3xl font-bold mb-4">Testemunhos</h2>
    </div>

    <div>
      <div class="overflow-x-auto">
        <div class="flex space-x-6 p-4 md:justify-center">
             <!-- Testemunho 3 -->

          <div class="bg-preto2 min-w-[250px] min-h-[200px] rounded-xl shadow-md p-4 flex flex-col justify-between" v-for="Testemunho in testemunhos">
            <div class="flex space-x-2">
              <div class="h-12 w-12 bg-amarelo rounded-3xl overflow-hidden">
                <img :src="Testemunho.userPhotoUrl" class="object-cover" alt="Foto do comentador" />
              </div>
              <div class="flex flex-col">
                <span class="font-bold font-montserrat">{{ Testemunho.userName }}</span>
                <span class="text-sm font-light font-montserrat text-amarelo">Programmer</span>
              </div>
            </div>

            <p class="py-6  line-clamp-3 break-words">"{{ Testemunho.content }}"</p>
          </div>
        </div>
      </div>
    </div>
    <div class="flex justify-center items-center py-4">
      <a ref="" 
        class="border rounded-3xl border-amarelo px-2 py-2 text-amarelo text-xs md:text-md cursor-pointer" @click="irPara('/TodosComentarios')"
        >Ver todos Comentários</a
      >
    </div>
  </section>

</template>