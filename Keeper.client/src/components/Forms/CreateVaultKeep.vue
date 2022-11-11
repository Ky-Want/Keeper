<template>
  <div class="col-5" v-if="profile.id != account.id">
    <button type="button" class="btns btn btn-primary d-flex align-items-center" @click="handleSubmit()">Save</button>
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
          Pop.error(error, '[Submitting Event Form failed]')
          logger.error(error, 'submitting create event form')
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