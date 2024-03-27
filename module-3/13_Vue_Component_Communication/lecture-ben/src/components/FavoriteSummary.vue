<template>
    <div class="well">
      <span class="amount">{{ numberOfReviews }}</span>
      How Many Favorites?
    </div>
  </template>
  
  <script>
  export default {
    name: 'favorite-summary',
    computed: {
      numberOfReviews() {
        const reviews = this.$store.state.reviews;
        const matchingReviews = reviews.filter((review) => {
          return review.favorited;
        });
        return matchingReviews.length;
      }
    }
  };
  </script>
  
  <style scoped>
  .well {
    display: inline-block;
    width: 15%;
    border: 1px black solid;
    border-radius: 6px;
    text-align: center;
    margin: 0.25rem;
    padding: 0.25rem;
  }
  
  .amount {
    color: darkslategray;
    display: block;
    font-size: 2.5rem;
  }
  
  .amount:hover {
    cursor: pointer;
  }
  
  </style>
  