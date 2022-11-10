<template>
  <!-- owned vaults -->
  <h2 class="px-5 pb-5 mb-3"><strong>Vaults</strong></h2>

  <!-- vault cards -->
  <div class="d-flex pb-5">
    <div class="card">
      <h3 class="title">Vault Name</h3>
      <div class="bar">
        <div class="emptybar"></div>
        <div class="filledbar"></div>
      </div>
      <div class="pt-5 mt-4">
        <router-link :to="{ name: 'Vault' }">
          <img
            src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdnb.artstation.com%2Fp%2Fmarketplace%2Fpresentation_assets%2F000%2F565%2F291%2Flarge%2Ffile.jpg%3F1603712584&f=1&nofb=1&ipt=a75c40805bf77b5562ebfd6c4bf9cbf5cafd4d1ea787adfa9e1e971e03b9f2ed&ipo=images"
            alt="" class="rounded vaultImg selectable">
        </router-link>
      </div>
    </div>
  </div>
</template>







<script>
export default {

  setup() {

    return {

    }
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