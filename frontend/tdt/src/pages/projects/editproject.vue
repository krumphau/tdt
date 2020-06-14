<template>
    <q-page padding>
        <leftDrawer />
        <div>
            <h5>Edit Project</h5>
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
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.projectIdentifier"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Name</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.projectName"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Description</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.projectDescription"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Application Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.applicationDate" mask="datetime">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qAppDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.applicationDate" @input="() => $refs.qAppDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Approved</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.dateGrantApproved" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qApproveDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.dateGrantApproved" @input="() => $refs.qApproveDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Paid</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.dateGrantPaid" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qPaidDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.dateGrantPaid" @input="() => $refs.qPaidDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Target Completion Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.targetCompletionDate" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qTargetDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.targetCompletionDate" @input="() => $refs.qTargetDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Requested</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToEdit.amountGrantRequested"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Approved</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToEdit.amountGrantApproved"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Recommended</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToEdit.amountGrantRecommended"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Paid</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToEdit.amountGrantPaid"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Total Project Cost</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model.number="projectToEdit.totalProjectCost"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToEdit.statusCode_Id" label="Please select" map-options emit-value option-value="id" option-label="statusCode" outlined :options="statusCodes" />
                            </q-item-section>
                            <q-item-section avatar clickable>
                                <q-icon name="add" title="Add a new Status Code"/>
                            </q-item-section>
                        </q-item>
                        </td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code Changed</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.statusCodeDate" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qStatusDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.statusCodeDate" @input="() => $refs.qStatusDateProxy.hide()" />
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
                                <q-select dense v-model="projectToEdit.region_Id" label="Please select" map-options emit-value option-value="id" option-label="name" outlined :options="regions" />
                            </q-item-section>
                            <q-item-section avatar clickable>
                                <q-icon name="add" title="Add a new Region"/>
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">District</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToEdit.district_Id" label="Please select" map-options emit-value option-value="id" option-label="name" outlined :options="districts" />
                            </q-item-section>
                            <q-item-section avatar clickable >
                                <q-icon name="add" title="Add a new District"/>
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToEdit.projOfficer_Id" label="Please select" map-options emit-value option-value="id" option-label="fullName" outlined :options="projectOfficers" />
                            </q-item-section>
                            <q-item-section avatar clickable>
                                <q-icon name="add" title="Add a new Project Officer"/>
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Cancel" to="/project/details" />
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
export default {
  data () {
    return {
      projectToEdit: {
        Id: this.$q.localStorage.getItem('selectedProjectId'),
        projectIdentifier: null,
        projectName: null,
        projectDescription: null,
        applicationDate: null,
        dateGrantApproved: null,
        dateGrantPaid: null,
        targetCompletionDate: null,
        amountGrantRequested: null,
        amountGrantApproved: null,
        amountGrantRecommended: null,
        amountGrantPaid: null,
        totalProjectCost: null,
        statusCode_Id: null,
        statusCodeDate: null,
        region_Id: null,
        district_Id: null,
        projOfficer_Id: null,
        lastUpdatedBy: 'Charlotte'
      }
    }
  },
  mounted () {
    this.load()
    this.$store.dispatch('projects/loadProjectDetails', this.$q.localStorage.getItem('selectedProjectId'))
    this.$store.dispatch('regions/loadRegions')
    this.$store.dispatch('projectOfficers/loadProjectOfficers')
    this.$store.dispatch('statusCodes/loadStatusCodes')
    this.$store.dispatch('districts/loadDistricts')
  },
  computed: {
    ...mapGetters({
      project: 'projects/getCurrentProject',
      regions: 'regions/regions',
      districts: 'districts/districts',
      projectOfficers: 'projectOfficers/projectOfficers',
      statusCodes: 'statusCodes/statusCodes'
    })
  },
  created () {
    this.populateEditProject()
  },
  components: {
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  },
  methods: {
    submitForm () {
      // todo: validation
      this.saveProject()
    },
    populateEditProject () {
      this.projectToEdit.projectIdentifier = this.project.projectIdentifier
      this.projectToEdit.projectName = this.project.projectName
      this.projectToEdit.projectDescription = this.project.projectDescription
      this.projectToEdit.applicationDate = this.project.applicationDate
      this.projectToEdit.dateGrantApproved = this.project.dateGrantApproved
      this.projectToEdit.dateGrantPaid = this.project.dateGrantPaid
      this.projectToEdit.targetCompletionDate = this.project.targetCompletionDate
      this.projectToEdit.amountGrantRequested = this.project.amountGrantRequested
      this.projectToEdit.amountGrantApproved = this.project.amountGrantApproved
      this.projectToEdit.amountGrantRecommended = this.project.amountGrantRecommended
      this.projectToEdit.amountGrantPaid = this.project.amountGrantPaid
      this.projectToEdit.totalProjectCost = this.project.totalProjectCost
      this.projectToEdit.statusCode_Id = this.project.statusCode_Id
      this.projectToEdit.region_Id = this.project.region_Id
      this.projectToEdit.district_Id = this.project.district_Id
      this.projectToEdit.projOfficer_Id = this.project.projOfficer_Id
    },
    async saveProject () {
      this.$store.dispatch('projects/updateProject', { item: this.projectToEdit })
      alert('Project updated')
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
  }
}
</script>
