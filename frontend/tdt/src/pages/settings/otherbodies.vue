<template>
   <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      title="Other Bodies"
      :data="otherBodies"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="Id"
      :pagination.sync="pagination"
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
      <addOtherBody @close="closeDialogs()" />
    </q-dialog>

    <q-dialog v-model="showEdit" persistent>
        <editOtherBody @close="closeDialogs()"
        :otherBody="selectedOtherBody">
        </editOtherBody>
      </q-dialog>

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    pagination: {
      rowsPerPage: 10 // current rows per page being displayed
    },
    visibleColumns: ['name', 'edit', 'delete'],
    props: ['id', 'name'],
    selectedOtherBody: {},
    columns: [
      {
        name: 'name',
        label: 'Name',
        field: 'name',
        align: 'left'
      },
      {
        name: 'edit',
        label: 'Edit',
        field: 'id',
        align: 'right'
      },
      {
        name: 'delete',
        label: 'Delete',
        field: 'id',
        align: 'right'
      }
    ],
    showAdd: false,
    showEdit: false
  }),
  mounted () {
    this.load()
    this.$store.dispatch('otherBodies/loadOtherBodies')
  },
  computed: {
    ...mapGetters('otherBodies', ['otherBodies'])
  },
  methods: {
    deleteRow (rowId) {
      this.selectedOtherBody = this.$store.getters['otherBodies/getOtherBodyById'](rowId)
      if (confirm('Are you sure you want to delete Other Body ' + this.selectedOtherBody.name + '?')) {
        this.$store.dispatch('otherBodies/deleteOtherBody', rowId)
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
      this.selectedOtherBody = this.$store.getters['otherBodies/getOtherBodyById'](rowValue)
      this.showEdit = true
    },
    // Returns a Promise that resolves after "ms" Milliseconds
    timer (ms) {
      return new Promise(resolve => setTimeout(resolve, ms))
    },
    async load () { // We need to wrap the loop into an async function for this to work
      for (var i = 0; i < 4; i++) {
        await this.timer(5000) // then the created Promise can be awaited
        if (!this.$store.getters['users/loading']) {
          break
        }
      }
      if (!this.$store.getters['users/user']) {
        this.$router.push('/notuser')
      } else {
        if (!this.$store.getters['users/user'].email) {
          this.$router.push('/notuser')
        }
      }
    }
  },
  components: {
    'addOtherBody': require('components/Modals/addOtherBody.vue').default,
    'editOtherBody': require('components/Modals/editOtherBody.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
