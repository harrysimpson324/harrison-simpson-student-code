import { createRouter as createRouter, createWebHistory } from 'vue-router'
import { useStore } from 'vuex'

import ApparelAddEditView from '../views/ApparelAddEditView.vue';
import ApparelListView from '../views/ApparelListView.vue';
import ShopAddApparelView from '../views/ShopAddApparelView.vue';
import ShopDetailView from '../views/ShopDetailView.vue';
import ShopListView from '../views/ShopListView.vue';
import LoginView from '../views/auth/LoginView.vue';
import LogoutView from '../views/auth/LogoutView.vue';

const routes = [
  {
    path: '/',
    name: 'home',
    redirect: {name: 'shop_list'}
  },
  {
    path: "/apparel",
    name: 'apparel_list', 
    component: ApparelListView,
    meta: {
      requiresAuth: true,
      role: 'HQ'
    }
  },
  {
    path: "/apparel/:id",
    name: 'add_edit_apparel', 
    component: ApparelAddEditView,
    meta: {
      requiresAuth: true,
      role: 'HQ'
    }
  }, 
  {
    path: "/shops",
    name: 'shop_list', 
    component: ShopListView,
    meta: {
      requiresAuth: true
    }
  },
  {
    path: "/shops/:id",
    name: 'shop_detail', 
    component: ShopDetailView,
    meta: {
      requiresAuth: true
    }
  },
  {
    path: "/shops/:id/apparel/add",
    name: 'shop_add_apparel', 
    component: ShopAddApparelView,
    meta: {
      requiresAuth: true
    }
  },
  {
    path: "/login",
    name: "login",
    component: LoginView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/logout",
    name: "logout",
    component: LogoutView,
    meta: {
      requiresAuth: false
    }
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes
});

router.beforeEach((to, from) => {

  const store = useStore();

  // If the route requires Auth, but there's no token, redirect to login
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  if (requiresAuth && store.state.token === '') {
    return {name: "login"};
  }

  // If the route requires a role and the user doesn't have it, redirect to home
  const reqRole = to.matched[0].meta.role;
  const userRoles = store.state.user.authorities;
  if (reqRole && userRoles.filter(role => role.name === 'ROLE_' + reqRole.toUpperCase()).length === 0) {
    return {name: "home"};
  }
});

export default router;
