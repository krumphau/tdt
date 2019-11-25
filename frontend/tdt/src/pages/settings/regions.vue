<template>
  <q-page padding>
    <template>
  <div class="q-pa-md">
    <q-table
      title="Regions"
      :data="tableData"
      :columns="columns"
      row-key="Name"
      :separator="separator"
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
        Name: 'Edinburgh',
        Id: 1
      },
      {
        Name: 'Glasgow',
        Id: 2
      },
      {
        Name: 'London',
        Id: 3
      }
    ]
  }),
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
