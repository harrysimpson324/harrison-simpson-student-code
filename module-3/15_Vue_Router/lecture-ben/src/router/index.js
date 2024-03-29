import { createRouter as _createRouter, createWebHistory } from 'vue-router';
import ProductsView from '../views/ProductsView.vue'
import ProductDetailView from '../views/ProductDetailView.vue'
import AddReviewView from '../views/AddReviewView.vue'

const routes = [
  {
    path: '/',
    redirect: { name: 'products'}
  },
  {
    path: '/products',
    name: 'products',
    component: ProductsView 
  },
  {
    path: '/products/:id',
    name: 'product-detail',
    component: ProductDetailView
  },
  {
    path: '/products/:id/add-review',
    name: 'add-review',
    component: AddReviewView
  }
];

export function createRouter () {
  return _createRouter({
    history: createWebHistory(),
    routes: routes
  })
}
