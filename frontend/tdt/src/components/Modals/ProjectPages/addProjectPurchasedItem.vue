<template>
    <q-card style="min-width: 350px">
        <modal-header>Add Purchased Item</modal-header>

        <form @submit.prevent="submitForm">
            <q-card-section class="q-pt-none">
             <q-input dense v-model="purchasedItemToAdd.PurchasedItem" label="Item Description" outlined  />
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense v-model="purchasedItemToAdd.DatePurchased" label="Date Purchased" outlined >
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qDatePurchasedProxy" transition-show="scale" transition-hide="scale">
                        <q-date v-model="purchasedItemToAdd.DatePurchased" @input="() => $refs.qDatePurchasedProxy.hide()" />
                    </q-popup-proxy>
                    </q-icon>
                </template>
             </q-input>
            </q-card-section>
            <q-card-section class="q-pt-none">
             <q-input dense v-model="purchasedItemToAdd.ItemCost" label="Item Cost" outlined  />
            </q-card-section>
           <modal-buttons />
        </form>
        <pre>{{ purchasedItemToAdd }}</pre>
    </q-card>

</template>

<script>
export default {
  data () {
    return {
      purchasedItemToAdd: {
        ProjectId: this.$q.localStorage.getItem('selectedProjectId'),
        PurchasedItem: null,
        DatePurchased: null,
        ItemCost: null
      }
    }
  },
  methods: {
    submitForm () {
      this.savePurchasedItem()
      this.$emit('close')
    },
    async savePurchasedItem () {
      this.$store.dispatch('purchasedItems/addPurchasedItem', { item: this.purchasedItemToAdd })
    }
  },
  components: {
    'modal-header': require('components/Modals/Shared/modalHeader.vue').default,
    'modal-buttons': require('components/Modals/Shared/modalButtons.vue').default
  }
}
</script>
