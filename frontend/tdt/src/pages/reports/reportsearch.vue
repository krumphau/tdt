<template>
  <q-page padding>
    <leftDrawer />
    <div>
      <h5>Reports</h5>
      <div>Choose the criteria for your report:</div>
      <q-markup-table flat bordered>
        <tbody>
          <tr>
            <td>
              Project Identifier <q-input dense outlined v-model="searchIdentifier" />
            </td>
            <td>
              Name <q-input dense outlined v-model="searchName" />
            </td>
          </tr>
          <tr>
            <td>
              Keywords <q-input dense outlined v-model="searchKeywords" />
            </td>
            <td>
              Region <q-select dense v-model="searchRegion" label="Please select" map-options emit-value option-value="id" option-label="name" outlined :options="regions" />
            </td>
          </tr>
          <tr>
            <td>
              NGO <q-select dense v-model="searchNGO" label="Please select" map-options emit-value option-value="id" option-label="name" outlined :options="NGOs" />
            </td>
            <td>
              Project Officer <q-select dense v-model="searchOfficer" label="Please select" map-options emit-value option-value="id" option-label="fullName" outlined :options="projectOfficers" />
            </td>
          </tr>
          <tr>
            <td>
              Status <q-select dense v-model="searchStatus" label="Please select" map-options emit-value option-value="id" option-label="statusCode" outlined :options="statusCodes" />
            </td>
            <td>
              Funder <q-select dense v-model="searchFunder" label="Please select" map-options emit-value option-value="id" option-label="name" outlined :options="funders" />
            </td>
          </tr>
          <tr>
            <td>
              Category <q-select dense v-model="searchCategory" label="Please select" map-options emit-value option-value="id" option-label="categoryName" outlined :options="categories" />
            </td>
            <td>
            </td>
          </tr>
        </tbody>
      </q-markup-table>
    </div>
    <div class="q-pa-md">
          <q-btn class="glossy" rounded color="indigo-12" label="Search" @click="doSearch()"/>
    </div>
  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  name: 'PageIndex',
  data: () => ({
    selectProject: null,
    searchFunder: null,
    searchStatus: null,
    searchOfficer: null,
    searchNGO: null,
    searchRegion: null,
    searchKeywords: null,
    searchName: null,
    searchIdentifier: null,
    searchDistrict: null,
    searchCategory: null,
    searchOtherBody: null,
    searchParams: {
      Identifier: '',
      Name: '',
      Keywords: '',
      RegionID: 0,
      NGOId: 0,
      OfficerId: 0,
      Status: 0,
      FunderId: 0,
      DistrictId: 0,
      CategoryId: 0,
      OtherBodyId: 0
    }
  }),
  mounted () {
    this.load()
    this.$store.dispatch('projects/loadProjects')
    this.$store.dispatch('regions/loadRegions')
    this.$store.dispatch('ngos/loadNGOs')
    this.$store.dispatch('projectOfficers/loadProjectOfficers')
    this.$store.dispatch('statusCodes/loadStatusCodes')
    this.$store.dispatch('funders/loadFunders')
    this.$store.dispatch('categories/loadCategories')
    this.$store.dispatch('districts/loadDistricts')
    this.$store.dispatch('otherBodies/loadOtherBodies')
  },
  computed: {
    ...mapGetters({
      projects: 'projects/projects',
      regions: 'regions/regions',
      NGOs: 'ngos/NGOs',
      projectOfficers: 'projectOfficers/projectOfficers',
      statusCodes: 'statusCodes/statusCodes',
      funders: 'funders/funders',
      categories: 'categories/categories',
      districts: 'districts/districts',
      otherBodies: 'otherBodies/otherBodies'
    })
  },
  components: {
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  },
  methods: {
    doSearch () {
      this.searchParams.Identifier = (this.searchIdentifier != null ? this.searchIdentifier : '')
      this.searchParams.Name = (this.searchName != null ? this.searchName : '')
      this.searchParams.Keywords = (this.searchKeywords != null ? this.searchKeywords : '')
      this.searchParams.RegionID = (this.searchRegion != null ? this.searchRegion : 0)
      this.searchParams.NGOId = (this.searchNGO != null ? this.searchNGO : 0)
      this.searchParams.OfficerId = (this.searchOfficer != null ? this.searchOfficer : 0)
      this.searchParams.Status = (this.searchStatus != null ? this.searchStatus : 0)
      this.searchParams.FunderId = (this.searchFunder != null ? this.searchFunder : 0)
      this.searchParams.CategoryId = (this.searchCategory != null ? this.searchCategory : 0)
      this.searchParams.DistrictId = (this.searchDistrict != null ? this.searchDistrict : 0)
      this.searchParams.OtherBodyId = (this.searchOtherBody != null ? this.searchOtherBody : 0)
      this.$q.localStorage.set('searchParams', this.searchParams)
      this.$router.push('/reports/results')
    },
    // Returns a Promise that resolves after "ms" Milliseconds
    timer (ms) {
      return new Promise(resolve => setTimeout(resolve, ms))
    },
    async load () { // We need to wrap the loop into an async function for this to work
      for (var i = 0; i < 4; i++) {
        await this.timer(5000) // then the created Promise can be awaited
        if (!this.$store.getters['users/loading']) {
          break
        }
      }
      if (!this.$store.getters['users/user']) {
        this.$router.push('/notuser')
      } else {
        if (!this.$store.getters['users/user'].email) {
          this.$router.push('/notuser')
        }
      }
    }
  }
}
</script>
