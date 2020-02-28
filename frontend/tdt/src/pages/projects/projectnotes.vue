<template>
    <q-page padding>
        <div>
            <h5>Project Notes</h5>
        </div>
        <leftDrawer />
        <div class="q-pa-md">
            <form>
            <q-markup-table flat bordered>
                <tbody>
                    <tr>
                    <td class="text-left" width="20%">Project Status</td>
                    <td class="text-right"><q-input outlined></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer Recommendation</td>
                    <td class="text-right"><q-input outlined type="textarea"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Keywords</td>
                    <td class="text-right">
                        <q-input outlined></q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Summary</td>
                    <td class="text-right">
                        <q-input outlined type="textarea"></q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Problems (SC13 Only)</td>
                    <td class="text-right">
                        <q-input outlined type="textarea"></q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Strengths and Weaknesses</td>
                    <td class="text-right">
                        <q-input outlined type="textarea"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Finance and Other Funders</td>
                    <td class="text-right"><q-input outlined type="textarea"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Local Contribution &amp; Running Costs</td>
                    <td class="text-right"><q-input outlined type="textarea"></q-input></td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Edit" />
                        </td>
                    </tr>
                </tbody>
            </q-markup-table>
            </form>
        </div>
    </q-page>
</template>

<script>
export default {
  data () {
    return {
      model: null,
      options: [
        'Google', 'Facebook', 'Twitter', 'Apple', 'Oracle'
      ],
      date: ''
    }
  },
  components: {
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  }
}
</script>
