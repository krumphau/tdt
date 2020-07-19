<template>
  <q-page padding>
    <leftDrawer />
    <div>
        <h5>{{ getProjectName() }} - Project Funders</h5>
    </div>
    <template>
  <div class="q-pa-md">
    <q-table
      :data="projectFunders"
      :columns="columns"
      :visible-columns="visibleColumns"
      row-key="id"
    >
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
      <addFunder @close="closeDialogs()" @postFinished="refreshGrid()"/>
    </q-dialog>

</template>

  </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data: () => ({
    visibleColumns: ['name', 'amount', 'delete'],
    props: ['id', 'name'],
    columns: [
      {
        name: 'id',
        label: 'Id',
        field: 'id',
        align: 'left',
        visible: 'false'
      },
      {
        name: 'name',
        label: 'Name',
        field: 'name',
        align: 'left'
      },
      {
        name: 'amount',
        label: 'Amount Funded',
        field: 'amountFunded',
        align: 'left',
        format: (val, row) => `£${val}`
      },
      {
        name: 'delete',
        label: 'Delete',
        field: 'id',
        align: 'right'
      }
    ],
    showAdd: false,
    showEdit: false,
    changeFlag: 0
  }),
  created () {
    if (!this.$store.getters['projects/getCurrentProject'].projectName) {
      this.$store.dispatch('projects/loadProjectDetails', this.$q.localStorage.getItem('selectedProjectId'))
    }
  },
  mounted () {
    this.load()
    this.$store.dispatch('projectFunders/loadProjectFunders', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters('projectFunders', ['projectFunders'])
  },
  methods: {
    deleteRow (rowId) {
      if (confirm('Are you sure you want to remove this funder from the project?')) {
        this.$store.dispatch('projectFunders/deleteProjectFunder', rowId)
      } else {
        alert('Delete cancelled')
      }
    },
    closeDialogs: function () {
      this.showAdd = false
      this.showEdit = false
    },
    getProjectName () {
      return this.$store.getters['projects/getCurrentProject'].projectIdentifier + ' - ' + this.$store.getters['projects/getCurrentProject'].projectName
    },
    toCurrency (value) {
      if (isNaN(value)) {
        return ''
      }

      var formatter = new Intl.NumberFormat('en-GB', {
        style: 'currency',
        currency: 'GBP',
        minimumFractionDigits: 0
      })
      return formatter.format(value)
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
    'addFunder': require('components/Modals/ProjectPages/addProjectFunder.vue').default,
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}

</script>
