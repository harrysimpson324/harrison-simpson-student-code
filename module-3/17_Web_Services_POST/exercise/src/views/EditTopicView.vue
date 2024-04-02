<template>
    <div class="loading" v-if="isLoading">
      <p>Loading...</p>
    </div>
    <div v-else>
      <h1>Edit Topic</h1>
      <topic-form v-bind:topic="topic" />
    </div>
  </template>
  
  <script>
  
  import topicService from '../services/TopicService';
  import TopicForm from '../components/TopicForm.vue';
  
  export default {
    components: {
      TopicForm
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
          .then(response => {
            this.topic = response.data;
            this.isLoading = false;
          })
          .catch(error => {
            if (error.response) {
              if (error.response.status == 404) {
                this.$router.push({name: 'NotFoundView'});
              } else {
                this.$store.commit('SET_NOTIFICATION',
                `Error getting topic. Response received was "${error.response.statusText}".`);
              }
            } else if (error.request) {
              this.$store.commit('SET_NOTIFICATION', `Error getting topic. Server could not be reached.`);
            } else {
              this.$store.commit('SET_NOTIFICATION', `Error getting topic. Request could not be created.`);
            }
          })
      }
    },
    created() {
      this.getTopic(this.$route.params.topicId);
    } 
  };
  </script>
  
<style scoped>
</style>
  