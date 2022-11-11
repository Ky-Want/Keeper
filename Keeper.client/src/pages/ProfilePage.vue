<template>
  <!-- FIXME: all users should have a public profile page -->
  <!-- Cover Image -->
  <div class="container mt-5">
    <div class="d-flex justify-content-center">
      <img :src="profile?.coverImg" alt="cover image" class="coverImg under">

      <!-- user picture -->
      <img :src="profile?.picture" alt="user image" class="rounded-circle over userImg">
    </div>
  </div>


  <div class="container lower-section">
    <!-- name -->
    <h1 class="text-center mb-4 aref">{{ profile?.name }}</h1>

    <!-- number of owned keeps and vaults -->
    <div class="d-flex gap-4 justify-content-center mb-5 pb-3">
      <p>{{ vaults?.length }} vaults</p> | <p>{{ keeps?.length }} keeps</p>
    </div>


    <!-- owned vaults -->
    <h2 class="px-5 pb-5 mb-3"><strong>Vaults</strong></h2>
    <!-- vault cards -->
    <div class="d-flex pb-5">
      <div v-for="v in vaults" :key="v.id">
        <VaultCard :vault="v" />
      </div>
    </div>



    <!-- owned keeps -->
    <div class="keeps">
      <h2 class="px-5 mt-5 pt-4"><strong>Keeps</strong></h2>
      <!-- keep cards -->
      <div class="grid-container">
        <div v-for="k in keeps" :key="k.id">
          <KeepsCard :keep="k" />
        </div>
      </div>
    </div>
  </div>


  <KeepsModal />
</template>







<script>
import Forms from "../components/Forms/NewVault.vue";
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'

import VaultCard from "../components/VaultCard.vue";
import KeepsCard from "../components/KeepsCard.vue";
import KeepsModal from "../components/KeepsModal.vue";

import { profileService } from "../services/ProfileService.js";

import { useRoute } from "vue-router";
import Pop from "../utils/Pop.js";



export default {
  setup() {
    // user should be pushed back to the home page when trying to open a vault they don't have access to
    const route = useRoute();


    async function getUserById() {
      try {
        await profileService.getUserById(route.params.creatorId)
      } catch (error) {
        Pop.error(error, 'getting user: profile page')
      }
    }



    async function getUserKeeps() {
      try {
        await profileService.getUserKeeps(route.params.creatorId)
      } catch (error) {
        Pop.error(error, 'getting user keeps: profile page')
      }
    }



    async function getUserVaults() {
      try {
        await profileService.getUserVaults(route.params.creatorId)
      } catch (error) {
        Pop.error(error, 'getting user vaults: profile page')
      }
    }




    onMounted(() => {
      getUserById()
      getUserKeeps()
      getUserVaults()
    });

    return {
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    };
  },
  components: { VaultCard, KeepsCard, Forms, KeepsModal }
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


.grid-container {
  columns: 5 200px;
  column-gap: 1.5rem;
  width: 90%;
  margin: 0 auto;
}

.keeps {
  position: relative;
}
</style>