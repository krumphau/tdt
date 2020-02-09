<template>
  <q-page padding>
    <template>
  <div class="q-pa-md">
    <q-table
      title="Regions"
      :data="tableData"
      :columns="columns"
      row-key="Name"
    >
      <template v-slot:body-cell-edit="cellProperties">
        <q-td :props="cellProperties">
            <a :href="'/editregion/' + cellProperties.value">Edit</a>
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
        name: 'name',
        label: 'Name',
        field: 'Name',
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
    axios.get('http://localhost:5000/regions').then(response => {
      this.tableData = response.data
    })
  },
  methods: {
    deleteRow: function (rowId) {
      if (confirm('Are you sure you want to delete region with ID ' + rowId + '?')) {
        console.log('Delete confirmed')
      } else {
        console.log('Delete cancelled')
      }
    }
  }
}

</script>
