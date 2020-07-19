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
    this.load()
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
      this.projectToEdit.StatusDescription = this.project.statusDescription
      this.projectToEdit.ProjOfficerRecommendation = this.project.projOfficerRecommendation
      this.projectToEdit.Keywords = this.project.keywords
      this.projectToEdit.Summary = this.project.summary
      this.projectToEdit.Problems = this.project.problems
      this.projectToEdit.StrengthsWeaknesses = this.project.strengthsWeaknesses
      this.projectToEdit.FinanceOtherFunders = this.project.financeOtherFunders
      this.projectToEdit.LocalContribution = this.project.localContribution
    },
    async saveProject () {
      this.$store.dispatch('projects/updateProjectNotes', { item: this.projectToEdit })
      alert('Project notes updated')
      this.$router.push('/project/notes')
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
  }
}
</script>
