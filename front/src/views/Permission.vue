<template>
  <div>
    <permission-form ref="permissionForm" :permission="permission"></permission-form>
  </div>
</template>

<script>
import PermissionForm from "@/components/PermissionForm";
import {PermissionService} from '../services/permission'
export default {
  name: "Permission",
  props: {},
  components: { PermissionForm },
  data() {
    return {
      id: null,
      permission: {
        id: null,
        employeeName: null,
        employeeLastName: null,
        permissionDate: null,
        permissionType: null,
      },
    };
  },
  methods: {},
  mounted: async function(){
		this.id = this.$route.params.id
		if (this.id)
		{
			this.permission = await PermissionService.get(this.id)
		}
  }
};
</script>
