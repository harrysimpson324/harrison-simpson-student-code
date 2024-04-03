<template>
  <table id="shop-items-table">
    <thead>
      <tr>
        <th>Name</th>
        <th>Address</th>
        <th>City</th>
        <th>State</th>
        <th>Zip</th>
      </tr>
    </thead>
    <tbody>
      <tr class="clickable" v-for="location in shops" v-bind:key="location.shopId" v-on:click="viewShop(location.shopId)">
        <td>{{location.name}}</td>
        <td>{{location.streetAddress}}</td>
        <td>{{location.city}}</td>
        <td>{{location.state}}</td>
        <td>{{location.zipCode}}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  props: {
    shops: {
      type: Array,
      required: true,
    },
  },
  methods: {
    viewShop(shopId) {
      this.$router.push({ name: 'shop_detail', params: {id: shopId} });
    },
  }
};
</script>

<style scoped>
.clickable {
  cursor: pointer;
} 
</style>