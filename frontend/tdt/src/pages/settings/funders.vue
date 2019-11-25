<template>
  <q-page padding>
    <template>
  <div class="q-pa-md">
    <q-table
      grid
      title="Funders"
      :data="tableData"
      :columns="columns"
      row-key="Id"
      :filter="filter"
      hide-header
    >
      <template v-slot:top-right>
        <q-input borderless dense debounce="300" v-model="filter" placeholder="Search">
          <template v-slot:append>
            <q-icon name="search" />
          </template>
        </q-input>
      </template>

      <template v-slot:item="props">
        <div          class="q-pa-xs col-xs-12 col-sm-6 col-md-4 col-lg-3 grid-style-transition"
          :style="props.selected ? 'transform: scale(0.95);' : ''"
        >
          <q-card :class="props.selected ? 'bg-grey-2' : ''">
            <q-card-section>
              {{ props.row.Name }}
            </q-card-section>
            <q-separator />
            <q-list dense>
              <q-item v-for="col in props.cols.filter(col => col.name !== 'Id' && col.name !== 'name')" :key="col.Id">
                <q-item-section>
                  <q-item-label>{{ col.label }}</q-item-label>
                </q-item-section>
                <q-item-section side>
                  <q-item-label caption>{{ col.value }}</q-item-label>
                </q-item-section>
              </q-item>
            </q-list>
            <q-separator />
            <q-card-section>
              <q-btn label="Edit" align="left"/>
              <q-btn label="Delete" align="right"/>
            </q-card-section>
          </q-card>
        </div>
      </template>
    </q-table>
  </div>
</template>
  </q-page>
</template>

<script>
export default {
  data: () => ({
    columns: [
      {
        name: 'Id',
        label: 'Id',
        field: 'Id'
      },
      {
        name: 'name',
        label: 'Name',
        field: 'Name'
      },
      {
        name: 'address1',
        label: 'Address 1',
        field: 'Address1'
      },
      {
        name: 'address2',
        label: 'Address 2',
        field: 'Address2'
      },
      {
        name: 'address3',
        label: 'Address 3',
        field: 'Address3'
      },
      {
        name: 'town',
        label: 'Town',
        field: 'Town'
      },
      {
        name: 'county',
        label: 'County',
        field: 'County'
      },
      {
        name: 'tel',
        label: 'Telephone',
        field: 'Tel'
      },
      {
        name: 'mainContact',
        label: 'Main Contact',
        field: 'MainContact'
      },
      {
        name: 'amount',
        label: 'Amount',
        field: 'Amount'
      }
    ],
    tableData: [
      {
        'Id': '1',
        'Name': 'A. Funder',
        'Tel': '01737557052',
        'Main Contact': 'Joe Bloggs',
        'Amount': '999.99',
        'Address1': '65 Reddown Road',
        'Address2': '',
        'Address3': '',
        'Town': 'Coulsdon',
        'County': 'Surrey',
        'Postcode': 'CR5 1AP'
      }
    ]
  })
}
</script>
