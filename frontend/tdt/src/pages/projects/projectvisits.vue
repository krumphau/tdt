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
import { date } from 'quasar'
export default {
  data: () => ({
    visibleColumns: ['visitStart', 'visitEnd', 'visitor', 'edit', 'delete'],
    props: ['id', 'name'],
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'id',
        align: 'left',
        visible: 'false'
      },
      {
        name: 'visitStart',
        label: 'Visit Start',
        field: 'visitStart',
        align: 'left',
        format: val => date.formatDate(val, 'DD/MM/YYYY')
      },
      {
        name: 'visitEnd',
        label: 'Visit End',
        field: 'visitEnd',
        align: 'left',
        format: val => date.formatDate(val, 'DD/MM/YYYY')
      },
      {
        name: 'visitor',
        label: 'Visitor',
        field: 'visitor',
        align: 'left'
      },
      {
        name: 'edit',
        label: 'Edit',
        field: 'id',
        align: 'right'
      },
      {
        name: 'delete',
        label: 'Delete',
        field: 'id',
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
    this.load()
    this.$store.dispatch('projectVisits/loadProjectVisits', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters('projectVisits', ['projectVisits'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to remove this visit from the project?')) {
        this.$store.dispatch('projectVisits/deleteProjectVisit', rowId)
      } else {
        alert('Delete cancelled')
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    getProjectName () {
      return this.$store.getters['projects/getCurrentProject'].projectIdentifier + ' - ' + this.$store.getters['projects/getCurrentProject'].projectName
    },
    showEditDialog: function (rowValue) {
      this.selectedVisit = this.$store.getters['projectVisits/getProjectVisitById'](rowValue)
      this.showEdit = true
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
    },
    formatTheDateDisplay (x) {
      return date.formatDate(x, 'DD/MM/YYYY')
    },
    formatTheDateSQL (x) {
      if (x != null && x.length === 10) {
        return x.split('/').reverse().join('-')
      } else {
        return null
      }
    }
  },
  components: {
    'addProjectVisit': require('components/Modals/ProjectPages/addProjectVisitDate.vue').default,
    'editProjectVisit': require('components/Modals/ProjectPages/editProjectVisitDate.vue').default,
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
