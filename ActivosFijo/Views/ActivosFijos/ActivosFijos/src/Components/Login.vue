<template>
    <div id="login">
        <div class="container">
            <h3>Iniciar Sesión</h3>
            <hr />
            <input type="text" placeholder="username" v-validate="'required'" name="usuario" class="form-control" id="username" />
            <span v-show="errors.has('usuario')" class="text-danger">Complete el usuario correctamente.</span><br><br>
            <input type="password" placeholder="password" v-validate="'required'" name="clave" class="form-control" id="password" />
            <span v-show="errors.has('clave')" class="text-danger">Complete la clave correctamente.</span><br><br>
            <button v-on:click.prevent ="login" class="btn btn-primary" :disabled="errors.any()"> Acceder </button>
            <br /><br /><br/>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Login', 
    data () {
    return {
     usarname: "",
     password: ""
    }
  },

    methods:{
        login: function(){
            this.$validator.validateAll().then(res=>{
                if(res) {
            this.username = document.getElementById('username').value;
            this.password = document.getElementById('password').value;
            this.$http.get("http://localhost:61542/Api/Empleados/Login?username=" + this.username + "&password=" + this.password).then(function(data){
                console.log(data);
                if (data.body == 1){

                    this.$router.push({ path: "/Home" })                    
                }
                else{
                    alert("Datos incorrectos");
                }
            });}})
        }
    }
}
</script>

<style>

</style>
