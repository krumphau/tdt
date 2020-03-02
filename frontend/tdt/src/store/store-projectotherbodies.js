import axios from 'axios'

const state = {
  projectOtherBodies: []
}

const mutations = {
  setProjectOtherBodies: (state, { projectOtherBodies }) => {
    state.projectOtherBodies = projectOtherBodies
  },
  deleteProjectOtherBody: (state, { id }) => {
    let idx = state.projectOtherBodies.map(p => p.id).indexOf(id)
    state.projectOtherBodies.splice(idx, 1)
  },
  addProjectOtherBody: (state, { projectOtherBody }) => {
    state.projectOtherBodies.push(projectOtherBody)
  }
}

const actions = {
  addProjectOtherBody: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/projectotherbody', item).then((response) => {
      commit('addProjectOtherBody', { projectOtherBody: item })
    }, (err) => {
      console.log(err)
    })
  },
  deleteProjectOtherBody: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/projectotherbody/' + id).then((response) => {
      commit('deleteProjectOtherBody', { id: id })
    }, (err) => {
      console.log(err)
    })
  },
  loadProjectOtherBodies: function ({ commit, state }, id) {
    axios.get('http://localhost:5000/projectotherbody/' + id).then((response) => {
      commit('setProjectOtherBodies', { projectOtherBodies: response.data })
    }, (err) => {
      console.log(err)
    })
  }
}

const getters = {
  projectOtherBodies: (state) => {
    return state.projectOtherBodies
  },
  getProjectOtherBodyById: (state) => (id) => {
    return state.projectOtherBodies.find(projectOtherBodies => projectOtherBodies.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
