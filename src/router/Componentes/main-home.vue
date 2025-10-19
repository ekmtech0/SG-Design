<script setup>

import ContactosSG from './ContactosSG.vue';
import FooterSG from './FooterSG.vue';
import NavBar from './NavBar.vue';
import PassosCriacao from './PassosCriacao.vue';
import ProjectoDestaques from './ProjectoDestaques.vue';
import ServicoSG from './ServicoSG.vue';
import SobreNos from './SobreNos.vue';
import TestemunhoSG from './TestemunhoSG.vue';
import WhatsApp from './whatsApp.vue';



</script>


<template>
   <NavBar/>   
    <!-- Pagina inicial Home -->
<section class="relative w-full h-[90vh] md:h-[80vh] overflow-hidden rounded-2xl pt-20 lg:pt-24">
  <picture>
    <source media="(min-width: 1024px)" srcset="" type="image/webp">

    <source media="(min-width: 640px)" srcset="" type="image/webp">

    <img src=""
         alt="Design criativo e moderno"
         loading="lazy"
         class="w-full h-full object-cover">
  </picture>
  <div class="absolute inset-0 bg-black/40 flex items-center justify-center flex-col p-4 text-center"> 
    <h1 class="text-3xl md:text-5xl font-bold bg-gradient-to-r from-yellow-400 via-white to-amarelo bg-clip-text text-transparent">
      Criação de Identidade Visual
    </h1>

   <div class="space-x-4 space-y-4">
      <button class="text-preto text-sm bg-amarelo rounded-3xl px-4 py-2 font-medium
           transition-all duration-300 
           hover:bg-amarelo hover:text-preto
           sm:px-5 sm:py-2 md:px-6 md:py-2.5 lg:px-8 lg:py-3">
Nossos Serviços 
</button>

  <button class="text-amarelo text-sm border border-amarelo rounded-3xl px-4 py-2 
           transition-all duration-300 
           hover:bg-amarelo hover:text-preto
           sm:px-5 sm:py-2 md:px-6 md:py-2.5 lg:px-8 lg:py-3">
Ver Projetos 
</button>
   </div>

  </div>
</section>


    <!-- Algumas Acções -->
   <!-- WhatsApp -->
<WhatsApp/>
    <section class="">
      <div
        class="border-b border-t border-t-preto2 border-b-preto2 lg:p-14 p-8 h-[100px] lg:h-[150px] lg:px-[400px] md:px-[150px]"
      >
        <div class="flex justify-between">
          <div
            class="bg-amarelo rounded-3xl px-1 py-1 lg:py-2 lg:px-2 lg:text-lg font-montserrat text-sm"
          >
            Ver mais
          </div>
          <div
            class="bg-amarelo rounded-3xl px-1 py-1 font-montserrat text-sm lg:py-2 lg:px-2 lg:text-lg"
          >
            Ver mais
          </div>
          <div
            class="bg-amarelo rounded-3xl px-1 py-1 font-montserrat text-sm lg:py-2 lg:px-2 lg:text-lg"
          >
            Ver mais
          </div>
          <div
            class="bg-amarelo rounded-3xl px-1 py-1 font-montserrat text-sm lg:py-2 lg:px-2 lg:text-lg"
          >
            Ver mais
          </div>
        </div>
      </div>
    </section>

    <!-- Nossos Serviços -->
     <ServicoSG/>
 
<!-- Projectos em Destaques -->

   <ProjectoDestaques/>

    <!--Nossos Passos Criação  -->
    <PassosCriacao/>

  <!-- Traformação do Projecto-->
  <section>
    <div class="border-b border-t border-t-preto2 border-b-preto2 p-4 pb-16">
      <p
        class="text-2xl md:text-3xl font-bold mb-4 font-montserrat font-bold tracking-wide text-center p-6 tracking-wide text-amarelo"
      >
        Pronto para transformar seu projeto?
      </p>
      <p class="text-center lg:text-xl font-montserrat font-regular p-4 mt-[-30px]">
        Entre em contato hoje mesmo e vamos conversar sobre como podemos elevar sua presença visual
      </p>

      <div class="flex justify-center items-center">
        <button class="border rounded-3xl border-amarelo px-2 py-2 text-amarelo text-xs md:text-md">
          Solicitar Orçamento
        </button>
      </div>
    </div>
  </section>

<!-- Sobre Nós -->

<SobreNos/>


  <!-- Testemunhos -->
<TestemunhoSG/>

<!-- Contactos -->
<ContactosSG/>

<!-- Footer -->
 <FooterSG/>
</template>
