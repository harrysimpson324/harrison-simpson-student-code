<template>
    <reading-list />
    <router-link :to="{name: 'addBook'}">Add Book to Reading List</router-link>
</template>



<script>
import ReadingList from '../components/ReadingList.vue';



export default {
    components: {
        ReadingList
    }
}
</script>



<style>



</style>