import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class VaultKeepsService {
  async getVaultKeeps(vaultId) {
    const res = await api.get('api/vaultKeeps/' + vaultId + '/keeps')
    logger.log(res.data)
    AppState.vaultKeeps = res.data
  }


  async getMyVaultKeeps() {
    const res = await api.get('account/')
    logger.log('[Get My Vault Keeps]', res.data)
    AppState.activeVaultKeeps = res.data
  }


  async getKeepsByVaultId(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    logger.log('getting vaultKeeps: Service', res.data)
    AppState.activeVaultKeeps = res.data
  }







  async createVaultKeep(data, vaultId) {
    const res = await api.post('api/vaultKeeps/' + vaultId + '/keeps', data)
    logger.log(res.data)
    AppState.vaultKeeps.push(res.data)
    AppState.keeps.kept++
  }
}


export const vaultkeepsService = new VaultKeepsService()