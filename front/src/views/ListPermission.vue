<template>
  <div>
    <b-table striped hover :items="items" :fields="fields" >
      <template v-slot:cell(actions)="row">
        <b-button size="sm" class="mr-2 btn-warning" v-if="row.item" @click="editPermission(row.item.id)">
         Editar
        </b-button>
        <b-button size="sm" class="mr-2 btn-danger" v-if="row.item" @click="deletePermission(row.item.id)">
         Eliminar
        </b-button>

      </template>
    </b-table>
  </div>
</template>

<script>
  import {PermissionService} from '../services/permission'
  export default {
    data() {
      return {
        items: [],
        fields: [
          {
            key:'id',
          },
          {
            key: 'employeeName',
            label: 'Nombre de empleado',
            sortable: true
          },
          {
            key: 'employeeLastName',
            label: 'Apellido de empleado',
            sortable: false
          },
          {
            key: 'permissionType',
            label: 'Tipo de permiso',
            sortable: false,
          },
          {
            key: 'permissionDate',
            label: 'Fecha de permiso',
            sortable: false,
          },
          {
            key: 'actions'
          }
        ],
      }
    },
    mounted: async function(){
      this.items = await PermissionService.getAll()
    },
    methods: {
      async deletePermission(id){
        
        this.$bvModal.msgBoxConfirm('Desea eliminar?')
          .then(value => {
            if(value)
            {
              PermissionService.delete(id)
              this.items = this.items.filter(p => p.id != id);
            }
          })
      },
      editPermission(id){
        this.$router.push('/permission/'+id);
      },
      
    }
  }
</script>