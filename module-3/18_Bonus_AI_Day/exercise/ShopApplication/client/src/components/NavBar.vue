<template>
  <header>
    <h1>Web Threads</h1>
    <nav id="main-nav" v-if="$store.state.token">
      <router-link v-bind:to="{ name: 'shop_list' }">Shop List</router-link>&nbsp;|&nbsp;
      <span v-if="isHQ"><router-link v-bind:to="{ name: 'apparel_list' }">Apparel List</router-link>&nbsp;|&nbsp;</span>
      <router-link v-bind:to="{ name: 'logout' }">Logout</router-link>
    </nav>
  </header>
</template>

<script>
export default {
  computed: {
    isHQ() {
      if (this.$store.state.user) {
        let roles = this.$store.state.user.authorities;
        if (roles && roles.filter(role => role.name === 'ROLE_HQ').length > 0) {
            return true;
        }
      }
      return false;
    }
  }
};
</script>

<style scoped>
header {
  background-color: #f0f0f0;
  display: flex;
  align-items: center;
  gap: 1rem;
  justify-content: space-between;
  margin-bottom: 1rem;
  padding: 0.5rem 1rem;
}

header h1 {
  margin: 0;
}

#main-nav {
  display: flex;
  justify-content: flex-end;
  gap: 0.5rem;
}

#main-nav a {
  text-decoration: none;
  color: #000;
}
</style>