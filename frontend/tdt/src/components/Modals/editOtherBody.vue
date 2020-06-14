<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Other Body</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="otherBody.name"
            ref="modalOBName"></modal-name>

            <modal-buttons />
        </form>
    </q-card>
</template>

<script>
export default {
  props: ['otherBody'],
  data () {
    return {
      otherBodyToEdit: {}
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalOBName.$refs.Name.validate()
      if (!this.$refs.modalOBName.$refs.Name.hasError) {
        this.$store.dispatch('otherBodies/updateOtherBody', { item: this.otherBody })
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
    this.otherBodyToEdit = Object.assign({}, this.otherBody)
  }
}
</script>
