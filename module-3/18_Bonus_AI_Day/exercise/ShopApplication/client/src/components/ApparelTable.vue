<template>
  <table id="shop-items-table">
    <thead>
      <tr>
        <th>Title</th>
        <th>Description</th>
        <th>Size</th>
        <th>Price</th>
        <th>&nbsp;</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in apparel" v-bind:key="item.apparelId">
        <td>{{ item.title }}</td>
        <td>{{ item.description }}</td>
        <td>{{ item.size }}</td>
        <td>{{ Intl.NumberFormat('en-US', { currency: 'USD', style: 'currency' }).format(item.price) }}
        </td>
        <td>
          <button v-on:click="$emit('editApparel', item.apparelId)">Edit</button>
          <button v-on:click="$emit('deleteApparel', item.apparelId)">Delete</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  emits: {
    deleteApparel(apparelId) {
      return apparelId
    },
    editApparel(apparelId) {
      return apparelId
    },
  },
  props: {
    apparel: {
      type: Array,
      required: true,
    },
  },
};
</script>

<style scoped>
.clickable {
  cursor: pointer;
}

tr:hover {
  background-color: #f5f5f5;
}
</style>