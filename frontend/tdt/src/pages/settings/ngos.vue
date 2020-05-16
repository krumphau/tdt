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
    showAdd: false,
    showEdit: false
  }),
  mounted () {
    if (!this.$store.getters['users/user']) {
      this.$router.push('/notuser')
    } else {
      if (!this.$store.getters['users/user'].Email) {
        this.$router.push('/notuser')
      }
    }
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
    }
  },
  components: {
    'addNGO': require('components/Modals/addNGO.vue').default,
    'editNGO': require('components/Modals/editNGO.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
