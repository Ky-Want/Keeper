<template>
  <!-- FIXME: draw my vaults to the drop downs -->
  <div class="row d-flex justify-content-between" v-if="profile.id != account.id">
    <button class="dropdown-toggle text-primary selectable col-5" type="button" data-bs-toggle="dropdown"
      aria-expanded="false"></button>
    <ul class="dropdown-menu">


      <!-- FIXME: add keep to a vault -->
      <!-- @click="createVaultKeep()" -->
      <li class="dropdown-item selectable" @click="handleSubmit()">
        {{ vault?.name }}
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
      async handleSubmit() {
        try {
          const vaultKeepData = editable.value
          let newVaultKeep = await vaultkeepsService.createVaultKeep(vaultKeepData)
          console.log('Sending newVaultKeep form:', newVaultKeep);
        } catch (error) {
          Pop.error(error, '[Submitting vaultKeep Form failed]')
          logger.error(error, 'submitting create vaultKeep form')
        }
      },

      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile)
    }
  }
}
</script>







<style scoped lang="scss">

</style>