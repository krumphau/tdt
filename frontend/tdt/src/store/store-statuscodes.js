import axios from 'axios'

const state = {
  statusCodes: []
}

const mutations = {
  setStatusCodes: (state, { statusCodes }) => {
    state.statusCodes = statusCodes
  },
  updateStatusCode: (state, { item }) => {
    let idx = state.statusCodes.map(p => p.id).indexOf(item.id)
    state.statusCodes.splice(idx, 1, item)
  },
  deleteStatusCode: (state, { id }) => {
    let idx = state.statusCodes.map(p => p.id).indexOf(id)
    state.statusCodes.splice(idx, 1)
  },
  addStatusCode: (state, { statusCode }) => {
    state.statusCodes.push(statusCode)
  }
}

const actions = {
  loadStatusCodes: async function (context) {
    axios.get('http://localhost:5000/statuscodes').then((response) => {
      context.commit('setStatusCodes', { statusCodes: response.data })
      return true
    }, () => {
      return false
    })
  },
  addStatusCode: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/statuscode', item).then((response) => {
      commit('addStatusCode', { statusCode: item })
    }, () => {
      return false
    })
  },
  deleteStatusCode: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/statuscode/' + id).then((response) => {
      commit('deleteStatusCode', { id: id })
    }, () => {
      return false
    })
  },
  updateStatusCode: function ({ commit, state }, { item }) {
    axios.put('http://localhost:5000/statuscode/' + item.Id, item).then((response) => {
      commit('updateStatusCode', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  statusCodes: (state) => {
    return state.statusCodes
  },
  getStatusCodeById: (state) => (id) => {
    return state.statusCodes.find(statusCodes => statusCodes.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
