<template>
  <table>
    <thead>
      <th>Title</th>
      <th>Reviewer</th>
      <th>Review</th>
      <th>Rating</th>
      <th>Favorited</th>
    </thead>
    <tbody>
      <review-table-row
         v-for="review in filteredReviews"
         v-bind:key="review.id"
         v-bind:review="review" />
         <tr v-show="filteredReviews.length == 0"><td colspan="5">There are no reviews</td></tr>
    </tbody>
  </table>
</template>

<script>
import ReviewTableRow from './ReviewTableRow.vue';

export default {
  components: {
    ReviewTableRow
  },
  computed: {
    filteredReviews() {
      const reviewsFilter = this.$store.state.filter;
      const reviews = this.$store.state.reviews;
      return reviews.filter(review => {
        return reviewsFilter === 0 || reviewsFilter === review.rating;
      });
    }
  }
  
};
</script>

<style scoped>
th {
  text-align: left;
}
table {
    border: 1px solid green;
    border-collapse: collapse;
}

</style>
