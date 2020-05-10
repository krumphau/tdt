<template>
    <q-card style="min-width: 350px">
        <modal-header>Add Project NGO</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-select dense v-model="ngoToAdd.NgoId" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="ngos" />
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
      ngoToAdd: {
        ProjectId: this.$q.localStorage.getItem('selectedProjectId'),
        NgoId: null
      }
    }
  },
  mounted () {
    this.$store.dispatch('ngos/loadNGOs')
  },
  computed: {
    ...mapGetters({
      ngos: 'ngos/NGOs'
    })
  },
  methods: {
    submitForm () {
      this.saveNgo()
      this.$emit('close')
    },
    async saveNgo () {
      this.$store.dispatch('projectNGOs/addProjectNGO', { item: this.ngoToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
