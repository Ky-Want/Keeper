<template>
  <!-- FIXME: logged in user can edit their account -->

  <form class="card account-form" @submit.prevent="handleSubmit">
    <div class="card-body text-start">

      <div>
        <label for="name">Name:</label>
        <input type="text" class="form-control" v-model="editable.name" required name="name">
      </div>

      <div>
        <label for="picture">Picture:</label>
        <input type="url" class="form-control" v-model="editable.picture" required name="picture" placeholder="picture">
      </div>

      <div>
        <label for="coverImg">Cover Image:</label>
        <input type="url" class="form-control" v-model="editable.coverImg" name="coverImg" placeholder="picture">
      </div>

      <div>
        <label for="bio">Bio:</label>
        <textarea type="text" class="form-control" v-model="editable.bio" name="bio" rows="8"
          style="resize:none"></textarea>
      </div>

      <div>
        <button type="submit" class="btn btn-primary w-100 mt-2">Save</button>
      </div>
    </div>
  </form>
</template>







<script>
import { ref, watchEffect } from "vue"
import { AppState } from "../../AppState.js"
import { accountService } from "../../services/AccountService.js"
import Pop from "../../utils/Pop.js"



export default {
  setup() {
    const editable = ref({})

    watchEffect(() => {
      editable.value = { ...AppState.account }
    })

    return {
      editable,
      async handleSubmit() {
        try {
          await accountService.editAccount(editable.value)
        } catch (error) {
          Pop.error(error, 'Editing account failed: account form')
        }
      }
    }
  }
}
</script>







<style scoped lang="scss">
.picture {
  background-image: url("https: //external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.7A_N_DAKftZXO7E0SThDXQHaEK%26pid%3DApi%26h%3D160&f=1&ipt=7ade3ecf7e4b2fc25c4289f802dba75f0f9d6a582de3e9a4562557ab944c836f&ipo=images");
}
</style>