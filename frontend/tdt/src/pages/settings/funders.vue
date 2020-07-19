<template>
  <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      grid
      title="Funders"
      :data="funders"
      :columns="columns"
      row-key="Id"
      hide-header
      :pagination.sync="pagination"
    >

      <template v-slot:item="props">
        <div          class="q-pa-xs col-xs-12 col-sm-6 col-md-4 col-lg-3 grid-style-transition"
          :style="props.selected ? 'transform: scale(0.95);' : ''"
        >
          <q-card :class="props.selected ? 'bg-grey-2' : ''">
            <q-card-section>
              {{ props.row.name }}
            </q-card-section>
            <q-separator />
            <q-list dense>
              <q-item v-for="col in props.cols.filter(col => col.name !== 'Id' && col.name !== 'name')" :key="col.Id">
                <q-item-section>
                  <q-item-label>{{ col.label }}</q-item-label>
                </q-item-section>
                <q-item-section side>
                  <q-item-label caption>{{ col.value }}</q-item-label>
                </q-item-section>
              </q-item>
            </q-list>
            <q-separator />
            <q-card-section>
              <q-btn class="glossy" rounded color="indigo-12" label="Edit" align="left" @click="showEditDialog(props.row.id)"/>
              <q-btn class="glossy" rounded color="indigo-12" label="Delete" align="right" @click="deleteRow(props.row.id)"/>
            </q-card-section>
          </q-card>
        </div>
      </template>
    </q-table>
  </div>
  <div>
    <q-btn class="glossy" rounded color="indigo-12" label="Add New" @click="showAdd = true"/>
  </div>

  <q-dialog v-model="showAdd" persistent>
    <addFunder @close="closeDialogs()" />
  </q-dialog>

  <q-dialog v-model="showEdit" persistent>
      <editFunder @close="closeDialogs()"
      :funder="selectedFunder">
      </editFunder>
  </q-dialog>

  </template>
  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    pagination: {
      rowsPerPage: 6 // current rows per page being displayed
    },
    selectedFunder: {},
    columns: [
      {
        name: 'Id',
        label: 'Id',
        field: 'id'
      },
      {
        name: 'name',
        label: 'Name',
        field: 'name'
      },
      {
        name: 'address1',
        label: 'Address 1',
        field: 'address1'
      },
      {
        name: 'address2',
        label: 'Address 2',
        field: 'address2'
      },
      {
        name: 'address3',
        label: 'Address 3',
        field: 'address3'
      },
      {
        name: 'town',
        label: 'Town',
        field: 'town'
      },
      {
        name: 'county',
        label: 'County',
        field: 'county'
      },
      {
        name: 'tel',
        label: 'Telephone',
        field: 'tel'
      },
      {
        name: 'mainContact',
        label: 'Main Contact',
        field: 'mainContact'
      },
      {
        name: 'amount',
        label: 'Amount',
        field: 'amount'
      }
    ],
    showAdd: false,
    showEdit: false
  }),
  methods: {
    deleteRow (rowId) {
      this.selectedFunder = this.$store.getters['funders/getFunderById'](rowId)
      if (confirm('Are you sure you want to delete funder ' + this.selectedFunder.name + '?')) {
        this.$store.dispatch('funders/deleteFunder', rowId)
      } else {
        alert('Delete cancelled')
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    showEditDialog: function (rowValue) {
      this.selectedFunder = this.$store.getters['funders/getFunderById'](rowValue)
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
  mounted () {
    this.load()
    this.$store.dispatch('funders/loadFunders')
  },
  computed: {
    ...mapGetters('funders', ['funders'])
  },
  components: {
    'addFunder': require('components/Modals/addFunder.vue').default,
    'editFunder': require('components/Modals/editFunder.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}
</script>
