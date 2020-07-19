<template>
    <q-card style="min-width: 350px">
        <modal-header>Add Related Project</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-select dense v-model="relatedProjectToAdd.RelationshipKey" label="Please select" map-options emit-value option-value="id" option-label="displayValue" outlined :options="categories" />
            </q-card-section>
           <modal-buttons />
        </form>
    </q-card>

</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data () {
    return {
      relatedProjectToAdd: {
        ProjectId: this.$q.localStorage.getItem('selectedProjectId'),
        RelationshipKey: null,
        ProjectName: null,
        ProjectIdentifier: null
      }
    }
  },
  mounted () {
    this.$store.dispatch('projects/loadProjects')
  },
  computed: {
    ...mapGetters({
      categories: 'projects/projects'
    })
  },
  methods: {
    submitForm () {
      this.saveRelatedProject()
      this.$emit('close')
    },
    async saveRelatedProject () {
      this.relatedProjectToAdd.ProjectName = this.$store.getters['projects/getProjectById'](this.relatedProjectToAdd.RelationshipKey).projectName
      this.relatedProjectToAdd.ProjectIdentifier = this.$store.getters['projects/getProjectById'](this.relatedProjectToAdd.RelationshipKey).projectIdentifier
      this.$store.dispatch('relatedProjects/addRelatedProject', { item: this.relatedProjectToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
