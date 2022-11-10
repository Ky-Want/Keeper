<template>
  <div class="profile-page" v-if="profile">
    <ProfileDetail :profile="profile" />
    <div>
      <ProjectCard v-for="p in projects" :project="p" :key="p.id" />
    </div>
  </div>


  <div v-else>
    loading....
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js';

import ProfileDetail from '../components/ProfileDetail.vue';
import ProjectCard from '../components/Project/ProjectCard.vue';

import { profilesService } from '../services/ProfilesService.js';
import { projectsService } from '../services/ProjectsService.js';
import Pop from '../utils/Pop.js';


export default {
  setup() {
    const route = useRoute();

    async function getProfileById() {
      try {
        await profilesService.getProfileById(route.params.id);
      }
      catch (error) {
        Pop.error(error, "[GetProfile]");
      }
    }
    async function getProjectsByCreatorId() {
      try {
        await projectsService.getProjectsByCreatorId(route.params.id)
      } catch (error) {
        Pop.error(error, '[GetProjectsByCreatorId]')
      }
    }
    onMounted(() => {
      getProfileById()
      getProjectsByCreatorId()
    });
    return {
      profile: computed(() => AppState.activeProfile),
      projects: computed(() => AppState.projects)
    };
  },
  components: { ProjectCard, ProfileDetail }
}
</script>


<style lang="scss" scoped>

</style>