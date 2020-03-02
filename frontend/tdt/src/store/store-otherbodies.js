import axios from 'axios'

const state = {
  otherBodies: []
}

const mutations = {
  setOtherBodies: (state, { otherBodies }) => {
    state.otherBodies = otherBodies
  },
  updateOtherBody: (state, { item }) => {
    let idx = state.otherBodies.map(p => p.id).indexOf(item.id)
    state.otherBodies.splice(idx, 1, item)
  },
  deleteOtherBody: (state, { id }) => {
    let idx = state.otherBodies.map(p => p.id).indexOf(id)
    state.otherBodies.splice(idx, 1)
  },
  addOtherBody: (state, { otherBody }) => {
    state.otherBodies.push(otherBody)
  }
}

const actions = {
  loadOtherBodies: async function (context) {
    axios.get('http://localhost:5000/otherbodies').then((response) => {
      context.commit('setOtherBodies', { otherBodies: response.data })
      return true
    }, () => {
      return false
    })
  },
  addOtherBody: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/otherbody', item).then((response) => {
      commit('addOtherBody', { otherBody: item })
    }, () => {
      return false
    })
  },
  deleteOtherBody: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/otherbody/' + id).then((response) => {
      commit('deleteOtherBody', { id: id })
    }, () => {
      return false
    })
  },
  updateOtherBody: function ({ commit, state }, { item }) {
    axios.put('http://localhost:5000/otherbody/' + item.Id, item).then((response) => {
      commit('updateOtherBody', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  otherBodies: (state) => {
    return state.otherBodies
  },
  getOtherBodyById: (state) => (id) => {
    return state.otherBodies.find(otherBodies => otherBodies.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
