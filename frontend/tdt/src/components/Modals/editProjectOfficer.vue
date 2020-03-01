<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Project Officer</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="projectOfficerToEdit.FirstName"
            ref="modalFirstName"></modal-name>
            <modal-name
            :Name.sync="projectOfficerToEdit.LastName"
            ref="modalLastName"></modal-name>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Address1"
            ref="modalAddress1"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Address2"
            ref="modalAddress2"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Address3"
            ref="modalAddress3"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Town"
            ref="modalTown"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.County"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.PostCode"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Tel"
            ref="modalTelephone"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Mobile"
            ref="modalMobile"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Image"
            ref="modalImage"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Info"
            ref="modalInfo"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.Email"
            ref="modalEmail"></modal-optional>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['officer'],
  data () {
    return {
      projectOfficerToEdit: {}
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalFirstName.$refs.Name.validate()
      if (!this.$refs.modalFirstName.$refs.Name.hasError) {
        this.$store.dispatch('projectOfficers/updateProjectOfficer', { item: this.projectOfficerToEdit })
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
    this.projectOfficerToEdit = Object.assign({}, this.officer)
  }
}
</script>
