import axios from 'axios';

export default {

  getAll() {
    return axios.get('/shops/');  
  },

  getShop(shopId) {
    return axios.get(`/shops/${shopId}`);  
  },

  getShopApparel(shopId) {
    return axios.get(`/shops/${shopId}/apparel`);  
  },

  getUnlistedApparel(shopId) {
    return axios.get(`/shops/${shopId}/apparel?inventory=false`);  
  },

  addApparelItems(shopId, selectedApparel) {
    let promises = [];
    for (let apparel of selectedApparel) {
      promises.push(axios.post(`/shops/${shopId}/apparel/${apparel.apparelId}`));
    }
    return Promise.allSettled(promises);
  },

  updateShopInventory(shopId, shopInventory) {
    return axios.put(`/shops/${shopId}/apparel/${shopInventory.apparelId}`, shopInventory);
  },

  deleteShopInventory(shopId, apparelId) {
    return axios.delete(`/shops/${shopId}/apparel/${apparelId}`);
  }
}