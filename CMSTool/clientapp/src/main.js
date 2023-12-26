import router from './router';
import { createApp } from 'vue'
import App from './App.vue'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import HomePage from './components/HomePage.vue';

import '@mdi/font/css/materialdesignicons.css'; // Import MDI styles
const vuetify = createVuetify({
    components,
    directives,
})

const app = createApp(App);

app.component('home-page', HomePage);


app.use(router).use(vuetify).mount('#app');
