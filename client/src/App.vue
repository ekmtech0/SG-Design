<!-- <template>
  <RouterView />
</template>

<script setup>
import { useRoute } from 'vue-router'
import { useHead } from '@vueuse/head'
import { watch } from 'vue'

// obtém a rota atual
const route = useRoute()

// observa mudanças de rota e atualiza o head dinamicamente
watch(
  () => route.meta,
  (meta) => {
    if (meta) {
      useHead({
        title: meta.title || 'SG Design',
        meta: [
          {
            name: 'description',
            content: meta.description || 'Agência de design e branding em Angola',
          },
          {
            name: 'keywords',
            content: meta.keywords || 'design gráfico, branding, SG Design, Angola',
          },
        ],
      })
    }
  },
  { immediate: true } // executa logo ao carregar a página
)
</script> -->
<template>
  <router-view></router-view>
</template>

<script>
export default {
  name: 'App'
}
</script>