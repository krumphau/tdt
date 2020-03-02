import axios from 'axios'

const state = {
  relatedProjects: []
}

const mutations = {
  setRelatedProjects: (state, { relatedProjects }) => {
    state.relatedProjects = relatedProjects
  },
  deleteRelatedProject: (state, { id }) => {
    let idx = state.relatedProjects.map(p => p.id).indexOf(id)
    state.relatedProjects.splice(idx, 1)
  },
  addRelatedProject: (state, { relatedProject }) => {
    state.relatedProjects.push(relatedProject)
  }
}

const actions = {
  addRelatedProject: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/relatedproject', item).then((response) => {
      commit('addRelatedProject', { relatedProject: item })
    }, (err) => {
      console.log(err)
    })
  },
  deleteRelatedProject: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/relatedproject/' + id).then((response) => {
      commit('deleteRelatedProject', { id: id })
    }, (err) => {
      console.log(err)
    })
  },
  loadRelatedProjects: function ({ commit, state }, id) {
    axios.get('http://localhost:5000/relatedproject/' + id).then((response) => {
      commit('setRelatedProjects', { relatedProjects: response.data })
    }, (err) => {
      console.log(err)
    })
  }
}

const getters = {
  relatedProjects: (state) => {
    return state.relatedProjects
  },
  getRelatedProjectById: (state) => (id) => {
    return state.relatedProjects.find(relatedProjects => relatedProjects.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
