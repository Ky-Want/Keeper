<template>
  <div class="card">
    <h3 class="title">{{ vault?.name }}</h3>
    <div class="bar">
      <div class="emptybar"></div>
      <div class="filledbar"></div>
    </div>
    <div class="pt-5 mt-4">
      <div @click="vaultPage()">
        <img :src="vault?.img" alt="vault image" class="rounded vaultImg selectable">
      </div>
    </div>
  </div>
</template>







<script>
import { AppState } from "../AppState.js";
import { router } from "../router.js";
import { logger } from "../utils/Logger.js";

export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },

  setup() {

    return {
      async vaultPage() {
        try {
          if (props.vault.isPrivate == true && AppState.account.id != props.vault.creatorId) {
            router.push({ name: 'Home' })
          }
          router.push({ name: 'Vault', params: { vaultId: props.vault.id } })
        } catch (error) {
          logger.error(error)
        }
      }
    };
  }
}
</script>







<style scoped lang="scss">
.vaultImg {
  /* background-size: contain; */
  height: 12.8rem;
  width: 12.4rem;
}

.card {
  display: flex;
  height: 280px;
  width: 200px;
  background-color: #17141d;
  border-radius: 10px;
  box-shadow: -1rem 0 3rem #000;
  /*   margin-left: -50px; */
  transition: 0.4s ease-out;
  position: relative;
  left: 0px;
}

.card:not(:first-child) {
  margin-left: -50px;
}

.card:hover {
  transform: translateY(-20px);
  transition: 0.4s ease-out;
}

.card:hover~.card {
  position: relative;
  left: 50px;
  transition: 0.4s ease-out;
}

.title {
  color: white;
  font-weight: 300;
  position: absolute;
  left: 20px;
  top: 15px;
}

.bar {
  position: absolute;
  top: 55px;
  left: 20px;
  height: 5px;
  width: 150px;
}

.emptybar {
  background-color: #2e3033;
  width: 100%;
  height: 100%;
}

.filledbar {
  position: absolute;
  top: 0px;
  z-index: 3;
  width: 0px;
  height: 100%;
  background: rgb(0, 154, 217);
  background: linear-gradient(90deg, rgba(0, 154, 217, 1) 0%, rgb(40, 0, 217) 65%, rgb(162, 10, 147) 100%);
  transition: 0.6s ease-out;
}

.card:hover .filledbar {
  width: 120px;
  transition: 0.4s ease-out;
}

.stroke {
  stroke: white;
  stroke-dasharray: 360;
  stroke-dashoffset: 360;
  transition: 0.6s ease-out;
}

.card:hover .stroke {
  stroke-dashoffset: 100;
  transition: 0.6s ease-out;
}
</style>