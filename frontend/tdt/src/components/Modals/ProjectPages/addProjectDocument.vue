<template>
    <q-card style="min-width: 350px">
        <modal-header>Add Project Document</modal-header>

<modal-header> 1. Upload the Document </modal-header>

  <form method="POST" @submit.prevent="uploadFile" enctype=multipart/form-data>
    <q-card-section class="q-pt-none">
      <q-input dense outlined type=file name=file v-model="selected_file">
        <template v-slot:before>
          <q-icon name="attachment" />
        </template>
      </q-input>
    </q-card-section>
    <q-card-section class="q-pt-none">
      <q-btn class="glossy" rounded color="indigo-12" label="Upload" type="submit" />
    </q-card-section>
  </form>

<modal-header> 2. Complete the Document Information </modal-header>
        <form @submit.prevent="submitForm" enctype=multipart/form-data>
          <q-card-section class="q-pt-none">
            <q-input
            v-model="documentToAdd.DocName"
            dense
            outlined
            label="Document Name"
            ref="modalDocName"></q-input>
          </q-card-section>
          <q-card-section class="q-pt-none">
            <q-input
            v-model="documentToAdd.Description"
            dense
            outlined
            ref="modalDescription"></q-input>
          </q-card-section>
          <q-card-section class="q-pt-none">
            <q-select
            :options="categoryOptions"
            dense
            outlined
            ref="modalDocCategory"
            v-model="documentToAdd.DocCategory" label="Please select" map-options emit-value ></q-select>
            <modal-buttons />
          </q-card-section>
        </form>
        <pre>{{ documentToAdd }}</pre>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      documentToAdd: {
        ProjectId: this.$q.localStorage.getItem('selectedProjectId'),
        DocName: '',
        FilePath: '',
        Description: '',
        DocCategory: ''
      },
      categoryOptions: ['Application Form',
        'Project Officer Report',
        'Documents supporting Application form',
        'Contract',
        'Local Rep Report',
        'Visit Report',
        'Other Correspondence',
        'Project Report',
        'General Correspondence',
        'Photograph'],
      selected_file: null,
      documentUploaded: false
    }
  },
  methods: {
    submitForm () {
      if (this.documentUploaded) {
        this.saveDocument()
        this.$emit('close')
      } else {
        alert('Please upload a file first')
      }
    },
    file_selected (file) {
      this.selected_file = file[0]
      this.check_if_document_upload = true
    },
    uploadFile () {
      if (this.selected_file) {
        let fd = new FormData()
        fd.append('file', this.selected_file[0])

        this.$store.dispatch('projectDocuments/uploadFile', { fileData: fd, projectId: this.documentToAdd.ProjectId })
        this.documentToAdd.FilePath = this.documentToAdd.ProjectId + '/' + this.selected_file[0].name
        this.documentUploaded = true
      } else {
        alert('No file selected!')
      }
    },
    async saveDocument () {
      this.$store.dispatch('projectDocuments/addProjectDocument', { item: this.documentToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
