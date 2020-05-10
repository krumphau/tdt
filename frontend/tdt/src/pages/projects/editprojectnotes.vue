<template>
    <q-page padding>
        <leftDrawer />
        <div>
            <h5>Edit Project Notes</h5>
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
                    <td class="text-left" width="20%">Project Progress</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.StatusDescription"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer Recommendation</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.ProjOfficerRecommendation"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Keywords</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.Keywords"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Summary</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.Summary"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Problems</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.Problems"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Strengths and Weaknesses</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.StrengthsWeaknesses"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Finance and Other Funders</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.FinanceOtherFunders"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Local Contribution</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.LocalContribution"></q-input></td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Cancel" to="/project/notes" />
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
        StatusDescription: null,
        ProjOfficerRecommendation: null,
        Keywords: null,
        Summary: null,
        Problems: null,
        StrengthsWeaknesses: null,
        FinanceOtherFunders: null,
        LocalContribution: null,
        LastUpdatedBy: 'Charlotte'
      }
    }
  },
  mounted () {
    this.$store.dispatch('projects/loadProjectDetails', this.$q.localStorage.getItem('selectedProjectId'))
  },
  computed: {
    ...mapGetters({
      project: 'projects/getCurrentProject'
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
      this.projectToEdit.StatusDescription = this.project.StatusDescription
      this.projectToEdit.ProjOfficerRecommendation = this.project.ProjOfficerRecommendation
      this.projectToEdit.Keywords = this.project.Keywords
      this.projectToEdit.Summary = this.project.Summary
      this.projectToEdit.Problems = this.project.Problems
      this.projectToEdit.StrengthsWeaknesses = this.project.StrengthsWeaknesses
      this.projectToEdit.FinanceOtherFunders = this.project.FinanceOtherFunders
      this.projectToEdit.LocalContribution = this.project.LocalContribution
    },
    async saveProject () {
      this.$store.dispatch('projects/updateProjectNotes', { item: this.projectToEdit })
      alert('Project notes updated')
    }
  }
}
</script>
