<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New District</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="districtToAdd.Name"
            ref="modalDisName"></modal-name>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      districtToAdd: {
        Name: ''
      }
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalDisName.$refs.Name.validate()
      if (!this.$refs.modalDisName.$refs.Name.hasError) {
        this.saveDistrict()
        this.$emit('close')
      }
    },
    async saveDistrict () {
      this.$store.dispatch('districts/addDistrict', { item: this.districtToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
