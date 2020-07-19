<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Project Officer</modal-header>

        <form @submit.prevent="submitForm">
        <div>
          <table>
            <tr>
              <td>
            <modal-name
            :Name.sync="projectOfficerToAdd.FirstName"
            :Label.sync="firstNameLabel"
            ref="modalFirstName"></modal-name>
            <modal-name
            :Name.sync="projectOfficerToAdd.LastName"
            :Label.sync="lastNameLabel"
            ref="modalLastName"></modal-name>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Address1"
            :Label.sync="add1Label"
            ref="modalAddress1"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Address2"
            :Label.sync="add2Label"
            ref="modalAddress2"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Address3"
            :Label.sync="add3Label"
            ref="modalAddress3"></modal-optional>
              </td>
              <td>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Town"
            :Label.sync="townLabel"
            ref="modalTown"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.County"
            :Label.sync="countyLabel"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.PostCode"
            :Label.sync="postCodeLabel"
            ref="modalPostcode"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Tel"
            :Label.sync="telLabel"
            ref="modalTelephone"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Mobile"
            :Label.sync="mobLabel"
            ref="modalMobile"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Info"
            :Label.sync="infoLabel"
            ref="modalInfo"></modal-optional>
            <modal-optional
            :Name.sync="projectOfficerToAdd.Email"
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
        Info: '',
        Email: ''
      },
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
