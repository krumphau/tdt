<template>
    <q-page padding>
        <q-drawer
        show-if-above
        :width="200"
        :breakpoint="400"
        >
            <q-img class="absolute-top" src="https://cdn.quasar.dev/img/material.png" style="height: 150px">
            <div class="absolute-top bg-transparent">
            <q-avatar size="56px" class="q-mb-sm">
                <img src="../../assets/LogoOnTransparent.gif">
            </q-avatar>
            </div>
            </q-img>
            <q-scroll-area style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd">
            <q-list padding>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="subject" />
                </q-item-section>

                <q-item-section>
                    Details
                </q-item-section>
                </q-item>

                <q-item active clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="assignment" />
                </q-item-section>

                <q-item-section>
                    Notes
                </q-item-section>
                </q-item>

                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="language" />
                </q-item-section>

                <q-item-section>
                    Web Site
                </q-item-section>
                </q-item>

                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="widgets" />
                </q-item-section>

                <q-item-section>
                    Categories
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="description" />
                </q-item-section>

                <q-item-section>
                    Documents
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="account_balance" />
                </q-item-section>

                <q-item-section>
                    Funders
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="location_city" />
                </q-item-section>

                <q-item-section>
                    NGOs
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="work" />
                </q-item-section>

                <q-item-section>
                    Other Bodies
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="shopping_cart" />
                </q-item-section>

                <q-item-section>
                    Purchased Items
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="mood" />
                </q-item-section>

                <q-item-section>
                    Visit Dates
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="extension" />
                </q-item-section>

                <q-item-section>
                    Related Projects
                </q-item-section>
                </q-item>
            </q-list>
            </q-scroll-area>
        </q-drawer>
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
  }
}
</script>
