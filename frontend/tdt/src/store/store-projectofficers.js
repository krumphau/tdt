import axios from 'axios'

const state = {
  projectOfficers: []
}

const mutations = {
  setProjectOfficers: (state, { projectOfficers }) => {
    state.projectOfficers = projectOfficers
  },
  updateProjectOfficer: (state, { item }) => {
    let idx = state.projectOfficers.map(p => p.id).indexOf(item.id)
    state.projectOfficers.splice(idx, 1, item)
  },
  deleteProjectOfficer: (state, { id }) => {
    let idx = state.projectOfficers.map(p => p.id).indexOf(id)
    state.projectOfficers.splice(idx, 1)
  },
  addProjectOfficer: (state, { projectOfficer }) => {
    state.projectOfficers.push(projectOfficer)
  }
}

const actions = {
  loadProjectOfficers: async function (context) {
    axios.get('http://localhost:5000/projectofficers').then((response) => {
      context.commit('setProjectOfficers', { projectOfficers: response.data })
      return true
    }, () => {
      return false
    })
  },
  addProjectOfficer: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/projectofficer', item).then((response) => {
      commit('addProjectOfficer', { projectOfficer: item })
    }, () => {
      return false
    })
  },
  deleteProjectOfficer: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/projectofficer/' + id).then((response) => {
      commit('deleteProjectOfficer', { id: id })
    }, () => {
      return false
    })
  },
  updateProjectOfficer: function ({ commit, state }, { item }) {
    axios.put('http://localhost:5000/projectofficer/' + item.Id, item).then((response) => {
      commit('updateProjectOfficer', { item: item })
    }, () => {
      return false
    })
  }
}

const getters = {
  projectOfficers: (state) => {
    return state.projectOfficers
  },
  getProjectOfficerById: (state) => (id) => {
    return state.projectOfficers.find(projectOfficers => projectOfficers.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
