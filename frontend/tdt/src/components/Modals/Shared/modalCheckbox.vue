<template>
    <q-card-section>
        <q-checkbox :value="Selected" label="High Level" />
    </q-card-section>
</template>

<script>
export default {
  props: ['Selected']
}
</script>
