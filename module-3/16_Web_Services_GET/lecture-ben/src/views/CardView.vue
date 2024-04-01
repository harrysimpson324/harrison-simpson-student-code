<template>
  <div>
  <div v-if="isLoading">
      <div class="loading">
        <img src="../assets/ping_pong_loader.gif" />
      </div>
  </div>
  <div v-else>
      <router-link v-bind:to="{ name: 'BoardView', params: { id: card.boardId }}">Back to Board</router-link>
      <card-detail v-bind:card="card" />
    </div>
  </div>
</template>

<script>
import CardDetail from '../components/CardDetail.vue';
import boardService from '../services/BoardService.js';

export default {
  components: {
    CardDetail
  },
  data() {
    return {
      card: {},
      isLoading: true
    };
  },
  created() {
    let cardId = parseInt(this.$route.params.cardId);
    boardService.getCard(cardId)
       .then((response) => {
        this.card = response.data;
        this.isLoading = false;
       });
  }
};
</script>
