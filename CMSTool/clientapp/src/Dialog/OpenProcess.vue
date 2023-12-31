<template>
    <v-row justify="center">
        <v-dialog v-model="dialog"
                  persistent
                  width="500px">
        
            <v-card>
                <v-card-title class="text-h5">
                    <center>Process to AI Tool</center> 
                </v-card-title>
                <v-container fluid>
    <v-radio-group v-model="radios">
      <template v-slot:label>
        <div>Select <strong>your option to Process to AI</strong></div>
      </template>
      <v-radio value="post">
        <template v-slot:label>
          <div><strong class="text-success">Only Posts</strong></div>
        </template>
      </v-radio>
      <v-radio value="postandimage">
        <template v-slot:label>
          <div> <strong class="text-primary">Posts and Image</strong></div>
        </template>
      </v-radio>
    </v-radio-group>
  </v-container>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="red-darken-1"
                           variant="text"
                           @click="this.$emit('close-dialog')">
                        Cancel
                    </v-btn>
                    <v-btn color="primary" variant="tonal" :loading="loadingbutton" @click="processtoAI">
                        Submit
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-row>
    <template>
        <UpdateDialog :dialogsucess="dialogsucess" :success="success" :message="confirmmessage"
                      @close-dialog-update="dialogsucess=false"></UpdateDialog>
    </template>
</template>
<script >
    import CryptoData from '../Model/CryptoData.js';
    import UpdateDialog from './UpdateDialog.vue';
    export default {
        data() {
            return {
                dialog: false,
                radios: "post",
                loadingbutton: false,
                dialogsucess : false,
                success: Boolean,
                message: String
            }
        },
        components:{
            UpdateDialog
        },
        props:{
            selecteditemvalue: [],
            dialogvalue:Boolean
        },
        watch: {
            dialogvalue(val) {
                this.dialog = val;
            }
        },
        methods: {
            processtoAI() {
                this.loadingbutton = true;
                var ListCryptoData=[];
                for (var item of this.selecteditemvalue) {
                    const cryptodata = Object.assign({}, CryptoData, {
                        Source: item.source,
                        Headline: item.headline,
                        PublishedDate: item.publishedDate,
                        NewsType: item.newsType,
                    });    
                    ListCryptoData.push(cryptodata);
                }

                fetch('/api/AI/processAI', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(ListCryptoData),
                })
                    .then(async (response) => {
                        if (!response.ok) {
                            this.loadingbutton = false;
                            this.$emit("close-dialog");
                            this.dialogsucess = true;
                            this.success = false;
                            this.confirmmessage = `Network Error,Please check your internet!`;
                        }

                        const responseData = await response.text(); // Parse the response as text

                        if (responseData === 'passed') {
                            // Success case
                            this.loadingbutton = false;
                            this.$emit("close-dialog");
                            this.dialogsucess = true;
                            this.success = true;
                            this.confirmmessage = "Congratulations! Request has been Processed by AI Successfully";
                        } else {
                            // Error case
                            this.loadingbutton = false;
                            this.$emit("close-dialog");
                            this.dialogsucess = true;
                            this.success = false;
                            this.confirmmessage = `Failed! ErrorMessage: ${responseData}`;
                        }
                    })
                    .catch((error) => {
                        // Network or other error
                        console.error('Error calling API:', error);
                        this.dialog = false;
                        this.dialogsucess = true;
                        this.success = false;
                        this.confirmmessage = `Failed! ErrorMessage: ${error}`;
                    });
            },
        }
        
    }
</script>