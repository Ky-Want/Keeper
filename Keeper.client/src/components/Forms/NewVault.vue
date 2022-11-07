<template>
  <div class="col-4 elevation-2 p-2 mx-5">
    <h1 class="text-center mb-5">Create New Vault Form</h1>
    <!-- title -->
    <div class="form-floating mb-3">
      <input type="name" class="form-control" id="name" placeholder="title">
      <label for="floatingInput">Title</label>
    </div>


    <!-- imgUrl -->
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="imgUrl" placeholder="Input">
      <label for="floatingInput">Img Url</label>
    </div>


    <!-- checkbox: private or public -->
    <div class="d-flex justify-content-between align-items-center">
      <div>
        <div class="font-1">private vaults can only be seen by you.</div>
        <div class="mb-3 form-check d-flex justify-content-end d-flex gap-2">
          <input type="checkbox" class="form-check-input" id="privateCheck">
          <label class="form-check-label" for="privateCheck"> Make Vault Private?</label>
        </div>
      </div>


      <!-- submit new vault -->
      <div class="d-flex justify-content-end px-2">
        <button type="submit" class="btn btn-primary mt-4 mx-3 mb-2">CREATE VAULT</button>
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
.font-1 {
  font-size: 10px;
  color: grey;
}
</style>