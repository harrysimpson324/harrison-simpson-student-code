<template>
  <tr>
    <td>{{ item.title }}</td>
    <td>{{ item.description }}</td>
    <td>{{ item.size }}</td>
    <td>{{ Intl.NumberFormat('en-US', { currency: 'USD', style: 'currency' }).format(item.price) }}</td>
    <td>
      <span v-if="!isEditing">{{ updateQuantity }}</span>
      <input v-else v-model="updateQuantity" size="4"/>
    </td>
    <td>
      <button class="save-button" v-if="isEditing" v-on:click="saveQuantity(item.shopInventory)">Save</button>
      <button class="edit-button" v-else v-on:click="editQuantity">Edit</button>
      <button v-on:click="deleteItem(item.shopInventory)">Delete</button>
    </td>
  </tr>
</template>

<script>
export default {
  data() {
    return {
      isEditing: false,
      updateQuantity: 0,
    };
  },
  emits: ['updateItem', 'deleteItem'],
  props: {
    item: {
      type: Object,
      required: true,
    },
  },
  created() {
    this.updateQuantity = this.item.shopInventory.quantity;
  },
  methods: {
    editQuantity() {
      this.isEditing = true;
    },
    saveQuantity(shopInventory) {
      try {
        let updateInventory = { ...shopInventory };
        updateInventory.quantity = Number(this.updateQuantity);
        this.isEditing = false;
        this.$emit('updateItem', updateInventory);
      } catch (error) {
        this.message = 'Quantity must be a number';
        this.updateQuantity = this.item.shopInventory.quantity;
      }
    },
    deleteItem(shopInventory) {
      this.$emit('deleteItem', shopInventory);
    },
  },
};
</script>

<style scoped>
button {
  min-width: 70px;
}

.save-button {
  background-color: rgb(198, 232, 198);
}
</style>