<template>
  <div v-for="k in keep" :key="k.id" :keep="k">

    <Keeps />

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
