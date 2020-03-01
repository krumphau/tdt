import axios from 'axios'

const state = {
  regions: []
}

const mutations = {
  setRegions: (state, { regions }) => {
    state.regions = regions
  },
  updateRegion: (state, { item }) => {
    let idx = state.regions.map(p => p.id).indexOf(item.id)
    state.regions.splice(idx, 1, item)
  },
  deleteRegion: (state, { id }) => {
    let idx = state.regions.map(p => p.id).indexOf(id)
    state.regions.splice(idx, 1)
  },
  addRegion: (state, { region }) => {
    state.regions.push(region)
  }
}

const actions = {
  loadRegions: async function (context) {
    axios.get('http://localhost:5000/regions').then((response) => {
      context.commit('setRegions', { regions: response.data })
      return true
    }, (err) => {
      console.log(err)
      return false
    })
  },
  addRegion: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/region', item).then((response) => {
      commit('addRegion', { region: item })
    }, (err) => {
      console.log(err)
    })
  },
  deleteRegion: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/region/' + id).then((response) => {
      commit('deleteRegion', { id: id })
    }, (err) => {
      console.log(err)
    })
  },
  updateRegion: function ({ commit, state }, { item }) {
    axios.put('http://localhost:5000/region/' + item.Id, item).then((response) => {
      commit('updateRegion', { item: item })
    }, (err) => {
      console.log(err)
    })
  }
}

const getters = {
  regions: (state) => {
    return state.regions
  },
  getRegionById: (state) => (id) => {
    return state.regions.find(regions => regions.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
