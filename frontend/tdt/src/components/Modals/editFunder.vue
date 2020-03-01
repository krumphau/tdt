<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Funder</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="funderToEdit.Name"
            ref="modalName"></modal-name>
            <modal-optional
            :Name.sync="funderToEdit.Address1"
            ref="modalAddress1"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.Address2"
            ref="modalAddress2"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.Address3"
            ref="modalAddress3"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.Town"
            ref="modalTown"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.County"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.PostCode"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.Tel"
            ref="modalTelephone"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.MainContact"
            ref="modalMainContact"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.Amount"
            ref="modalAmount"></modal-optional>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['funder'],
  data () {
    return {
      funderToEdit: {}
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalName.$refs.Name.validate()
      if (!this.$refs.modalName.$refs.Name.hasError) {
        this.$store.dispatch('funders/updateFunder', { item: this.funderToEdit })
        this.$emit('close')
      }
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-optional': require('components/Modals/Shared/modalOptionalField.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  },
  mounted () {
    this.funderToEdit = Object.assign({}, this.funder)
  }
}
</script>
