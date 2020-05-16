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
                    <td class="text-left">{{ project.ProjectIdentifier }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Name</td>
                    <td class="text-left">{{ project.ProjectName }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Description</td>
                    <td class="text-left">{{ project.ProjectDescription }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Application Date</td>
                    <td class="text-left">{{ project.ApplicationDate }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Approved</td>
                    <td class="text-left">{{ project.DateGrantApproved }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Paid</td>
                    <td class="text-left">{{ project.DateGrantPaid }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Target Completion Date</td>
                    <td class="text-left">{{ project.TargetCompletionDate }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Requested</td>
                    <td class="text-left">{{ toCurrency(project.AmountGrantRequested) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Recommended</td>
                    <td class="text-left">{{ toCurrency(project.AmountGrantRecommended) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Approved</td>
                    <td class="text-left">{{ toCurrency(project.AmountGrantApproved) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Paid</td>
                    <td class="text-left">{{ toCurrency(project.AmountGrantPaid) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Total Project Cost</td>
                    <td class="text-left">{{ toCurrency(project.TotalProjectCost) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code</td>
                    <td class="text-left">{{ project.StatusDescription }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code Changed</td>
                    <td class="text-left">{{ project.StatusCodeDate }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Region</td>
                    <td class="text-left">{{ getRegion(project.Region_Id) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">District</td>
                    <td class="text-left">{{ getDistrict(project.District_Id) }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer</td>
                    <td class="text-left">{{ getProjOfficer(project.ProjOfficer_Id) }}</td>
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
},
mounted () {
  if (!this.$store.getters['users/user']) {
    this.$router.push('/notuser')
  } else {
    if (!this.$store.getters['users/user'].Email) {
      this.$router.push('/notuser')
    }
  }
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
    return this.$store.getters['regions/getRegionById'](regionId).Name
  },
  getDistrict (districtId) {
    return this.$store.getters['districts/getDistrictById'](districtId).Name
  },
  getProjOfficer (officerId) {
    return this.$store.getters['projectOfficers/getProjectOfficerById'](officerId).FullName
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
    return this.project.ProjectName
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
  }
}
}
</script>
