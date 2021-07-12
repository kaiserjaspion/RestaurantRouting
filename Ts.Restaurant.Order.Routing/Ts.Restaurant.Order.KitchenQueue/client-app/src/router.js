import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

import KitchenOrder from "./components/KitchenOrder";

export default new Router({
    mode: 'history',
    routes: [
        {
            alias: ["/", "/home"],
            path: '/Home',
          component: KitchenOrder
        }
    ]
})