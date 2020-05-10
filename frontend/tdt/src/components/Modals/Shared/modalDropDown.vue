<template>
    <q-card-section class="q-pt-none">
            <q-select
                outlined
                label="Name"
                :value="Name"
                @input="$emit('update:Name', $event)"
                dense
                :rules="[val => !!val || 'Field is required']"
                ref="Name"/>
    </q-card-section>
</template>

<script>
export default {
  props: ['Name']
}
</script>
