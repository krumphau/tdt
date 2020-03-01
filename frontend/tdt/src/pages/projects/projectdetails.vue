<template>
    <q-page padding>
        <leftDrawer />
        <div>
            <h5>Project Details</h5>
        </div>
        <!-- <q-item class="row" outlined>
            <q-item-label padding>
                Project Identifier
            </q-item-label>
            <q-item-section padding>
                <q-input outlined dense></q-input>
            </q-item-section>
        </q-item> -->
        <div class="q-pa-md">
            <form>
            <q-markup-table flat bordered>
                <tbody>
                    <tr>
                    <td class="text-left" width="20%">Project Identifier</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Name</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Application Date</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Approved</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Paid</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Target Completion Date</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Requested</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Approved</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Paid</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Total Project Cost</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code</td>
                    <td class="text-right"></td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code Changed</td>
                    <td class="text-right">
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Region</td>
                    <td class="text-right">
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">District</td>
                    <td class="text-right">
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer</td>
                    <td class="text-right">
                    </td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn class="glossy" rounded color="indigo-12" label="Edit" to="/" />
                            <q-btn class="glossy" rounded color="indigo-12" label="Delete" type="submit" />
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
