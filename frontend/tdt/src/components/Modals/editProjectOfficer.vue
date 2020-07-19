<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Project Officer</modal-header>

        <form @submit.prevent="submitForm">
        <div>
          <table>
            <tr>
              <td>
            <modal-name
            :Name.sync="projectOfficerToEdit.firstName"
            :Label.sync="firstNameLabel"
            ref="modalFirstName"></modal-name>
            <modal-name
            :Name.sync="projectOfficerToEdit.lastName"
            :Label.sync="lastNameLabel"
            ref="modalLastName"></modal-name>
            <modal-optional
            :Name.sync="projectOfficerToEdit.address1"
            :Label.sync="add1Label"
            ref="modalAddress1"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.address2"
            :Label.sync="add2Label"
            ref="modalAddress2"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.address3"
            :Label.sync="add3Label"
            ref="modalAddress3"></modal-optional>
              </td>
              <td>
            <modal-optional
            :Name.sync="projectOfficerToEdit.town"
            :Label.sync="townLabel"
            ref="modalTown"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.county"
            :Label.sync="countyLabel"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.postCode"
            :Label.sync="postCodeLabel"
            ref="modalPostcode"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.tel"
            :Label.sync="telLabel"
            ref="modalTelephone"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.mobile"
            :Label.sync="mobLabel"
            ref="modalMobile"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.info"
            :Label.sync="infoLabel"
            ref="modalInfo"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToEdit.email"
            :Label.sync="emailLabel"
            ref="modalEmail"></modal-optional>
              </td>
            </tr>
          </table>
        </div>
        <div>
            <modal-buttons />
        </div>
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['officer'],
  data () {
    return {
      projectOfficerToEdit: {},
      firstNameLabel: 'First Name',
      lastNameLabel: 'Last Name',
      add1Label: 'Address 1',
      add2Label: 'Address 2',
      add3Label: 'Address 3',
      townLabel: 'Town',
      countyLabel: 'County',
      postCodeLabel: 'Postcode',
      telLabel: 'Telephone',
      mobLabel: 'Mobile',
      infoLabel: 'Information',
      emailLabel: 'Email'
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
