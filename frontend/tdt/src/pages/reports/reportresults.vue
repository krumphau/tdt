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

/* const fields = ['ProjectIdentifier', 'ProjectName', 'RegionName']
 const opts = { fields } */

export default {
  data: () => ({
    visibleColumns: ['identifier', 'name', 'region', 'keywords', 'projectofficer', 'statuscode'],
    props: ['id', 'name', 'view'],
    selectedCategory: {},
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'Id',
        align: 'left'
      },
      {
        name: 'identifier',
        label: 'Project Identifier',
        field: 'ProjectIdentifier',
        align: 'left'
      },
      {
        name: 'name',
        label: 'Project Name',
        field: 'ProjectName',
        align: 'left'
      },
      {
        name: 'region',
        label: 'Region',
        field: 'RegionName',
        align: 'left'
      },
      {
        name: 'keywords',
        label: 'Keywords',
        field: 'Keywords',
        align: 'left'
      },
      {
        name: 'projectofficer',
        label: 'Project Officer',
        field: 'ProjectOfficerName',
        align: 'left'
      },
      {
        name: 'statuscode',
        label: 'Status',
        field: 'StatusCode',
        align: 'left'
      }
    ],
    json_data: []
  }),
  mounted () {
    this.$store.dispatch('projects/searchProjects', this.$q.localStorage.getItem('searchParams'))
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
      const csv = parse(this.searchResults)
      console.log(csv)
      var hiddenElement = document.createElement('a')
      hiddenElement.href = 'data:text/csv;charset=utf-8,' + encodeURI(csv)
      hiddenElement.target = '_blank'
      hiddenElement.download = 'report.csv'
      hiddenElement.click()
    }
  },
  components: {
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
