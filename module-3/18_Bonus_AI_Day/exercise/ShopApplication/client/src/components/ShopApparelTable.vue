<template>
  <table id="shop-items-table">
    <thead>
      <tr>
        <th>Title</th>
        <th>Description</th>
        <th>Size</th>
        <th>Price</th>
        <th>Quantity</th>
        <th v-if="hasEditAuth">&nbsp;</th>
      </tr>
    </thead>
    <tbody v-if="hasEditAuth">
      <ApparelEditableRow v-for="item in apparel" v-bind:key="item.id" v-bind:item="item"
          v-on:updateItem="updateItem" v-on:deleteItem="deleteItem" />
    </tbody>
    <tbody v-else>
      <tr v-for="item in apparel" v-bind:key="item.id">
        <td>{{ item.title }}</td>
        <td>{{ item.description }}</td>
        <td>{{ item.size }}</td>
        <td>{{ Intl.NumberFormat('en-US', { currency: 'USD', style: 'currency' }).format(item.price) }}</td>
        <td>{{ item.shopInventory.quantity }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import ApparelEditableRow from './ShopApparelEditableRow.vue';
import ShopService from '../services/ShopService';

export default {
  components: {
    ApparelEditableRow,
  },
  emits: ['refreshApparel'],
  props: {
    apparel: {
      type: Array,
      required: true,
    },
    hasEditAuth: {
      type: Boolean,
      required: true,
    },
  },
  methods: {
    updateItem(shopInventory) {
      ShopService.updateShopInventory(shopInventory.shopId, shopInventory)
        .then(() => {
          this.$emit('refreshApparel');
        })
        .catch(error => {
          const response = error.response;
          if (response) { // response received
            console.error('Error updating apparel inventory', response.data?.message);
          } else { // no response received
            console.error('Error updating apparel inventory', error.message);
          }
        });
    },
    deleteItem(shopInventory) {
      ShopService.deleteShopInventory(shopInventory.shopId, shopInventory.apparelId)
        .then(() => {
          this.$emit('refreshAparel');
        })
        .catch(error => {
          const response = error.response;
          if (response) { // response received
            console.error('Error deleting apparel', response.data?.message);
          } else { // no response received
            console.error('Error deleting apparel', error.message);
          }
        });
    },
  }
};
</script>

<style scoped>

</style>