<template>
    <v-row justify="center">
        <v-dialog v-model="dialog"
                  persistent
                  width="auto">
        
            <v-card>
                <v-card-title class="text-h5">
                    Process to AI Tool
                </v-card-title>
                <v-container fluid>
    <v-radio-group v-model="radios">
      <template v-slot:label>
        <div>Select <strong>your option</strong></div>
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
                    <v-btn color="green-darken-1"
                           variant="text"
                           @click="dialog = false">
                        Disagree
                    </v-btn>
                    <v-btn color="green-darken-1"
                           variant="text"
                           @click="dialog = false">
                        Agree
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-row>
</template>
<script>
    export default {
        data() {
            return {
                dialog: false,
                radios:"post"
            }
        },
        props:{
            selecteditemvalue:null
        }
    }
</script>