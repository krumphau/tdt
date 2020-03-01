<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Status Code</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="statusCodeToAdd.StatusCode"
            ref="modalStatusCode"></modal-name>

            <modal-name
            :Name.sync="statusCodeToAdd.Description"
            ref="modalDescription"></modal-name>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      statusCodeToAdd: {
        StatusCode: '',
        Description: ''
      }
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalStatusCode.$refs.Name.validate()
      if (!this.$refs.modalStatusCode.$refs.Name.hasError) {
        this.saveStatusCode()
        this.$emit('close')
      }
    },
    async saveStatusCode () {
      this.$store.dispatch('statusCodes/addStatusCode', { item: this.statusCodeToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
