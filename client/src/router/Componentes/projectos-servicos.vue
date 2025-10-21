<script setup>
import WhatsApp from './whatsApp.vue';
import Navbar from './navbar.vue';
import { useRouter } from 'vue-router';
import { ref } from 'vue';

const router = useRouter();

function irPara(path) {
  router.push(path);
}

const Projetos = ref([
  {
    titulo: "Identidade Visual",
    descricao:
      "Desenvolvimento de identidades visuais únicas que refletem a essência da sua marca, transmitindo credibilidade, propósito e estilo em cada detalhe.",
    imagem: new URL('/Edna.png', import.meta.url).href,
    vertodos: "/IdentidadeVisual"
  },
  {
    titulo: "Flyers & Banners",
    descricao:
      "Design de flyers impactantes e banners profissionais para eventos, campanhas e promoções — criados para atrair olhares e gerar resultados.",
    imagem: new URL('/Edna.png', import.meta.url).href,
    vertodos: "/FlyersEventos"
  },
  {
    titulo: "Logotipos",
    descricao:
      "Criação de logotipos originais e memoráveis que traduzem o posicionamento e a personalidade da sua marca com criatividade e estratégia.",
    imagem: new URL('/Edna.png', import.meta.url).href,
    vertodos: "/LogotiposProfissionais"
  },
  {
    titulo: "Cartão de Visitas & Passes",
    descricao:
      "Design elegante e funcional de cartões de visita e passes personalizados, perfeitos para causar uma excelente primeira impressão.",
    imagem: new URL('/Edna.png', import.meta.url).href,
    vertodos: "/CartaodeVisita"
  },
  {
    titulo: "Criação de Sites",
    descricao:
      "Desenvolvimento de websites modernos, responsivos e otimizados — projetados para destacar a sua marca e oferecer uma experiência envolvente ao utilizador.",
    imagem: new URL('/Edna.png', import.meta.url).href,
    vertodos: "/CriacaoSites"
  },
]);
</script>


<template>
  <Navbar/>

  <!-- Nossos Projetos -->
  <section>
    <div class="relative w-full h-96">
      <img src="/web.jpg" alt="" class="opacity-20 w-full h-96 object-cover object-center" />
      <div class="absolute inset-0 flex flex-col items-center justify-center text-center">
        <p class="text-2xl md:text-3xl font-bold font-montserrat text-amarelo mb-4 p-6">Nossos Projetos Incríveis</p>
        <p class="lg:text-xl font-regular p-4 mt-[-50px]">
          Descubra o portfólio de designs gráficos que transformam ideias em realidade. Modernos, vibrantes e cheios de vida!
        </p>
      </div>
    </div>
  </section>

  <WhatsApp/>

  <!-- Projetos com responsividade -->
  <section class="p-6 md:p-10 xl:px-40">
    <!-- Mobile: rolagem horizontal -->
    <div class="flex overflow-x-auto gap-6 md:hidden snap-x snap-mandatory no-scrollbar">
      <div 
        v-for="(Projeto, index) in Projetos"
        :key="index"
        class="flex-shrink-0 snap-center bg-preto2 rounded-xl shadow-sm transition-all duration-300 min-w-[250px] max-w-[280px] flex flex-col"
      >
        <img :src="Projeto.imagem" alt="" class="w-full h-48 object-cover rounded-t-xl"/>
        <div class="p-4 flex flex-col flex-1 justify-between">
          <div>
            <p class="text-xl font-bold font-montserrat mb-2">{{ Projeto.titulo }}</p>
            <p class="text-gray-300 text-sm">{{ Projeto.descricao }}</p>
          </div>
          <button
            class="mt-4 border border-amarelo text-amarelo rounded-3xl px-4 py-2 hover:bg-amarelo hover:text-preto transition"
            @click="irPara(Projeto.vertodos)"
          >
            Ver todos projetos
          </button>
        </div>
      </div>
    </div>

    <!-- Tablet/desktop: grid centralizado -->
    <div class="hidden md:flex justify-center">
      <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-8 max-w-[1200px] w-full">
        <div 
          v-for="(Projeto, index) in Projetos"
          :key="index"
          class="bg-preto2 rounded-xl shadow-sm flex flex-col"
        >
          <img :src="Projeto.imagem" alt="" class="w-full h-64 object-cover rounded-t-xl"/>
          <div class="p-6 flex flex-col flex-1 justify-between">
            <div>
              <p class="text-xl font-bold font-montserrat mb-4">{{ Projeto.titulo }}</p>
              <p class="text-gray-300">{{ Projeto.descricao }}</p>
            </div>
            <button
              class="mt-4 border border-amarelo text-amarelo rounded-3xl px-6 py-2 hover:bg-amarelo hover:text-preto transition"
              @click="irPara(Projeto.vertodos)"
            >
              Ver todos projetos
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
/* Remove scroll bar no mobile */
.no-scrollbar::-webkit-scrollbar {
  display: none;
}
.no-scrollbar {
  -ms-overflow-style: none;
  scrollbar-width: none;
}
</style>
