<template>
  <!-- Cover Image -->
  <div class="container mt-5">
    <div class="d-flex justify-content-center">
      <img src="//thiscatdoesnotexist.com" alt="cover image" class="mh-1 under">

      <!-- user picture -->
      <!-- <div class="rounded-circle border border-none d-flex justify-content-center"> -->
      <img
        src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwallup.net%2Fwp-content%2Fuploads%2F2019%2F09%2F1005109-picture-abandoned-lake-color-nice-leaves-shore-autumn-splendor-dock-water-house-mirrored-boat-river-pretty-landscape-mountain-autumn-colors-nature-weather-tree-pier-green-houses-forgot-3.jpg&f=1&nofb=1&ipt=1ba40cb7bab9f6551a2cab69de20f8bb066499dda93455dbafd71e6c5f961a2e&ipo=images"
        alt="user image" class="rounded-circle over font-2">
      <!-- </div> -->
    </div>
  </div>


  <div class="container lower-section">
    <!-- name -->
    <h1 class="text-center mb-4">Ky Want</h1>

    <!-- number of owned keeps and vaults -->
    <div class="d-flex gap-4 justify-content-center mb-5 pb-3">
      <p>5 vaults</p> | <p>21 keeps</p>
    </div>


    <!-- owned keeps -->
    <div>
      <h2 class="px-5"><strong>Keeps</strong></h2>
      <Keeps />
    </div>


    <!-- owned vaults -->
    <div class="mt-5 mb-5 pb-5">
      <h2 class="px-5"><strong>Vaults</strong></h2>
    </div>
  </div>
</template>







<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import Forms from "../components/Forms/NewVault.vue";


export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    };
  },
  components: { Forms }
}
</script>







<style scoped>
.font-2 {
  height: 10rem;
  width: 10rem;
}

.mh-1 {
  max-height: 20rem;
  max-width: 25rem;
}

.lower-section {
  position: relative;
  top: 28rem;
}

.under {
  position: absolute;
  z-index: -1;
}

.over {
  position: absolute;
  top: 23rem;
  z-index: -1;
}
</style>
