<template>
  <form v-on:submit.prevent="submit">
    <div class="alert" v-show="message">
      <p>{{ message }}</p>
    </div>
    <table id="shop-items-table">
      <thead>
        <tr>
          <th>Select</th>
          <th>Title</th>
          <th>Description</th>
          <th>Size</th>
          <th>Price</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in apparel" v-bind:key="item.apparelId">
          <td><input type="checkbox" v-model="item.selected"></td>
          <td>{{ item.title }}</td>
          <td>{{ item.description }}</td>
          <td>{{ item.size }}</td>
          <td>{{ item.price }}</td>
        </tr>
      </tbody>
    </table>
    <div class="button-group">
      <button type="submit" class="btn-submit">Submit</button>
      <button type="cancel">Cancel</button>
    </div>
  </form>
</template>

<script>
export default {
  props: {
    shopId: {
      type: String,
      required: true,
    },
    apparel: {
      type: Array,
      required: true,
    },
  },
  data() {
    return {
      selectedRows: {},
      message: '',
    };
  },
  methods: {
    submit() {
      const selected = this.apparel.filter(item => item.selected);
      this.$emit('addApparel', selected);
    },
  },
};
</script>

<style scoped>
table {
  margin-bottom: 1rem;
}

.button-group button:not(:last-child) {
  margin-right: 15px;
}

.btn-submit {
  background-color: rgba(152, 231, 136, 0.5);
}
</style>