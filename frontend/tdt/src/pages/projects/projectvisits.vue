<template>
  <q-page padding>
    <leftDrawer />
    <div>
        <h5>{{ getProjectName() }} - Visit Dates</h5>
    </div>
    <template>
  <div class="q-pa-md">
    <q-table
      :data="projectVisits"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
    >
      <template v-slot:body-cell-delete="cellProperties">
          <q-td :props="cellProperties">
              <q-btn class="glossy" rounded color="indigo-12" label="Delete" @click="deleteRow(cellProperties.value)"/>
          </q-td>
      </template>
      <template v-slot:body-cell-edit="cellProperties">
          <q-td :props="cellProperties">
              <q-btn class="glossy" rounded color="indigo-12" label="Edit" @click="showEditDialog(cellProperties.value)"/>
          </q-td>
      </template>
    </q-table>
  </div>
  <div>
    <q-btn class="glossy" rounded color="indigo-12" label="Add New" @click="showAdd = true"/>
  </div>

  <q-dialog v-model="showAdd" persistent>
      <addProjectVisit @close="closeDialogs()" @postFinished="refreshGrid()"/>
  </q-dialog>
  <q-dialog v-model="showEdit" persistent>
    <editProjectVisit @close="closeDialogs()" @postFinished="refreshGrid()" :projectVisit="selectedVisit" />
  </q-dialog>
</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    visibleColumns: ['visitStart', 'visitEnd', 'visitor', 'edit', 'delete'],
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
        name: 'visitStart',
        label: 'Visit Start',
        field: 'VisitDateStart',
        align: 'left'
      },
      {
        name: 'visitEnd',
        label: 'Visit End',
        field: 'VisitDateEnd',
        align: 'left'
      },
      {
        name: 'visitor',
        label: 'Visitor',
        field: 'Visitor',
        align: 'left'
      },
      {
        name: 'edit',
        label: 'Edit',
        field: 'Id',
        align: 'right'
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
    selectedVisit: [],
    changeFlag: 0
  }),
  created () {
    if (!this.$store.getters['projects/getCurrentProject'].ProjectName) {
      this.$store.dispatch('projects/loadProjectDetails', this.$q.localStorage.getItem('selectedProjectId'))
    }
  },
  mounted () {
    if (!this.$store.getters['users/user']) {
      this.$router.push('/notuser')
    } else {
      if (!this.$store.getters['users/user'].Email) {
        this.$router.push('/notuser')
      }
    }
    this.$store.dispatch('projectVisits/loadProjectVisits', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters('projectVisits', ['projectVisits'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to remove this visit from the project?')) {
        confirm('params: { id:' + rowId + ' }')
        this.$store.dispatch('projectVisits/deleteProjectVisit', rowId)
      } else {
        confirm('Delete cancelled')
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    getProjectName () {
      return this.$store.getters['projects/getCurrentProject'].ProjectName
    },
    showEditDialog: function (rowValue) {
      alert(rowValue)
      this.selectedVisit = this.$store.getters['projectVisits/getProjectVisitById'](rowValue)
      this.showEdit = true
    }
  },
  components: {
    'addProjectVisit': require('components/Modals/ProjectPages/addProjectVisitDate.vue').default,
    'editProjectVisit': require('components/Modals/ProjectPages/editProjectVisitDate.vue').default,
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
