<template>
    <q-card style="min-width: 350px">
        <modal-header>Add New Project Visit</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-input dense v-model="visitDateToAdd.VisitStart" label="Visit Start" outlined >
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qVisitStartProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="visitDateToAdd.VisitStart" @input="() => $refs.qVisitStartProxy.hide()" />
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section>
             <q-card-section class="q-pt-none">
             <q-input dense v-model="visitDateToAdd.VisitEnd" label="Visit End" outlined >
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qVisitEndProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="visitDateToAdd.VisitEnd" @input="() => $refs.qVisitEndProxy.hide()" />
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense v-model="visitDateToAdd.Visitor" label="Visitor" outlined  />
            </q-card-section>
           <modal-buttons />
        </form>
    </q-card>

</template>

<script>
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
      this.saveVisitDate()
      this.$emit('close')
    },
    async saveVisitDate () {
      this.$store.dispatch('projectVisits/addProjectVisit', { item: this.visitDateToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
