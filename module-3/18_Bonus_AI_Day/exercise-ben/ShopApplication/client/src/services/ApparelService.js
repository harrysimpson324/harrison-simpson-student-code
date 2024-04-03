import axios from 'axios';

export default {

  getAll() {
    return axios.get('/apparel/');  
  },

  getItem(itemId) {
    return axios.get(`/apparel/${itemId}`);  
  },

  addItem(item) {
    return axios.post('/apparel/', item);
  },

  updateItem(item) {
    return axios.put(`/apparel/${item.apparelId}`, item);
  },

  deleteItem(itemId) {
    return axios.delete(`/apparel/${itemId}`);
  }

}