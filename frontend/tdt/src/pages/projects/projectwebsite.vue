<template>
    <q-page padding>
        <div>
            <h5>Project Website</h5>
        </div>
        <leftDrawer />
        <div class="q-pa-md">
            <form>
            <q-markup-table flat bordered>
                <tbody>
                    <tr>
                    <td class="text-left" width="20%">Project Description and Needs</td>
                    <td class="text-right"><q-input outlined></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Impact of the Project</td>
                    <td class="text-right"><q-input outlined></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Picture</td>
                    <td>
                        <q-img
                        :src="url"
                        spinner-color="white"
                        style="height: 140px; max-width: 150px"
                        />
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Picture Caption</td>
                    <td class="text-right">
                        <q-input outlined></q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Latitude [Decimal]</td>
                    <td class="text-right">
                        <q-input outlined></q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Longitude [Decimal]</td>
                    <td class="text-right">
                        <q-input outlined></q-input></td>
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
      url: 'https://placeimg.com/500/300/nature',
      options: [
        'Google', 'Facebook', 'Twitter', 'Apple', 'Oracle'
      ],
      date: ''
    }
  },
  components: {
    'leftDrawer': require('components/projectLeftDrawer.vue').default
  },
  methods: {
    refresh () {
      this.url = 'https://placeimg.com/500/300/nature?t=' + Math.random()
    }
  }
}
</script>
