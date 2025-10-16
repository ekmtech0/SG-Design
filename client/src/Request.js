import axios from 'axios';

const api = axios.create({
  baseURL: 'https://sg-design.onrender.com',
});

export default api;
