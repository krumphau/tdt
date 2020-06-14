<template>
   <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      title="NGOs"
      :data="NGOs"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
      :key="changeFlag"
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
      <addNGO @close="closeDialogs()" />
    </q-dialog>

    <q-dialog v-model="showEdit" persistent>
        <editNGO @close="closeDialogs()"
        :NGO="selectedNGO">
        </editNGO>
      </q-dialog>

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    visibleColumns: ['name', 'edit', 'delete'],
    props: ['id', 'name'],
    selectedNGO: {},
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
    this.$store.dispatch('ngos/loadNGOs')
  },
  computed: {
    ...mapGetters('ngos', ['NGOs'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to delete NGO with ID ' + rowId + '?')) {
        this.$store.dispatch('ngos/deleteNGO', rowId)
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
      this.selectedNGO = this.$store.getters['ngos/getNGOById'](rowValue)
      this.showEdit = true
    },
    // Returns a Promise that resolves after "ms" Milliseconds
    timer (ms) {
      return new Promise(resolve => setTimeout(resolve, ms))
    },
    async load () { // We need to wrap the loop into an async function for this to work
      for (var i = 0; i < 50; i++) {
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
    'addNGO': require('components/Modals/addNGO.vue').default,
    'editNGO': require('components/Modals/editNGO.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
