<template>
  <div class="container">
    <div class="selectable text-danger d-flex justify-content-end" @click="deleteVault()">X</div>
    <div class="mt-5 d-flex justify-content-center">
      <img :src="vault.img" alt="" class="img-size">
    </div>

    <div class="d-flex justify-content-center mt-5">
      <strong>{{ vaultKeeps.length }}</strong>
    </div>

    <!-- FIXME: show only the vault keeps for this vault -->
    <!-- FIXME: allow users to remove a keep from their vault -->
    <div class="grid-container">
      <div v-for="k in keeps" :key="k.id">
        <KeepsCard :keep="k" />
      </div>
    </div>
  </div>
</template>







<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import KeepsCard from "../components/KeepsCard.vue";
import { vaultkeepsService } from "../services/VaultKeepsService.js";
import { vaultsService } from "../services/VaultsService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const route = useRoute();

    async function getKeepsByVaultId() {
      try {
        await vaultkeepsService.getKeepsByVaultId(route.params.id);
      } catch (error) {
        logger.error(error)
      }
    }


    onMounted(() => {
      getKeepsByVaultId();
    });

    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaultKeeps: computed(() => AppState.vaultKeeps),
      profile: computed(() => AppState.profile),
      vault: computed(() => AppState.vaults),



      async deleteVault() {
        try {
          if (AppState.account.id != AppState.activeVault.creatorId) {
            throw new Error('You are not authorized to delete this vault')
          }
          const yes = await Pop.confirm('Are you sure you want to delete this vault?')
          if (!yes) { return }
          await vaultsService.deleteVault(route.params.id);
          Pop.success('Vault successfully deleted')
        } catch (error) {
          logger.error(error)
          Pop.error("Delete vault failed: vault page")
        }
      },



      async deleteVaultKeep() {
        try {
          if (AppState.account.id != AppState.activeVault.creatorId) { throw new Error("You are not authorized to delete this vault keep.") }
          const yes = await Pop.confirm("Are you sure you want to remove this vault keep?")
          if (!yes) { return }
          vaultkeepsService.deleteVaultKeep(route.params.id)
          Pop.success('Vault Keep successfully removed')
        } catch (error) {
          logger.error(error)
          Pop.error("Delete vault keep failed: vault page")
        }
      }
    }
  }
}
</script>







<style scoped lang="scss">
.img-size {
  height: 30rem;
  width: 60rem;
}

.grid-container {
  columns: 5 200px;
  column-gap: 1.5rem;
  width: 90%;
  margin: 0 auto;

  .div-container {
    width: 150px;
    margin: 0 1.5rem 1.5rem 0;
    display: inline-block;
    width: 100%;
    border: solid 2px black;
    padding: 5px;
    box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.5);
    border-radius: 5px;
    transition: all .25s ease-in-out;

    &:hover .img-grey {
      filter: grayscale(0);
    }

    &:hover {
      border-color: rgb(122, 50, 255);
    }

    .img-grey {
      width: 100%;
      filter: grayscale(100%);
      border-radius: 5px;
      transition: all .25s ease-in-out;
    }

    p {
      margin: 5px 0;
      padding: 0;
      text-align: center;
      font-style: italic;
    }
  }
}
</style>