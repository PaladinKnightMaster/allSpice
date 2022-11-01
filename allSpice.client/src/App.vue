<template >
  <section class="fontFancy">
    <Navigation />
  </section>
  <section class="font">
    <main>
      <router-view />
    </main>
    <footer class="bg-dark text-light"></footer>
  </section>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}

.fontFancy {
  font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif
}

.font {
  font-family: Verdana, Geneva, Tahoma, sans-serif
}
</style>
