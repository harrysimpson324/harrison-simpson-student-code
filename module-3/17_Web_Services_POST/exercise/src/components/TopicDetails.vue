<template>
  <header class="flex">
    <h1>{{ topic.title }}</h1>
    <div class="actions">
      <button class="btn-edit" v-on:click="$router.push({ name: 'EditTopicView', params: {topicId: topicId} })">Edit</button>
      <button class="btn-delete" v-on:click="deleteTopic">Delete</button>
    </div>
  </header>
  <div class="created">
    <label>Topic created on:</label>&nbsp;
    <span>{{ createdDate }} {{ createdTime }}</span>
  </div>
  <div class="flex">
    <h2>Messages</h2>
    <button class="btn-add" v-on:click="$router.push({ name: 'AddMessageView', params: {topicId: topic.id} })">Add Message</button>
  </div>
  <message-summary v-for="message in topic.messages" v-bind:key="message.id" v-bind:message="message" />
</template>

<script>
import topicService from '../services/TopicService.js';
import MessageSummary from '../components/MessageSummary.vue';

export default {
  components: {
    MessageSummary
  },
  props: {
    topic: {
      type: Object,
      required: true
    }
  },
  computed: {
    createdDate() {
      let created = new Date(this.topic.date);
      return created.toLocaleDateString();
    },
    createdTime() {
      let created = new Date(this.topic.date);
      return created.toLocaleTimeString();
    }
  },
  methods: {
    deleteTopic() {
      if (confirm("Are you sure you want to delete this topic and all associated messages? This action cannot be undone.")) {
        
        // TODO - Do a delete, then navigate Home on success
        // For errors, call handleErrorResponse
        
      }
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        if (error.response.status == 404) {
          this.$router.push({name: 'NotFoundView'});
        } else {
          this.$store.commit('SET_NOTIFICATION',
          `Error ${verb} topic. Response received was "${error.response.statusText}".`);
        }
      } else if (error.request) {
        this.$store.commit('SET_NOTIFICATION', `Error ${verb} topic. Server could not be reached.`);
      } else {
        this.$store.commit('SET_NOTIFICATION', `Error ${verb} topic. Request could not be created.`);
      }
    },
  }
};
</script>

<style scoped>
header {
  margin-bottom: 1rem;
}
h2 {
  font-size: large;
}
.created {
  margin-bottom: 1rem;
}
</style>
