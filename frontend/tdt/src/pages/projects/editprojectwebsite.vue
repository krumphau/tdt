<template>
    <q-page padding>
        <leftDrawer />
        <div>
            <h5>Edit Project Website</h5>
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
                    <td class="text-left">Impact of the Project</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.Impact"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Picture</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.WebsitePicture"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Picture Caption</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.Caption"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Latitude (decimal)</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.Latitude"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Longitude (decimal)</td>
                    <td class="text-right"><q-input outlined dense v-model="projectToEdit.Longitude"></q-input></td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Cancel" to="/project/website" />
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
        ImpactOfProject: null,
        WebsitePicture: null,
        Caption: null,
        Latitude: null,
        Longitude: null,
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
      this.projectToEdit.Impact = this.project.impactOfProject
      this.projectToEdit.WebsitePicture = this.project.webSitePicture
      this.projectToEdit.Caption = this.project.webSitePictureDescription
      this.projectToEdit.Latitude = this.project.latitude
      this.projectToEdit.Longitude = this.project.longitude
    },
    async saveProject () {
      this.$store.dispatch('projects/updateProjectMeta', { item: this.projectToEdit })
      alert('Project website details updated')
      this.$router.push('/project/website')
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
