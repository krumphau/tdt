
const routes = [
  {
    path: '/',
    component: () => import('layouts/MyLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') },
      { path: 'settings/districts', component: () => import('pages/settings/districts.vue') },
      { path: 'settings/funders', component: () => import('pages/settings/funders.vue') },
      { path: 'settings/ngos', component: () => import('pages/settings/ngos.vue') },
      { path: 'settings/otherbodies', component: () => import('pages/settings/otherbodies.vue') },
      { path: 'settings/regions', component: () => import('pages/settings/regions.vue') },
      { path: 'settings/projectofficers', component: () => import('pages/settings/projectofficers.vue') },
      { path: 'settings/statuscodes', component: () => import('pages/settings/statuscodes.vue') },
      { path: 'settings/categories', component: () => import('pages/settings/categories.vue') },
      { path: 'project', component: () => import('pages/projects/addproject.vue') },
      { path: 'project/categories', component: () => import('pages/projects/projectcategories.vue') },
      { path: 'project/details', component: () => import('pages/projects/projectdetails.vue') },
      { path: 'project/documents', component: () => import('pages/projects/projectdocs.vue') },
      { path: 'project/funders', component: () => import('pages/projects/projectfunders.vue') },
      { path: 'project/purchaseditems', component: () => import('pages/projects/projectitems.vue') },
      { path: 'project/ngos', component: () => import('pages/projects/projectngos.vue') },
      { path: 'project/notes', component: () => import('pages/projects/projectnotes.vue') },
      { path: 'project/otherbodies', component: () => import('pages/projects/projectotherbodies.vue') },
      { path: 'project/relatedprojects', component: () => import('pages/projects/projectrelated.vue') },
      { path: 'project/visits', component: () => import('pages/projects/projectvisits.vue') },
      { path: 'project/website', component: () => import('pages/projects/projectwebsite.vue') },
      { path: 'project/search', component: () => import('pages/projects/projectsearchresults.vue') },
      { path: 'reports/search', component: () => import('pages/reports/reportsearch.vue') },
      { path: 'reports/results', component: () => import('pages/reports/reportresults.vue') }
    ]
  }
]

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue')
  })
}

export default routes
