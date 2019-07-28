import Vue from 'vue'
import App from './App.vue'
import Constants from './utils/constants';
import GlobalComponents from './global-component-registry';
import Api from './api';
import router from './router';

Vue.config.productionTip = false

Vue.use(GlobalComponents);

Vue.prototype.$constants = Constants;
Vue.prototype.$api = Api;

new Vue({
	router,
	render: h => h(App),
}).$mount('#app')
