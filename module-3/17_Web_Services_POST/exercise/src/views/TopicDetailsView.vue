<template>
  <div class="loading" v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else>
    <nav>
      <router-link v-bind:to="{ name: 'HomeView' }">Back to Topic List</router-link>
    </nav>
    <topic-details v-bind:topic="topic" />
  </div>
</template>

<script>
import topicService from '../services/TopicService.js';
import TopicDetails from '../components/TopicDetails.vue';

export default {
  components: {
    TopicDetails
  },
  data() {
    return {
      topic: {},
      isLoading: true
    }
  },
  methods: {
    getTopic(id) {
      topicService.get(id)
        .then( response => {
          this.topic = response.data;
          this.isLoading = false;
        })
        .catch( error => {
        this.handleErrorResponse(error);
      })
    },
    handleErrorResponse(error) {
      if (error.response.status == 404) {
          this.$router.push({name: 'NotFoundView'});
        } else {
          this.isLoading = false;
          this.$store.commit('SET_NOTIFICATION', `Could not get topic data from server.`);
        }
    }
  },
  created() {
    this.getTopic(this.$route.params.topicId);
  }
};
</script>

<style scoped>
</style>