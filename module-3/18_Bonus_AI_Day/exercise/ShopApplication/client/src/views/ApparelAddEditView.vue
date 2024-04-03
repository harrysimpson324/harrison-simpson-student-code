<template>
  <div class="page-title">
    <h1>{{title}}</h1>
  </div>
  <ApparelForm v-bind:item="apparelItem" v-bind:title="title"/>
</template>

<script>
import ApparelService from '../services/ApparelService';

import ApparelForm from '../components/ApparelForm.vue';

export default {
	components: {
    ApparelForm
  },
  data() {
    return {
      apparelItem: {},
    };
  },
  created() {
    let apparelId = this.$route.params.id;
    if (apparelId === 'add') {
      this.apparelItem = {};
    } else {
      this.getApparelItem(apparelId);
    }
  },
  methods: {
    getApparelItem(apparelId) {
      ApparelService.getItem(apparelId)
        .then(response => {
          this.apparelItem = response.data;
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
  },
	computed: {
    title() {
      return this.$route.params.id === 'add' ? 'Add Apparel' : 'Edit Apparel';
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