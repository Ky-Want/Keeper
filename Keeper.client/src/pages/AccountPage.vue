<template>
  <!-- Cover Image -->
  <div class="container mt-5">
    <div class="d-flex justify-content-center">
      <img
        src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwallpapertag.com%2Fwallpaper%2Ffull%2F4%2F3%2F2%2F465141-beautiful-anime-wallpaper-1920x1200-for-4k.jpg&f=1&nofb=1&ipt=ac3e330a39e1aca1f7ee46a30e783255978882c9f479a5428151336cb74e8e4a&ipo=images"
        alt="cover image" class="coverImg under">

      <!-- user picture -->
      <img
        src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwallup.net%2Fwp-content%2Fuploads%2F2019%2F09%2F1005109-picture-abandoned-lake-color-nice-leaves-shore-autumn-splendor-dock-water-house-mirrored-boat-river-pretty-landscape-mountain-autumn-colors-nature-weather-tree-pier-green-houses-forgot-3.jpg&f=1&nofb=1&ipt=1ba40cb7bab9f6551a2cab69de20f8bb066499dda93455dbafd71e6c5f961a2e&ipo=images"
        alt="user image" class="rounded-circle over userImg">
    </div>
  </div>


  <div class="container lower-section">
    <!-- name -->
    <h1 class="text-center mb-4 aref">Ky Want</h1>

    <!-- number of owned keeps and vaults -->
    <div class="d-flex gap-4 justify-content-center mb-5 pb-3">
      <p>5 vaults</p> | <p>10 keeps</p>
    </div>




    <!-- owned vaults -->
    <h2 class="px-5 pb-5 mb-3"><strong>Vaults</strong></h2>
    <!-- vault cards -->
    <div class="d-flex pb-5">
      <div class="card selectable">
        <h3 class="title">Vault 1</h3>
        <div class="bar">
          <div class="emptybar"></div>
          <div class="filledbar"></div>
        </div>
        <div class="pt-5 mt-4">
          <img src="//thiscatdoesnotexist.com" alt="" class="img-fluid">
        </div>
      </div>

      <div class="card selectable">
        <h3 class="title">Vault 2</h3>
        <div class="bar">
          <div class="emptybar"></div>
          <div class="filledbar"></div>
        </div>
        <div class="pt-5 mt-4">
          <img src="//thiscatdoesnotexist.com" alt="" class="img-fluid">
        </div>
      </div>

      <div class="card selectable">
        <h3 class="title">Vault 3</h3>
        <div class="bar">
          <div class="emptybar"></div>
          <div class="filledbar"></div>
        </div>
        <div class="pt-5 mt-4">
          <img src="//thiscatdoesnotexist.com" alt="" class="img-fluid">
        </div>
      </div>
    </div>






    <!-- owned keeps -->
    <h2 class="px-5 mt-5 pt-4"><strong>Keeps</strong></h2>
    <div class=" mb-5 pb-5">
      <Keeps />
    </div>
  </div>
  <!-- keep cards -->
  <div class="keeps-position">
    <KeepsCard />
  </div>
</template>







<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import Forms from "../components/Forms/NewVault.vue";
import KeepsCard from "../components/KeepsCard.vue";


export default {
  setup() {

    return {
      account: computed(() => AppState.account)
    };
  },
  components: { Forms, KeepsCard }
}
</script>







<style scoped>
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






/* #region carousel css */
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
  top: 100px;
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

/* #endregion */
</style>
