<template>
    <q-page padding>
        <leftDrawer />
        <div>
            <h5>Add New Project</h5>
        </div>
        <!-- <q-item class="row" outlined>
            <q-item-label padding>
                Project Identifier
            </q-item-label>
            <q-item-section padding>
                <q-input outlined dense></q-input>
            </q-item-section>
        </q-item> -->
        <div class="q-pa-md">
            <form @submit="submitForm()">
            <q-markup-table flat bordered>
                <tbody>
                    <tr>
                    <td class="text-left" width="20%">Project Identifier</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToAdd.projectIdentifier" :rules="[val => !!val || 'Field is required']" ref='projId'></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Name</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToAdd.projectName" :rules="[val => !!val || 'Field is required']" ref='projName'></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Description</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToAdd.ProjectDescription"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Application Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.ApplicationDate" >
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qAppDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.ApplicationDate" @input="() => $refs.qAppDateProxy.hide()" mask="DD/MM/YYYY" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Approved</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.DateGrantApproved" >
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qApproveDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.DateGrantApproved" @input="() => $refs.qApproveDateProxy.hide()" mask="DD/MM/YYYY" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Paid</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.DateGrantPaid" >
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qPaidDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.DateGrantPaid" @input="() => $refs.qPaidDateProxy.hide()" mask="DD/MM/YYYY" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Target Completion Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.TargetCompletionDate" >
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qTargetDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.TargetCompletionDate" @input="() => $refs.qTargetDateProxy.hide()" mask="DD/MM/YYYY" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Requested</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToAdd.AmountGrantRequested"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Approved</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToAdd.AmountGrantApproved"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Recommended</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToAdd.AmountGrantRecommended"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Paid</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToAdd.AmountGrantPaid"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Total Project Cost</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToAdd.TotalProjectCost"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToAdd.StatusCode_Id" label="Please select" map-options emit-value option-value="id" option-label="statusCode" outlined :options="statusCodes" :rules="[requiredDropdown]" ref='statusCodeDD'/>
                            </q-item-section>
                        </q-item>
                        </td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code Changed</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.StatusCodeDate" >
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qStatusDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.StatusCodeDate" @input="() => $refs.qStatusDateProxy.hide()" mask="DD/MM/YYYY" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Region</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToAdd.Region_Id" label="Please select" map-options emit-value option-value="id" option-label="name" outlined :options="regions" :rules="[requiredDropdown]" ref='regionDD'/>
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">District</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToAdd.District_Id" label="Please select" map-options emit-value option-value="id" option-label="name" outlined :options="districts" />
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToAdd.ProjOfficer_Id" label="Please select" map-options emit-value option-value="id" option-label="fullName" outlined :options="projectOfficers" />
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Cancel" to="/" />
                            <q-btn class="glossy" rounded color="indigo-12" label="Save" type="submit" />
                        </td>
                    </tr>
                </tbody>
            </q-markup-table>
            </form>
        </div>
    </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
import { date } from 'quasar'
export default {
  data () {
    return {
      projectToAdd: {
        projectIdentifier: null,
        projectName: null,
        ProjectDescription: null,
        ApplicationDate: null,
        DateGrantApproved: null,
        DateGrantPaid: null,
        TargetCompletionDate: null,
        AmountGrantRequested: null,
        AmountGrantApproved: null,
        AmountGrantRecommended: null,
        AmountGrantPaid: null,
        TotalProjectCost: null,
        StatusCode_Id: null,
        StatusCodeDate: null,
        Region_Id: null,
        District_Id: null,
        ProjOfficer_Id: null
      }
    }
  },
  mounted () {
    this.load()
    this.$store.dispatch('regions/loadRegions')
    this.$store.dispatch('projectOfficers/loadProjectOfficers')
    this.$store.dispatch('statusCodes/loadStatusCodes')
    this.$store.dispatch('districts/loadDistricts')
  },
  computed: {
    ...mapGetters({
      regions: 'regions/regions',
      districts: 'districts/districts',
      projectOfficers: 'projectOfficers/projectOfficers',
      statusCodes: 'statusCodes/statusCodes'
    })
  },
  components: {
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  },
  methods: {
    submitForm () {
      // todo: validation
      this.saveProject()
    },
    async saveProject () {
      var errors = false
      this.$refs.projId.validate()
      this.$refs.projName.validate()
      this.$refs.statusCodeDD.validate()
      this.$refs.regionDD.validate()
      if (!this.$refs.projId.hasError && !this.$refs.projName.hasError && !this.$refs.statusCodeDD.hasError && !this.$refs.regionDD.hasError) {
        if ((this.projectToAdd.ApplicationDate != null) && !date.isValid(this.formatTheDate(this.projectToAdd.ApplicationDate))) {
          alert('Please enter the Application Date in DD/MM/YYYY format')
          errors = true
        }
        if ((this.projectToAdd.DateGrantApproved != null) && !date.isValid(this.formatTheDate(this.projectToAdd.DateGrantApproved))) {
          alert('Please enter the Grant Approved Date in DD/MM/YYYY format')
          errors = true
        }
        if ((this.projectToAdd.DateGrantPaid != null) && !date.isValid(this.formatTheDate(this.projectToAdd.DateGrantPaid))) {
          alert('Please enter the Grant Paid Date in DD/MM/YYYY format')
          errors = true
        }
        if ((this.projectToAdd.TargetCompletionDate != null) && !date.isValid(this.formatTheDate(this.projectToAdd.TargetCompletionDate))) {
          alert('Please enter the Target Completion Date in DD/MM/YYYY format')
          errors = true
        }
        if ((this.projectToAdd.StatusCodeDate != null) && !date.isValid(this.formatTheDate(this.projectToAdd.StatusCodeDate))) {
          alert('Please enter the Status Code Date in DD/MM/YYYY format')
          errors = true
        }
        alert(this.formatTheDate(this.projectToAdd.ApplicationDate, 'YYYY-MM-DD'))
        if ((this.projectToAdd.ApplicationDate != null) && (this.formatTheDate(this.projectToAdd.ApplicationDate) > date.formatDate(Date.now(), 'YYYY-MM-DD'))) {
          alert('The Application Date cannot be in the future')
          errors = true
        }
        if ((this.projectToAdd.DateGrantApproved != null) && (this.formatTheDate(this.projectToAdd.DateGrantApproved) > date.formatDate(Date.now(), 'YYYY-MM-DD'))) {
          alert('The Grant Approved Date cannot be in the future')
          errors = true
        }
        if ((this.projectToAdd.DateGrantPaid != null) && (this.formatTheDate(this.projectToAdd.DateGrantPaid) > date.formatDate(Date.now(), 'YYYY-MM-DD'))) {
          alert('The Grant Paid Date cannot be in the future')
          errors = true
        }
        if ((this.projectToAdd.StatusCodeDate != null) && (this.formatTheDate(this.projectToAdd.StatusCodeDate) > date.formatDate(Date.now(), 'YYYY-MM-DD'))) {
          alert('The Status Code Date cannot be in the future')
          errors = true
        }
        if (!errors) {
          this.projectToAdd.ApplicationDate = this.formatTheDate(this.projectToAdd.ApplicationDate)
          this.projectToAdd.DateGrantApproved = this.formatTheDate(this.projectToAdd.DateGrantApproved)
          this.projectToAdd.DateGrantPaid = this.formatTheDate(this.projectToAdd.DateGrantPaid)
          this.projectToAdd.TargetCompletionDate = this.formatTheDate(this.projectToAdd.TargetCompletionDate)
          this.projectToAdd.StatusCodeDate = this.formatTheDate(this.projectToAdd.StatusCodeDate)
          this.$store.dispatch('projects/addProject', { item: this.projectToAdd })
          this.$store.dispatch('projects/loadProjects')
          alert('Project added')
          this.$router.push('/')
        }
      } else {
        alert('The following fields are required - Project Identifier, Project Name, Status Code, Region.')
      }
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
      if (x != null && x.length === 10) {
        return x.split('/').reverse().join('-')
      } else {
        return null
      }
    },
    requiredDropdown (val) {
      if (val === null) {
        return 'Please select a value'
      }
    }
  }
}
</script>
