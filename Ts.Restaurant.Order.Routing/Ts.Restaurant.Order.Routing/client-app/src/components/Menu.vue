<template>
   <v-content fluid fill-height>
      <v-layout align-center justify-center>
         <v-flex xs12 sm8 md4 id="login">
            <v-row justify="space-around">
                  <v-card :loading="loading"
                          class="mx-auto my-12"
                          max-width="800"
                          align-center
                          justify-center>
                     <v-card-title> Menu </v-card-title>
                     <v-data-table :headers="headers"
                                   :items="request"
                                   :search="search"
                                    :single-expand="singleExpand"
                                    :expanded.sync="expanded"
                                    item-key="menuName"
                                    show-expand
                                   :items-per-page="15"
                                   :loading ="isLoading"
                                   loading-text="Loading... Please wait"
                                   group-by="foodType.foodName"
                                   class="elevation-1"
                                   :footer-props="{
                                       showFirstLastPage: true
                                    }">
                        <template v-slot:group.header="{ headers,items }">
                           <td colspan="12" align="left">
                              </v-icon>
                              {{ items[0].foodType.foodName }}
                           </td>
                        </template>
                        <template v-slot:top>
                           <v-toolbar flat>
                              <v-toolbar-title class="mx-4"
                                               style="margin:5px;">
                                 Search
                              </v-toolbar-title>
                              <v-text-field v-model="search"
                                            class="ms-8"
                                            append-icon="mdi-magnify"
                                            label="pizza,ice-cream..."
                                            single-line
                                            hide-details></v-text-field>
                           </v-toolbar>
                        </template>
                        <template v-slot:item.actions="{ item }">
                           <v-btn small
                                   class="mr-2"
                                   @click="saveOrder(item)"
                                  outlined
                                  color="primary"
                                  >
                              Pedir
                           </v-btn>
                        </template>
                        <template v-slot:no-data>
                           <v-btn color="primary"
                                  @click="initialize">
                              Reset
                           </v-btn>
                        </template>

                        <template v-slot:expanded-item="{ headers, item }">
                           <td :colspan="headers.length">
                              <Ingredients :ingredients="item.ingredients" />
                           </td>
                        </template>
                     </v-data-table>
                  </v-card>
            </v-row>
         </v-flex>
      </v-layout>
   </v-content>
</template>

<script>
   import ordermenuService from "../service/ordermenu.service";
   import ingredients from './Ingredients';

   export default {
      name: 'Menu',
      props: {
      },
      data: () => ({
         expanded: [],
         singleExpand: false,
         search: "",
         request: [],
         isLoading: true,
         headers: [
            {
               text: "Id",
               align: "start",
               value: "idMenu",
               groupable: false,
               sortable: false,
               class: "ms-2"
            },
            {
               text: "Nome",
               value: "menuName",
               sortable: false,
               groupable: false,
               class: "mx-4"
            },
            {
               text: "Qt Ingredients",
               value: "ingredients.length",
               sortable: false,
               groupable: false,
               class: "mx-4"
            },
            {
               text: "Category",
               value: "foodType.foodName",
               sortable: false,
               align: 'right'
            },
            { text: '', value: 'actions', sortable: false, groupable: false },
            { text: '', value: 'data-table-expand', groupable: false },
         ],
      }),
      async created() {
         this.request = await ordermenuService.getMenu();
         this.isLoading = false
      },
      components: {
         Ingredients: ingredients
      },
      methods: {
         async saveOrder(item) {
            let data = await ordermenuService.postMenu(item);
         }
      }
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
