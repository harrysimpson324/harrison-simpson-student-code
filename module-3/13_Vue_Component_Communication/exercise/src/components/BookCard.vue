<template>
  <div id="" class="card" :class="{'read': book.read}">
    <h2 class="book-title">{{ book.title }}</h2>
    <h3 class="book-author">{{ book.author }}</h3>
    <img class="book-image" :src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'"/>
    <button
    :class="{ 'mark-read' : buttonText=='Mark Read', 'mark-unread': buttonText=='Mark Unread'}"
    @click="addOrChangeBookStatus(book)" 
    >{{ buttonText }}</button>
    <!-- debug book status: {{ displayBookStatus }}
    debug button classes: {{ {'mark-read' : buttonText=='Mark Read', 'mark-unread': buttonText=='Mark Unread'} }} -->
  </div>
</template>

<script>
export default {
  props: ['book'],

  computed: {
    buttonText() {
      if (this.book.read) {
        return 'Mark Unread';
      }
      return 'Mark Read'
    },

    displayBookStatus() {
      if (this.book.status == undefined ) {
        return 'undefined';
      }
      else if (this.book.status == null ) {
        return 'null'
      }
      else if (this.book.status == '') {
        return 'empty string';
      }
      return this.book.status;
    }
  },

  methods: {
    addOrChangeBookStatus(book) {
      this.$store.commit('CHANGE_READ_STATUS', book);
    }
  }

}
</script>

<style>
.card {
  border: 2px solid black;
  border-radius: 10px;
  width: 250px;
  height: 550px;
  margin: 20px;
  position: relative;
}

.card.read {
  background-color: lightgray;
}

.card .book-title {
  font-size: 1.5rem;
}

.card .book-author {
  font-size: 1rem;
}

.book-image {
  width: 80%;
}

.mark-read, .mark-unread {
  display: block;
  position: absolute;
  bottom: 40px;
  width: 80%;
  left: 10%;
  font-size: 1rem;
}


</style>