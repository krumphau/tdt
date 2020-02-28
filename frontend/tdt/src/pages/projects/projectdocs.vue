<template>
    <q-page>
        <leftDrawer />
        <h3>ProjectDocs</h3>
    </q-page>
</template>

<script>
import axios from 'axios'
export default {
  data: () => ({
    visibleColumns: ['name', 'amount', 'edit', 'delete'],
    props: ['id', 'name', 'highLevel'],
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
        name: 'amount',
        label: 'Amount',
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
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
