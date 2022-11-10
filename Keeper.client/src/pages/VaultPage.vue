<template>
  <div class="container">
    <div class="mt-5 d-flex justify-content-center">
      <img
        src="https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Flatestwall.com%2Fimages%2Fwallpaper%2Fsunset_hd_wallpaper_21.jpg&f=1&nofb=1&ipt=538ad29db1aec59b2dbaaed2d8619426b1f0a74ba85fedec5822a576d96acc8b&ipo=images"
        alt="" class="img-size">
    </div>

    <div class="d-flex justify-content-center mt-5">
      <strong>13 keeps</strong>
    </div>

    <div class="grid-container">
      <div v-for="k in keeps" :key="k.id">
        <KeepsCard :keep="k" />
      </div>
    </div>
  </div>
</template>







<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import KeepsCard from "../components/KeepsCard.vue";

export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepsCard }
}
</script>







<style scoped lang="scss">
.img-size {
  height: 30rem;
  width: 60rem;
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