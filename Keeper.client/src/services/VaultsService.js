import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class VaultsService {
  async getVaults() {
    const res = await api.get('api/vaults')
    logger.log('[Get Vaults]', res.data)
    AppState.vaults = res.data.map(v => new Vault(v))
  }


  async getVaultById(id) {
    const res = await api.get('api/vaults/' + id)
    logger.log(res.data)
    AppState.vaults = new Vault(res.data)
    return res.data
  }


  async getVaultsByAccount() {
    const res = await api.get('account/vaults')
    logger.log('getting vault by account: service', res.data)
    AppState.accountVaults = res.data
  }






  // logged in user can create and delete vaults
  async createVault(newVault) {
    const res = await api.post('api/vaults', newVault)
    logger.log(res.data)
    AppState.vaults.push(new Vault(res.data))
  }


  // can remove vault keeps from vault page
  async deleteVault(id) {
    const res = await api.delete('api/vaults/' + id)
    logger.log(res.data)
    AppState.vaults = AppState.vaults.filter(v => v.id !== id)
  }
}


export const vaultsService = new VaultsService()