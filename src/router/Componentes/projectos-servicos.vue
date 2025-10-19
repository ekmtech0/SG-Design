    
<script setup>
import WhatsApp from './whatsApp.vue';
import Navbar from './navbar.vue';
import { useRouter } from 'vue-router';
const router = useRouter() // Instancia do roteador


function irPara(path) {
  router.push(path)
}
</script>


<template>
    <!-- Header -->
<Navbar/>



    <!-- Nossos Projectos -->
    <section class="">
        <div class="relative w-full h-96">
            <img src="/web.jpg" alt="" class="opacity-20 w-full h-96 object-cover object-center" />

            <div class="absolute inset-0 flex items-center justify-center flex-col">
                <p class="text-2xl md:text-3xl font-bold mb-4 font-montserrat tracking-wide text-center p-6 text-amarelo">
                    Nossos Projectos Incriveis
                </p>
               <p class="text-center lg:text-xl  font-regular p-4 mt-[-50px]">Descubra o portfólio de designs gráficos que transformam ideias em realidade. Modernos, vibrantes e cheios de vida!</p>
            </div>
        </div> 
    </section>
<WhatsApp/>
    <!-- Serviços dos Projectos -->
   <section class="">

    <!-- Serviços -->
     <div class="p-6 md:p-10 xl:px-40">
  <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
 


    <!-- Identidade Visual -->
    <div class="bg-preto2 rounded-xl shadow-sm transition-all duration-300 hover:shadow-xl hover:shadow-amarelo hover:border-red-600 flex flex-col">
      <div class="w-full">
        <img src="/Edna.png" alt="" class="overflow-hidden rounded-lg w-full object-cover" />
      </div>
      <div class="p-8 flex flex-col flex-1 justify-between">
        <div>
          <p class="text-xl font-bold font-montserrat mb-4">Identidade Visual</p>
          <p>Desenvolvimento de identidades visuais únicas que refletem a essência da sua marca, transmitindo credibilidade, propósito e estilo em cada detalhe.</p>
        </div>
        <div class="flex items-center justify-center pt-8">
          <button
            class="border border-amarelo text-amarelo rounded-3xl px-4 py-2 transition-all duration-300 hover:bg-amarelo hover:text-preto sm:px-5 sm:py-2 md:px-6 md:py-2.5 lg:px-8 lg:py-3 "
            @click="irPara('/IdentidadeVisual')"
          >
            Ver todos projetos
          </button>
        </div>
      </div>
    </div>

    <!-- Flyers -->
   <div class="bg-preto2 rounded-xl shadow-sm transition-all duration-300 hover:shadow-xl hover:shadow-amarelo hover:border-red-600 flex flex-col">
      <div class="w-full">
        <img src="/Edna.png" alt="" class="overflow-hidden rounded-lg w-full object-cover" />
      </div>
      <div class="p-8 flex flex-col flex-1 justify-between">
        <div>
          <p class="text-xl font-bold font-montserrat mb-4">Flyers & Banners</p>
          <p>Design de flyers impactantes e banners profissionais para eventos, campanhas e promoções — criados para atrair olhares e gerar resultados.</p>
        </div>
        <div class="flex items-center justify-center pt-8">
          <button
            class="border border-amarelo text-amarelo rounded-3xl px-4 py-2 transition-all duration-300 hover:bg-amarelo hover:text-preto sm:px-5 sm:py-2 md:px-6 md:py-2.5 lg:px-8 lg:py-3 "
            @click="irPara('/FlyersEventos')"
          >
            Ver todos projetos
          </button>
        </div>
      </div>
    </div>
  </div>
</div>

<!-- Serviços Parte II -->
 
     <div class="p-6 md:p-10 xl:px-40">
  <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">

    <!-- Logotipos -->

       <div class="bg-preto2 rounded-xl shadow-sm transition-all duration-300 hover:shadow-xl hover:shadow-amarelo hover:border-red-600 flex flex-col">
      <div class="w-full">
        <img src="/Edna.png" alt="" class="overflow-hidden rounded-lg w-full object-cover" />
      </div>
      <div class="p-8 flex flex-col flex-1 justify-between">
        <div>
          <p class="text-xl font-bold font-montserrat mb-4">Logotipos</p>
          <p>Criação de logotipos originais e memoráveis que traduzem o posicionamento e a personalidade da sua marca com criatividade e estratégia.</p>
        </div>
        <div class="flex items-center justify-center pt-8">
          <button
            class="border border-amarelo text-amarelo rounded-3xl px-4 py-2 transition-all duration-300 hover:bg-amarelo hover:text-preto sm:px-5 sm:py-2 md:px-6 md:py-2.5 lg:px-8 lg:py-3 "
            @click="irPara('/LogotiposProfissionais')"
          >
            Ver todos projetos
          </button>
        </div>
      </div>
    </div>



    <!-- Cartão de Visitas e Passes -->
 <div class="bg-preto2 rounded-xl shadow-sm transition-all duration-300 hover:shadow-xl hover:shadow-amarelo hover:border-red-600 flex flex-col">
      <div class="w-full">
        <img src="/Edna.png" alt="" class="overflow-hidden rounded-lg w-full object-cover" />
      </div>
      <div class="p-8 flex flex-col flex-1 justify-between">
        <div>
          <p class="text-xl font-bold font-montserrat mb-4">Cartão de Visitas & Passes</p>
          <p>Design elegante e funcional de cartões de visita e passes personalizados, perfeitos para causar uma excelente primeira impressão.</p>
        </div>
        <div class="flex items-center justify-center pt-8">
          <button
            class="border border-amarelo text-amarelo rounded-3xl px-4 py-2 transition-all duration-300 hover:bg-amarelo hover:text-preto sm:px-5 sm:py-2 md:px-6 md:py-2.5 lg:px-8 lg:py-3 "
            @click="irPara('/CartaodeVisita')"
          >
            Ver todos projetos
          </button>
        </div>
      </div>
    </div>

    <!-- Site-->
<div class="bg-preto2 rounded-xl shadow-sm transition-all duration-300 hover:shadow-xl hover:shadow-amarelo hover:border-red-600 flex flex-col">
      <div class="w-full">
        <img src="/Edna.png" alt="" class="overflow-hidden rounded-lg w-full object-cover" />
      </div>
      <div class="p-8 flex flex-col flex-1 justify-between">
        <div>
          <p class="text-xl font-bold font-montserrat mb-4">Criação de Sites</p>
          <p>Desenvolvimento de websites modernos, responsivos e otimizados — projetados para destacar a sua marca e oferecer uma experiência envolvente ao utilizador.</p>
        </div>
        <div class="flex items-center justify-center pt-8">
          <button
            class="border border-amarelo text-amarelo rounded-3xl px-4 py-2 transition-all duration-300 hover:bg-amarelo hover:text-preto sm:px-5 sm:py-2 md:px-6 md:py-2.5 lg:px-8 lg:py-3 "
            @click="irPara('/CriacaoSites')"
          >
            Ver todos projetos
          </button>
        </div>
      </div>
    </div>

 


  </div>
</div>

   </section>
</template>