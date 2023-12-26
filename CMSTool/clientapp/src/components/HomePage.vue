
<script>
    import AvailableNews from './AvaliableNews.vue';
import GetCMSData from './GetCMSData.vue';

    export default {
        data() {
            return {
                selectedComponent: null,
            };
        },
        components: {
            AvailableNews,
            GetCMSData,
            // Include other components here
        },
        methods: {
            showContent(componentName) {
                this.selectedComponent = componentName;
            },
            logout() {
                // Implement logout functionality here
            },
        },
    };
</script>

<template>
    <v-card>
        <v-layout>
            <v-navigation-drawer class="bg-deep-purple" theme="dark" permanent>
                <v-list color="transparent">
                    <!-- Utilize the v-list-item to call the showContent method -->
                    <v-list-item @click="showContent('AvailableNews')" prepend-icon="mdi-view-dashboard" title="Available News"></v-list-item>
                    <v-list-item @click="showContent('PostToCMS')" prepend-icon="mdi-widgets" title="Post to CMSs"></v-list-item>
                    <v-list-item @click="showContent('GetCMSData')" prepend-icon="mdi-folder_open" title="Available on CMS"></v-list-item>
                </v-list>

                <template v-slot:append>
                    <div class="pa-2">
                        <!-- Call the logout method on button click -->
                        <v-btn @click="logout" block>
                            Logout
                        </v-btn>
                    </div>
                </template>
            </v-navigation-drawer>

            <v-main style="height: 100%">
                <!-- Use dynamic component to display selected component -->
                <component :is="selectedComponent"></component>
            </v-main>
        </v-layout>
    </v-card>
</template>


