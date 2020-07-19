<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Funder</modal-header>
        <form @submit.prevent="submitForm">
        <div>
          <table>
            <tr>
              <td>
            <modal-name
            :Name.sync="funderToAdd.Name"
            :Label.sync="nameLabel"
            ref="modalName"></modal-name>
            <modal-optional
            :Name.sync="funderToAdd.Address1"
            :Label.sync="add1Label"
            ref="modalAddress1"></modal-optional>
            <modal-optional
            :Name.sync="funderToAdd.Address2"
            :Label.sync="add2Label"
            ref="modalAddress2"></modal-optional>
            <modal-optional
            :Name.sync="funderToAdd.Address3"
            :Label.sync="add3Label"
            ref="modalAddress3"></modal-optional>
            <modal-optional
            :Name.sync="funderToAdd.Town"
            :Label.sync="townLabel"
            ref="modalTown"></modal-optional>
              </td>
              <td>
            <modal-name
            :Name.sync="funderToAdd.MainContact"
            :Label.sync="mainContactLabel"
            ref="modalMainContact"></modal-name>
            <modal-optional
            :Name.sync="funderToAdd.County"
            :Label.sync="countyLabel"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="funderToAdd.PostCode"
            :Label.sync="postCodeLabel"
            ref="modalPostcode"></modal-optional>
            <modal-optional
            :Name.sync="funderToAdd.Tel"
            :Label.sync="telLabel"
            ref="modalTelephone"></modal-optional>
            <modal-optional
            :Name.sync="funderToAdd.Amount"
            :Label.sync="amountLabel"
            ref="modalAmount"></modal-optional>
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
      funderToAdd: {
        Name: '',
        Address1: '',
        Address2: '',
        Address3: '',
        Town: '',
        County: '',
        PostCode: '',
        Tel: '',
        MainContact: '',
        Amount: 0
      },
      nameLabel: 'Name',
      add1Label: 'Address 1',
      add2Label: 'Address 2',
      add3Label: 'Address 3',
      townLabel: 'Town',
      countyLabel: 'County',
      postCodeLabel: 'Postcode',
      telLabel: 'Telephone',
      mainContactLabel: 'Main Contact',
      amountLabel: 'Amount'
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalName.$refs.Name.validate()
      this.$refs.modalMainContact.$refs.Name.validate()
      if (!this.$refs.modalName.$refs.Name.hasError && !this.$refs.modalMainContact.$refs.Name.hasError) {
        this.saveFunder()
        this.$emit('close')
      }
    },
    async saveFunder () {
      this.$store.dispatch('funders/addFunder', { item: this.funderToAdd })
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
