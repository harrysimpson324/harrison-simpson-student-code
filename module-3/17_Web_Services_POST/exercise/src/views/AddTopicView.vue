<template>
  <h1>Add New Topic</h1>
  <topic-form v-bind:topic="topic" />
</template>

<script>
import TopicForm from '../components/TopicForm.vue';

export default {
  components: {
    TopicForm
  },
  data() {
    return {
      // Default data for a new topic
      topic: {
        id: 0,
        title: '',
        date: new Date(),
      },
    }
  } 
};
</script>

<style scoped>
</style>