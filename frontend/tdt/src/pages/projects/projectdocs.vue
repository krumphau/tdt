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
              <q-btn type="a" class="glossy" rounded color="indigo-12" label="Download" :href="'http://localhost:5000/download/' + cellProperties.value" />
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
export default {
  data: () => ({
    visibleColumns: ['name', 'path', 'desc', 'category', 'delete'],
    props: ['id', 'name', 'path', 'desc', 'category'],
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
        field: 'DocName',
        align: 'left'
      },
      {
        name: 'path',
        label: 'Download',
        field: 'FilePath',
        align: 'left'
      },
      {
        name: 'desc',
        label: 'Description',
        field: 'Description',
        align: 'left'
      },
      {
        name: 'category',
        label: 'Category',
        field: 'DocCategory',
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
    this.$store.dispatch('projectDocuments/loadProjectDocuments', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters('projectDocuments', ['projectDocuments'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to remove document with ID from the project' + rowId + '?')) {
        confirm('params: { id:' + rowId + ' }')
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
      return this.$store.getters['projects/getCurrentProject'].ProjectName
    }
  },
  components: {
    'addDocument': require('components/Modals/ProjectPages/addProjectDocument.vue').default,
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
