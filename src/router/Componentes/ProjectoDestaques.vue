<script setup>
import { ref, computed, onMounted } from "vue";

const destaques = ref([
  { 
    descricao: "Flyers", 
    categoria: "Redes Sociais", 
    imagem: new URL('/Edna.png', import.meta.url).href,
    dizer: "Transformamos ideias em imagens que prendem a atenção e geram resultados."
  },
  { 
    descricao: "Logotipos", 
    categoria: "Logotipos", 
    imagem: new URL('/Front.png', import.meta.url).href,
    dizer: "Criamos marcas com identidade, propósito e presença inesquecível."
  },
  { 
    descricao: "Identidade Visual", 
    categoria: "Identidade Visual", 
    imagem: new URL('/Makuka.jpg', import.meta.url).href,
    dizer: "Do conceito ao visual: a imagem que representa quem tu és."
  },
  { 
    descricao: "Cartão de Visitas", 
    categoria: "Cartão de Visitas", 
    imagem: new URL('/Call.png', import.meta.url).href,
    dizer: "O primeiro aperto de mão da tua marca — elegante e memorável."
  },
  { 
    descricao: "Websites", 
    categoria: "Websites", 
    imagem: new URL('/web.jpg', import.meta.url).href,
    dizer: "Sites que impressionam, convertem e geram confiança."
  },
]);

/* ✅ Modal */
const modalAberto = ref(false);
const indiceAtual = ref(0);

function abrirModal(index) {
  indiceAtual.value = index;
  modalAberto.value = true;
}

function fecharModal() {
  modalAberto.value = false;
}

function anterior() {
  indiceAtual.value = (indiceAtual.value - 1 + destaques.value.length) % destaques.value.length;
}

function seguinte() {
  indiceAtual.value = (indiceAtual.value + 1) % destaques.value.length;
}

const itemSelecionado = computed(() => destaques.value[indiceAtual.value]);

/* ✅ Bullets & Scroll */
const destaquesContainer = ref(null);
const activeIndex = ref(0);

function scrollParaCard(index) {
  const cardWidth = 250 + 20; // Largura + gap (min-w + espaço entre)
  destaquesContainer.value.scrollTo({
    left: index * cardWidth,
    behavior: "smooth",
  });
  activeIndex.value = index;
}

function atualizarIndice() {
  const scrollLeft = destaquesContainer.value.scrollLeft;
  const cardWidth = 250 + 20;
  activeIndex.value = Math.round(scrollLeft / cardWidth);
}

onMounted(() => {
  atualizarIndice();
});
</script>

<template>
  <section>
    <h1 class="text-2xl md:text-3xl font-bold mb-4 font-montserrat text-center p-6 tracking-wide text-amarelo">
      Projectos em Destaque
    </h1>

    <!-- ✅ Cards com scroll -->
    <div class="overflow-x-auto scroll-smooth snap-x snap-mandatory no-scrollbar md:overflow-visible px-4"
         ref="destaquesContainer"
         @scroll="atualizarIndice">
      <div class="flex space-x-5 md:space-x-6 md:justify-center">
        <div
          v-for="(destaque, index) in destaques"
          :key="index"
          @click="abrirModal(index)"
          class="group cursor-pointer snap-start min-w-[250px]">

          <div class="w-[250px] h-[350px] bg-preto2 rounded-2xl shadow-lg overflow-hidden relative transition-transform duration-500 hover:scale-105">
            <img :src="destaque.imagem" class="w-full h-full object-cover object-center" />
            <div class="absolute inset-0 bg-gradient-to-t from-black/70 via-black/40 to-transparent opacity-0 group-hover:opacity-100 transition-opacity duration-500"></div>

            <div class="absolute bottom-3 left-3 text-white font-semibold text-sm">
              <span class="bg-black/40 px-3 py-1 rounded-lg">{{ destaque.descricao }} </span>
            </div>

            <h3 class="absolute bottom-3 right-3 text-white text-lg font-bold opacity-0 group-hover:opacity-100 group-hover:translate-y-0 translate-y-2 transition-all duration-500">
              {{ destaque.categoria }}
            </h3>
          </div>
        </div>
      </div>
    </div>

    <!-- ✅ Bullets (mobile only) -->
    <div class="flex justify-center mt-4 gap-2 md:hidden">
      <button
        v-for="(d, i) in destaques"
        :key="i"
        @click="scrollParaCard(i)"
        class="w-1.5 h-1.5 rounded-full transition-all duration-300"
        :class="activeIndex === i ? 'bg-amarelo scale-110' : 'bg-gray-500 opacity-60'">
      </button>
    </div>

    <!-- ✅ MODAL -->
    <div
      v-if="modalAberto"
      class="fixed inset-0 bg-black/80 backdrop-blur-md flex items-center justify-center z-50">
      <div class="relative bg-preto2 p-4 md:p-6 rounded-2xl w-[90%] md:w-[70%] lg:w-[55%] max-h-[90vh] flex flex-col items-center shadow-2xl">

        <button @click="fecharModal" class="absolute top-4 right-4 text-white text-2xl hover:text-amarelo transition">✕</button>

        <div class="w-full flex items-center justify-center">
          <img :src="itemSelecionado.imagem" class="max-h-[65vh] w-auto object-contain rounded-xl shadow-lg" />
        </div>

        <div class="mt-4 text-center">
          <h2 class="text-amarelo text-xl md:text-2xl font-bold">{{ itemSelecionado.descricao }}</h2>
          <p class="text-white text-sm md:text-base mt-1">{{ itemSelecionado.dizer }}</p>
        </div>

        <button @click="anterior" class="absolute left-4 top-1/2 -translate-y-1/2 text-white text-4xl hover:text-amarelo">‹</button>
        <button @click="seguinte" class="absolute right-4 top-1/2 -translate-y-1/2 text-white text-4xl hover:text-amarelo">›</button>

      </div>
    </div>
  </section>
</template>
