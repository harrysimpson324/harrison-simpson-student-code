<template>
  <h1>Add New Message</h1>
  <message-form v-bind:message="message" />
</template>

<script>
import MessageForm from '../components/MessageForm.vue';

export default {
  components: {
    MessageForm
  },
  data() {
    return {
      message: {
        id: 0,
        topicId: Number(this.$route.params.topicId),
        created: new Date(),
        title: '',
        messageText: ''
      },
    }
  } 
};
</script>

<style scoped>
</style>