<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Project Officer</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="projectOfficerToAdd.FirstName"
            ref="modalFirstName"></modal-name>
            <modal-name
            :Name.sync="projectOfficerToAdd.LastName"
            ref="modalLastName"></modal-name>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Address1"
            ref="modalAddress1"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Address2"
            ref="modalAddress2"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Address3"
            ref="modalAddress3"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Town"
            ref="modalTown"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.County"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.PostCode"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Tel"
            ref="modalTelephone"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Mobile"
            ref="modalMobile"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Image"
            ref="modalImage"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Info"
            ref="modalInfo"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Email"
            ref="modalEmail"></modal-optional>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      projectOfficerToAdd: {
        FirstName: '',
        LastName: '',
        Address1: '',
        Address2: '',
        Address3: '',
        Town: '',
        County: '',
        PostCode: '',
        Tel: '',
        Mobile: '',
        Image: '',
        Info: '',
        Email: ''
      }
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalFirstName.$refs.Name.validate()
      if (!this.$refs.modalFirstName.$refs.Name.hasError) {
        this.saveOfficer()
        this.$emit('close')
      }
    },
    async saveOfficer () {
      this.$store.dispatch('projectOfficers/addProjectOfficer', { item: this.projectOfficerToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-optional': require('components/Modals/Shared/modalOptionalField.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
