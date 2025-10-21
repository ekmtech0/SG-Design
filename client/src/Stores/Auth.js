import { defineStore } from 'pinia';
import api from '@/Request';

export const useAuthStore = defineStore('auth', {
  state: () => ({
    isLogged: false,
    userData: null,
    token: '',
    checked: false,
  }),
  actions: {
    async checkAuth() {
      if (this.checked) return; // já checou → não faz nada
      this.checked = true;

      try {
        // 1️⃣ pega token do localStorage
        let token = localStorage.getItem('accessToken');
        if (token) {
          this.token = token;
          console.log('Usando token existente:', token);
        }

        // função auxiliar para buscar /getMe
        const fetchUser = async (tokenToUse) => {
          const res = await api.get('/getMe', {
            headers: { Authorization: `Bearer ${tokenToUse}` },
          });
          return res.data;
        };

        try {
          // 2️⃣ tenta buscar o usuário com token atual
          this.userData = await fetchUser(this.token);
          this.isLogged = true;
          return;
        } catch (err) {
          // 3️⃣ se der 401, renova o token
          if (err.response && err.response.status === 401) {
            console.log('Token expirado, pedindo novo...');
            const res = await api.get('/tokens/acessToken');
            this.token = res.data.accessToken;
            localStorage.setItem('accessToken', this.token);

            // tenta buscar o usuário de novo
            this.userData = await fetchUser(this.token);
            this.isLogged = true;
          } else {
            throw err;
          }
        }
      } catch {
        // falhou → limpa dados
        this.userData = null;
        this.isLogged = false;
        this.token = '';
        localStorage.removeItem('accessToken');
        console.log('Usuário não autenticado');
      }
    },
  },
});
