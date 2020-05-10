<template>
    <q-card style="min-width: 350px">
        <modal-header>Add Project Funder</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-select dense v-model="funderToAdd.FunderId" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="funders" />
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense outlined v-model="funderToAdd.AmountFunded" label="Amount Funded" />
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
      funderToAdd: {
        ProjectId: this.$q.localStorage.getItem('selectedProjectId'),
        FunderId: null,
        AmountFunded: null
      }
    }
  },
  mounted () {
    this.$store.dispatch('funders/loadFunders')
  },
  computed: {
    ...mapGetters({
      funders: 'funders/funders'
    })
  },
  methods: {
    submitForm () {
      this.saveFunder()
      this.$emit('close')
    },
    async saveFunder () {
      this.$store.dispatch('projectFunders/addProjectFunder', { item: this.funderToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
