<template>
  <q-page padding>
    <div>
      <h3>TDT Projects</h3>
      <q-btn label="Create New Project" to="/project"/>
      <br/>
      <h5>Or choose an existing project...</h5>
      <q-btn-dropdown label="Please Select"/>
      <br/>
      <h5>Search Projects</h5>
      <q-input label="Project Identifier" />
      <q-input label="Name" />
      <q-input label="Keywords" />
      <q-item-label>Region</q-item-label><q-btn-dropdown label="Please Select"/>
      <q-item-label>NGO</q-item-label><q-btn-dropdown label="Please Select"/>
      <q-item-label>Officer</q-item-label><q-btn-dropdown label="Please Select"/>
      <q-item-label>Status Code</q-item-label><q-btn-dropdown label="Please Select"/>
      <q-item-label>Funder</q-item-label><q-btn-dropdown label="Please Select"/>
      <q-btn label="Search" />
    </div>
  </q-page>
</template>

<script>
export default {
  name: 'PageIndex',
  drawer1: false
}
</script>
