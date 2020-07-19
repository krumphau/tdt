<template>
    <q-card style="min-width: 350px">
        <modal-header>Add Project Category</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-select dense v-model="categoryToAdd.categoryId" label="Please select" map-options emit-value option-value="id" option-label="categoryName" outlined :options="categories" />
            </q-card-section>
           <modal-buttons />
        </form>
    </q-card>

</template>

<script>
import { mapGetters } from 'vuex'
export default {
  data () {
    return {
      categoryToAdd: {
        projectId: this.$q.localStorage.getItem('selectedProjectId'),
        categoryId: null,
        categoryName: null
      }
    }
  },
  mounted () {
    this.$store.dispatch('categories/loadCategories')
  },
  computed: {
    ...mapGetters({
      categories: 'categories/categories'
    })
  },
  methods: {
    submitForm () {
      this.saveCategory()
      this.$emit('close')
    },
    async saveCategory () {
      this.categoryToAdd.categoryName = this.$store.getters['categories/getCategoryById'](this.categoryToAdd.categoryId).categoryName
      this.$store.dispatch('projectCategories/addProjectCategory', { item: this.categoryToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
