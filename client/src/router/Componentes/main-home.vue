<script setup>

import ContactosSG from './ContactosSG.vue';
import CookiesCach from './CookiesCach.vue';
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
    <CookiesCach/>
<WhatsApp/>
   

  <!-- Nossos Serviços -->
<section class="w-full border-y border-preto2 py-12">
  <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-12">
    <ServicoSG/>
  </div>
</section>

<!-- Projectos em Destaques -->
<section class="w-full border-y border-preto2 py-12">
  <div class=" mx-auto px-4 sm:px-6 lg:px-12">
    <ProjectoDestaques/>
  </div>
</section>

<!-- Nossos Passos -->
<section class="w-full border-y border-preto2 py-12">
  <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-12">
    <PassosCriacao/>
  </div>
</section>

<!-- Sobre Nós -->
<section class="w-full border-y border-preto2 py-12">
  <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-12">
    <SobreNos/>
  </div>
</section>

<!-- Testemunhos -->
<section class="w-full border-y border-preto2 py-12">
  <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-12">
    <TestemunhoSG/>
  </div>
</section>

<!-- Pronto para transformar -->
<section class="w-full border-y border-preto2 py-16">
  <div class="max-w-4xl mx-auto px-4 sm:px-6">
    <p class="text-2xl md:text-3xl font-bold text-center text-amarelo mb-4">
      Pronto para transformar seu projeto?
    </p>
    <p class="text-center text-gray-200 mb-6">
      Entre em contato hoje mesmo e vamos conversar sobre como podemos elevar sua presença visual
    </p>
    <div class="flex justify-center">
      <button class="border rounded-3xl border-amarelo px-2 py-2 text-amarelo text-xs md:text-md cursor-pointer">
        Solicitar Orçamento
      </button>
    </div>
  </div>
</section>

<!-- Contactos -->
<section class="w-full border-y border-preto2 py-12">
  <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-12">
    <ContactosSG/>
  </div>
</section>

<!-- Footer -->
 <section>
  <FooterSG/>
 </section>
</template>
