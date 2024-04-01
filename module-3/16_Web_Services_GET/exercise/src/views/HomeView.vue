<template>
  <div class="loading" v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else>
    <header class="flex">
      <h1>Topics</h1>
    </header>
    <topic-list v-bind:topics="topics"/>
  </div>
</template>

<script>
import TopicList from '../components/TopicList.vue';

import TopicService from '../services/TopicService.js';

export default {
  components: {
    TopicList
  },
  data() {
    return {
      topics: [],
      isLoading: true
    };
  },
  methods: {
    getTopics() {

      TopicService.list()
          .then((resp) => {
          this.topics = resp.data;
          this.isLoading = false;
      });

    },
  },
  created() {
    this.getTopics();
  }
}
</script>

<style scoped>
</style>