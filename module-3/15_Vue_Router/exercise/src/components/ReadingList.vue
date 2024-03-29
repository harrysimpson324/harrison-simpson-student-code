<template>
  <div class="book-container">
    <div class="card-holder" v-for="book in $store.state.books" v-bind:key="book.isbn">
      <router-link :to="{name: 'bookDetails', params: {bookIsbn: book.isbn}}">
        <book-card v-bind:book="book"/>
      </router-link>
    </div>
  </div>
</template>

<script>
import BookCard from '../components/BookCard.vue';

export default {
  components: {
    BookCard
  },
}
</script>

<style>
.book-container {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
}
</style>