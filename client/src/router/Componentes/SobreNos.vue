<template>
      <!-- Sobre SG Design -->
  <section class="border-b border-t border-b-preto border-t-preto text-white px-6 py-12" id="sobre">
    <div class="bg-preto2 rounded-lg p-4">
      <div class="max-w-6xl mx-auto grid md:grid-cols-2 gap-8 items-center">
        <!-- Texto -->
        <div>
          <h1 class="text-2xl md:text-3xl font-bold mb-4">
            Sobre a <span class="text-amarelo">SG Design</span>
          </h1>
          <p class="text-gray-300 mb-4">
            Somos um estúdio de design gráfico dedicado a criar soluções visuais que não apenas
            impressionam, mas também comunicam efetivamente a essência da sua marca.
          </p>
          <p class="text-gray-300 mb-6">
            Combinamos criatividade, estratégia e técnica para desenvolver identidades visuais
            consistentes e materiais gráficos de alto impacto que fortalecem a presença da sua marca
            no mercado.
          </p>

          <!-- Itens -->
          <div class="grid grid-cols-2 gap-4 mb-6">
            <div class="flex items-center space-x-2">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                class="text-amarelo"
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
              <p>2+ Anos de Experiência</p>
            </div>
            <div class="flex items-center space-x-2">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                class="text-amarelo"
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
              <p>100+ Projetos Concluídos</p>
            </div>
            <div class="flex items-center space-x-2">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                class="text-amarelo"
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
              <p>Design Personalizado</p>
            </div>
            <div class="flex items-center space-x-2">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                class="text-amarelo"
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
              <p>Atendimento Nacional</p>
            </div>
          </div>

          <!-- Botão -->
          <a
            href="#contato"
            class="inline-block bg-amarelo text-black font-bold px-6 py-3 rounded-lg shadow-md hover:bg-yellow-500 transition"
          >
            Fale Conosco
          </a>
        </div>

        <!-- Imagem + Caixa -->
        <div class="relative">
          <div class="overflow-hidden rounded-xl shadow-lg w-full">
            <img src="/Sobre.png" alt="" class="rounded-xl w-full h-auto" />
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
</script>