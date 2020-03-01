<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Status Code</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="statusCode.Name"
            ref="modalStatusCode"></modal-name>

            <modal-name
            :Name.sync="statusCode.Name"
            ref="modalDescription"></modal-name>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['statusCode'],
  data () {
    return {
      statusCodeToEdit: {}
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalStatusCode.$refs.Name.validate()
      if (!this.$refs.modalStatusCode.$refs.Name.hasError) {
        this.$store.dispatch('statusCodes/updateStatusCode', { item: this.statusCode })
        this.$emit('close')
      }
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  },
  mounted () {
    this.statusCodeToEdit = Object.assign({}, this.name)
  }
}
</script>
