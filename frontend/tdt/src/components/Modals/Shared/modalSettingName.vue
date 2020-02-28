<template>
    <q-card-section class="q-pt-none">
            <q-input
                outlined
                label="Category Name"
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
