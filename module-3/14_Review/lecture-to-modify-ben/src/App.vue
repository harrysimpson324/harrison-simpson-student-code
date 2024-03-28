<template>
  <div class="main">
    <our-classroom />
  </div>
</template>

<script>
// import AverageSummary from "./components/AverageSummary.vue";
//import StarSummary from "./components/StarSummary.vue";
//import AddReview from "./components/AddReview.vue";
// import ReviewList from "./components/ReviewList.vue";
//import ReviewTable from "./components/ReviewTable.vue";
import OurClassroom from "./components/OurClassroom.vue"

export default {
  components: {
    OurClassroom
  }
};
</script>

<style>
:root {
    --gray: #6c757d;
}

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

body {
    background: url(https://images.unsplash.com/photo-1531315630201-bb15abeb1653?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80);
    background-size: cover;
    width: 99vw;
    margin:0;
    padding:0;
}

ul {
    margin: 0;
    padding: 0;
    list-style-type: none;
}

ul#classroom {
    display: flex;
    flex-wrap: wrap;
    gap: 15px;
    flex-direction: column;
    height: 490px;
    justify-content: space-between;
    align-items: center;
}


ul#classroom li {
    display: flex;
    justify-content: center;
    align-items: center;
    color: white;
    background: red;;
    font-size: 2rem;
    font-weight: bold;
    border: 3px solid #ddd;
    padding: 3px;
    min-height: 80px;
    min-width:100px;
}


#headHoncho,
.instructor {
    font-size: 3rem;
    flex-basis: 45%;
    border: 3px solid yellow !important;
}

#headHoncho {
    text-shadow: 2px 1px black;
    color: var(--gray) !important;
    background: white !important;
}

.campusDirector {
    flex-basis: 75%;
    font-style: italic;
    text-align: center;
    text-shadow: 2px 2px white;
    border: 4px dashed darkred !important;
    background-image: linear-gradient(rgba(0, 0, 255, 0.5), rgba(0, 255, 0, 0.5)) !important;
    color: var(--gray) !important;

}

.javablue {
    background: blue !important;
}

.javagray {
    background: var(--gray) !important;
}

.javagreen {
    background: green !important;
}
</style>
