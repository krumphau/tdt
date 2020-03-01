<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New NGO</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="NGOToAdd.Name"
            ref="modalDisName"></modal-name>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      NGOToAdd: {
        NGOName: ''
      }
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalDisName.$refs.Name.validate()
      if (!this.$refs.modalDisName.$refs.Name.hasError) {
        this.saveNGO()
        this.$emit('close')
      }
    },
    async saveNGO () {
      this.$store.dispatch('ngos/addNGO', { item: this.NGOToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
