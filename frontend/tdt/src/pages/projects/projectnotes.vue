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
                    <td class="text-left" >{{ project.StatusDescription }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer Recommendation</td>
                    <td class="text-left">{{ project.ProjOfficerRecommendation }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Keywords</td>
                    <td class="text-left">{{ project.Keywords }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Summary</td>
                    <td class="text-left">{{ project.Summary }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Problems (SC13 Only)</td>
                    <td class="text-left">{{ project.Problems }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Strengths and Weaknesses</td>
                    <td class="text-left">{{ project.StrengthsWeaknesses }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Finance and Other Funders</td>
                    <td class="text-left">{{ project.FinanceOtherFunders }}</td>
                    </tr>
                    <tr>
                    <td class="text-left">Local Contribution &amp; Running Costs</td>
                    <td class="text-left">{{ project.LocalContribution }}</td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Edit" />
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
  mounted () {
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
      return this.$store.getters['projects/getProjectById'](this.$q.localStorage.getItem('selectedProjectId')).ProjectName
    }
  }
}
</script>
