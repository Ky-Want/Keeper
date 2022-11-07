<template>
  <!-- title -->
  <div class="col-4 elevation-2 p-2 mx-5">
    <h1 class="d-flex justify-content-center mb-5">Create New Keep Form</h1>
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

</style>