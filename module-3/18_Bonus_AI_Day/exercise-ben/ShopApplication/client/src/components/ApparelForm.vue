<template>
  <form v-on:submit.prevent="submit">
    <div class="alert" v-show="message">
      <p>{{ message }}</p>
    </div>
    <div class="form-control">
      <label for="title">Title:</label>
      <input type="text" id="title" size=80 v-model="editableItem.title" />
    </div>
    <div class="form-control">
      <label for="size">Size:</label>
      <input type="size" id="size" size=20 v-model="editableItem.size" />
    </div>
    <div class="form-control">
      <label for="price">Price:</label>
      <input type="text" id="price" size=20 v-model="editableItem.price" />
    </div>
    <div class="form-control">
      <label for="description">Description:</label>
      <textarea id="description" rows="3" cols="80" v-model="editableItem.description" />
    </div>
    <div class="button-group">
      <button type="submit" class="btn-submit">Save</button>
      <button type="button" v-on:click="cancel">Cancel</button>
    </div>
  </form>
</template>

<script>
import service from '../services/ApparelService';

export default {
  props: {
      item: {
          type: Object,
          required: true,
      }
    },
  data() {
    return {
      editableItem: {},
      message: ''
    }
  },
  updated() {
    if (this.editableItem.apparelId != this.item.apparelId){
      this.init();
    }
  },
  methods: {
    init() {
      if (this.item.apparelId) {
        this.editableItem = {...this.item}
      } else {
        this.editableItem = {
          title: '',
          description: '',
          size: '',
          price: ''
        }
      }
    },
    cancel(){
      this.$router.push({name: "apparel_list"});
    },
    isValid() {
      return this.editableItem.title && this.editableItem.description &&
          this.editableItem.size && this.editableItem.price;
    },
    submit() {
      if (this.editableItem.apparelId) {
        if (!this.isValid()) {
          this.message = 'Please fill out all fields.';
          return;
        }

        service.updateItem(this.editableItem)
          .then(() => {
            this.$router.push({name: "apparel_list"});
          })
          .catch(error => {
            const response = error.response;
            if (response) { // response received
              if (response.status === 401) { // Token expired or otherwise invalid
                this.$store.commit("LOGOUT");
                this.$router.push({name: "login"});
              } else {
                // Something else unexpected happened
                console.error('Could not update apparel item.', this.editableItem, response.data?.message);
                this.message = 'Sorry, the apparel item could not be updated at this time.';
              }
            } else { // no response received
              console.error('Could not update apparel item.', this.editableItem, error.message);
              this.message = 'Sorry, the apparel item could not be updated at this time.';
            }
          })
      } else {
        service.addItem(this.editableItem)
          .then(() => {
            this.$router.push({name: "apparel_list"});
          })
          .catch(error => {
            const response = error.response;
            if (response) { // response received
              if (response.status === 401) { // Token expired or otherwise invalid
                this.$store.commit("LOGOUT");
                this.$router.push({name: "login"});
              } else {
                // Something else unexpected happened
                console.error('Could not add apparel item.', this.editableItem, response.data?.message);
                this.message = 'Sorry, the apparel item could not be added at this time.';
              }
            } else { // no response received
              console.error('Could not add apparel item.', this.editableItem, error.message);
              this.message = 'Sorry, the apparel item could not be added at this time.';
            }
          })
      }
    }
  }
  };
</script>

<style scoped>
form {
  margin-bottom: 1rem;
}

label {
  text-align: right;
  display: inline-block;
  margin-right: 15px;
  width: 150px;
}

input {
  display: inline-block;
}

button {
  border: 1px solid black;
  border-radius: 5px;
  padding: 0.25rem 0.5rem;
}

.button-group {
  margin-left: 165px;
}

.button-group button:not(:last-child) {
  margin-right: 15px;
}

.btn-submit {
  background-color: rgba(152, 231, 136, 0.5);
}

.form-control {
  display: flex;
  margin-bottom: 1rem;
  align-items: baseline;
}
</style>