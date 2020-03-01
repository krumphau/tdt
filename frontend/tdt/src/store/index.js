import Vue from 'vue'
import Vuex from 'vuex'

import categories from './store-categories'
import otherBodies from './store-otherbodies'
import districts from './store-districts'
import regions from './store-regions'
import statusCodes from './store-statuscodes'
import ngos from './store-ngos'
import funders from './store-funders'
import projectOfficers from './store-projectofficers'

Vue.use(Vuex)

/*
 * If not building with SSR mode, you can
 * directly export the Store instantiation
 */

export default function (/* { ssrContext } */) {
  const Store = new Vuex.Store({
    modules: {
      categories,
      otherBodies,
      districts,
      regions,
      statusCodes,
      ngos,
      funders,
      projectOfficers
    },

    // enable strict mode (adds overhead!)
    // for dev mode only
    strict: process.env.DEV
  })

  return Store
}
