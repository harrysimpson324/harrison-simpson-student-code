<template>
  <form class="new-book-form" v-on:submit.prevent="saveBook">
    <input class="title-input" name="title-input" type="text" placeholder="Title" v-model="book.title" />
    <input class="author-input" name="author-input" type="text" placeholder="Author" v-model="book.author" />
    <input class="isbn-input" name="isbn-input" type="text" placeholder="ISBN" v-model="book.isbn" />
    <input type="number" name="num-pages-input" placeholder="Num Pages" v-model="book.numPages" />
    <input type="url" name="more-info-link" placeholder="More Info Link" v-model="book.moreInfoLink" />
    <button>Save</button>
  </form>
</template>

<script>
export default {
  data() {
    return {
      book: {}
    }
  },
  methods: {
    saveBook() {
      this.$store.commit('SAVE_BOOK', this.book);
      this.book = {};
    }
  }
}
</script>

<style>
.new-book-form {
  margin: 20px;
}

.new-book-form input, .new-book-form button {
  margin: 10px;
  font-size: 1rem;
}
</style>
