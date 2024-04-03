<template>
  <div class="table-title">
    <h1>Apparel</h1>
    <div><button v-on:click="addApparel">Add Apparel</button></div>
  </div>
  <ApparelTable v-bind:apparel="apparel"
      v-on:refresh-apparel="getApparel"
      v-on:edit-apparel="editApparel"
      v-on:delete-apparel="deleteApparel" />
</template>

<script>
import ApparelService from '../services/ApparelService';
import ApparelTable from '../components/ApparelTable.vue';
export default {
	components: {
    ApparelTable
},
	data() {
		return {
			apparel: [],
		};
	},
  created() {
    this.getApparel();
  },
  methods: {
    addApparel() {
      this.$router.push({ name: 'add_edit_apparel', params: {id: 'add'} });
    },
    editApparel(apparelId) {
      this.$router.push({ name: 'add_edit_apparel', params: {id: apparelId} });
    },
    getApparel() {
      ApparelService.getAll()
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
    deleteApparel(apparelId) {
      ApparelService.deleteItem(apparelId)
      .then( () => {
        this.getApparel();
      })
      .catch(error => {
        const response = error.response;
        if (response) { // response received
          if (response.status === 401) { // Token expired or otherwise invalid
            this.$store.commit("LOGOUT");
            this.$router.push({name: "login"});
          } else {
            // Something else unexpected happened
            console.error('Could not delete apparel item.', response.data?.message);
          }
        } else { // no response received
          console.error('Could not delete apparel item.', error.message);
        }
      });
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