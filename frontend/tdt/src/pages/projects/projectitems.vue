<template>
  <q-page padding>
    <leftDrawer />
    <div>
        <h5>{{ getProjectName() }} - Purchased Items</h5>
    </div>
    <template>
  <div class="q-pa-md">
    <q-table
      :data="purchasedItems"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
    >
      <template v-slot:body-cell-delete="cellProperties">
          <q-td :props="cellProperties">
              <q-btn class="glossy" rounded color="indigo-12" label="Delete" @click="deleteRow(cellProperties.value)"/>
          </q-td>
      </template>
      <template v-slot:body-cell-edit="cellProperties">
          <q-td :props="cellProperties">
              <q-btn class="glossy" rounded color="indigo-12" label="Edit" @click="showEditDialog(cellProperties.value)"/>
          </q-td>
      </template>
    </q-table>
  </div>
  <div>
    <q-btn class="glossy" rounded color="indigo-12" label="Add New" @click="showAdd = true"/>
  </div>

  <q-dialog v-model="showAdd" persistent>
      <addPurchasedItem @close="closeDialogs()" @postFinished="refreshGrid()"/>
    </q-dialog>

    <q-dialog v-model="showEdit" persistent>
      <editPurchasedItem @close="closeDialogs()" @postFinished="refreshGrid()" :purchasedItem="selectedItem" />
    </q-dialog>

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    visibleColumns: ['name', 'date', 'cost', 'edit', 'delete'],
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
        field: 'PurchasedItem',
        align: 'left'
      },
      {
        name: 'date',
        label: 'Date',
        field: 'DatePurchased',
        align: 'left'
      },
      {
        name: 'cost',
        label: 'Cost',
        field: 'ItemCost',
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
    showEdit: false,
    selectedItem: {},
    changeFlag: 0
  }),
  mounted () {
    this.$store.dispatch('purchasedItems/loadPurchasedItems', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters('purchasedItems', ['purchasedItems'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to remove this purchased item from the project?')) {
        confirm('params: { id:' + rowId + ' }')
        this.$store.dispatch('purchasedItems/deletePurchasedItem', rowId)
      } else {
        confirm('Delete cancelled')
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    getProjectName () {
      return this.$store.getters['projects/getProjectById'](this.$q.localStorage.getItem('selectedProjectId')).ProjectName
    },
    showEditDialog: function (rowValue) {
      alert(rowValue)
      this.selectedItem = this.$store.getters['purchasedItems/getPurchasedItemById'](rowValue)
      this.showEdit = true
    }
  },
  components: {
    'addPurchasedItem': require('components/Modals/ProjectPages/addProjectPurchasedItem.vue').default,
    'editPurchasedItem': require('components/Modals/ProjectPages/editProjectPurchasedItem.vue').default,
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
