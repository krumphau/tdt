<template>
  <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      title="NGOs"
      :data="tableData"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
      :key="changeFlag"
    >
      <template v-slot:body-cell-edit="cellProperties">
        <q-td :props="cellProperties">
            <q-btn class="glossy" rounded color="teal-9" label="Edit" @click="showEdit = true"/>
        </q-td>
      </template>
      <template v-slot:body-cell-delete="cellProperties">
          <q-td :props="cellProperties">
              <q-btn class="glossy" rounded color="teal-9" label="Delete" @click="deleteRow(cellProperties.value)"/>
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

    <q-dialog v-model="showEdit" persistent>
        <editCategory
        :name="name">
        </editCategory>
      </q-dialog>

</template>

  </q-page>
</template>

<script>
import axios from 'axios'
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
        field: 'CategoryName',
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
    tableData: [],
    showAdd: false,
    showEdit: false,
    changeFlag: 0
  }),
  mounted () {
    axios.get('http://localhost:5000/categories').then(response => {
      this.tableData = response.data
    })
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to delete category with ID ' + rowId + '?')) {
        confirm('params: { id:' + rowId + ' }')
        axios.delete('http://localhost:5000/category/' + rowId, { headers: {
          'Access-Control-Max-Age': 86400,
          'Content-Type': 'text/plain'
        } })
      } else {
        confirm('Delete cancelled')
      }
    },
    refreshGrid: function () {
      alert('Category saved successfully')
      axios.get('http://localhost:5000/categories').then(response => {
        this.tableData = response.data
        this.changeFlag += 1
      })
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    getHighLevelBool: function (rowValue) {
      return rowValue === 1
    }
  },
  components: {
    'addCategory': require('components/Modals/addCategory.vue').default,
    'editCategory': require('components/Modals/editCategory.vue').default,
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
