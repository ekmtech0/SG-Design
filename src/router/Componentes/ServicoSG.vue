<template>
  <!-- Nossos Serviços -->
  <section id="servicos">
    <h1
      class="text-2xl md:text-3xl font-bold mb-4 font-montserrat tracking-wide text-center p-4 text-amarelo "
    >
      Nossos Serviços
    </h1>
    <h2 class="text-center lg:text-xl font-montserrat font-regular p-4 mt-[-30px]">
      Oferecemos soluções completas de design para elevar sua presença visual
    </h2>

    <!-- Container de cards -->
    <div class="relative p-6 md:p-10 xl: ">
      <!-- Carrossel -->
      <div
        class="flex overflow-x-auto md:grid md:grid-cols-2 lg:grid-cols-3 gap-8 scroll-smooth snap-x snap-mandatory no-scrollbar "
        ref="carousel"
        @scroll="handleScroll"
      >
        <div
          v-for="(servico, index) in servicos"
          :key="index"
          class="bg-preto2 rounded-xl p-8 shadow-sm transition-all duration-300 hover:shadow-lg hover:border-red-600 flex-shrink-0 w-[90%] sm:w-[80%] md:w-auto snap-center"
        >
          <p class="text-xl font-bold font-montserrat mb-4 text-amarelo">
            {{ servico.titulo }}
          </p>
          <p class="pb-4">{{ servico.descricao }}</p>

          <div class="space-y-2 py-2">
            <div
              v-for="(item, i) in servico.itens"
              :key="i"
              class="bg-preto rounded-lg p-1"
            >
              <p class="flex items-center gap-2">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  class="text-amarelo h-5"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                >
                  <path
                    fill="none"
                    stroke="currentColor"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M20 6L9 17l-5-5"
                  />
                </svg>
                {{ item }}
              </p>
            </div>
          </div>

          <!-- Preço -->
          <div class="mt-4 space-y-4">
            <div
              class="border flex flex-col space-y-2 p-4 rounded-lg text-center border-amarelo bg-preto"
            >
              <span class="text-sm text-yellow-500">{{ servico.pacote }}</span>
              <span class="text-3xl font-medium text-amarelo">{{ servico.preco }}</span>
              <span class="text-sm text-gray-400">Inclui todos os recursos listados</span>
            </div>

            <div
              class="flex justify-center items-center bg-amarelo text-black font-medium rounded-lg p-1"
            >
              Solicitar Orçamento
            </div>
          </div>
        </div>
      </div>

      <!-- Setas laterais (somente mobile) -->
      <button
        @click="scrollLeft"
        class="absolute top-1/2 left-0 transform -translate-y-1/2 bg-preto2 text-amarelo p-2 rounded-full shadow-md hover:bg-preto transition md:hidden"
      >
        ‹
      </button>
      <button
        @click="scrollRight"
        class="absolute top-1/2 right-0 transform -translate-y-1/2 bg-preto2 text-amarelo p-2 rounded-full shadow-md hover:bg-preto transition md:hidden"
      >
        ›
      </button>

      <!-- Bullets -->
      <div class="flex justify-center mt-6 gap-2 md:hidden">
        <button
          v-for="(s, i) in servicos"
          :key="i"
          @click="scrollToCard(i)"
          class="w-1.5 h-1.5 rounded-full transition-all duration-300"
          :class="activeIndex === i ? 'bg-amarelo w-1.5' : 'bg-gray-500'"
        ></button>
      </div>
    </div>
  </section>
</template>

<script setup>
import { ref, onMounted } from "vue";

const servicos = ref([
  {
    titulo: "Identidade Visual",
    descricao:
      "Criação de identidades únicas e consistentes que traduzem a essência e os valores da marca.",
    itens: ["Logotipos Profissionais", "Manual da Marca", "Cores e Tipografia"],
    pacote: "Pacote Completo",
    preco: "15.000kz",
  },
  {
    titulo: "Flyers & Banners",
    descricao:
      "Design de flyers e banners criativos e impactantes, ideais para campanhas e eventos.",
    itens: [
      "Flyers promocionais",
      "Banners para impressão e digital",
      "Arte otimizada para redes sociais",
    ],
    pacote: "Pacote Completo",
    preco: "3.500kz",
  },
  {
    titulo: "Logotipos",
    descricao:
      "Criação de logotipos originais e memoráveis, com base em estratégia e impacto visual.",
    itens: [
      "3 propostas de conceito inicial",
      "Logotipo final vetorial e digital",
      "Versões horizontal, vertical e ícone",
    ],
    pacote: "Pacote Completo",
    preco: "6.000kz",
  },
  {
    titulo: "Redes Sociais",
    descricao:
      "Criação de templates e publicações que fortalecem a presença visual e o engajamento.",
    itens: [
      "Capa e perfil para redes sociais",
      "Padronização de identidade digital",
      "Conteúdos otimizados para plataformas",
    ],
    pacote: "Pacote Completo",
    preco: "3.500kz",
  },
  {
    titulo: "Cartão de Visitas & Passes",
    descricao:
      "Cartões e passes profissionais que reforçam a credibilidade e imagem da marca.",
    itens: [
      "Design personalizado e exclusivo",
      "Layout pronto para impressão",
      "Ajuste à identidade visual",
    ],
    pacote: "Pacote Completo",
    preco: "2.500kz",
  },
  {
    titulo: "Criação de Sites",
    descricao:
      "Desenvolvimento de websites modernos e responsivos, com foco em performance.",
    itens: [
      "Estrutura UX/UI moderna",
      "Design responsivo para todos os ecrãs",
      "Integração com SEO básico",
    ],
    pacote: "Pacote Completo",
    preco: "80.000kz",
  },
]);

const carousel = ref(null);
const activeIndex = ref(0);

function scrollLeft() {
  const width = carousel.value.clientWidth;
  carousel.value.scrollBy({ left: -width, behavior: "smooth" });
}

function scrollRight() {
  const width = carousel.value.clientWidth;
  carousel.value.scrollBy({ left: width, behavior: "smooth" });
}

function scrollToCard(index) {
  const width = carousel.value.clientWidth;
  carousel.value.scrollTo({ left: width * index, behavior: "smooth" });
  activeIndex.value = index;
}

function handleScroll() {
  const width = carousel.value.clientWidth;
  const scrollLeft = carousel.value.scrollLeft;
  activeIndex.value = Math.round(scrollLeft / width);
}

onMounted(() => {
  handleScroll();
});
</script>

<style scoped>
.no-scrollbar::-webkit-scrollbar {
  display: none;
}
.no-scrollbar {
  -ms-overflow-style: none;
  scrollbar-width: none;
}
</style>
