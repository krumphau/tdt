<template>
    <q-page padding>
        <div>
            <h5>{{ getProjectName() }} - Project Website</h5>
        </div>
        <leftDrawer />
        <div class="q-pa-md">
            <form>
            <q-markup-table flat bordered>
                <tbody>
                  <tr>
                    <td class="text-left">Impact of the Project</td>
                    <td class="text-left">{{ project.impactOfProject }}</td>
                  </tr>
                  <tr>
                    <td class="text-left">Picture</td>
                    <td>
                        <q-img
                        :src="project.WebSitePicture"
                        spinner-color="white"
                        style="height: 140px; max-width: 150px"
                        />
                    </td>
                  </tr>
                  <tr>
                    <td class="text-left">Picture Caption</td>
                    <td class="text-left">{{ project.webSitePictureDescription }}</td>
                  </tr>
                  <tr>
                    <td class="text-left">Latitude [Decimal]</td>
                    <td class="text-left">{{ project.latitude }}</td>
                  </tr>
                  <tr>
                    <td class="text-left">Longitude [Decimal]</td>
                    <td class="text-left">{{ project.longitude }}</td>
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
            </form>
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
      this.$router.push('/editprojectwebsite')
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
