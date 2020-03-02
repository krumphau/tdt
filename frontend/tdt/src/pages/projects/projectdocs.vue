<template>
  <q-page padding>
    <leftDrawer />
    <div>
        <h5>{{ getProjectName() }} - Project Documents</h5>
    </div>
    <div class="q-pa-md">
      Project documents to be implemented
    </div>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    visibleColumns: ['name', 'edit', 'delete'],
    props: ['id', 'name'],
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'Id',
        align: 'left',
        visible: 'false'
      },
      {
        name: 'name',
        label: 'Name',
        field: 'Name',
        align: 'left'
      },
      {
        name: 'delete',
        label: 'Delete',
        field: 'Id',
        align: 'right'
      }
    ],
    showAdd: false,
    showEdit: false,
    changeFlag: 0
  }),
  mounted () {
    this.$store.dispatch('projectFunders/loadProjectFunders', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters('projectFunders', ['projectFunders'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to remove funder with ID from the project' + rowId + '?')) {
        confirm('params: { id:' + rowId + ' }')
        this.$store.dispatch('projectFunders/deleteProjectFunder', rowId)
      } else {
        confirm('Delete cancelled')
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    getProjectName () {
      return this.$store.getters['projects/getProjectById'](this.$q.localStorage.getItem('selectedProjectId')).ProjectName
    }
  },
  components: {
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
