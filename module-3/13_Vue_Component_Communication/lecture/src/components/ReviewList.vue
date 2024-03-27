<template>
  <div>
    <review-display
      v-for="review in filteredReviews"
      v-bind:key="review.id"
      v-bind:review="review"
    />
  </div>
</template>

<script>
import ReviewDisplay from './ReviewDisplay.vue';

export default {
  components: {
    ReviewDisplay
  },
  computed: {
    filteredReviews() {
      const reviewsFilter = -1;
      const reviews = [];
      return reviews.filter(review => {
        return reviewsFilter === 0 || reviewsFilter === review.rating;
      });
    }
  }
};
</script>
