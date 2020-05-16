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
import projects from './store-projects'
import projectCategories from './store-projectcategories'
import projectDocuments from './store-projectdocs'
import projectFunders from './store-projectfunders'
import projectNGOs from './store-projectngos'
import projectOtherBodies from './store-projectotherbodies'
import purchasedItems from './store-purchaseditems'
import relatedProjects from './store-relatedprojects'
import projectVisits from './store-projectvisits'
import settings from './store-settings'
import users from './store-users'

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
      projectOfficers,
      projects,
      projectCategories,
      projectDocuments,
      projectFunders,
      projectNGOs,
      projectOtherBodies,
      purchasedItems,
      relatedProjects,
      projectVisits,
      settings,
      users
    },

    // enable strict mode (adds overhead!)
    // for dev mode only
    strict: process.env.DEV
  })

  return Store
}
