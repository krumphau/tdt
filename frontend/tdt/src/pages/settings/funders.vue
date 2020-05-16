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
      :filter="filter"
      hide-header
    >
      <template v-slot:top-right>
        <q-input borderless dense debounce="300" v-model="filter" placeholder="Search">
          <template v-slot:append>
            <q-icon name="search" />
          </template>
        </q-input>
      </template>

      <template v-slot:item="props">
        <div          class="q-pa-xs col-xs-12 col-sm-6 col-md-4 col-lg-3 grid-style-transition"
          :style="props.selected ? 'transform: scale(0.95);' : ''"
        >
          <q-card :class="props.selected ? 'bg-grey-2' : ''">
            <q-card-section>
              {{ props.row.Name }}
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
              <q-btn class="glossy" rounded color="indigo-12" label="Edit" align="left" @click="showEditDialog(props.row.Id)"/>
              <q-btn class="glossy" rounded color="indigo-12" label="Delete" align="right" @click="deleteRow(props.row.Id)"/>
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
    selectedFunder: {},
    columns: [
      {
        name: 'Id',
        label: 'Id',
        field: 'Id'
      },
      {
        name: 'name',
        label: 'Name',
        field: 'Name'
      },
      {
        name: 'address1',
        label: 'Address 1',
        field: 'Address1'
      },
      {
        name: 'address2',
        label: 'Address 2',
        field: 'Address2'
      },
      {
        name: 'address3',
        label: 'Address 3',
        field: 'Address3'
      },
      {
        name: 'town',
        label: 'Town',
        field: 'Town'
      },
      {
        name: 'county',
        label: 'County',
        field: 'County'
      },
      {
        name: 'tel',
        label: 'Telephone',
        field: 'Tel'
      },
      {
        name: 'mainContact',
        label: 'Main Contact',
        field: 'MainContact'
      },
      {
        name: 'amount',
        label: 'Amount',
        field: 'Amount'
      }
    ],
    showAdd: false,
    showEdit: false
  }),
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to delete funder with ID ' + rowId + '?')) {
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
    }
  },
  mounted () {
    if (!this.$store.getters['users/user']) {
      this.$router.push('/notuser')
    } else {
      if (!this.$store.getters['users/user'].Email) {
        this.$router.push('/notuser')
      }
    }
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
