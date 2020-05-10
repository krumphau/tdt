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
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.ProjectIdentifier"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Name</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.ProjectName"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Description</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.ProjectDescription"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Application Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.ApplicationDate" mask="datetime">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qAppDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.ApplicationDate" @input="() => $refs.qAppDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Approved</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.DateGrantApproved" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qApproveDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.DateGrantApproved" @input="() => $refs.qApproveDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Paid</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.DateGrantPaid" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qPaidDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.DateGrantPaid" @input="() => $refs.qPaidDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Target Completion Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToEdit.TargetCompletionDate" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qTargetDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.TargetCompletionDate" @input="() => $refs.qTargetDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Requested</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToEdit.AmountGrantRequested"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Approved</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToEdit.AmountGrantApproved"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Recommended</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToEdit.AmountGrantRecommended"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Paid</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToEdit.AmountGrantPaid"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Total Project Cost</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToEdit.TotalProjectCost"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToEdit.StatusCode_Id" label="Please select" map-options emit-value option-value="Id" option-label="StatusCode" outlined :options="statusCodes" />
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
                        <q-input outlined dense v-model="projectToEdit.StatusCodeDate" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qStatusDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToEdit.StatusCodeDate" @input="() => $refs.qStatusDateProxy.hide()" />
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
                                <q-select dense v-model="projectToEdit.Region_Id" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="regions" />
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
                                <q-select dense v-model="projectToEdit.District_Id" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="districts" />
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
                                <q-select dense v-model="projectToEdit.ProjOfficer_Id" label="Please select" map-options emit-value option-value="Id" option-label="FullName" outlined :options="projectOfficers" />
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
            <pre>{{ project }}</pre>
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
        ProjectIdentifier: null,
        ProjectName: null,
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
        ProjOfficer_Id: null,
        LastUpdatedBy: 'Charlotte'
      }
    }
  },
  mounted () {
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
      this.projectToEdit.ProjectIdentifier = this.project.ProjectIdentifier
      this.projectToEdit.ProjectName = this.project.ProjectName
      this.projectToEdit.ProjectDescription = this.project.ProjectDescription
      this.projectToEdit.ApplicationDate = this.project.ApplicationDate
      this.projectToEdit.DateGrantApproved = this.project.DateGrantApproved
      this.projectToEdit.DateGrantPaid = this.project.DateGrantPaid
      this.projectToEdit.TargetCompletionDate = this.project.TargetCompletionDate
      this.projectToEdit.AmountGrantRequested = this.project.AmountGrantRequested
      this.projectToEdit.AmountGrantApproved = this.project.AmountGrantApproved
      this.projectToEdit.AmountGrantRecommended = this.project.AmountGrantRecommended
      this.projectToEdit.AmountGrantPaid = this.project.AmountGrantPaid
      this.projectToEdit.TotalProjectCost = this.project.TotalProjectCost
      this.projectToEdit.StatusCode_Id = this.project.StatusCode_Id
      this.projectToEdit.Region_Id = this.project.Region_Id
      this.projectToEdit.District_Id = this.project.District_Id
      this.projectToEdit.ProjOfficer_Id = this.project.ProjOfficer_Id
    },
    async saveProject () {
      this.$store.dispatch('projects/updateProject', { item: this.projectToEdit })
      alert('Project updated')
    }
  }
}
</script>
