<template>
  <section class="min-h-screen bg-preto px-4 md:px-8 lg:px-16 py-20 flex flex-col items-center text-gray-400">
    <!-- Cabeçalho -->
    <header class="text-center max-w-3xl mx-auto mb-12">
      <img src="/public/Logo web.png" alt="Logo SG Design" class="h-10 mx-auto mb-4" />
      <h1 class="text-4xl md:text-5xl font-bold text-gray-200 mb-2">Termos de Uso</h1>
      <p class="text-gray-400 text-lg md:text-xl leading-relaxed">
        Leia atentamente antes de utilizar o SG Design. Estas regras garantem uma experiência segura e agradável para todos os visitantes.
      </p>
    </header>

    <!-- Conteúdo com scroll suave -->
    <main class="max-w-4xl w-full overflow-y-auto space-y-10">
      <!-- Seção 1 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">1. Conta e Cadastro</h2>
        <p>
          Para comentar ou contactar, os visitantes devem criar uma conta utilizando informações verdadeiras.
          Contas falsas podem ser removidas sem aviso prévio.
        </p>
      </section>

      <!-- Seção 2 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">2. Comportamento do Usuário</h2>
        <p>
          É proibido publicar comentários ofensivos, discriminatórios, ilegais ou que violem direitos de terceiros.
          O SG Design reserva-se o direito de remover qualquer conteúdo que viole estas regras.
        </p>
      </section>

      <!-- Seção 3 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">3. Responsabilidades</h2>
        <p>
          O uso do site é por conta do usuário. O SG Design não se responsabiliza por opiniões, comentários ou conteúdos publicados pelos usuários.
        </p>
      </section>

      <!-- Seção 4 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">4. Alterações nos Termos</h2>
        <p>
          Estes termos podem ser atualizados a qualquer momento. Recomenda-se que os usuários revisem periodicamente esta página.
        </p>
      </section>
    </main>

    <!-- Botão voltar -->
    <footer class="mt-12 text-center w-full">
      <button
        @click="voltarPagina"
        class="bg-amarelo text-preto font-semibold py-3 px-8 rounded-full hover:bg-yellow-600 transition-colors text-lg"
      >
        Voltar
      </button>
    </footer>
  </section>

<FooterSG />
</template>

<script setup>
import { useRouter } from 'vue-router';
import FooterSG from './FooterSG.vue';
const router = useRouter();

function voltarPagina() {
  router.back();
}
</script>

<style scoped>
/* Scroll suave para links internos (se você adicionar sumário) */
html {
  scroll-behavior: smooth;
}
</style>
