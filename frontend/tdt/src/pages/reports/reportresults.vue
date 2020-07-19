<template>
  <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      title="Search Results"
      :data="searchResults"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
    >
    </q-table>
  </div>
  <div class="q-pa-md">
    <q-btn class="glossy" rounded color="indigo-12" label="Generate Report" @click="generateReport()" />
  </div>

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
import { parse } from 'json2csv'

const fields = ['projectIdentifier', 'regionName', 'districtName', 'projectOfficerName', 'applicationDate', 'projectName', 'amountGrantRequested', 'amountGrantRecommended', 'amountGrantApproved', 'statusDescription', 'projOfficerRecommendation', 'projectDescription', 'summary', 'statusCode', 'dateGrantApproved', 'amountGrantPaid', 'dateGrantPaid', 'targetCompletionDate', 'keywords', 'problems', 'statusCodeDate', 'strengthsWeaknesses', 'financeOtherFunders', 'localContribution', 'webSitePicture', 'webSitePictureDescription', 'latitude', 'longitude', 'documentsUrl', 'publicDocumentsUrl', 'impactOfProject', 'lastUpdated', 'totalProjectCost', 'lastUpdatedBy']
const opts = { fields }

export default {
  data: () => ({
    visibleColumns: ['identifier', 'name', 'region', 'keywords', 'projectofficer', 'statuscode'],
    props: ['id', 'name', 'view'],
    selectedCategory: {},
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'id',
        align: 'left'
      },
      {
        name: 'identifier',
        label: 'Project Identifier',
        field: 'projectIdentifier',
        align: 'left'
      },
      {
        name: 'name',
        label: 'Project Name',
        field: 'projectName',
        align: 'left'
      },
      {
        name: 'region',
        label: 'Region',
        field: 'regionName',
        align: 'left'
      },
      {
        name: 'keywords',
        label: 'Keywords',
        field: 'keywords',
        align: 'left'
      },
      {
        name: 'projectofficer',
        label: 'Project Officer',
        field: 'projectOfficerName',
        align: 'left'
      },
      {
        name: 'statuscode',
        label: 'Status',
        field: 'statusCode',
        align: 'left'
      }
    ],
    searchParams: {},
    json_data: []
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
    this.$store.dispatch('projects/searchProjects', this.$q.localStorage.getItem('searchParams'))
    this.searchParams = this.$q.localStorage.getItem('searchParams')
  },
  computed: {
    ...mapGetters({
      searchResults: 'projects/searchResults'
    })
  },
  methods: {
    viewProject (rowId) {
      this.$q.localStorage.set('selectedProjectId', rowId)
      this.$router.push('/project/details')
    },
    generateReport () {
      const header = this.buildHeader()
      const csv = parse(this.searchResults, opts)
      var hiddenElement = document.createElement('a')
      hiddenElement.href = 'data:text/csv;charset=utf-8,' + encodeURI(header + '\r\n' + csv)
      hiddenElement.target = '_blank'
      hiddenElement.download = 'report.csv'
      hiddenElement.click()
      hiddenElement.remove()
    },
    buildHeader () {
      var searchHeader = ''
      if (this.searchParams.Identifier !== '') {
        searchHeader += 'Project Identifier, ' + this.searchParams.Identifier + ','
      }
      if (this.searchParams.Name !== '') {
        searchHeader += 'Project Name,' + this.searchParams.Name + ','
      }
      if (this.searchParams.Keywords !== '') {
        searchHeader += 'Keywords,' + this.searchParams.Keywords + ','
      }
      if (this.searchParams.RegionID !== 0) {
        searchHeader += 'Region,' + this.getRegion(this.searchParams.RegionID) + ','
      }
      if (this.searchParams.NGOId !== 0) {
        searchHeader += 'NGO,' + this.getNGO(this.this.searchParams.NGOId) + ','
      }
      if (this.searchParams.OfficerId !== 0) {
        searchHeader += 'Project Officer,' + this.getProjOfficer(this.searchParams.OfficerId) + ','
      }
      if (this.searchParams.Status !== 0) {
        searchHeader += 'Status Code,' + this.getStatusCode(this.searchParams.Status) + ','
      }
      if (this.searchParams.FunderId !== 0) {
        searchHeader += 'Funder,' + this.getFunder(this.searchParams.FunderId) + ','
      }
      if (this.searchParams.DistrictId !== 0) {
        searchHeader += 'District,' + this.getDistrict(this.searchParams.DistrictId) + ','
      }
      if (this.searchParams.CategoryId !== 0) {
        searchHeader += 'Category,' + this.getCategory(this.searchParams.CategoryId) + ','
      }
      if (this.searchParams.OtherBodyId !== 0) {
        searchHeader += 'Other Body,' + this.getOtherBody(this.searchParams.OtherBodyId)
      }
      return searchHeader
    },
    getRegion (regionId) {
      return this.$store.getters['regions/getRegionById'](regionId).name
    },
    getDistrict (districtId) {
      return this.$store.getters['districts/getDistrictById'](districtId).name
    },
    getProjOfficer (officerId) {
      return this.$store.getters['projectOfficers/getProjectOfficerById'](officerId).fullName
    },
    getNGO (NGOId) {
      return this.$store.getters['ngos/getNGOById'](NGOId).name
    },
    getStatusCode (statusCodeId) {
      return this.$store.getters['statusCodes/getStatusCodeById'](statusCodeId).statusCode
    },
    getFunder (funderId) {
      return this.$store.getters['funders/getFunderById'](funderId).fullName
    },
    getCategory (catId) {
      return this.$store.getters['categories/getCategoryById'](catId).categoryName
    },
    getOtherBody (otherBodyId) {
      return this.$store.getters['otherbodies/getOtherBodyById'](otherBodyId).name
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
  },
  components: {
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
