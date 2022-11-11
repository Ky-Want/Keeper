<template>
  <EditAccountForm />
  <!-- Cover Image -->
  <div class="container mt-5">
    <div class="d-flex justify-content-center">
      <img :src="account?.coverImg" alt="cover image" class="coverImg under">

      <!-- user picture -->
      <img :src="account?.picture" alt="user image" class="rounded-circle over userImg">
    </div>
  </div>


  <div class="container lower-section">
    <!-- name -->
    <h1 class="text-center mb-4 aref">{{ account?.name }}</h1>

    <!-- number of owned keeps and vaults -->
    <div class="d-flex gap-4 justify-content-center mb-5 pb-3">
      <p>{{ vaults?.length }} vaults</p> | <p>{{ keeps?.length }} keeps</p>
    </div>


    <VaultCard />


    <!-- owned keeps -->
    <h2 class="px-5 mt-5 pt-4"><strong>Keeps</strong></h2>
    <div class=" mb-5 pb-5">
      <Keeps />
    </div>
  </div>
  <!-- keep cards -->
  <div class="grid-container">
    <div v-for="k in keeps" :key="k.id">
      <KeepsCard :keep="k" />
    </div>
  </div>

</template>







<script>
import Forms from "../components/Forms/NewVault.vue";
import EditAccountForm from "../components/Forms/EditAccountForm.vue";
import { accountService } from "../services/AccountService.js";

import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'

import VaultCard from "../components/VaultCard.vue";
import KeepsCard from "../components/KeepsCard.vue";

import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";



export default {
  setup() {
    async function getAccount() {
      try {
        await accountService.getAccount();
      }
      catch (error) {
        Pop.error("Getting account failed");
        logger.error(error, "Home page");
      }
    }

    onMounted(() => {
      getAccount();
    });

    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { VaultCard, KeepsCard, Forms, EditAccountForm }
}
</script>







<style scoped>
/* #region */
.aref {
  font-family: 'Aref Ruqaa Ink', serif;
}

.userImg {
  height: 10rem;
  width: 10rem;
}

.coverImg {
  height: 30rem;
}

.lower-section {
  position: relative;
  top: 40rem;
}

.keeps-position {
  position: relative;
  top: 36rem
}

.under {
  position: absolute;
  z-index: -1;
}

.over {
  position: absolute;
  top: 32rem;
  z-index: -1;
}

/* #endregion */
</style>