import axios from "axios";

const baseURL =
  import.meta.env.MODE === "development"
    ? "http://server.dev.localhost:5133" // backend local para dev
    : "https://sg-design.onrender.com"; // produção

const api = axios.create({
  baseURL,
  withCredentials: true, // 🔥 envia cookies HttpOnly automaticamente
});

export default api;
