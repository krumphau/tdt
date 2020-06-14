<template>
    <q-card style="min-width: 350px">
        <modal-header>Edit Purchased Item</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-input dense v-model="purchasedItem.purchasedItem" label="Item Description" outlined  />
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense v-model="purchasedItem.datePurchased" label="Date Purchased" outlined >
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qDatePurchasedProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="purchasedItem.datePurchased" @input="() => $refs.qDatePurchasedProxy.hide()" />
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense v-model.number="purchasedItem.itemCost" label="Item Cost" outlined />
            </q-card-section>
           <modal-buttons />

        <pre> {{ purchasedItem}} </pre>
        </form>
    </q-card>

</template>

<script>
export default {
  props: ['purchasedItem'],
  methods: {
    submitForm () {
      this.$store.dispatch('purchasedItems/updatePurchasedItem', { item: this.purchasedItem })
      this.$emit('close')
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
