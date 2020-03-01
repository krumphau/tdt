<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Region</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="regionToAdd.Name"
            ref="modalDisName"></modal-name>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      regionToAdd: {
        Name: ''
      }
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalDisName.$refs.Name.validate()
      if (!this.$refs.modalDisName.$refs.Name.hasError) {
        this.saveRegion()
        this.$emit('close')
      }
    },
    async saveRegion () {
      this.$store.dispatch('regions/addRegion', { item: this.regionToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
