<template>
  <div class="page-title">
    <h1>Our Shops</h1>
  </div>
  <ShopTable v-bind:shops="shops" />
</template>

<script>
import ShopService from '../services/ShopService';
import ShopTable from '../components/ShopTable.vue';
export default {
	components: {
    ShopTable
},
	data() {
		return {
			shops: [],
		};
	},
  created() {
    ShopService.getAll()
      .then(response => {
        this.shops = response.data;
      })
      .catch(error => {
        const response = error.response;
        if (response) { // response received
          if (response.status === 401) { // Token expired or otherwise invalid
            this.$store.commit("LOGOUT");
            this.$router.push({name: "login"});
          } else {
            // Something else unexpected happened
            console.error('Could not get shops at this time.', response.data?.message);
          }
        } else { // no response received
          console.error('Could not get shops at this time.', error.message);
        }
      });
  }
};
</script>

<style scoped>

</style>