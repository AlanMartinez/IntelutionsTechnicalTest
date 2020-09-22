import axios from 'axios'

const CONTROLLER = '/permission'
const URL_API = process.env.VUE_APP_API + CONTROLLER

const PermissionService = {
    async getAll(){
        let modelPermission = await axios.get(URL_API)
        return modelPermission.data
    },

    async create(request){
        let permission = await axios.post(URL_API, request)
        return permission.data
    },

    async update(request){
        await axios.put(URL_API, request)
    },

    async delete(id){
        await axios.delete(URL_API+"?id="+id)
    },

    async get(id){
        let modelPermission = await axios.get(URL_API+"/getPermission?id="+id)
        return modelPermission.data
    }
}

export {PermissionService}