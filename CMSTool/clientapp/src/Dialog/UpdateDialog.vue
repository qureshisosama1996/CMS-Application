<template>
    <v-row justify="center">
        <v-dialog v-model="dialog"
                  persistent
                  width="500px">
        
            <v-card>
                <v-card-title class="text-h5">
                    <center v-if="success" color="green">Request Sucessful!</center> 
                    <center v-if="!success" color="Red">Request Failed!</center> 
                </v-card-title>
                <v-container fluid>
      <template v-if="success">
        <div><strong>{{message}}</strong></div>
      </template>
      <template v-if="!success">
        <div><strong>{{message}}</strong></div>
      </template>
  </v-container>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="green-darken-1"
                           @click="close">
                        okay
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-row>
</template>
<script >
    export default {
        data() {
            return {
                dialog: false,
            }
        },
        props:{
            success:Boolean,
            dialogsucess:Boolean,
            message:String,
        },
        watch: {
            dialogsucess(val) {
                this.dialog = val;
            }
        },
        methods: {
            close() {
                this.$emit("close-dialog-update");
        }
        
    }
}
</script>