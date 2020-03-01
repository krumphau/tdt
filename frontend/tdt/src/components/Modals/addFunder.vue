<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Funder</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="funderToAdd.Name"
            ref="modalName"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.Address1"
            ref="modalAddress1"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.Address2"
            ref="modalAddress2"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.Address3"
            ref="modalAddress3"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.Town"
            ref="modalTown"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.County"
            ref="modalCounty"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.PostCode"
            ref="modalCounty"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.Tel"
            ref="modalTelephone"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.MainContact"
            ref="modalMainContact"></modal-name>
            <modal-name
            :Name.sync="funderToAdd.Amount"
            ref="modalAmount"></modal-name>

            <modal-buttons />
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
        Amount: ''
      }
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalName.$refs.Name.validate()
      if (!this.$refs.modalName.$refs.Name.hasError) {
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
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
