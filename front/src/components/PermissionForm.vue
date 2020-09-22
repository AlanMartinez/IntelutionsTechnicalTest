<template>
  <div>
    <dynamic-form
      ref="dynamicForm"
      :schema="schema"
      @input="input"
      @change="change"
      @submit="submit"
    ></dynamic-form>
  </div>
</template>

<script>
import DynamicForm from "@/components/DynamicForm";
import {PermissionTypeService} from '../services/permissionType'
import {PermissionService} from '../services/permission'
export default {
  name: "PermissionForm",
  props: {
    permission: {
      type: Object,
      default: function () {
        return {
          id: null,
          employeeName: null,
          employeeLastName: null,
          permissionDate: null,
          permissionTypeId: null,
        };
      },
    },
  },
  components: { DynamicForm },
  data() {
    return {
      typePermits: [
        {
          value: null,
          text: "Seleccione tipo de permiso",
        },
      ],
    };
  },
  mounted: async function(){
    this.typePermits = this.typePermits.concat(await PermissionTypeService.getAll())
  },
  methods: {
    async input(event) {
      var a = this.schema.elements.find((x) => x.key === event.key);
      a.value = event.value;
    },
    async change(event) {
      var a = this.schema.elements.find((x) => x.key === event.key);
      a.value = event.value;
    },
    async submit() {
      var request = {
        id: this.permission.id,
        employeeName: this.schema.elements.find((x) => x.key === "employeeName").value,
        employeeLastName: this.schema.elements.find((x) => x.key === "employeeLastName").value,
        permissionDate: this.schema.elements.find((x) => x.key === "permissionDate").value,
        permissionTypeId: this.schema.elements.find((x) => x.key === "permissionTypeId").value,
      };
      
      if(this.permission.id)
      {
        await PermissionService.update(request)
        this.makeToast("Permiso editado correctamente", "Edicion")
      }
      else
      {
        var newPermission = await PermissionService.create(request)
        this.permission = newPermission
        this.makeToast("Permiso creado correctamente", "Creacion")
      }
    },
    makeToast(msj, title) {
      this.$bvToast.toast(msj, {
        title: title,
        autoHideDelay: 5000,
        variant: "success"
      })
    },
  },
  computed: {
    schema() {
      return {
        bSave: this.permission && this.permission.id ? "Editar" : "Guardar",
        bBack: "Regresar",
        elements: [
          {
            key: "employeeName",
            component: "b-form-input",
            value:
              this.permission && this.permission.employeeName
                ? this.permission.employeeName
                : null,
            placeholder: "Nombre de empleado",
            md: "4",
            offsetMd: "4",
            validations: "required|max:100",
            readonly: this.permission && this.permission.id ? true : false,
          },
          {
            key: "employeeLastName",
            component: "b-form-input",
            value:
              this.permission && this.permission.employeeLastName
                ? this.permission.employeeLastName
                : null,
            placeholder: "Apellido de empleado",
            md: "4",
            offsetMd: "4",
            validations: "required|max:100",
            readonly: this.permission && this.permission.id ? true : false,
          },
          {
            key: "permissionDate",
            component: "b-form-datepicker",
            value:
              this.permission && this.permission.permissionDate
                ? this.permission.permissionDate
                : new Date(),
            placeholder: "Fecha de permiso",
            md: "4",
            offsetMd: "4",
            validations: "required",
            min: new Date(),
            todayButton: "today-button",
            resetButton: "reset-button",
            closeButton: "close-button",
            locale: "es",
          },
          {
            key: "permissionTypeId",
            component: "b-form-select",
            value:
              this.permission && this.permission.permissionTypeId
                ? this.permission.permissionTypeId
                : null,
            options: this.typePermits,
            md: "4",
            offsetMd: "4",
            validations: "required",
          },
        ],
      };
    },
  },
};
</script>
