<template>
  <nav class="navbar navbar-expand-sm navbar-dark bg-dark px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center border border-light px-2 p-1 selectable rounded">
        <strong>HOME</strong>
      </div>
    </router-link>


    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>


    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
          <!-- <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase"> -->
          <div class="dropdown text-primary selectable">
            <a class="btn btn-secondary dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
              aria-expanded="false">
              CREATE
            </a>



            <!-- FIXME: make button elsewhere to test -->
            <!-- <NewKeep /> -->
            <ul class="dropdown-menu">
              <div class="dropdown-item text-green" data-bs-toggle="modal" data-bs-target="#NewKeep">
                <strong>new keep</strong>
              </div>

              <!-- <NewVault /> -->
              <div class="dropdown-item text-danger" data-bs-toggle="modal" data-bs-target="#NewVault">
                <strong>new vault</strong>
              </div>
            </ul>
          </div>
        </li>
      </ul>


      <!-- LOGIN COMPONENT -->
      <Login />
    </div>
  </nav>
</template>







<script>
import NewVault from "./Forms/NewVault.vue";
import NewKeep from "./Forms/NewKeep.vue"
import Login from './Login.vue'

export default {
  setup() {
    return {}
  },
  components: { Login, NewVault, NewKeep }
}
</script>







<style scoped>
.text-green {
  color: green;
}

a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
