<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Category</modal-header>

        <form @submit.prevent="submitForm">
            <modal-name
            :Name.sync="categoryToAdd.Name"
            ref="modalCatName"></modal-name>

            <modal-highlevel :Selected.sync="categoryToAdd.HighLevel"></modal-highlevel>

            <modal-buttons />
        </form>
        <pre>{{ categoryToAdd}}</pre>
    </q-card>

</template>

<script>
import axios from 'axios'
export default {
  data () {
    return {
      categoryToAdd: {
        Name: '',
        HighLevel: false
      }
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
      await axios.post('http://localhost:5000/category', this.categoryToAdd).then(this.$emit('postFinished'))
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-name': require('components/Modals/Shared/modalSettingName.vue').default,
    'modal-highlevel': require('components/Modals/Shared/modalCheckbox.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
