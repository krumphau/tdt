import axios from 'axios'

const state = {
  projectVisits: []
}

const mutations = {
  setProjectVisits: (state, { projectVisits }) => {
    state.projectVisits = projectVisits
  },
  deleteProjectVisit: (state, { id }) => {
    let idx = state.projectVisits.map(p => p.id).indexOf(id)
    state.projectVisits.splice(idx, 1)
  },
  addProjectVisit: (state, { projectVisit }) => {
    state.projectVisits.push(projectVisit)
  }
}

const actions = {
  addProjectVisit: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/projectvisit', item).then((response) => {
      commit('addProjectVisit', { projectVisit: item })
    }, (err) => {
      console.log(err)
    })
  },
  deleteProjectVisit: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/projectvisit/' + id).then((response) => {
      commit('deleteProjectVisit', { id: id })
    }, (err) => {
      console.log(err)
    })
  },
  loadProjectVisits: function ({ commit, state }, id) {
    axios.get('http://localhost:5000/projectvisit/' + id).then((response) => {
      commit('setProjectVisits', { projectVisits: response.data })
    }, (err) => {
      console.log(err)
    })
  }
}

const getters = {
  projectVisits: (state) => {
    return state.projectVisits
  },
  getProjectVisitById: (state) => (id) => {
    return state.projectVisits.find(projectVisits => projectVisits.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
