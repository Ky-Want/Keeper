<template>

  <Keeps />


  <div v-for="k in keep" :key="k.id" :keep="k">

    <div class="div-container">
      <!-- Keep image + title -->
      <div data-bs-toggle="modal" data-bs-target="#KeepModal">
        <img class='grid-item selectable img-grey' :src="keep.img" alt='Keep image title' :title="keep.creator">
      </div>


      <!-- Keep name -->
      <div class="d-flex justify-content-between">
        <p>{{ keep.description }}</p>


        <!-- Profile picture of keep creator -->
        <router-link :to="{ name: 'Account' }">
          <p><img :src="account.picture" alt="profile pic" :title="account.name"
              class="img-fluid profile-pic selectable rounded-circle">
          </p>
        </router-link>
      </div>
    </div>

  </div>
</template>







<script>
import Keeps from "../components/KeepsCard.vue";
import { keepsService } from "../services/KeepsService.js";

import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";

import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { api } from "../services/AxiosService.js";


export default {
  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        Pop.error('[Getting keeps: home page]')
        logger.error(error, "[Getting keeps: home page]")
      }
    }

    onMounted(() => {
      getKeeps();
    })

    return {

    };
  },


  components: { Keeps }
}
</script>







<style scoped lang="scss">

</style>
