<template>
  <div id="store-app">
    <NavBar />
    <main>
      <router-view />
    </main>
  </div>
</template>

<script>
import NavBar from './components/NavBar.vue';
export default {
  components: {
    NavBar
  }
};
</script>

<style>
body {
  font-family: Arial, sans-serif;
  margin: 0;
  padding: 0;
}

main {
  padding: 20px;
  width: 80%;
  margin: 0 auto;
}

button {
  border-radius: 5px;
  border: 1px solid transparent;
  cursor: pointer;
  margin-right: 0.5rem;
  padding: 0.2rem 0.75rem;
}

button:hover {
  border-color: #000;
}

.button-group button:not(:last-child) {
  margin-right: 15px;
}

.btn-submit {
  background-color: rgba(152, 231, 136, 0.5);
}

table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  text-align: left;
  padding: 0.5rem 0.5rem;
  vertical-align: baseline;
}

tr:hover {
  background-color: #f5f5f5;
}


</style>

