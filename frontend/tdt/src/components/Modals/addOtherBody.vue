<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Other Body</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="otherBodyToAdd.Name"
            ref="modalDisName"></modal-name>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      otherBodyToAdd: {
        Name: ''
      }
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalDisName.$refs.Name.validate()
      if (!this.$refs.modalDisName.$refs.Name.hasError) {
        this.saveOtherBody()
        this.$emit('close')
      }
    },
    async saveOtherBody () {
      this.$store.dispatch('otherBodies/addOtherBody', { item: this.otherBodyToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
