<template>
  <div class="page-title">
    <h1>Add Apparel to Shop</h1>
  </div>
  <div v-if="unlisted && unlisted.length === 0">
    <p>No additional apparel available to add.</p>
    <button v-on:click="$router.push({ name: 'shop_detail', params: {id: shopId} })">Back</button>
  </div>
  <ShopAddApparelForm v-else v-bind:shopId="shopId" v-bind:apparel="unlisted"
      v-on:add-apparel="addApparel" />
</template>

<script>
import ShopService from '../services/ShopService';

import ShopAddApparelForm from '../components/ShopAddApparelForm.vue';

export default {
  components: {
    ShopAddApparelForm
  },
    data() {
        return {
            unlisted: [],
            shopId: null
        };
    },
  created() {
    this.shopId = this.$route.params.id;
    ShopService.getUnlistedApparel(this.shopId)
      .then(response => {
        this.unlisted = response.data;
      })
      .catch(error => {
        const response = error.response;
        if (response) { // response received
          if (response.status === 401) { // Token expired or otherwise invalid
            this.$store.commit("LOGOUT");
            this.$router.push({name: "login"});
          } else {
            // Something else unexpected happened
            console.error('Could not get shop inventory at this time.', response.data?.message);
          }
        } else { // no response received
          console.error('Could not get shop inventory at this time.', error.message);
        }
      });
  },
  methods: {
    addApparel(selectedApparel) {
      ShopService.addApparelItems(this.shopId, selectedApparel)
        .then(responses => {
          this.$router.push({ name: 'shop_detail', params: {id: this.shopId} });
        })
    },
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