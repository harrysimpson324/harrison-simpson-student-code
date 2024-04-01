import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  getBoards() {
    return http.get('/boards');
  },

  getBoard(boardId) {
    return http.get(`/boards/${boardId}`)
  },

  getCard(cardId) {
    return http.get(`/cards/${cardId}`)
  }

}
