import axios from 'axios'

const CONTROLLER = "/permissionType"
const URL_API = process.env.VUE_APP_API + CONTROLLER

const PermissionTypeService = {
    async getAll(){
        let response = await axios.get(URL_API)
        return response.data
    }
}

export {PermissionTypeService}