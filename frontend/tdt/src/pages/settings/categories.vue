<template>
  <q-page padding>
    <template>
  <div class="q-pa-md">
    <q-table
      title="Categories"
      :data="tableData"
      :columns="columns"
      row-key="Name"
      :separator="separator"
    >
      <template v-slot:body-cell-edit="cellProperties">
        <q-td :props="cellProperties">
            <a :href="'/editcategory/' + cellProperties.value">Edit</a>
        </q-td>
    </template>
     <template v-slot:body-cell-delete="cellProperties">
        <q-td :props="cellProperties">
            <a href="#" @click="deleteRow(cellProperties.value)">Delete</a>
        </q-td>
    </template>
    <template v-slot:body-cell-highLevel="cellProperties">
        <q-td :props="cellProperties">
            <q-checkbox true-value=1 false-value=0 :value="cellProperties.value" />
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
        name: 'highLevel',
        label: 'High Level',
        field: 'HighLevelCategory',
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
        Name: 'Toilets',
        Id: 1,
        HighLevelCategory: 1
      },
      {
        Name: 'Schools',
        Id: 2,
        HighLevelCategory: 0
      },
      {
        Name: 'Water',
        Id: 3,
        HighLevelCategory: 1
      }
    ]
  }),
  methods: {
    deleteRow: function (rowId) {
      if (confirm('Are you sure you want to delete category with ID ' + rowId + '?')) {
        console.log('Delete confirmed')
      } else {
        console.log('Delete cancelled')
      }
    }
  }
}

</script>
