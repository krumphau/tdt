<template>
   <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      title="Districts"
      :data="districts"
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
      <addDistrict @close="closeDialogs()" />
    </q-dialog>

    <q-dialog v-model="showEdit" persistent>
        <editDistrict @close="closeDialogs()"
        :district="selectedDistrict">
        </editDistrict>
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
    selectedDistrict: {},
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
    this.$store.dispatch('districts/loadDistricts')
  },
  computed: {
    ...mapGetters('districts', ['districts'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to delete district with ID ' + rowId + '?')) {
        this.$store.dispatch('districts/deleteDistrict', rowId)
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
      this.selectedDistrict = this.$store.getters['districts/getDistrictById'](rowValue)
      this.showEdit = true
    }
  },
  components: {
    'addDistrict': require('components/Modals/addDistrict.vue').default,
    'editDistrict': require('components/Modals/editDistrict.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
