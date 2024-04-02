<template>
  <div class="loading" v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else>
    <h1>Edit Message</h1>
    <message-form v-bind:message="message" />
  </div>
</template>

<script>

import messageService from '../services/MessageService';
import MessageForm from '../components/MessageForm.vue';

export default {
  components: {
    MessageForm
  },
  data() {
    return {
      message: {},
      isLoading: true
    }
  },
  methods: {
    getMessage(id) {
      messageService.get(id)
        .then(response => {
          this.message = response.data;
          this.isLoading = false;
        })
        .catch(error => {
          if (error.response) {
            if (error.response.status == 404) {
              this.$router.push({name: 'NotFoundView'});
            } else {
              this.$store.commit('SET_NOTIFICATION',
              `Error getting message. Response received was "${error.response.statusText}".`);
            }
          } else if (error.request) {
            this.$store.commit('SET_NOTIFICATION', `Error getting message. Server could not be reached.`);
          } else {
            this.$store.commit('SET_NOTIFICATION', `Error getting message. Request could not be created.`);
          }
        })
    }
  },
  created() {
    this.getMessage(this.$route.params.messageId);
  } 
};
</script>

<style scoped>
</style>
