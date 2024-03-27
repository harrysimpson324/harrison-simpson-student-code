<template>
  <div class="book-container">
    <book-card v-for="(book, index) in $store.state.books" v-bind:key="index" :book="book"/>
  </div>
</template>

<script>
import BookCard from './BookCard.vue';

export default {
  components: {
    BookCard
  }
  
}
</script>

<style>
.book-container {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
}
</style>