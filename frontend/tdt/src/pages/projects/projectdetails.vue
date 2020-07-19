<template>
    <q-page padding>
        <leftDrawer />
        <div>
            <h5>{{ getProjectName() }} - Project Details</h5>
        </div>
        <div class="q-pa-md">
            <q-markup-table flat bordered>
                <tbody>
                    <tr>
                    <td class="text-left" width="20%">Project Identifier</td>
                    <td class="text-left">{{ project.projectIdentifier }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Name</td>
                    <td class="text-left">{{ project.projectName }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Description</td>
                    <td class="text-left">{{ project.projectDescription }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Application Date</td>
                    <td class="text-left">{{ formatTheDate(project.applicationDate) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Approved</td>
                    <td class="text-left">{{ formatTheDate(project.dateGrantApproved) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Paid</td>
                    <td class="text-left">{{ formatTheDate(project.dateGrantPaid) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Target Completion Date</td>
                    <td class="text-left">{{ formatTheDate(project.targetCompletionDate) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Requested</td>
                    <td class="text-left">{{ toCurrency(project.amountGrantRequested) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Recommended</td>
                    <td class="text-left">{{ toCurrency(project.amountGrantRecommended) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Approved</td>
                    <td class="text-left">{{ toCurrency(project.amountGrantApproved) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Paid</td>
                    <td class="text-left">{{ toCurrency(project.amountGrantPaid) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Total Project Cost</td>
                    <td class="text-left">{{ toCurrency(project.totalProjectCost) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code</td>
                    <td class="text-left">{{ getStatusCode(project.statusCode_Id) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code Changed</td>
                    <td class="text-left">{{ formatTheDate(project.statusCodeDate) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Region</td>
                    <td class="text-left">{{ getRegion(project.region_Id) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">District</td>
                    <td class="text-left">{{ getDistrict(project.district_Id) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer</td>
                    <td class="text-left">{{ getProjOfficer(project.projOfficer_Id) }}</td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Edit" @click="showEditDialog()" />
                            <q-btn class="glossy" rounded color="indigo-12" label="Delete" @click="deleteProject()" />
                        </td>
                    </tr>
                </tbody>
            </q-markup-table>
        </div>

        <q-dialog v-model="showEdit" persistent>
        <editProject @close="closeDialog()"
        :project="project">
        </editProject>
      </q-dialog>

    </q-page>

</template>

<script>
import { mapGetters } from 'vuex'
import { date } from 'quasar'
export default { data: () => ({
  showEdit: false
}),
created () {
  if (this.$store.getters['regions/regions'].length === 0) {
    this.$store.dispatch('regions/loadRegions')
  }
  if (this.$store.getters['districts/districts'].length === 0) {
    this.$store.dispatch('districts/loadDistricts')
  }
  if (this.$store.getters['projectOfficers/projectOfficers'].length === 0) {
    this.$store.dispatch('projectOfficers/loadProjectOfficers')
  }
  if (this.$store.getters['statusCodes/statusCodes'].length === 0) {
    this.$store.dispatch('statusCodes/loadStatusCodes')
  }
},
mounted () {
  this.load()
  this.$store.dispatch('projects/loadProjectDetails', this.$q.localStorage.getItem('selectedProjectId'))
},
computed: {
  ...mapGetters({
    project: 'projects/getCurrentProject'
  })
},
components: {
  'leftDrawer': require('components/projectLeftDrawer.vue').default
},
methods: {
  getRegion (regionId) {
    return (regionId == null ? '' : this.$store.getters['regions/getRegionById'](regionId).name)
  },
  getDistrict (districtId) {
    return (districtId == null ? '' : this.$store.getters['districts/getDistrictById'](districtId).name)
  },
  getProjOfficer (officerId) {
    return (officerId == null ? '' : this.$store.getters['projectOfficers/getProjectOfficerById'](officerId).fullName)
  },
  getStatusCode (statusCodeId) {
    return (statusCodeId == null ? '' : this.$store.getters['statusCodes/getStatusCodeById'](statusCodeId).statusCode)
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
  getProjectName () {
    return this.project.projectIdentifier + ' - ' + this.project.projectName
  },
  showEditDialog () {
    this.$router.push('/editproject')
  },
  deleteProject () {
    if (confirm('Are you sure you want to delete this project? !!!WARNING this cannot be undone!!!')) {
      this.$store.dispatch('projects/deleteProject', this.$q.localStorage.getItem('selectedProjectId'))
      this.$router.push('/')
    } else {
      alert('Delete cancelled')
    }
  },
  closeDialog: function () {
    this.showEdit = false
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
  },
  formatTheDate (x) {
    return date.formatDate(x, 'DD/MM/YYYY')
  }
}
}
</script>
