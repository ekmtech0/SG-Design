import axios from 'axios';

const api = axios.create({
  baseURL: 'http://server.dev.localhost:5133',
});

export default api;
