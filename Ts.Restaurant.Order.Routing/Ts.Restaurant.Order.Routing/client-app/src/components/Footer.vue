<template>
  <v-card >
    <v-footer app  
      padless
      fixed   
    >
      <v-card 
      dark 
      width="100%" 
      style="background-color: #041e42; border-radius: 0"
            
      > 
        <v-divider></v-divider> 

        <v-card-text style="display: -webkit-inline-box; color: #ffffff; -webkit-box-pack: center">   
        Desenvolvido por 
         <strong>BPT</strong>
        </v-card-text>
      </v-card>
    </v-footer>

     
  </v-card>
</template>

<script>
  export default {
    data: () => ({ 
      items: [ 
        'fixed' 
      ],
      padless: true,
      }),
      created() {
        
      },
   }
</script>

<style scoped>
.dark--blue--inb{
    background-color: #041e42;
}
</style>