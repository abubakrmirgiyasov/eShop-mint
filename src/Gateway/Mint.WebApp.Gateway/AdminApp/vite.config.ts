import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      "/main": {
        target: "https://localhost:7064",
        changeOrigin: true,
        secure: false,
        headers: {
          Connection: "Keep-Alive",
        }
      },
      "/pass": {
        target: "https://localhost:7064",
        changeOrigin: true,
        secure: false,
        headers: {
          Connection: "Keep-Alive",
        }
      }
    }
  }
})
