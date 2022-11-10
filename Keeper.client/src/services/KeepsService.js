import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";



class KeepsService {
  // visitors can see all keeps
  // when keep is viewed views ++
  async getKeeps() {
    const res = await api.get('api/keeps')
    logger.log('getting keeps: Service', res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
    // AppState.keeps = res.data
  }










  // logged in user can create and delete keeps
  async createKeep(data) {
    const res = await api.post('api/keeps', data)
    logger.log('creating keep in service', res.data)
    AppState.keeps.push(new Keep(res.data))
  }



  async deleteKeep(id) {
    const res = await api.delete('api/keeps', + id)
    logger.log('deleting keep in service', res.data)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
  }
}


export const keepsService = new KeepsService()