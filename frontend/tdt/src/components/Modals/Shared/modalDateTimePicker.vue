<template>
    <q-card-section class="q-pt-none">
            <q-input
                outlined
                label="Date"
                :value="date"
                @input="$emit('update:date', $event)"
                dense
                ref="Date"
                mask="date">
                <template v-slot:append>
                    <q-icon name="event" class="cursor-pointer">
                    <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                        <q-date :value="date" @input="() => $refs.qDateProxy.hide()" />
                    </q-popup-proxy>
                    </q-icon>
                </template>
            </q-input>
    </q-card-section>
</template>

<script>
export default {
  props: ['date']
}
</script>
