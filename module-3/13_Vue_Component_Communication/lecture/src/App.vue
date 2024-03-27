<template>
  <div class="main">
    <h1>Product Reviews for </h1>
    <p class="description"></p>
    <div class="well-display">
      <average-summary />
      <!-- This form of v-for loops through i = 1 to 5 (see https://vuejs.org/guide/essentials/list.html#v-for-with-a-range) -->
      <star-summary v-for="i in 5" v-bind:key="i" />
    </div>
    <add-review />
    <review-list />
  </div>
</template>

<script>
import AverageSummary from './components/AverageSummary.vue';
import StarSummary from './components/StarSummary.vue';
import AddReview from './components/AddReview.vue';
import ReviewList from './components/ReviewList.vue';

export default {
  components: {
    AverageSummary,
    StarSummary,
    AddReview,
    ReviewList
  }
};
</script>

<style scoped>
.main {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  max-width: 800px;
  margin: 60px auto 0 auto;
}

.well-display {
  display: flex;
  justify-content: space-around;
  margin-bottom: 1rem;
}
</style>
