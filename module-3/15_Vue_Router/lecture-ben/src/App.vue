<template>
  <div class="main">
    <img src="./assets/logo.png" />
    <router-view />
    <h6>&copy;2024 - All Rights Reserved</h6>
  </div>
</template>

<script>
export default {};
</script>

<style>
.main {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  max-width: 800px;
  margin: 60px auto 0 auto;
}
</style>
