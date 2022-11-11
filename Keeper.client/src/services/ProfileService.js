import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { api } from "./AxiosService.js"



class ProfileService {
  async getUserById(creatorId) {
    const res = await api.get(`api/profiles/${creatorId}`, {
      params: {
        creatorId
      }
    })
    AppState.profile = res.data
    console.log("getting profile:", res.data)
  }



  async getUserKeeps(creatorId) {
    AppState.keeps = []
    const res = await api.get(`api/profiles/${creatorId}/keeps`, {
      params: {
        creatorId
      }
    })
    AppState.keeps = res.data.map(k => new Keep(k))
  }



  async getUserVaults(creatorId) {
    AppState.vaults = []
    const res = await api.get(`api/profiles/${creatorId}/vaults`, {
      params: {
        creatorId
      }
    })
    console.log(AppState.vaults);
    AppState.vaults = res.data.map(v => new Vault(v))
  }

}



export const profileService = new ProfileService()