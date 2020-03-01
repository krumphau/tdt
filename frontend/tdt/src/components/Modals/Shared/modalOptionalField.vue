<template>
    <q-card-section class="q-pt-none">
            <q-input
                outlined
                label="Name"
                :value="Name"
                @input="$emit('update:Name', $event)"
                dense
                ref="Name"/>
    </q-card-section>
</template>

<script>
export default {
  props: ['Name']
}
</script>
