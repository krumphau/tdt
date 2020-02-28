<template>
  <q-page padding>
    <leftDrawer />
    <div>
      <h3>TDT Projects</h3>
      <q-btn class="glossy" rounded color="indigo-12" label="Create New Project" to="/project"/>
      <br/>
      <h5>Or choose an existing project...</h5>
      <q-select v-model="searchProject" label="Project" map-options emit-value option-value="Id" option-label="ProjectName" outlined :options="existingProjects" />
      <br/>
      <h5>Search Projects</h5>
      <q-input outlined label="Project Identifier" />
      <q-input outlined label="Name" />
      <q-input outlined label="Keywords" />
      <q-item class="row">
      <q-item-label>Region</q-item-label>
        <q-item-section avatar>
            <q-icon name="language" />
        </q-item-section>
        <q-item-section>
          <q-select v-model="searchRegion" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="regions" />
        </q-item-section>
      </q-item>
      <q-item class="row">
      <q-item-label>NGO</q-item-label>
        <q-item-section avatar>
            <q-icon name="language" />
        </q-item-section>
        <q-item-section>
          <q-select v-model="searchNGO" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="ngos" />
        </q-item-section>
      </q-item>
      <q-item class="row">
      <q-item-label>Project Officer</q-item-label>
        <q-item-section avatar>
            <q-icon name="language" />
        </q-item-section>
        <q-item-section>
          <q-select v-model="searchOfficer" label="Please select" map-options emit-value option-value="Id" option-label="FullName" outlined :options="officers" />
        </q-item-section>
      </q-item>
      <q-item class="row">
      <q-item-label>Status Code</q-item-label>
        <q-item-section avatar>
            <q-icon name="language" />
        </q-item-section>
        <q-item-section>
          <q-select v-model="searchStatusCode" label="Please select" map-options emit-value option-value="Id" option-label="Description" outlined :options="statuscodes" />
        </q-item-section>
      </q-item>
      <q-item class="row">
      <q-item-label>Funder</q-item-label>
        <q-item-section avatar>
            <q-icon name="language" />
        </q-item-section>
        <q-item-section>
          <q-select v-model="searchFunder" label="Please select" map-options emit-value option-value="Id" option-label="Name" outlined :options="funders" />
        </q-item-section>
      </q-item>
      <q-btn class="glossy" rounded color="indigo-12" label="Search" />
    </div>
  </q-page>
</template>

<script>
import axios from 'axios'
export default {
  name: 'PageIndex',
  drawer1: false,
  data: () => ({
    searchProject: null,
    searchRegion: null,
    searchNGO: null,
    searchOfficer: null,
    searchStatusCode: null,
    searchFunder: null,
    existingProjects: [],
    regions: [],
    ngos: [],
    officers: [],
    statuscodes: [],
    funders: []
  }),
  mounted () {
    axios.get('http://localhost:5000/projects').then(response => {
      this.existingProjects = response.data
    })
    axios.get('http://localhost:5000/regions').then(response => {
      this.regions = response.data
    })
    axios.get('http://localhost:5000/ngos').then(response => {
      this.ngos = response.data
    })
    axios.get('http://localhost:5000/projectofficers').then(response => {
      this.officers = response.data
    })
    axios.get('http://localhost:5000/statuscodes').then(response => {
      this.statuscodes = response.data
    })
    axios.get('http://localhost:5000/funders').then(response => {
      this.funders = response.data
    })
  },
  components: {
    'leftDrawer': require('components/plainLeftDrawer.vue').default
  }
}
</script>
