<template>
  <q-page padding>
    <template>
  <div class="q-pa-md">
    <q-table
      title="Other Bodies"
      :data="tableData"
      :columns="columns"
      row-key="Name"
      :separator="separator"
    >
      <template v-slot:body-cell-edit="cellProperties">
        <q-td :props="cellProperties">
            <a :href="'/editob/' + cellProperties.value">Edit</a>
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
    tableData: [
      {
        Name: 'Friends of Tanzania (FOT) U.S. A.',
        Id: 1
      },
      {
        Name: 'Tanzania Bureau of Standards (TBS)',
        Id: 2
      }
    ]
  }),
  methods: {
    deleteRow: function (rowId) {
      if (confirm('Are you sure you want to delete Other Body with ID ' + rowId + '?')) {
        console.log('Delete confirmed')
      } else {
        console.log('Delete cancelled')
      }
    }
  }
}

</script>
