import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

import Menu from "./components/Menu";

export default new Router({
    mode: 'history',
    routes: [
        {
            alias: ["/", "/home"],
            path: '/Home',
          component: Menu
        }
    ]
})