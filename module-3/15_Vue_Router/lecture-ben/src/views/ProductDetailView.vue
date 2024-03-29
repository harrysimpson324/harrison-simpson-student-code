<template>
    <h1>Product Detail for {{ product.name }}</h1>
    <p class="description">{{  product.description }}</p>
    <div class="actions"> 
        <!-- <router-link to="/">Back to Products</router-link>&nbsp;&nbsp; -->
        <router-link v-bind:to="{ name: 'products' }">Back to Products</router-link>&nbsp;&nbsp;
        <router-link v-bind:to="{ name: 'add-review', params: { id: product.id } }">Add Review</router-link>
    </div>
    <div class="well-display">
        <average-summary v-bind:reviews="product.reviews" />
        <star-summary
            v-for="i in 5"
            v-bind:rating="6-i"
            v-bind:key="i"
            v-bind:reviews="product.reviews" />
    </div>
    <review-list v-bind:reviews="product.reviews" />
</template>

<script>
import AverageSummary from '../components/AverageSummary.vue';
import StarSummary from '../components/StarSummary.vue';
import ReviewList from '../components/ReviewList.vue';

export default {
    components: {
        AverageSummary,
        StarSummary,
        ReviewList
    },
    computed: {
        product() {
            let productId = this.$route.params.id;
            let product = this.$store.state.products.find((p) => {
                return p.id == productId;
            });
            return product;
        }
    }
}
</script>

<style scoped>
.well-display {
  display: flex;
  justify-content: space-around;
  margin-bottom: 1rem;
}
.actions {
  margin: 2rem;
}
</style>

