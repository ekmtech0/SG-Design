/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  theme: {
    extend: {
      colors: {
        amarelo: '#ffb22c',
        castanho: '#854836',
        preto2: '#232323',
        preto: '#1e1e1e',
      },
      fontFamily: {
        montserrat: ['Montserrat', 'sans-serif'],
    poppins: ['Poppins', 'sans-serif'],
        bebas: ['Bebas Neue', 'sans-serif'],
      },
    },
  },
  plugins: [],
}

