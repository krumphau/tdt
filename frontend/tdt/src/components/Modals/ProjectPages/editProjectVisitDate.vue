<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Project Visit</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-input dense v-model="projectVisit.visitStart" label="Visit Start" outlined :rules="[val => !!val || 'Field is required']" ref='visitStart' >
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qVisitStartProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="projectVisit.visitStart" @input="() => $refs.qVisitStartProxy.hide()" mask="DD/MM/YYYY"/>
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section><q-card-section class="q-pt-none">
             <q-input dense v-model="projectVisit.visitEnd" label="Visit End" outlined :rules="[val => !!val || 'Field is required']" ref='visitEnd' >
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qVisitEndProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="projectVisit.visitEnd" @input="() => $refs.qVisitEndProxy.hide()" mask="DD/MM/YYYY"/>
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense v-model="projectVisit.visitor" label="Visitor" outlined :rules="[val => !!val || 'Field is required']" ref='visitor'/>
            </q-card-section>
           <modal-buttons />
        </form>
    </q-card>

</template>

<script>
import { date } from 'quasar'
export default {
  props: ['projectVisit'],
  methods: {
    submitForm () {
      this.$refs.visitStart.validate()
      this.$refs.visitEnd.validate()
      this.$refs.visitor.validate()
      if (!this.$refs.visitStart.hasError && !this.$refs.visitEnd.hasError && !this.$refs.visitor.hasError) {
        var errors = false
        if (!date.isValid(this.formatTheDate(this.projectVisit.visitStart))) {
          alert('Please enter the Visit Start Date in DD/MM/YYYY format')
          errors = true
        }
        if (!date.isValid(this.formatTheDate(this.projectVisit.visitEnd))) {
          alert('Please enter the Visit End Date in DD/MM/YYYY format')
          errors = true
        }
        if (!errors) {
          this.projectVisit.visitStart = this.formatTheDate(this.projectVisit.visitStart)
          this.projectVisit.visitEnd = this.formatTheDate(this.projectVisit.visitEnd)
          this.$store.dispatch('projectVisits/updateProjectVisit', { item: this.projectVisit })
          this.$emit('close')
        }
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
  created () {
    this.projectVisit.visitStart = date.formatDate(this.projectVisit.visitStart, 'DD/MM/YYYY')
    this.projectVisit.visitEnd = date.formatDate(this.projectVisit.visitEnd, 'DD/MM/YYYY')
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
