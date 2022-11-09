import { useRouter } from "vue-router";
import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";



class KeepsService {
  async getKeeps() {
    try {

    } catch (error) {
      logger.error(error, 'getting keeps failed: service')
      Pop.error('getting keeps failed: service')
    }
  }


  //   async getKeepById(id) {
  //     try {
  //       const res = await api.get(`api/keeps/${id}`)
  //       AppState.activeKeep = new TowerEvent(res.data)
  //     } catch (error) {
  //       logger.error(error, 'getting keeps by id in service')
  //       Pop.error('getting keeps by id in service failed')
  //     }
  //   }
}


export const keepsService = new KeepsService()