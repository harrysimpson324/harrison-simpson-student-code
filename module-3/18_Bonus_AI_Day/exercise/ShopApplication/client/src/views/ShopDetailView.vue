<template>
  <div class="page-title">
    <h1>{{shop.name || 'Shop'}}</h1>
  </div>
  <div class="table-title">
    <h2>Apparel Available</h2>
    <div v-if="hasEditAuth"><button v-on:click="addApparel">Add Apparel</button></div>
  </div>
  <ShopApparelTable v-bind:apparel="apparel" v-bind:hasEditAuth="hasEditAuth"
      v-on:refresh-apparel="getApparel" />
</template>

<script>
import ShopApparelTable from '../components/ShopApparelTable.vue';
import ShopService from '../services/ShopService';

export default {
	components: {
    ShopApparelTable
  },
	data() {
		return {
      shopId: null,
			shop: {},
      apparel: [],
		};
	},
  created() {
    this.shopId = this.$route.params.id;
    this.getShop();
    this.getApparel();
  },
  methods: {
    getShop() {
      ShopService.getShop(this.shopId)
        .then(response => {
          this.shop = response.data;
        })
        .catch(error => {
          const response = error.response;
          if (response) { // response received
            if (response.status === 401) { // Token expired or otherwise invalid
              this.$store.commit("LOGOUT");
              this.$router.push({name: "login"});
            } else {
              // Something else unexpected happened
              console.error('Could not get shop information at this time.', response.data?.message);
            }
          } else { // no response received
            console.error('Could not get shop information at this time.', error.message);
          }
        });
    },
    getApparel() {
      ShopService.getShopApparel(this.shopId)
        .then(response => {
          this.apparel = response.data;
        })
        .catch(error => {
          const response = error.response;
          if (response) { // response received
            if (response.status === 401) { // Token expired or otherwise invalid
              this.$store.commit("LOGOUT");
              this.$router.push({name: "login"});
            } else {
              // Something else unexpected happened
              console.error('Could not get apparel at this time.', response.data?.message);
            }
          } else { // no response received
            console.error('Could not get apparel at this time.', error.message);
          }
        });
    },
    addApparel() {
      this.$router.push({ name: 'shop_add_apparel' });
    }
  },
  computed: {
    hasEditAuth() {
      if (this.$store.state.user) {
        let roles = this.$store.state.user.authorities;
        if (roles && roles.filter(role => role.name === 'ROLE_SHOP').length > 0) {
            return true;
        }
      }
      return false;
    }
  }
};
</script>

<style scoped>
.table-title{
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  gap: 1rem;
}
</style>