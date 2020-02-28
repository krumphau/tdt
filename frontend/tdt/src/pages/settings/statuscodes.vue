<template>
  <q-page padding>
    <template>
  <div class="q-pa-md">
    <q-table
      title="Status Codes"
      :data="tableData"
      :columns="columns"
      row-key="Name"
      :separator="separator"
    >
      <template v-slot:body-cell-edit="cellProperties">
        <q-td :props="cellProperties">
            <a :href="'/editstatus/' + cellProperties.value">Edit</a>
        </q-td>
    </template>
     <template v-slot:body-cell-delete="cellProperties">
        <q-td :props="cellProperties">
            <a href="#" @click="deleteRow(cellProperties.value)">Delete</a>
        </q-td>
    </template>
    </q-table>
  </div>
</template>

  </q-page>
</template>

<script>
import axios from 'axios'
export default {
  data: () => ({
    columns: [
      {
        name: 'statusCode',
        label: 'Status Code',
        field: 'StatusCode',
        align: 'left'
      },
      {
        name: 'desc',
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
    tableData: []
  }),
  mounted () {
    axios.get('http://localhost:5000/statuscodes').then(response => {
      this.tableData = response.data
    })
  },
  methods: {
    deleteRow: function (rowId) {
      if (confirm('Are you sure you want to delete status code with ID ' + rowId + '?')) {
        confirm('params: { id:' + rowId + ' }')
        axios.delete('http://localhost:5000/statuscode/' + rowId).then(location.reload(true))
      } else {
        confirm('Delete cancelled')
      }
    }
  }
}

</script>
