<template>
    <q-drawer
      show-if-above
      :width="200"
      :breakpoint="400"
    >
      <q-img class="absolute-top" src="https://cdn.quasar.dev/img/material.png" style="height: 100%">
        <div class="absolute-top bg-transparent">
          <q-avatar size="56px" class="q-mb-sm">
            <img src="../assets/LogoOnTransparent.gif">
          </q-avatar>
        </div>
      </q-img>
      <div class="absolute-bottom bg-transparent">
            <q-item>
            <q-item-section avatar>
                <q-icon name="account_circle" />
            </q-item-section>

            <q-item-section>{{ this.fullname }}</q-item-section>
            </q-item>
        </div>

    </q-drawer>
</template>

<script>
export default {
  data: () => ({
    fullname: ''
  }),
  mounted () {
    this.fullname = this.$msal.data.user.name
  }
}
</script>
