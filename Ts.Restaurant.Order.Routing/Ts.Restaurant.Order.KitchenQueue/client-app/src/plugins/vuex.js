import Vue from 'vue';
import Vuex from 'vuex';
//import createPersistedState from "vuex-persistedstate";
import createCache from 'vuex-cache';

Vue.use(Vuex);

export const store = new Vuex.Store({
   modules: {
   },
   plugins: [createCache()],
})