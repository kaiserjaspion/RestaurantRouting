<template>
   <v-main fluid fill-height>
      <v-layout align-center justify-center>
         <v-flex xs12 sm8 md6>
            <v-row justify="space-around" style="padding-top:5%;">
               <v-card max-width="500"
                       class="mx-auto"
                       style="height: 900px;
                              min-width: 310px;
                              padding-left: 5px;
                              padding-right: 5px;">
                  <v-card-title>Pedidos</v-card-title>


                  <v-divider inset
                             vertical></v-divider>
                  <v-card v-for="request in requested" :key="request.idMenu">
                     <v-card-title class="text-h5">
                        {{ request.idMenu }} - {{ request.menuName }}
                        <v-spacer></v-spacer>
                     </v-card-title>

                     <v-card-text style="text-align:left;">
                        <div v-for="ingredient in request.ingredients" :key="ingredient.idIngredient">
                           {{ingredient.idIngredient}} - {{ingredient.ingredientName}} - {{ingredient.qtdItem}}
                        </div>
                     </v-card-text>
                  </v-card>
                  <v-divider inset
                             vertical></v-divider>
               </v-card>
            </v-row>
         </v-flex>
      </v-layout>
   </v-main>
</template>

<script>
   import kitchenOrder from "../service/kitchenorder.service";
   export default {
      name: 'KitchenOrder',
      props: {
      },
      data: () => ({
         requested: []
      }),
      async created() {
         await this.get();
         await this.getByFront()
      },
      methods: {
         async get() {
            await kitchenOrder.getOrders()
               .then((resp) => {
                  resp.forEach((x) => {
                     this.requested.push(x);
                  })
               })
               .then((resp) => { this.get(); });
         },
      },
   }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
   h3 {
      margin: 40px 0 0;
   }

   ul {
      list-style-type: none;
      padding: 0;
   }

   li {
      display: inline-block;
      margin: 0 10px;
   }

   a {
      color: #42b983;
   }
</style>
