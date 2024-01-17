import { createRouter, createWebHistory } from 'vue-router'
import RecipesView from '../views/RecipesView.vue'
import MenuView from '../views/MenuView.vue'
import ShoppingListView from '../views/ShoppingListView.vue'
import LoginView from '../views/LoginView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: RecipesView
    },
    {
      path: '/menu',
      component: MenuView
    },
    {
      path: '/shoppinglist',
      component: ShoppingListView
    },
    {
      path: '/login',
      component: LoginView
    },
  ]
})

export default router
