<template>
    <h1>Add Review</h1>
    <add-review v-bind:productId="productId" />
</template>

<script>
import AddReview from '../components/AddReview.vue'

export default {
    components: {
        AddReview
    },
    computed: {
        productId() {
            return this.$route.params.id;
        }
    }
}

</script>