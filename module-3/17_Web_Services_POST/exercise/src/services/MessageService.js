import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  //GET
  get(id) {
    return http.get(`/messages/${id}`);
  },

  //POST
  addMessage(message) {
    return http.post(`/messages`, message);
  },

  //PUT
  updateMessage(messageId, message) {
    return http.put(`/messages/${messageId}`, message);
  },

  //DELETE
  deleteMessage(messageId) {
    return http.delete(`/messages/${messageId}`);
  }

}
