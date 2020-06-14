<template>
    <q-card style="min-width: 350px">
        <modal-header>Add Project Other Body</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-select dense v-model="otherbodyToAdd.OtherBodyId" label="Please select" map-options emit-value option-value="id" option-label="name" outlined :options="otherbodies" />
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
      otherbodyToAdd: {
        ProjectId: this.$q.localStorage.getItem('selectedProjectId'),
        OtherBodyId: null
      }
    }
  },
  mounted () {
    this.$store.dispatch('otherBodies/loadOtherBodies')
  },
  computed: {
    ...mapGetters({
      otherbodies: 'otherBodies/otherBodies'
    })
  },
  methods: {
    submitForm () {
      this.saveOtherBody()
      this.$emit('close')
    },
    async saveOtherBody () {
      this.$store.dispatch('projectOtherBodies/addProjectOtherBody', { item: this.otherbodyToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
