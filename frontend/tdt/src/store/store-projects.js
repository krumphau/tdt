import axios from 'axios'
import storeSettings from './store-settings'

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
  },
  setCurrentProject: (state, { currentProject }) => {
    state.currentProject = currentProject
  }
}

const actions = {
  loadProjects: async function (context) {
    axios.get(storeSettings.state.baseUrl + 'projects').then((response) => {
      context.commit('setProjects', { projects: response.data })
      return true
    }, () => {
      return false
    })
  },
  addProject: function ({ commit }, { item }) {
    axios.post(storeSettings.state.baseUrl + 'project', item).then((response) => {
      commit('addProject', { project: item })
    }, () => {
      return false
    })
  },
  deleteProject: function ({ commit, state }, id) {
    axios.delete(storeSettings.state.baseUrl + 'project/' + id).then((response) => {
      commit('deleteProject', { id: id })
    }, () => {
      return false
    })
  },
  updateProject: function ({ commit, state }, { item }) {
    axios.put(storeSettings.state.baseUrl + 'project/' + item.Id, item).then((response) => {
      commit('updateProject', { item: item })
    }, () => {
      return false
    })
  },
  searchProjects: function ({ commit }, item) {
    axios.post(storeSettings.state.baseUrl + 'search', item).then((response) => {
      commit('setSearchResults', { results: response.data })
    }, () => {
      return false
    })
  },
  loadProjectDetails: function ({ commit, state }, id) {
    axios.get(storeSettings.state.baseUrl + 'project/' + id).then((response) => {
      commit('setCurrentProject', { currentProject: response.data })
    }, () => {
      return false
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
  },
  getCurrentProject: (state) => {
    return state.currentProject
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}