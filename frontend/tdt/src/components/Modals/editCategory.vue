<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Category</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="category.categoryName"
            ref="modalCatName"></modal-name>
            <q-checkbox v-model="categoryToEdit.highLevelCategory" label="High Level" ref="modalHL"/>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['category'],
  data () {
    return {
      categoryToEdit: {}
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalCatName.$refs.Name.validate()
      if (!this.$refs.modalCatName.$refs.Name.hasError) {
        this.$store.dispatch('categories/updateCategory', { item: this.categoryToEdit })
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
    this.categoryToEdit = Object.assign({}, this.category)
  }
}
</script>
