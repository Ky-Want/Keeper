<template>
  <KeepsModal />

  <body class="grid-container div-container mt-5 mb-5">
    <div class="div-container">

      <!-- Keep image + title -->
      <div data-bs-toggle="modal" data-bs-target="#KeepModal">
        <img class='grid-item selectable img-grey' :src='keeps.img' alt='Keep image' :title="keeps.name">
      </div>


      <!-- Keep name -->
      <div class="d-flex justify-content-between">
        <p>{{ keeps.description }}</p>


        <!-- Profile picture of keep creator -->
        <router-link :to="{ name: 'Account' }">
          <p><img :src="account.picture" alt="profile pic" :title="keeps.creator"
              class="img-fluid profile-pic selectable rounded-circle">
          </p>
        </router-link>
      </div>
    </div>

  </body>
</template>






<script>
import KeepsModal from "./KeepsModal.vue";

import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";


export default {
  setup() {

    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keep)
    };
  },


  components: { KeepsModal }
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