<template>
  <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      title="Status Codes"
      :data="statusCodes"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
      :pagination.sync="pagination"
    >
      <template v-slot:body-cell-edit="cellProperties">
        <q-td :props="cellProperties">
            <q-btn class="glossy" rounded color="indigo-12" label="Edit" @click="showEditDialog(cellProperties.value)"/>
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
      <addStatusCode @close="closeDialogs()" />
    </q-dialog>

    <q-dialog v-model="showEdit" persistent>
        <editStatusCode @close="closeDialogs()"
        :statusCode="selectedStatusCode">
        </editStatusCode>
      </q-dialog>

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    pagination: {
      rowsPerPage: 10 // current rows per page being displayed
    },
    visibleColumns: ['name', 'description', 'edit', 'delete'],
    props: ['id', 'name', 'description'],
    selectedStatusCode: {},
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'id',
        align: 'left'
      },
      {
        name: 'name',
        label: 'Status Code',
        field: 'statusCode',
        align: 'left'
      },
      {
        name: 'description',
        label: 'Description',
        field: 'description',
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
    showEdit: false
  }),
  mounted () {
    this.load()
    this.$store.dispatch('statusCodes/loadStatusCodes')
  },
  computed: {
    ...mapGetters('statusCodes', ['statusCodes'])
  },
  methods: {
    deleteRow (rowId) {
      this.selectedStatusCode = this.$store.getters['statusCodes/getStatusCodeById'](rowId)
      if (this.selectedStatusCode.isUsed) {
        alert('This status code cannot be edited because it is currently linked to a Project.')
      } else {
        if (confirm('Are you sure you want to delete status code ' + this.selectedStatusCode.statusCode + '?')) {
          this.$store.dispatch('statusCodes/deleteStatusCode', rowId)
        } else {
          alert('Delete cancelled')
        }
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    getHighLevelBool: function (rowValue) {
      return rowValue === 1
    },
    showEditDialog: function (rowValue) {
      this.selectedStatusCode = this.$store.getters['statusCodes/getStatusCodeById'](rowValue)
      if (this.selectedStatusCode.isUsed) {
        alert('Warning - This status code is currently linked to a Project.')
      }
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
    }
  },
  components: {
    'addStatusCode': require('components/Modals/addStatusCode.vue').default,
    'editStatusCode': require('components/Modals/editStatusCode.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
