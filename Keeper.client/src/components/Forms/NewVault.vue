<template>
  <div class="modal fade" id="NewVault" data-bs-keyboard="false" aria-labelledby="NewVaultLabel" aria-hidden="true">
    <div class="elevation-2 p-2 mx-5 modal-dialog">
      <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      <h1 class="text-center mb-5">Create New Vault Form</h1>
      <div class="modal-content">


        <!-- title -->
        <form @submit.prevent="createVault()" class="modal-body">
          <div class="form-floating mb-3">
            <input v-model="editable.name" type="text" class="form-control" id="name" placeholder="title" required>
            <label for="floatingInput">Title</label>
          </div>


          <!-- description -->
          <div class="form-floating mb-3">
            <input v-model="editable.description" type="text" class="form-control" id="description"
              placeholder="description" required>
            <label for="floatingInput">Description</label>
          </div>


          <!-- imgUrl -->
          <div class="form-floating mb-3">
            <input v-model="editable.img" type="url" class="form-control" id="imgUrl" placeholder="Input" required>
            <label for="floatingInput">Img Url</label>
          </div>


          <!-- checkbox: private or public -->
          <div class="d-flex justify-content-between align-items-center">
            <div>
              <div class="font-1">private vaults can only be seen by you.</div>
              <div class="mb-3 form-check d-flex justify-content-end d-flex gap-2">
                <input v-model="editable.isPrivate" type="checkbox" class="form-check-input" id="privateVaultCheck">
                <label class="form-check-label" for="privateCheck"> Make Vault Private?</label>
              </div>
            </div>


            <!-- submit new vault -->
            <div class="d-flex justify-content-end px-2">
              <button type="submit" class="btn btn-primary mt-4 mx-3 mb-2">CREATE VAULT</button>
            </div>
          </div>
        </form>

      </div>
    </div>
  </div>
</template>







<script>
import { ref } from "vue";
import { AppState } from "../../AppState.js";
import { vaultsService } from "../../services/VaultsService.js";
import { logger } from "../../utils/Logger.js";
import Pop from "../../utils/Pop.js";

export default {

  setup() {
    const editable = ref({});

    return {
      editable,

      async createVault() {
        try {
          if (!AppState.account.id) {
            throw new Error('You must be signed in to create a vault')
          }
          await vaultsService.createVault(editable.value);
          editable.value = {};

          Pop.success("Successfully created vault")
        } catch (error) {
          logger.error(error)
          Pop.error("Create Vault Failed: new vault")
        }
      }
    }

  }
}
</script>







<style scoped lang="scss">
.font-1 {
  font-size: 10px;
  color: grey;
}
</style>