<template>
  <div class="row d-flex justify-content-between" v-if="profile.id != account.id">
    <button class="dropdown-toggle text-primary selectable col-5" type="button" data-bs-toggle="dropdown"
      aria-expanded="false">Dropdown</button>
    <ul class="dropdown-menu">


      <li class="dropdown-item selectable" v-for="v in profileVaults" :key="v.id" @click="handleSubmit(v.id)">
        {{ v.name }}
      </li>
    </ul>
  </div>
</template>







<script>
import { computed } from "@vue/reactivity";
import { ref } from "vue";
import { AppState } from "../../AppState.js";
import { vaultkeepsService } from "../../services/VaultKeepsService.js";
import { logger } from "../../utils/Logger.js";
import Pop from "../../utils/Pop.js";


export default {

  setup() {
    const editable = ref({});

    return {
      editable,
      async handleSubmit(vaultId) {
        try {
          let vaultKeepData = { vaultId: vaultId, keepId: AppState.activeKeep.id }
          let newVaultKeep = await vaultkeepsService.createVaultKeep(vaultKeepData)
          console.log('Sending newVaultKeep form:', newVaultKeep);
        } catch (error) {
          Pop.error(error, '[Submitting vaultKeep Form failed]')
          logger.error(error, 'submitting create vaultKeep form')
        }
      },

      account: computed(() => AppState.account),
      profileVaults: computed(() => AppState.profileVaults),
      profile: computed(() => AppState.profile),
      activeKeep: computed(() => AppState.activeKeep),

    }
  }
}
</script>







<style scoped lang="scss">

</style>