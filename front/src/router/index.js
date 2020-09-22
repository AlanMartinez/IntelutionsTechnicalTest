import Vue from 'vue'
import VueRouter from 'vue-router'
import Permission from '../views/Permission.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/permission/:id?',
    name: 'Permission',
    component: Permission
  },
  {
    path: '/',
    name: 'ListPermission',
    component: () => import('../views/ListPermission.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
