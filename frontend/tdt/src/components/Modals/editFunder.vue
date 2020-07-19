<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Funder</modal-header>

        <form @submit.prevent="submitForm">
        <div>
          <table>
            <tr>
              <td>
            <modal-name
            :Name.sync="funderToEdit.name"
            :Label.sync="nameLabel"
            ref="modalName"></modal-name>
            <modal-optional
            :Name.sync="funderToEdit.address1"
            :Label.sync="add1Label"
            ref="modalAddress1"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.address2"
            :Label.sync="add2Label"
            ref="modalAddress2"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.address3"
            :Label.sync="add3Label"
            ref="modalAddress3"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.town"
            :Label.sync="townLabel"
            ref="modalTown"></modal-optional>
              </td>
              <td>
            <modal-name
            :Name.sync="funderToEdit.mainContact"
            :Label.sync="mainContactLabel"
            ref="modalMainContact"></modal-name>
            <modal-optional
            :Name.sync="funderToEdit.county"
            :Label.sync="countyLabel"
            ref="modalCounty"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.postCode"
            :Label.sync="postCodeLabel"
            ref="modalPostcode"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.tel"
            :Label.sync="telLabel"
            ref="modalTelephone"></modal-optional>
            <modal-optional
            :Name.sync="funderToEdit.amount"
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
  props: ['funder'],
  data () {
    return {
      funderToEdit: {},
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
