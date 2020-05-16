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
                    <td class="text-left">{{ project.ImpactOfProject }}</td>
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
                    <td class="text-left">{{ project.WebSitePictureDescription }}</td>
                  </tr>
                  <tr>
                    <td class="text-left">Latitude [Decimal]</td>
                    <td class="text-left">{{ project.Latitude }}</td>
                  </tr>
                  <tr>
                    <td class="text-left">Longitude [Decimal]</td>
                    <td class="text-left">{{ project.Longitude }}</td>
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
    if (!this.$store.getters['projects/getCurrentProject'].ProjectName) {
      this.$store.dispatch('projects/loadProjectDetails', this.$q.localStorage.getItem('selectedProjectId'))
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
      return this.$store.getters['projects/getCurrentProject'].ProjectName
    },
    showEditDialog () {
      this.$router.push('/editprojectwebsite')
    }
  }
}
</script>
