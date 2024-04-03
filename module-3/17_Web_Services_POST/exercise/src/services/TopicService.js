import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  //GET
  list() {
    return http.get('/topics');
  },

  get(id) {
    return http.get(`/topics/${id}`);
  },

  //POST
  addTopic(topic) {
    return http.post(`/topics`, topic);
  },

  //PUT
  updateTopic(topicId, topic) {
    return http.put(`/topics/${topicId}`, topic);
  },

  //DELETE
  deleteTopic(topicId) {
    return http.delete(`/topics/${topicId}`);
  }

}
