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



              <!-- FIXME -->
              <router-link :to="{ name: 'Profile', params: { id: profile.id } }">
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

                <!-- FIXME: increment views and keeps -->
                <i class="fa-solid fa-eye"> - {{ keep?.views }}</i> <i class="fa-solid fa-k"> - {{ keep?.kept
                }}</i>
              </div>
            </div>



            <!-- #region -->
            <!-- The title and description of this keep -->
            <div class="row mb-3">
              <h2 class="d-flex justify-content-center">{{ keep?.name }}</h2>
              <p class="d-flex justify-content-center">{{ keep?.description }}</p>
            </div>

            <CreateVaultKeep />
            <!-- #endregion -->
          </div>
        </div>
      </div>
    </div>
  </div>
</template>







<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import CreateVaultKeep from "./Forms/CreateVaultKeep.vue";


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
      keep: computed(() => AppState.activeKeep),
      vault: computed(() => AppState.vaults),
      profile: computed(() => AppState.profile)
    };
  },
  components: { CreateVaultKeep }
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