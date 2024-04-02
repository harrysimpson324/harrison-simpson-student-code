<template>
  <header class="flex">
    <h1>{{ message.title }}</h1>
    <div class="actions">
      <button class="btn-edit" v-on:click="$router.push({ name: 'EditMessageView', params: {messageId: messageId} })">Edit</button>
      <button class="btn-delete" v-on:click="deleteMessage">Delete</button>
    </div>
  </header>
  <div class="created">
    <label>Created on:</label>&nbsp;
    <span>{{ createdDate }} {{ createdTime }}</span>
  </div>
  <div class="message">
    <div class="wrap">
      {{ message.messageText }}
    </div>
  </div>
</template>

<script>
import messageService from '../services/MessageService';
export default {
  props: {
    message: { type: Object, required: true }
  },
  computed: {
    createdDate() {
      let created = new Date(this.message.created);
      return created.toLocaleDateString();
    },
    createdTime() {
      let created = new Date(this.message.created);
      return created.toLocaleTimeString();
    }
  },
  methods: {
    deleteMessage() {
      if (confirm("Are you sure you want to delete this message? This action cannot be undone.")) {
        
        // TODO - Do a delete, then navigate to Topic Details on success
        // For errors, call handleErrorResponse

      }
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        if (error.response.status == 404) {
          this.$router.push({name: 'NotFoundView'});
        } else {
          this.$store.commit('SET_NOTIFICATION',
          `Error ${verb} message. Response received was "${error.response.statusText}".`);
        }
      } else if (error.request) {
        this.$store.commit('SET_NOTIFICATION', `Error ${verb} message. Server could not be reached.`);
      } else {
        this.$store.commit('SET_NOTIFICATION', `Error ${verb} message. Request could not be created.`);
      }
    },
  }
};
</script>

<style scoped>
.message {
  background: rgb(245, 245, 245);
  border: solid 2px rgba(0, 0, 0, 0.5);
  border-radius: 10px;
  margin-bottom: 10px;
  padding: 10px;
  text-shadow: 0 1px 1px rgba(255, 255, 255, 0.8);
  word-wrap: break-word;
}
.wrap {
  white-space: pre-wrap;
}
.created {
  margin-bottom: 1rem;
}
</style>
