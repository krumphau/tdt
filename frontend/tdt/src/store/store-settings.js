const state = {
  baseUrl: 'http://127.0.0.1:5000/'
}

const getters = {
  url: (state) => {
    return state.baseUrl
  }
}

export default {
  namespaced: true,
  state,
  getters
}
