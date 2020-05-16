const state = {
  baseUrl: 'http://127.0.0.1:5000/',
  apiKey: 'CBAEA0AB-D7E2-4639-A54E-EAD7E6A14869',
  msalConfig: {
    auth: {
      clientId: '7f0b9718-3ed8-43dc-b2f4-17817aa8877e',
      authority: 'https://login.microsoftonline.com/common',
      redirectUri: 'http://localhost:3000/'
    },
    cache: {
      cacheLocation: 'sessionStorage', // This configures where your cache will be stored
      storeAuthStateInCookie: false // Set this to 'true' if you are having issues on IE11 or Edge
    }
  },
  // Add here scopes for id token to be used at MS Identity Platform endpoints.
  loginRequest: {
    scopes: ['openid', 'profile', 'User.Read']
  },
  // Add here scopes for access token to be used at MS Graph API endpoints.
  tokenRequest: {
    scopes: ['Mail.Read']
  }
}

const getters = {
  url: (state) => {
    return state.baseUrl
  },
  apiKey: (state) => {
    return state.apiKey
  }
}

export default {
  namespaced: true,
  state,
  getters
}
