
<template>
    <form @submit.prevent="addBookToList" class="new-book-form">
        <input v-model="newBook.title" type="text" id="title-input" name="title-input" class="title-input" />
        <input v-model="newBook.author" type="text" id="author-input" name="author-input" class="author-input"/>
        <input v-model="newBook.isbn" type="text" id="isbn-input" name="isbn-input" class="isbn-input"/>
        <input type="submit" value="Save"/>
    </form>
</template>


<script>

export default {

    data() {
        return {
            newBook: {title: '', author: '', isbn: ''}
        }
    },

    methods: {
        addBookToList() {
            this.$store.commit('ADD_BOOK', this.newBook);
            this.resetForm();
        },
        resetForm() {
            this.newBook = {title: '', author: '', isbn: ''};
        }
    }
}



</script>



<style scoped>




</style>