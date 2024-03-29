<template>

    <h1>{{ book.title }}</h1>
    <h1>{{ book.author }}</h1>
    <img v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" />
    <p>Number of pages: {{ book.numPages }}</p>
    <a :href=book.moreInfoLink target="_blank">More Information</a>
    <p>{{ haveReadBook }}</p>


</template>

<script>



export default {
    props: ['book'],
    computed: {
        haveReadBook() {
            if (this.book.read) {
                return 'I have read this book';
            }
            return 'I have not read this book';
        },
        moreInfo() {
            return this.book.moreInfoLink;
        }
    }
}

</script>

<style scoped>

img {
    width: 400px;
}

</style>