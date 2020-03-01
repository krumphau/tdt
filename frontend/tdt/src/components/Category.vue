<template>
  <q-item
clickable
v-ripple>
<q-item-section side top>

<q-item-section>
<div class="row">
<div class="column">
{{ category.CategoryName }}
</div>
</div>
</q-item-section>
</q-item-section>

<q-item-section
side>
<div class="row">
<div class="column">
<q-checkbox
:value="getHighLevelBool(category.HighLevelCategory)"
class="no-pointer-events" />
</div>
</div>
</q-item-section>

<q-item-section side>
<div class="row">
<q-btn
@click.stop="showEditCategory = true"
flat
round
dense
color="primary"
icon="edit" />
<q-btn
@click.stop="deleteRow(id)"
flat
round
dense
color="red"
icon="delete" />
</div>
</q-item-section>

<q-dialog v-model="showEditCategory">
<edit-category
@close="showEditCategory = false"
:name="name"
:id="id" />
</q-dialog>

</q-item>
</template>

<script>
import axios from 'axios'

export default {
  props: ['category', 'id'],
  data () {
    return {
      showEditCategory: false
    }
  },
  methods: {
    promptToDelete (id) {
      this.$q.dialog({
        title: 'Confirm',
        message: 'Really delete?',
        ok: {
          push: true
        },
        cancel: {
          color: 'negative'
        },
        persistent: true
      }).onOk(() => {
        this.deleteCategory(id)
      })
    },
    deleteRow (rowId) {
      if (confirm('Are you sure you want to delete category with ID ' + rowId + '?')) {
        confirm('params: { id:' + rowId + ' }')
        axios.delete('http://localhost:5000/category/' + rowId, { headers: {
          'Access-Control-Max-Age': 86400,
          'Content-Type': 'text/plain'
        } })
      } else {
        confirm('Delete cancelled')
      }
    },
    getHighLevelBool: function (rowValue) {
      return rowValue === 1
    }
  },
  components: {
    'edit-category': require('components/Modals/EditCategory.vue').default
  }
}
</script>
