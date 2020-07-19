<template>
  <q-page padding>
    <leftDrawer />
    <template>
  <div class="q-pa-md">
    <q-table
      grid
      title="Project Officers"
      :data="projectOfficers"
      :columns="columns"
      row-key="Id"
      hide-header
      :pagination.sync="pagination"
    >

      <template v-slot:item="props">
        <div
          class="q-pa-xs col-xs-12 col-sm-6 col-md-4 col-lg-3 grid-style-transition"
          :style="props.selected ? 'transform: scale(0.95);' : ''"
        >
          <q-card :class="props.selected ? 'bg-grey-2' : ''">
            <q-card-section>
              {{ props.row.firstName + ' ' + props.row.lastName }}
            </q-card-section>
            <q-separator />
            <q-list dense>
              <q-item v-for="col in props.cols.filter(col => col.name !== 'Id' && col.name !== 'firstName' && col.name !== 'lastName')" :key="col.name">
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
      <addOfficer @close="closeDialogs()" @postFinished="refreshGrid()"/>
    </q-dialog>

    <q-dialog v-model="showEdit" persistent>
        <editOfficer
        :officer="selectedOfficer"
         @close="closeDialogs()">
        </editOfficer>
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
    selectedOfficer: {},
    columns: [
      {
        name: 'Id',
        label: 'Id',
        field: 'id'
      },
      {
        name: 'firstName',
        label: 'First Name',
        field: 'firstName'
      },
      {
        name: 'lastName',
        label: 'Last Name',
        field: 'lastName'
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
        name: 'mobile',
        label: 'Mobile',
        field: 'mobile'
      },
      {
        name: 'email',
        label: 'Email',
        field: 'email'
      }
    ],
    showAdd: false,
    showEdit: false
  }),
  methods: {
    deleteRow (rowId) {
      this.selectedOfficer = this.$store.getters['projectOfficers/getProjectOfficerById'](rowId)
      if (this.selectedOfficer.isUsed) {
        alert('This project officer cannot be deleted because he/she is currently linked to a Project.')
      } else {
        if (confirm('Are you sure you want to delete project officer ' + this.selectedOfficer.firstName + ' ' + this.selectedOfficer.lastName + '?')) {
          this.$store.dispatch('projectOfficers/deleteProjectOfficer', rowId)
        } else {
          alert('Delete cancelled')
        }
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    showEditDialog: function (rowValue) {
      this.selectedOfficer = this.$store.getters['projectOfficers/getProjectOfficerById'](rowValue)
      if (this.selectedOfficer.isUsed) {
        alert('Warning - This project officer is currently linked to a Project.')
      }
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
    this.$store.dispatch('projectOfficers/loadProjectOfficers')
  },
  computed: {
    ...mapGetters('projectOfficers', ['projectOfficers'])
  },
  components: {
    'addOfficer': require('components/Modals/addProjectOfficer.vue').default,
    'editOfficer': require('components/Modals/editProjectOfficer.vue').default,
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}
</script>
