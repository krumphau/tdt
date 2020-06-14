<template>
  <q-page padding>
    <leftDrawer />
    <div>
        <h5>{{ getProjectName() }} - Project Documents</h5>
    </div>
      <div class="q-pa-md">
    <q-table
      :data="projectDocuments"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
    >
      <template v-slot:body-cell-path="cellProperties">
          <q-td :props="cellProperties">
              <q-btn class="glossy" rounded color="indigo-12" label="Download" @click="downloadFromS3(cellProperties.value)" />
          </q-td>
      </template>
      <template v-slot:body-cell-delete="cellProperties">
          <q-td :props="cellProperties">
              <q-btn class="glossy" rounded color="indigo-12" label="Delete" @click="deleteRow(cellProperties.value)"/>
          </q-td>
      </template>
    </q-table>
  </div>
  <div>
    <q-btn class="glossy" rounded color="indigo-12" label="Add New" @click="showAdd = true"/>
  </div>

<q-dialog v-model="showAdd" persistent>
      <addDocument @close="closeDialogs()" @postFinished="refreshGrid()"/>
    </q-dialog>
  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
import axios from 'axios'
export default {
  data: () => ({
    visibleColumns: ['name', 'path', 'delete'],
    props: ['id', 'name', 'path'],
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'id',
        align: 'left',
        visible: 'false'
      },
      {
        name: 'name',
        label: 'Name',
        field: 'docName',
        align: 'left'
      },
      {
        name: 'path',
        label: 'Download',
        field: 'filePath',
        align: 'left'
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
    changeFlag: 0
  }),
  created () {
    if (!this.$store.getters['projects/getCurrentProject'].projectName) {
      this.$store.dispatch('projects/loadProjectDetails', this.$q.localStorage.getItem('selectedProjectId'))
    }
  },
  mounted () {
    this.load()
    this.$store.dispatch('projectDocuments/loadProjectDocuments', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters('projectDocuments', ['projectDocuments'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to remove document with ID ' + rowId + ' from the project?')) {
        this.$store.dispatch('projectDocuments/deleteProjectDocument', rowId)
      } else {
        confirm('Delete cancelled')
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    getProjectName () {
      return this.$store.getters['projects/getCurrentProject'].projectName
    },
    forceFileDownload (response, fileName) {
      const url = window.URL.createObjectURL(new Blob([response.data]))
      const link = document.createElement('a')
      link.href = url
      link.setAttribute('download', fileName.substring(fileName.indexOf('/') + 1)) // or any other extension
      document.body.appendChild(link)
      link.click()
      link.remove()
    },
    downloadFromS3 (fileName) {
      axios.get('https://localhost:44349/download/' + fileName, { headers: { 'x-api-key': 'CBAEA0AB-D7E2-4639-A54E-EAD7E6A14869' } }).then((response) => {
        this.forceFileDownload(response, fileName)
      }, () => {
        alert('Problem downloading file!')
      })
    },
    // Returns a Promise that resolves after "ms" Milliseconds
    timer (ms) {
      return new Promise(resolve => setTimeout(resolve, ms))
    },
    async load () { // We need to wrap the loop into an async function for this to work
      for (var i = 0; i < 50; i++) {
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
    'addDocument': require('components/Modals/ProjectPages/addProjectDocument.vue').default,
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
