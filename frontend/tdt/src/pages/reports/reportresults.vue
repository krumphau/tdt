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

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    visibleColumns: ['name', 'projectofficer'],
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
        name: 'name',
        label: 'Project Name',
        field: 'ProjectName',
        align: 'left'
      },
      {
        name: 'projectofficer',
        label: 'Project Officer',
        field: 'ProjectOfficerName',
        align: 'left'
      }
    ]
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
    }
  },
  components: {
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
