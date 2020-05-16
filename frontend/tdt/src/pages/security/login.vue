// src/pages/Login.vue

<template>
  <q-page padding class="">
    <q-card >
  <q-card-title>
    Already a user? Log In To SwapSteem!
  </q-card-title>
  <q-card-separator />
  <q-card-main>
      <q-field
        icon="mail"
        label="Email"
        label-width= 3
        @blur="form.email.$touch"
        :error="form.email.$error"
        helper="Enter your registered email address to Log in"
        error-label="Please type a valid email address"
        >
        <q-input
        type="email"
        v-model="form.email"
        />
      </q-field>
      <q-field
        icon="vpn_key"
        label="Password"
        label-width= 3
        helper="Enter your password"
        :error="form.email.$error"
        error-label="Please type a valid password"
        >
        <q-input
        type="password"
        v-model="form.password"
        />
      </q-field>
  </q-card-main>
  <q-card-separator />
  <q-card-actions align="center">
    <q-btn color="primary" align="center" label="Log In" @click="submit" />
  </q-card-actions>
</q-card>
<pre>{{ user }}</pre>
</q-page>
</template>

<script>
/* import { required, email } from 'vuelidate/lib/validators' */

export default {
  data () {
    return {
      form: {
        email: '',
        password: ''
      },
      user: {}
    }
  },
  /* validations: {
    form: {
      email: { required, email },
      password: { required }
    }
  }, */
  methods: {
    submit () {
      if (!this.$msal.isAuthenticated()) {
        alert('Signing in')
        this.$msal.signIn()
      }
      this.user = {
        ...this.$msal.data.user
      }
      /* this.$v.form.$touch()

      if (this.$v.form.$error) {
        this.$q.notify('Please review fields again.')
      }
      this.$store.dispatch('user/login', {
        email: this.form.email,
        password: this.form.password,
        strategy: 'local'
      }).then(() => {
        this.$router.push('/')
      }) */
    }
  }
}
</script>
