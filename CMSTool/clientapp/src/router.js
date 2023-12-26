
import { createRouter, createWebHistory } from 'vue-router';
import  HomePage from './components/HomePage.vue';
import AvaliableNews from './components/AvaliableNews.vue';

// Use Vue Router
const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
          component: HomePage,
      },
      {
          path: '/avaliablenews',
          component: AvaliableNews,
      }
  ],
});

export default router;
