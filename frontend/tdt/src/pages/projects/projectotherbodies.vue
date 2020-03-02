<template>
  <q-page padding>
    <leftDrawer />
    <div>
        <h5>{{ getProjectName() }} - Other Bodies</h5>
    </div>
    <template>
  <div class="q-pa-md">
    <q-table
      :data="projectOtherBodies"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
    >
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
      <addCategory @close="closeDialogs()" @postFinished="refreshGrid()"/>
    </q-dialog>

</template>

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
    this.$store.dispatch('projectOtherBodies/loadProjectOtherBodies', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters('projectOtherBodies', ['projectOtherBodies'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to remove Other Body with ID from the project' + rowId + '?')) {
        confirm('params: { id:' + rowId + ' }')
        this.$store.dispatch('projectOtherBodies/deleteProjectOtherBody', rowId)
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
