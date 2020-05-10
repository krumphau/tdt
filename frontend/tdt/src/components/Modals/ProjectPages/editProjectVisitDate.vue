<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Project Visit</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-input dense v-model="projectVisit.VisitStart" label="Visit End" outlined >
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qVisitStartProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="projectVisit.VisitStart" @input="() => $refs.qVisitStartProxy.hide()" />
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section><q-card-section class="q-pt-none">
             <q-input dense v-model="projectVisit.VisitEnd" label="Visit End" outlined >
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qVisitEndProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="projectVisit.VisitEnd" @input="() => $refs.qVisitEndProxy.hide()" />
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense v-model="projectVisit.Visitor" label="Visitor" outlined  />
            </q-card-section>
           <modal-buttons />
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['projectVisit'],
  methods: {
    submitForm () {
      this.$store.dispatch('projectVisits/updateProjectVisit', { item: this.projectVisit })
      this.$emit('close')
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
