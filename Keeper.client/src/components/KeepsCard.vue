<template>

  <div class="div-container grid-container mt-5">
    <!-- Keep image + title -->
    <div data-bs-toggle="modal" data-bs-target="#KeepModal" @click="setActiveKeep">
      <img class='grid-item selectable img-grey' :src="keep?.img" alt='Keep image' :title="keep?.name">
    </div>
    <!-- Keep name -->
    <div class="d-flex justify-content-between">
      <p>{{ keep?.name }}</p>


      <!-- Profile picture of keep creator -->
      <p><img :src="keep?.creator?.picture" alt="profile pic" :title="keep?.creator?.name"
          class="img-fluid profile-pic selectable rounded-circle">
      </p>
    </div>
  </div>

</template>






<script>
import KeepsModal from "./KeepsModal.vue";
import { Keep } from "../models/Keep.js";

import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";


export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup(props) {


    return {
      account: computed(() => AppState.account),

      setActiveKeep() {
        AppState.activeKeep = props.keep
      }
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