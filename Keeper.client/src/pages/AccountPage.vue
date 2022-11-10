<template>
  <!-- Cover Image -->
  <div class="container mt-5">
    <div class="d-flex justify-content-center">
      <img :src="account.coverImg" alt="cover image" class="coverImg under">

      <!-- user picture -->
      <img :src="account.picture" alt="user image" class="rounded-circle over userImg">
    </div>
  </div>


  <div class="container lower-section">
    <!-- name -->
    <h1 class="text-center mb-4 aref">{{ account.name }}</h1>

    <!-- number of owned keeps and vaults -->
    <div class="d-flex gap-4 justify-content-center mb-5 pb-3">
      <p>5 vaults</p> | <p>10 keeps</p>
    </div>


    <VaultCard />


    <!-- owned keeps -->
    <h2 class="px-5 mt-5 pt-4"><strong>Keeps</strong></h2>
    <div class=" mb-5 pb-5">
      <Keeps />
    </div>
  </div>
  <!-- keep cards -->
  <!-- v-for="k in keeps" :key="k.id" :keep="k" -->
  <div class="keeps-position">
    <KeepsCard />
  </div>
</template>







<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import Forms from "../components/Forms/NewVault.vue";
import KeepsCard from "../components/KeepsCard.vue";
import VaultCard from "../components/VaultCard.vue";


export default {
  setup() {

    return {
      account: computed(() => AppState.account)
    };
  },
  components: { Forms, KeepsCard, VaultCard }
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