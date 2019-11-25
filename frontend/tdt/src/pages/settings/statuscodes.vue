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
    tableData: [
      {
        ID: 2,
        StatusCode: '01 Waiting list',
        Description: 'On waiting list'
      },
      {
        ID: 3,
        StatusCode: '02 Allocated',
        Description: 'With Project Officer for report preparation'
      },
      {
        ID: 4,
        StatusCode: '03 For committee',
        Description: 'Project officer report complete. For committee consideration'
      },
      {
        ID: 5,
        StatusCode: '04 Project approved',
        Description: 'Committee has approved project and will be granted funding when funds available'
      }
    ]
  }),
  methods: {
    deleteRow: function (rowId) {
      if (confirm('Are you sure you want to delete Status Code with ID ' + rowId + '?')) {
        console.log('Delete confirmed')
      } else {
        console.log('Delete cancelled')
      }
    }
  }
}

</script>
