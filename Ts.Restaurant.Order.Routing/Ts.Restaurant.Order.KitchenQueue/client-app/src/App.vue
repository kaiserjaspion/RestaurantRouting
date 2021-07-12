<template>
   <v-main>
      <v-app>
         <KitchenOrder />
         <Footer />
      </v-app>
   </v-main>
</template>

<script>
   import KitchenOrder from './components/KitchenOrder.vue'
   import Footer from './components/Footer.vue'

   export default {
      name: 'app',
      components: {
         Footer,
         KitchenOrder
      }
   }
</script>

<style>
   #app {
      font-family: Avenir, Helvetica, Arial, sans-serif;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      text-align: center;
      color: #2c3e50;
      background-color: darkblue;
   }

   #v-main {
      background-color: darkblue;
      background-image: url('assets/imgs/66d15f90fac618893bab025c7729a75f.jpg');
      background-repeat: no-repeat;
   }
</style>
