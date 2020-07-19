<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Project Visit</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-input dense v-model="visitDateToAdd.VisitStart" label="Visit Start" outlined :rules="[val => !!val || 'Field is required']" ref='visitStart'>
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qVisitStartProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="visitDateToAdd.VisitStart" @input="() => $refs.qVisitStartProxy.hide()" mask="DD/MM/YYYY"/>
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section>
             <q-card-section class="q-pt-none">
             <q-input dense v-model="visitDateToAdd.VisitEnd" label="Visit End" outlined :rules="[val => !!val || 'Field is required']" ref='visitEnd'>
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qVisitEndProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="visitDateToAdd.VisitEnd" @input="() => $refs.qVisitEndProxy.hide()" mask="DD/MM/YYYY"/>
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense v-model="visitDateToAdd.Visitor" label="Visitor" outlined :rules="[val => !!val || 'Field is required']" ref='visitor' />
            </q-card-section>
           <modal-buttons />
        </form>
    </q-card>

</template>

<script>
import { date } from 'quasar'
export default {
  data () {
    return {
      visitDateToAdd: {
        ProjectId: this.$q.localStorage.getItem('selectedProjectId'),
        VisitStart: null,
        VisitEnd: null,
        Visitor: null
      }
    }
  },
  methods: {
    submitForm () {
      this.$refs.visitStart.validate()
      this.$refs.visitEnd.validate()
      this.$refs.visitor.validate()
      if (!this.$refs.visitStart.hasError && !this.$refs.visitEnd.hasError && !this.$refs.visitor.hasError) {
        this.saveVisitDate()
      }
    },
    async saveVisitDate () {
      var errors = false
      if (!date.isValid(this.formatTheDate(this.visitDateToAdd.VisitStart))) {
        alert('Please enter the Visit Start Date in DD/MM/YYYY format')
        errors = true
      }
      if (!date.isValid(this.formatTheDate(this.visitDateToAdd.VisitEnd))) {
        alert('Please enter the Visit End Date in DD/MM/YYYY format')
        errors = true
      }
      if (!errors) {
        this.visitDateToAdd.VisitStart = this.formatTheDate(this.visitDateToAdd.VisitStart)
        this.visitDateToAdd.VisitEnd = this.formatTheDate(this.visitDateToAdd.VisitEnd)
        this.$store.dispatch('projectVisits/addProjectVisit', { item: this.visitDateToAdd })
        this.$emit('close')
      }
    },
    formatTheDate (x) {
      if (x != null && x.length === 10) {
        return x.split('/').reverse().join('-')
      } else {
        return null
      }
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
