<template>
    <book-details :book="book" />
    <!-- TODO: <a href="">More Information</a> -->
</template>



<script>
import BookDetails from '../components/BookDetails.vue';



export default {
    components: {
        BookDetails
    },
    computed: {
        book() {
            const isbn = this.$route.params.bookIsbn;
            console.log("isbn: " +isbn);
            return this.$store.state.books.find((element) => {
                if (element.isbn == isbn) {
                    console.log("title: " + element.title);
                    return element;
                }
            });
        }
    }
}
</script>
