import { createRouter as _createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import TopicDetailsView from '../views/TopicDetailsView.vue';
import AddMessageView from '../views/AddMessageView.vue';
import AddTopicView from '../views/AddTopicView.vue';
import EditTopicView from '../views/EditTopicView.vue';
import NotFoundView from '../views/NotFoundView.vue';
import EditMessageView from '../views/EditMessageView.vue';
import MessageDetailsView from '../views/MessageDetailsView.vue';

// Create routes
const routes = [
  {
    path: "/not-found",
    name: "NotFoundView",
    component: NotFoundView
  },
  {
    path: '/',
    name: 'HomeView',
    component: HomeView
  },
  {
    path: '/topic/:topicId',
    name: 'TopicDetailsView',
    component: TopicDetailsView
  },
  {
    path: '/topic/create',
    name: 'AddTopicView',
    component: AddTopicView
  },
  {
    path: '/topic/:topicId/edit',
    name: 'EditTopicView',
    component: EditTopicView
  },
  {
    path: '/topic/:topicId/message/:messageId',
    name: 'MessageDetailsView',
    component: MessageDetailsView
  },
  {
    path: '/topic/:topicId/message/create',
    name: 'AddMessageView',
    component: AddMessageView
  },
  {
    path: '/topic/:topicId/message/:messageId/edit',
    name: 'EditMessageView',
    component: EditMessageView
  },
];

export function createRouter () {
  return _createRouter({
    history: createWebHistory(),
    routes: routes
  })
}
