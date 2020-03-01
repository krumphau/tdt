<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit NGO</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="NGO.Name"
            ref="modalCatName"></modal-name>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['NGO'],
  data () {
    return {
      NGOToEdit: {}
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalCatName.$refs.Name.validate()
      if (!this.$refs.modalCatName.$refs.Name.hasError) {
        this.$store.dispatch('ngos/updateNGO', { item: this.NGO })
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
    this.NGOToEdit = Object.assign({}, this.NGO)
  }
}
</script>
