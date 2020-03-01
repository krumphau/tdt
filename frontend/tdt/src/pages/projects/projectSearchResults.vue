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
      <template v-slot:body-cell-view="cellProperties">
          <q-td :props="cellProperties">
              <q-btn class="glossy" rounded color="indigo-12" label="View" @click="viewProject(cellProperties.value)"/>
          </q-td>
      </template>
    </q-table>
  </div>
  <div>
    <q-btn class="glossy" rounded color="indigo-12" label="Blah" @click="blah()"/>
  </div>

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    visibleColumns: ['name', 'view'],
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
        label: 'Name',
        field: 'ProjectName',
        align: 'left'
      },
      {
        name: 'view',
        label: 'View',
        field: 'Id',
        align: 'right'
      }
    ]
  }),
  mounted () {
    alert(this.$q.localStorage.getItem('searchParams').RegionID)
    this.$store.dispatch('projects/searchProjects', this.$q.localStorage.getItem('searchParams'))
  },
  computed: {
    ...mapGetters({
      searchResults: 'projects/searchResults'
    })
  },
  methods: {
    viewProject (rowId) {
      alert(rowId)
    },
    blah () {
      alert(this.$q.localStorage.getItem('searchParams').RegionID)
    }
  },
  components: {
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
