import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";



class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data.map(k => new Keep(k))
  }


  async getKeepById(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    AppState.activeKeep = res.data
    logger.log("getting keep", res.data)
  }




  async createKeep(data) {
    const res = await api.post('api/keeps', data)
    AppState.keeps.push(new Keep(res.data))
  }



  async deleteKeep(id) {
    const res = await api.delete(`api/keeps/${id}`, + id)
    logger.log('deleting keep in service', res.data)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
  }
}


export const keepsService = new KeepsService()