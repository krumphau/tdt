<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Category</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="categoryToAdd.CategoryName"
            :Label.sync="label"
            ref="modalCatName"></modal-name>
            <q-checkbox v-model="selected" label="High Level" ref="modalHL"/>

            <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      categoryToAdd: {
        CategoryName: '',
        HighLevelCategory: null
      },
      selected: false,
      label: 'Category Name'
    }
  },
  methods: {
    submitForm () {
      this.$refs.modalCatName.$refs.Name.validate()
      if (!this.$refs.modalCatName.$refs.Name.hasError) {
        this.saveCategory()
        this.$emit('close')
      }
    },
    async saveCategory () {
      this.categoryToAdd.HighLevelCategory = this.selected
      this.$store.dispatch('categories/addCategory', { item: this.categoryToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
