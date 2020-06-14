<template>
  <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      title="Categories"
      :data="categories"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="Id"
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
      <template v-slot:body-cell-highLevel="cellProperties">
          <q-td :props="cellProperties">
              <q-checkbox :value="getHighLevelBool(cellProperties.value)"/>
          </q-td>
      </template>
    </q-table>
  </div>
  <div>
    <q-btn class="glossy" rounded color="indigo-12" label="Add New" @click="showAdd = true"/>
  </div>

  <q-dialog v-model="showAdd" persistent>
      <addCategory @close="closeDialogs()" />
    </q-dialog>

    <q-dialog v-model="showEdit" persistent>
        <editCategory @close="closeDialogs()"
        :category="selectedCategory">
        </editCategory>
      </q-dialog>

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data: () => ({
    visibleColumns: ['name', 'highLevel', 'edit', 'delete'],
    props: ['id', 'name', 'highLevel'],
    selectedCategory: {},
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'id',
        align: 'left'
      },
      {
        name: 'name',
        label: 'Name',
        field: 'categoryName',
        align: 'left'
      },
      {
        name: 'highLevel',
        label: 'High Level',
        field: 'highLevelCategory',
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
    this.$store.dispatch('categories/loadCategories')
  },
  computed: {
    ...mapGetters('categories', ['categories'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to delete category with ID ' + rowId + '?')) {
        this.$store.dispatch('categories/deleteCategory', rowId)
      } else {
        alert('Delete cancelled')
      }
    },
    closeDialogs: function () {
      this.$store.dispatch('categories/loadCategories')
      this.showAdd = false
      this.showEdit = false
    },
    getHighLevelBool: function (rowValue) {
      return rowValue === 1
    },
    showEditDialog: function (rowValue) {
      this.selectedCategory = this.$store.getters['categories/getCategoryById'](rowValue)
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
    'addCategory': require('components/Modals/addCategory.vue').default,
    'editCategory': require('components/Modals/editCategory.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}

</script>
