import Vue from 'vue'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import colors from 'vuetify/lib/util/colors'
import '@mdi/font/css/materialdesignicons.css'

Vue.use(Vuetify)

export default new Vuetify({
    icons: {
    iconfont: 'mdi' 
  },
  theme: {
    themes: {
      light: {
        primary: colors.indigo.darken4, 
        secondary: colors.blue.darken4, 
        accent: colors.indigo.base,
        corzinha: colors.cyan.darken1
      },
    },
  },
})
