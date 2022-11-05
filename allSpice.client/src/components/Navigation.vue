<template>
  <div class="component">
    <div class="m-3 rounded p-5 covImg elevation-4 "
      :style="{ backgroundImage: `url(src/assets/img/AllSpiceCoverImg.png)` }">
      <span class="">
        <Login />
      </span>
      <div class="text-center">
        <h1 class="text-light text-shadow">All-Spice</h1>
      </div>
      <div class="d-flex justify-content-center">
        <div class="card p-3 elevation-2">
          <div class="d-flex justify-content-around flex-wrap">
            <span class="uline no-select text-center text-success fs-5">Home</span>
            <span class="uline no-select text-center text-success fs-5">My Recipes</span>
            <span class="uline no-select text-center text-success fs-5">Favorites</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { onMounted } from 'vue';
import Login from './Login.vue';

export default {
  setup() {
    onMounted(() => {
      console.log("this works..");
    });
    return {};
  },
  components: { Login }
}
</script>


<style lang="scss" scoped>
.covImg {
  height: 34vh;
  background-size: cover;
  background-position: center;
}

span {
  margin-left: 0.7rem;
  margin-right: 0.7rem;
}

.uline:hover {
  cursor: pointer;
  font-size: 22px !important;
  transition: all 300ms;
  font-size-adjust: 20px;
  border-bottom: solid #219653;
  padding-left: 1rem;
  padding-right: 1rem;
}

.card {
  position: absolute;
  top: 33vh;
  width: 58vw;
}
</style>