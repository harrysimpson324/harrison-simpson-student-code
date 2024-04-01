<template>
  <div>
    <h1><img v-bind:src="card.avatar" height="30" /> &nbsp;{{ card.title }}</h1>
    <p>{{ card.description }}</p>    
    <comments-list v-bind:comments="card.comments" />
  </div>
</template>

<script>
import CommentsList from '../components/CommentsList.vue';

export default {
  props: ['card'],
  components: {
    CommentsList
  }
};
</script>
