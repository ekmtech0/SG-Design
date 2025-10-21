

<template>
      <section class="text-white px-6 py-12">
    <div class="max-w-6xl mx-auto grid md:grid-cols-2 gap-8 items-center" id="contactos">
      <!-- Texto -->
      <div class="">
        <h1 class="text-2xl md:text-3xl font-bold mb-6">Gostaríamos muito de ouvir você!</h1>

        <form class="space-y-4">
          <div>
            <label class="block mb-1">Nome completo</label>
            <input
              type="text"
              placeholder="Seu nome"
              class="w-full px-4 py-2 rounded-lg bg-[#2a2a2a] border border-gray-600 text-white focus:border-amarelo focus:outline-none"
            />
          </div>

          <div>
            <label class="block mb-1">Endereço de email</label>
            <input
              type="email"
              placeholder="email@exemplo.com"
              class="w-full px-4 py-2 rounded-lg bg-[#2a2a2a] border border-gray-600 text-white focus:border-amarelo focus:outline-none"
            />
          </div>

          <div>
            <label class="block mb-1">Descreva sua necessidade de design</label>
            <textarea
              rows="4"
              placeholder="O que você precisa?"
              class="w-full px-4 py-2 rounded-lg bg-[#2a2a2a] border border-gray-600 text-white focus:border-amarelo focus:outline-none"
            ></textarea>
          </div>

          <div>
            <p class="mb-2">Que tipo de design você precisa?</p>
            <div class="flex flex-col space-y-2">
              <label><input type="checkbox" class="mr-2 accent-amarelo" />Flyers</label>
              <label
                ><input type="checkbox" class="mr-2 accent-amarelo" /> Identidades Visuais</label
              >
              <label><input type="checkbox" class="mr-2 accent-amarelo" /> Panfletos</label>
              <label><input type="checkbox" class="mr-2 accent-amarelo" /> Banners</label>
              <label><input type="checkbox" class="mr-2 accent-amarelo" /> Cartões de visita</label>
              <label><input type="checkbox" class="mr-2 accent-amarelo" /> Logotipos</label>
            </div>
          </div>

          <button
            type="submit"
            class="w-full bg-amarelo text-black font-bold py-3 rounded-lg hover:bg-yellow-500 transition"
          >
            Enviar
          </button>
        </form>
      </div>

      <!-- Imagem + Caixa
      <div class="relative">
        <div class="rounded-xl  overflow-hidden bg-preto2 text-white ">sdnm </div>
      </div> -->
    </div>
  </section>
</template>