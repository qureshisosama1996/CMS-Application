<template>
    <v-card flat
            title="Avaliable News">
        <template v-slot:text>
            <v-text-field v-model="search"
                          label="Search"
                          prepend-inner-icon="mdi-magnify"
                          single-line
                          variant="outlined"
                          hide-details></v-text-field>
            <v-btn color="primary"
                   @click="openDialog">
                Open Dialog
            </v-btn>
        </template>
        <v-data-table v-model="selected"
                      :items="items"
                      :loading="loading"
                      :search="search"
                      :items-per-page="5"
                      item-value="headline"
                      show-select></v-data-table>
        <open-process :selecteditemvalue="selected"></open-process>
    </v-card>
</template>

<script>
    import OpenProcess from '../Dialog/OpenProcess.vue';



    export default {
        data() {
            return {
                selected: [],
                items: [],
                search: '',
            };
        },
        mounted() {
            // Fetch data from the ASP.NET API
            this.fetchData();
        },
        components: {
            OpenProcess
        },
        methods: {
            async fetchData() {
                try {
                    const response = await fetch('/api/GetNews/GetCryptoNews');

                    if (!response.ok) {
                        throw new Error(`HTTP error! Status: ${response.status}`);
                    }

                    const data = await response.json();
                    this.items = data; // Set the fetched data to the items array
                } catch (error) {
                    console.error('Error fetching data:', error);
                }
            },

            openDialog() {
                this.dialog = true;
            }

        },
    };
</script>
