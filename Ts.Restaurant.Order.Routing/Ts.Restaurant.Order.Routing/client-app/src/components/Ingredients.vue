<template>
   <v-data-table :headers="headers"
                  :items="ingredients">
   </v-data-table>
</template>

<script>
   export default {
      name: 'Ingredients',
      props: {
         ingredients: {
            type: [],
            required: true
         }
      },
      data: () => ({
         search: "",
         headers: [
            {
               text: "Id",
               align: "start",
               value: "idIngredient",
               class: "md-1"
            },
            {
               text: "Nome",
               align: "left",
               value: "ingredientName",
               class: "md-9"
            },
            {
               text: "Quantidade",
               align: "left",
               value: "qtdItem",
               class: "md-3"
            },

         ],
      })
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

   button {
      display: none
   }

   tr {
      background: aqua;
   }
</style>
