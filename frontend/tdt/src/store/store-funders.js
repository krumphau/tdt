import axios from 'axios'

const state = {
  funders: []
}

const mutations = {
  setFunders: (state, { funders }) => {
    state.funders = funders
  },
  updateFunder: (state, { item }) => {
    let idx = state.funders.map(p => p.id).indexOf(item.id)
    state.funders.splice(idx, 1, item)
  },
  deleteFunder: (state, { id }) => {
    let idx = state.funders.map(p => p.id).indexOf(id)
    state.funders.splice(idx, 1)
  },
  addFunder: (state, { funder }) => {
    state.funders.push(funder)
  }
}

const actions = {
  loadFunders: async function (context) {
    axios.get('http://localhost:5000/funders').then((response) => {
      context.commit('setFunders', { funders: response.data })
      return true
    }, (err) => {
      console.log(err)
      return false
    })
  },
  addFunder: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/funder', item).then((response) => {
      commit('addFunder', { funder: item })
    }, (err) => {
      console.log(err)
    })
  },
  deleteFunder: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/funder/' + id).then((response) => {
      commit('deleteFunder', { id: id })
    }, (err) => {
      console.log(err)
    })
  },
  updateFunder: function ({ commit, state }, { item }) {
    axios.put('http://localhost:5000/funder/' + item.Id, item).then((response) => {
      commit('updateFunder', { item: item })
    }, (err) => {
      console.log(err)
    })
  }
}

const getters = {
  funders: (state) => {
    return state.funders
  },
  getFunderById: (state) => (id) => {
    return state.funders.find(funders => funders.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
