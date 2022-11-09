<template>
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
        <img
          src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Flbpost.com%2Fhi-lo%2Fwp-content%2Fuploads%2F2017%2F09%2FLOKI_in_the_window.jpg&f=1&nofb=1&ipt=49f0a21c54405a86c3db2dc2513f0701f51344fa64e962e9cb2df8057197e565&ipo=images"
          alt="" class="rounded vaultImg">
      </div>
    </div>


    <div class="card selectable">
      <h3 class="title">Vault 2</h3>
      <div class="bar">
        <div class="emptybar"></div>
        <div class="filledbar"></div>
      </div>
      <div class="pt-5 mt-4">
        <img
          src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.thesprucepets.com%2Fthmb%2Fi2kYBI-R2a9aZPXUq8WD9O8mVWw%3D%2F2121x1414%2Ffilters%3Afill(auto%2C1)%2FGettyImages-177213599-7fbd715f80b7438abc9a627a9014239b.jpg&f=1&nofb=1&ipt=0ed658f56bfdc91964fa366250b1444befe0863a4ff5aa58149fec93a2caa270&ipo=images"
          alt="" class="rounded vaultImg">
      </div>
    </div>


    <div class="card selectable">
      <h3 class="title">Vault 3</h3>
      <div class="bar">
        <div class="emptybar"></div>
        <div class="filledbar"></div>
      </div>
      <div class="pt-5 mt-4">
        <img
          src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn0.wideopenpets.com%2Fwp-content%2Fuploads%2F2017%2F08%2FAdobeStock_142093063.jpeg&f=1&nofb=1&ipt=a06bbe91cb5c6ec0b2027594ee0794883762ae35cb43f028595272c801103832&ipo=images"
          alt="" class="rounded vaultImg">
      </div>
    </div>


    <div class="card selectable">
      <h3 class="title">Vault 4</h3>
      <div class="bar">
        <div class="emptybar"></div>
        <div class="filledbar"></div>
      </div>
      <div class="pt-5 mt-4">
        <img
          src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwallup.net%2Fwp-content%2Fuploads%2F2016%2F01%2F180325-animals-fox.jpg&f=1&nofb=1&ipt=fa4f393d1fa07346481b0adceedd2ecf14648fa51f998515053ee9e3b2629966&ipo=images"
          alt="" class="rounded vaultImg">
      </div>
    </div>


    <div class="card selectable">
      <h3 class="title">Vault 5</h3>
      <div class="bar">
        <div class="emptybar"></div>
        <div class="filledbar"></div>
      </div>
      <div class="pt-5 mt-4">
        <img
          src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fchelseaflowers.co.uk%2Fwp-content%2Fuploads%2F2016%2F07%2Fshutterstock_307536584.jpg&f=1&nofb=1&ipt=26abad48f6489b897f1849ed4c2e560b6f4c769bb2a63f2fa888661de6bcf73b&ipo=images"
          alt="" class="rounded vaultImg">
      </div>
    </div>


    <div class="card selectable">
      <h3 class="title">Vault 6</h3>
      <div class="bar">
        <div class="emptybar"></div>
        <div class="filledbar"></div>
      </div>
      <div class="pt-5 mt-4">
        <img
          src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdnb.artstation.com%2Fp%2Fmarketplace%2Fpresentation_assets%2F000%2F565%2F291%2Flarge%2Ffile.jpg%3F1603712584&f=1&nofb=1&ipt=a75c40805bf77b5562ebfd6c4bf9cbf5cafd4d1ea787adfa9e1e971e03b9f2ed&ipo=images"
          alt="" class="rounded vaultImg">
      </div>
    </div>


    <div class="card selectable">
      <h3 class="title">Vault 7</h3>
      <div class="bar">
        <div class="emptybar"></div>
        <div class="filledbar"></div>
      </div>
      <div class="pt-5 mt-4">
        <img
          src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fdnd.dragonmag.com%2Fwp-content%2Fuploads%2Fsites%2F587%2F2020%2F05%2Fopendd.jpg&f=1&nofb=1&ipt=bcd563fa1444ac4707ec4e1150d3660f589a8211847f208ef378a040aec494be&ipo=images"
          alt="" class="rounded vaultImg">
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