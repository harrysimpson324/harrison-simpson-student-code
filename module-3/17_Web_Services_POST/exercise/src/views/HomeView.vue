<template>
  <div class="loading" v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else>
    <header class="flex">
      <h1>Topics</h1>
      <button class="btn-add" v-on:click="$router.push({ name: 'AddTopicView' })">Add Topic</button>
    </header>
    <topic-list v-bind:topics="topics"/>
  </div>
</template>

<script>
import topicService from '../services/TopicService.js';
import TopicList from '../components/TopicList.vue';

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
      topicService.list()
        .then(response => {
          this.topics = response.data;
          this.isLoading = false;
        })
        .catch(error => {
          this.handleErrorResponse();
        })
    },
    handleErrorResponse() {
      this.isLoading = false;
      this.$store.commit('SET_NOTIFICATION', `Could not get topic data from server.`);
    }
  },
  created() {
    this.getTopics();
  }
}
</script>

<style scoped>
</style>