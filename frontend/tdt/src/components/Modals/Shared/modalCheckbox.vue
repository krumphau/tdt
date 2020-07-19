<template>
    <q-card-section>
        <q-checkbox v-model="Selected" :value="Selected" @input="$emit('update:Selected', $event)" label="High Level" />
    </q-card-section>
</template>

<script>
export default {
  props: ['Selected']
}
</script>
