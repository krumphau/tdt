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
                    <td class="text-right"><q-input outlined dense v-model="projectToAdd.ProjectIdentifier"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Name</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToAdd.ProjectName"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Description</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToAdd.ProjectDescription"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Application Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.ApplicationDate" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qAppDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.ApplicationDate" @input="() => $refs.qAppDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Approved</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.DateGrantApproved" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qApproveDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.DateGrantApproved" @input="() => $refs.qApproveDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Paid</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.DateGrantPaid" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qPaidDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.DateGrantPaid" @input="() => $refs.qPaidDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Target Completion Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="projectToAdd.TargetCompletionDate" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qTargetDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.TargetCompletionDate" @input="() => $refs.qTargetDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Requested</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToAdd.AmountGrantRequested"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Approved</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToAdd.AmountGrantApproved"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Recommended</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToAdd.AmountGrantRecommended"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Paid</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToAdd.AmountGrantPaid"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Total Project Cost</td>
                    <td class="text-right"><q-input outlined dense prefix="£" v-model="projectToAdd.TotalProjectCost"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select dense v-model="projectToAdd.StatusCode_Id" label="Please select" map-options emit-value option-value="Id" option-label="StatusCode" outlined :options="statusCodes" />
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
                        <q-input outlined dense v-model="projectToAdd.StatusCodeDate" mask="date">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qStatusDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="projectToAdd.StatusCodeDate" @input="() => $refs.qStatusDateProxy.hide()" />
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
                                <q-select dense v-model="projectToAdd.Region_Id" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="regions" />
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
                                <q-select dense v-model="projectToAdd.District_Id" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="districts" />
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
                                <q-select dense v-model="projectToAdd.ProjOfficer_Id" label="Please select" map-options emit-value option-value="Id" option-label="FullName" outlined :options="projectOfficers" />
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
                            <q-btn class="glossy" rounded color="indigo-12" label="Cancel" to="/" />
                            <q-btn class="glossy" rounded color="indigo-12" label="Save" type="submit" />
                        </td>
                    </tr>
                </tbody>
            </q-markup-table>
            </form>
            <pre>{{ projectToAdd }}</pre>
        </div>
    </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data () {
    return {
      projectToAdd: {
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
        ProjOfficer_Id: null
      }
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
      this.$store.dispatch('projects/addProject', { item: this.projectToAdd })
      alert('Project added')
      this.$router.push('/')
    }
  }
}
</script>
