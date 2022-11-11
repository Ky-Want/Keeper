import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},


  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  /** @type {import('./models/Keep.js').Keep} */
  activeKeep: {},


  /** @type {import('./models/Vault.js').Vault[]} */
  vaults: [],
  /** @type {import('./models/Vault.js').Vault} */
  activeVault: {},


  profileVaults: [],


  /** @type {import('./models/VaultKeep.js').VaultKeep[]} */
  vaultKeeps: [],
  /** @type {import('./models/VaultKeep.js').VaultKeep} */
  activeVaultKeeps: {},


  /** @type {import('./models/Profile.js').Profile} */
  profile: {},
  /** @type {import('./models/Profile.js').Profile[]} */
  activeProfile: []
})
