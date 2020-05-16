import Vue from 'vue'
import msal from 'vue-msal'

Vue.use(msal, {
  auth: {
    clientId: '7f0b9718-3ed8-43dc-b2f4-17817aa8877e',
    requireAuthOnInitialize: true
  }
})
