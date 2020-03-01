<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit District</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="district.Name"
            ref="modalCatName"></modal-name>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['district'],
  data () {
    return {
      districtToEdit: {}
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalCatName.$refs.Name.validate()
      if (!this.$refs.modalCatName.$refs.Name.hasError) {
        this.$store.dispatch('districts/updateDistrict', { item: this.district })
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
    this.districtToEdit = Object.assign({}, this.district)
  }
}
</script>
