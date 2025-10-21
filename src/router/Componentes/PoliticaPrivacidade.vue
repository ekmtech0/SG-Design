<template>
  <section class="min-h-screen bg-preto px-4 md:px-8 lg:px-16 py-20 flex flex-col items-center text-gray-400">
    <!-- Cabeçalho -->
    <header class="text-center max-w-3xl mx-auto mb-12">
      <img src="/public/Logo web.png" alt="Logo SG Design" class="h-10 mx-auto mb-4" />
      <h1 class="text-4xl md:text-5xl font-bold text-gray-200 mb-2">Política de Privacidade</h1>
      <p class="text-gray-400 text-lg md:text-xl leading-relaxed">
        A sua privacidade é muito importante para nós. Leia atentamente para entender como tratamos seus dados e usamos tecnologias de navegação.
      </p>
    </header>

    <!-- Conteúdo com scroll suave -->
    <main class="max-w-4xl w-full overflow-y-auto space-y-10">
      <!-- Seção 1 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">1. Dados Coletados</h2>
        <p>
          Coletamos informações como nome, email e qualquer dado fornecido ao criar uma conta, enviar comentários ou contactar-nos.
        </p>
      </section>

      <!-- Seção 2 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">2. Uso dos Dados</h2>
        <p>
          Os dados coletados são usados apenas para autenticação de usuários, envio de respostas, melhoria da experiência e comunicação com o usuário.
        </p>
      </section>

      <!-- Seção 3 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">3. Cookies e Tecnologias de Navegação</h2>
        <p>
          Utilizamos cookies, caches e tecnologias semelhantes para melhorar a experiência do usuário, analisar desempenho do site e personalizar conteúdos. 
          Você pode ajustar as configurações do seu navegador para recusar cookies, mas algumas funcionalidades do site podem ser afetadas.
        </p>
      </section>

      <!-- Seção 4 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">4. Proteção e Segurança</h2>
        <p>
          Implementamos medidas de segurança para proteger seus dados contra acesso não autorizado, alteração, divulgação ou destruição.
        </p>
      </section>

      <!-- Seção 5 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">5. Compartilhamento de Dados</h2>
        <p>
          Não compartilhamos seus dados com terceiros sem seu consentimento, exceto quando exigido por lei ou para prestar serviços essenciais.
        </p>
      </section>

      <!-- Seção 6 -->
      <section class="scroll-mt-20">
        <h2 class="text-2xl md:text-3xl font-semibold text-amarelo mb-3">6. Direitos do Usuário</h2>
        <p>
          Você pode solicitar a exclusão ou correção de seus dados a qualquer momento. Ao utilizar o SG Design, você concorda com esta política de privacidade.
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
html {
  scroll-behavior: smooth;
}
</style>
