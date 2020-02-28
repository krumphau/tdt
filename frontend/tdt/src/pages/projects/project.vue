<template>
    <q-page padding>
        <leftDrawer />
        <div>
            <h5>Add New Project</h5>
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
                    <td class="text-right"><q-input outlined dense></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Name</td>
                    <td class="text-right"><q-input outlined dense></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Application Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="date" mask="date" :rules="['date']">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="date" @input="() => $refs.qDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Approved</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="date" mask="date" :rules="['date']">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="date" @input="() => $refs.qDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Date Grant Paid</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="date" mask="date" :rules="['date']">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="date" @input="() => $refs.qDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Target Completion Date</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="date" mask="date" :rules="['date']">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="date" @input="() => $refs.qDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Requested</td>
                    <td class="text-right"><q-input outlined dense prefix="£"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Approved</td>
                    <td class="text-right"><q-input outlined dense prefix="£"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Amount of Grant Paid</td>
                    <td class="text-right"><q-input outlined dense prefix="£"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Total Project Cost</td>
                    <td class="text-right"><q-input outlined dense prefix="£"></q-input></td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select outlined dense v-model="model" :options="options" label="Please select" />
                            </q-item-section>
                            <q-item-section avatar clickable>
                                <q-icon name="add" title="Add a new Status Code"/>
                            </q-item-section>
                        </q-item>
                        </td>
                    </tr>
                    <tr>
                    <td class="text-left">Status Code Changed</td>
                    <td class="text-right">
                        <q-input outlined dense v-model="date" mask="date" :rules="['date']">
                            <template v-slot:append>
                                <q-icon name="event" class="cursor-pointer">
                                <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                                    <q-date v-model="date" @input="() => $refs.qDateProxy.hide()" />
                                </q-popup-proxy>
                                </q-icon>
                            </template>
                        </q-input>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Region</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select outlined dense v-model="model" :options="options" label="Please select" />
                            </q-item-section>
                            <q-item-section avatar clickable>
                                <q-icon name="add" title="Add a new Region"/>
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">District</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select outlined dense v-model="model" :options="options" label="Please select" />
                            </q-item-section>
                            <q-item-section avatar clickable >
                                <q-icon name="add" title="Add a new District"/>
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                    <td class="text-left">Project Officer</td>
                    <td class="text-right">
                        <q-item>
                            <q-item-section>
                                <q-select outlined dense v-model="model" :options="options" label="Please select" />
                            </q-item-section>
                            <q-item-section avatar clickable>
                                <q-icon name="add" title="Add a new Project Officer"/>
                            </q-item-section>
                        </q-item>
                    </td>
                    </tr>
                    <tr>
                        <td class="text-left">
                        </td>
                        <td class="text-right">
                            <q-btn flat label="Cancel" to="/" />
                            <q-btn flat label="Save" type="submit" />
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
