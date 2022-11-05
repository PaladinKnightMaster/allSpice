<template>
  <div class="home">
  </div>
</template>

<script>
import { onMounted } from 'vue';


export default {
  setup() {
    onMounted(() => {
    });
    return {
      async GetAllRecipes() {
      },
      async GetUserRecipes() {
      },
      async GetUserFavRecipes() {
      }
    };
  },
}
</script>

<style scoped lang="scss">
.home {
  height: 70vh;
  user-select: none;
}
</style>
