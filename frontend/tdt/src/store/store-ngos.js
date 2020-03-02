import axios from 'axios'

const state = {
  NGOs: []
}

const mutations = {
  setNGOs: (state, { NGOs }) => {
    state.NGOs = NGOs
  },
  updateNGO: (state, { item }) => {
    let idx = state.NGOs.map(p => p.id).indexOf(item.id)
    state.NGOs.splice(idx, 1, item)
  },
  deleteNGO: (state, { id }) => {
    let idx = state.NGOs.map(p => p.id).indexOf(id)
    state.NGOs.splice(idx, 1)
  },
  addNGO: (state, { NGO }) => {
    state.NGOs.push(NGO)
  }
}

const actions = {
  loadNGOs: async function (context) {
    axios.get('http://localhost:5000/ngos').then((response) => {
      context.commit('setNGOs', { NGOs: response.data })
      return true
    }, () => {
      return false
    })
  },
  addNGO: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/ngo', item).then((response) => {
      commit('addNGO', { NGO: item })
    }, () => {
      return false
    })
  },
  deleteNGO: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/ngo/' + id).then((response) => {
      commit('deleteNGO', { id: id })
    }, () => {
      return false
    })
  },
  updateNGO: function ({ commit, state }, { item }) {
    axios.put('http://localhost:5000/ngo/' + item.Id, item).then((response) => {
      commit('updateNGO', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  NGOs: (state) => {
    return state.NGOs
  },
  getNGOById: (state) => (id) => {
    return state.NGOs.find(NGOs => NGOs.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
