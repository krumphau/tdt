import axios from 'axios'

const state = {
  projects: [],
  currentProject: {},
  searchResults: []
}

const mutations = {
  setProjects: (state, { projects }) => {
    state.projects = projects
  },
  updateProject: (state, { item }) => {
    let idx = state.projects.map(p => p.id).indexOf(item.id)
    state.projects.splice(idx, 1, item)
  },
  deleteProject: (state, { id }) => {
    let idx = state.projects.map(p => p.id).indexOf(id)
    state.projects.splice(idx, 1)
  },
  addProject: (state, { project }) => {
    state.projects.push(project)
    state.currentProject = project
  },
  setSearchResults: (state, { results }) => {
    state.searchResults = results
  }
}

const actions = {
  loadProjects: async function (context) {
    axios.get('http://localhost:5000/projects').then((response) => {
      context.commit('setProjects', { projects: response.data })
      return true
    }, (err) => {
      console.log(err)
      return false
    })
  },
  addProject: function ({ commit }, { item }) {
    axios.post('http://localhost:5000/project', item).then((response) => {
      commit('addProject', { project: item })
    }, (err) => {
      console.log(err)
    })
  },
  deleteProject: function ({ commit, state }, id) {
    axios.delete('http://localhost:5000/project/' + id).then((response) => {
      commit('deleteProject', { id: id })
    }, (err) => {
      console.log(err)
    })
  },
  updateProject: function ({ commit, state }, { item }) {
    axios.put('http://localhost:5000/project/' + item.Id, item).then((response) => {
      commit('updateProject', { item: item })
    }, (err) => {
      console.log(err)
    })
  },
  searchProjects: function ({ commit }, item) {
    axios.post('http://localhost:5000/search', item).then((response) => {
      commit('setSearchResults', { results: response.data })
    }, (err) => {
      console.log(err)
    })
  }
}

const getters = {
  projects: (state) => {
    return state.projects
  },
  searchResults: (state) => {
    return state.searchResults
  },
  getProjectById: (state) => (id) => {
    return state.projects.find(projects => projects.Id === id)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}
