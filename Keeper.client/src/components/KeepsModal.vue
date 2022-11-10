<template>
  <!-- Modal -->
  <div class="modal fade" id="KeepModal" data-bs-backdrop="static" data-bs-keyboard="false"
    aria-labelledby="KeepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">

        <!-- picture of the keep -->
        <div class="modal-body row">
          <div class="col-7">
            <img :src="keep?.img" alt="keep image" class="img-fluid rounded">
          </div>



          <div class="col-5">
            <!-- close btn + creator pic -->
            <div class="d-flex justify-content-between">
              <!-- picture and onHover name of the creator of this keep -->
              <router-link :to="{ name: 'Account' }">
                <div>
                  <img :src="keep.creator?.picture" data-bs-dismiss="modal" alt="Keep Creator Pic"
                    :title="keep.creator?.name" class="creator-pic rounded-circle selectable">
                </div>
              </router-link>

              <!-- close modal -->
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>



            <!-- how many people have view and saved this keep -->
            <div class="row mt-3 mb-5 pb-2">
              <div class="d-flex gap-5 justify-content-center">
                <i class="fa-solid fa-eye"> - {{ keep?.views }}</i> <i class="fa-solid fa-k"> - {{ keep?.kept }}</i>
              </div>
            </div>



            <!-- The title and description of this keep -->
            <div class="row mb-3">
              <h2 class="d-flex justify-content-center">{{ keep?.name }}</h2>
              <p class="d-flex justify-content-center">{{ keep?.description }}</p>
            </div>



            <!-- Save keep to specified vault -->
            <div class="row d-flex justify-content-between">
              <div class="dropdown text-primary selectable col-5">
                <a class="btn btn-secondary dropdown-toggle" href="#chooseVault" role="button" data-bs-toggle="dropdown"
                  aria-expanded="false">
                  Vault
                </a>
                <ul class="dropdown-menu">
                  <li>
                    <a class="dropdown-item text-green" href="#chooseVault">
                      vault name
                    </a>
                  </li>
                </ul>
              </div>

              <div class="col-5">
                <button type="button" class="btns btn btn-primary d-flex align-items-center">Save</button>
              </div>
            </div>

          </div>
        </div>

      </div>
    </div>
  </div>
</template>







<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";


export default {
  // props: {
  //   keep: {
  //     type: Keep,
  //     required: true
  //   }
  // },
  setup(props) {

    return {
      account: computed(() => AppState.account),
      keep: computed(() => AppState.activeKeep)
    };
  },
}
</script>







<style scoped lang="scss">
.creator-pic {
  width: 2rem;
  height: 2rem;
}

.align-flex-end {
  align-items: flex-end;
}

.btns {
  width: 4rem;
  height: 2rem;
}
</style>