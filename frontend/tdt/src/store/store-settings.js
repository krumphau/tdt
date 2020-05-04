const state = {
  baseUrl: 'http://tdtapitest-dev2.eu-west-2.elasticbeanstalk.com/'
}

const getters = {
  url: (state) => {
    return state.baseUrl
  }
}

export default {
  namespaced: true,
  state,
  getters
}
