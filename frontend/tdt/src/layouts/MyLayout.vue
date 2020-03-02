<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-toolbar-title>
          TDT
        </q-toolbar-title>
        <div><q-btn to="/" label="Home"/></div>
        <div><q-btn-dropdown label="Settings">
          <q-list dense>
            <q-item tag="label" clickable>
              <q-item-section><router-link to="/settings/districts">Districts</router-link></q-item-section>
            </q-item>
            <q-item tag="label" clickable>
              <q-item-section><router-link to="/settings/funders">Funders</router-link></q-item-section>
            </q-item>
            <q-item tag="label" clickable>
              <q-item-section><router-link to="/settings/ngos">NGOs</router-link></q-item-section>
            </q-item>
            <q-item tag="label" clickable>
              <q-item-section><router-link to="/settings/otherbodies">Other Bodies</router-link></q-item-section>
            </q-item>
            <q-item tag="label" clickable>
              <q-item-section><router-link to="/settings/projectofficers">Project Officers</router-link></q-item-section>
            </q-item>
            <q-item tag="label" clickable>
              <q-item-section><router-link to="/settings/regions">Regions</router-link></q-item-section>
            </q-item>
            <q-item tag="label" clickable>
              <q-item-section><router-link to="/settings/statuscodes">Status Codes</router-link></q-item-section>
            </q-item>
            <q-item tag="label" clickable>
              <q-item-section><router-link to="/settings/categories">Categories</router-link></q-item-section>
            </q-item>
          </q-list>
          </q-btn-dropdown></div>
        <div><q-btn label="Reports" to="/reports/search"/></div>
        <div>
          <q-btn-dropdown label="Account">
            <q-item tag="label" clickable>
              <q-item-section>Log Out</q-item-section>
            </q-item>
          </q-btn-dropdown></div>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
export default {
  name: 'MyLayout'
}
</script>
