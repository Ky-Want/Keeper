<template>
  <!-- create forms -->
  <div class="d-flex justify-content-end m-3 mt-4" v-if="profile.id != account.id">
    <ul class="navbar-nav me-auto">
      <li>
        <div class="dropdown text-primary selectable">
          <a class="btn btn-secondary dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
            aria-expanded="false">
            CREATE
          </a>


          <ul class="dropdown-menu">
            <div class="dropdown-item text-green" data-bs-toggle="modal" data-bs-target="#NewKeep">
              <strong>new keep</strong>
            </div>


            <div class="dropdown-item text-danger" data-bs-toggle="modal" data-bs-target="#NewVault">
              <strong>new vault</strong>
            </div>
          </ul>
        </div>
      </li>
    </ul>
  </div>

  <div v-else></div>




  <div class="grid-container">
    <div v-for="k in keeps" :key="k.id" @click="viewed(k.id)">
      <KeepsCard :keep="k" />
    </div>
  </div>



  <NewVault />
  <NewKeep />

</template>







<script>
import { keepsService } from "../services/KeepsService.js";
import Keeps from "../components/KeepsCard.vue";
import KeepsCard from "../components/KeepsCard.vue";
import KeepsModal from "../components/KeepsModal.vue";

import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";

import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";

import NewKeep from "../components/Forms/NewKeep.vue";
import NewVault from "../components/Forms/NewVault.vue";


export default {

  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        Pop.error('Getting keeps failed')
        logger.error(error, "Home page")
      }
    }



    onMounted(() => {
      getKeeps();
    })

    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      keep: computed(() => AppState.activeKeep),
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.vaults),



      async viewed(id) {
        try {
          await keepsService.getKeepById(id)
          // views = AppState.activeKeep.views()
          logger.log(views)
        } catch (error) {
          logger.error("failed to add view")
        }
      }
    }
  },
  components: { Keeps, NewKeep, NewVault, KeepsCard, KeepsModal }
}
</script>







<style scoped lang="scss">
.profile-pic {
  max-width: 1.5rem;
  max-height: 1.5rem;
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