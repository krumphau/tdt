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
    visibleColumns: ['name', 'description', 'edit', 'delete'],
    props: ['id', 'name', 'description'],
    selectedStatusCode: {},
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'Id',
        align: 'left'
      },
      {
        name: 'name',
        label: 'Status Code',
        field: 'StatusCode',
        align: 'left'
      },
      {
        name: 'description',
        label: 'Description',
        field: 'Description',
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
    showEdit: false
  }),
  mounted () {
    if (!this.$store.getters['users/user']) {
      this.$router.push('/notuser')
    } else {
      if (!this.$store.getters['users/user'].Email) {
        this.$router.push('/notuser')
      }
    }
    this.$store.dispatch('statusCodes/loadStatusCodes')
  },
  computed: {
    ...mapGetters('statusCodes', ['statusCodes'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to delete status code with ID ' + rowId + '?')) {
        this.$store.dispatch('statusCodes/deleteStatusCode', rowId)
      } else {
        alert('Delete cancelled')
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
      this.showEdit = true
    }
  },
  components: {
    'addStatusCode': require('components/Modals/addStatusCode.vue').default,
    'editStatusCode': require('components/Modals/editStatusCode.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
