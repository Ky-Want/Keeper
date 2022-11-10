<template>
  <div class="modal" tabindex="-1" id="NewKeep">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create Keep</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createKeep()">
            <div class="form-floating mb-3">
              <input type="name" class="form-control" id="name" placeholder="title">
              <label for="floatingInput">Title</label>
            </div>


            <!-- img url -->
            <div class="form-floating mb-3">
              <input type="url" class="form-control" id="imgUrl" placeholder="Input">
              <label for="floatingInput">Img Url</label>
            </div>


            <!-- tags -->
            <div class="form-floating">
              <input type="tag" class="form-control" id="tags" placeholder="tags">
              <label for="tags">Tags</label>
            </div>
            <div class="mb-5">* Separate tags with a comma</div>


            <!-- description -->
            <div class="form-floating">
              <textarea class="form-control" placeholder="Leave a comment here" id="floatingTextarea"></textarea>
              <label for="floatingTextarea">Description</label>
            </div>


            <!-- submit new keep -->
            <div class="d-flex justify-content-end">
              <button type="submit" class="btn btn-primary mt-4 mx-3 mb-2">CREATE</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>



  <!-- <div class="modal bg-dark fade" id="NewKeep" data-bs-keyboard="false" aria-labelledby="NewKeepLabel"
    aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-body">

        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        
      </div>
    </div>
  </div> -->
</template>







<script>
import Pop from "../../utils/Pop.js";

export default {

  setup() {

    return {
      async createKeep() {
        try {
          console.log('Submitted')
        } catch (error) {
          Pop.error(error, 'Creating Keep')
        }
      }
    }
  }
}
</script>







<style scoped lang="scss">

</style>