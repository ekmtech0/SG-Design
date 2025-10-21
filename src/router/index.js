import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'main-home',
    component: () => import('./Componentes/main-home.vue'),
    meta: {
      title: 'SG Design | Criação de Identidades Visuais e Design Profissional',
      description:
        'A SG Design é uma agência criativa especializada em design gráfico, branding e identidade visual. Ajudamos marcas a destacarem-se através de logotipos, websites e estratégias de comunicação impactantes.',
      keywords:
        'SG Design, design gráfico Angola, criação de logotipos, identidade visual, branding, web design, marketing digital',
    },
  },
  {
    path: '/projectos-servicos',
    name: 'projectos-servicos',
    component: () => import('./Componentes/projectos-servicos.vue'),
    meta: {
      title: 'Projetos e Serviços | SG Design',
      description:
        'Descubra os serviços e projetos criativos da SG Design. Branding, web design e design gráfico de qualidade profissional.',
      keywords: 'projetos SG Design, serviços de design, branding, logotipos, Angola',
    },
  },
  {
    path: '/IdentidadeVisual',
    name: 'IdentidadeVisual',
    component: () => import('./Componentes/IdentidadeVisual.vue'),
    meta: {
      title: 'Identidade Visual | SG Design',
      description:
        'Criação de identidades visuais únicas que destacam a sua marca no mercado. Conheça o serviço de branding da SG Design.',
      keywords: 'identidade visual, branding, logotipo profissional, design Angola',
    },
  },
  {
    path: '/FlyersEventos',
    name: 'FlyersEventos',
    component: () => import('./Componentes/FlyersEventos.vue'),
    meta: {
      title: 'Flyers e Eventos | SG Design',
      description:
        'Flyers profissionais e designs criativos para eventos. Destaque a sua marca com a SG Design.',
      keywords: 'flyers, eventos, design criativo, publicidade Angola, SG Design',
    },
  },
  {
    path: '/LogotiposProfissionais',
    name: 'LogotiposProfissionais',
    component: () => import('./Componentes/LogotiposProfissionais.vue'),
    meta: {
      title: 'Logotipos Profissionais | SG Design',
      description:
        'Criação de logotipos personalizados e memoráveis. Transforme a sua marca com a SG Design.',
      keywords: 'criação de logotipos, design gráfico Angola, SG Design, branding',
    },
  },
  {
    path: '/CartaodeVisita',
    name: 'CartaodeVisita',
    component: () => import('./Componentes/CartaodeVisita.vue'),
    meta: {
      title: 'Cartão de Visita | SG Design',
      description:
        'Design de cartões de visita modernos e elegantes. Impressione com a primeira impressão certa.',
      keywords: 'cartão de visita, design profissional, identidade visual',
    },
  },
  {
    path: '/CriacaoSites',
    name: 'CriacaoSites',
    component: () => import('./Componentes/CriacaoSites.vue'),
    meta: {
      title: 'Criação de Sites | SG Design',
      description:
        'Desenvolvimento de websites modernos, responsivos e otimizados para SEO. Potencie a presença digital da sua marca.',
      keywords: 'criação de sites, web design Angola, SEO, SG Design, design web',
    },
  },
  {
    path: '/ProjectoDestaques',
    name: 'ProjectoDestaques',
    component: () => import('./Componentes/ProjectoDestaques.vue'),
    meta: {
      title: 'Projetos em Destaque | SG Design',
      description:
        'Veja os projetos realizados pela SG Design e descubra como ajudamos marcas a crescer com design e criatividade.',
      keywords: 'portfólio, projetos SG Design, branding, identidade visual, design gráfico',
    },
  },
  {
    path: '/SobreNos',
    name: 'SobreNos',
    component: () => import('./Componentes/SobreNos.vue'),
    meta: {
      title: 'Sobre Nós | SG Design',
      description:
        'Conheça a história e a missão da SG Design, agência criativa especializada em branding e design gráfico.',
      keywords: 'sobre SG Design, agência de design Angola, branding, design gráfico profissional',
    },
  },
  {
    path: '/ContactosSG',
    name: 'ContactosSG',
    component: () => import('./Componentes/ContactosSG.vue'),
    meta: {
      title: 'Contactos | SG Design',
      description:
        'Entre em contacto com a SG Design e transforme a identidade da sua marca. Solicite o seu orçamento agora.',
      keywords: 'contactos SG Design, design Angola, identidade visual, branding',
    },
  },
  {
    path: '/ServicoSG',
    name: 'ServicoSG',
    component: () => import('./Componentes/ServicoSG.vue'),
    meta: {
      title: 'Serviços de Design | SG Design',
      description:
        'Conheça os serviços da SG Design: criação de logotipos, branding, web design e marketing digital.',
      keywords: 'serviços de design, branding Angola, criação de logo, web design, SG Design',
    },
  },
  {
    path: '/whatsApp',
    name: 'whatsApp',
    component: () => import('./Componentes/whatsApp.vue'),
    
  },
  {
    path: '/TodosComentarios',
    name: 'TodosComentarios',
    component: () => import('./Componentes/TodosComentarios.vue'),
  },
  {
    path: '/CadastroSG',
    name: 'CadastroSG',
    component: () => import('./Componentes/CadastroSG.vue'),
  },
  {
    path:'/VerficacaoEmail',
    name:'VerficacaoEmail',
    component: () => import('./Componentes/VerficacaoEmail.vue'),
  },

  {
    path: '/TermosUso',
    name: 'TermosUso',
    component: () => import('./Componentes/TermosUso.vue'),
  },
  {
    path: '/PoliticaPrivacidade',
    name: 'PoliticaPrivacidade',
    component: () => import('./Componentes/PoliticaPrivacidade.vue'),
  },
  {
    path: '/CookiesCach',
    name: 'CookiesCach',
    component: () => import('./Componentes/CookiesCach.vue'),
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
  scrollBehavior(to) {
    if (to.hash) {
      return { el: to.hash, behavior: 'smooth' }
    }
    return { top: 0 }
  },
})

export default router
