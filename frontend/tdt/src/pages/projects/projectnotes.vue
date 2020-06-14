<template>
    <q-page padding>
        <leftDrawer />
        <div>
            <h5>{{ getProjectName() }} - Project Notes</h5>
        </div>
        <div class="q-pa-md">
            <q-markup-table flat bordered>
                <tbody>
                    <tr>
                    <td class="text-left" width="20%">Project Progress</td>
                    <td class="text-left" >{{ project.statusDescription }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer Recommendation</td>
                    <td class="text-left">{{ project.projOfficerRecommendation }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Keywords</td>
                    <td class="text-left">{{ project.keywords }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Summary</td>
                    <td class="text-left">{{ project.summary }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Problems (SC13 Only)</td>
                    <td class="text-left">{{ project.problems }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Strengths and Weaknesses</td>
                    <td class="text-left">{{ project.strengthsWeaknesses }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Finance and Other Funders</td>
                    <td class="text-left">{{ project.financeOtherFunders }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Local Contribution &amp; Running Costs</td>
                    <td class="text-left">{{ project.localContribution }}</td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Edit" @click="showEditDialog()"/>
                        </td>
                    </tr>
                </tbody>
            </q-markup-table>
        </div>
    </q-page>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  created () {
    if (!this.$store.getters['projects/getCurrentProject'].projectName) {
      this.$store.dispatch('projects/loadProjectDetails', this.$q.localStorage.getItem('selectedProjectId'))
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
    getProjectName () {
      return this.$store.getters['projects/getCurrentProject'].projectName
    },
    showEditDialog () {
      this.$router.push('/editprojectnotes')
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
