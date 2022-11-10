<template>

  <div class="d-flex justify-content-end m-3 mt-4">
    <ul class="navbar-nav me-auto">
      <li>
        <!-- <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase"> -->
        <div class="dropdown text-primary selectable">
          <a class="btn btn-secondary dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
            aria-expanded="false">
            CREATE
          </a>

          <NewKeep />
          <ul class="dropdown-menu">
            <div class="dropdown-item text-green" data-bs-toggle="modal" data-bs-target="#NewKeep">
              <strong>new keep</strong>
            </div>

            <NewVault />
            <div class="dropdown-item text-danger" data-bs-toggle="modal" data-bs-target="#NewVault">
              <strong>new vault</strong>
            </div>
          </ul>
        </div>
      </li>
    </ul>
  </div>






  <div v-for="k in keeps" :key="k.id" :keep="k">
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
      keeps: computed(() => AppState.keeps)
    };
  },


  components: { Keeps, NewKeep, NewVault }
}
</script>







<style scoped lang="scss">
.profile-pic {
  max-width: 1.5rem;
  max-height: 1.5rem;
}

body {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  font-family: sans-serif;
}

h1 {
  color: coral;
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