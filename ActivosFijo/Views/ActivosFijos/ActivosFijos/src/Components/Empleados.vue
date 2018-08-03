<template>
  <div id="Empleados">
      <div class = "container">
  
      <h3>Empleados</h3>
      
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Nombre</label><br>
          <input type="text" v-model="nombre" v-validate="'required'" name="nombre" class="form-control" placeholder="Ingrese el nombre">
          <span v-show="errors.has('nombre')" class="text-danger">El nombre es requerido.</span><br><br>
          <label>Cedula</label><br>
          <input type="text" v-model="cedula" v-validate="'cedula'" name="cedula" class="form-control" placeholder="Ingrese la cedula">
          <span v-show="errors.has('cedula')" class="text-danger">La cedula es requerida.</span><br><br>
          <label>Usuario</label><br>
          <input type="text" v-model="usuario" placeholder="Ingrese el usuario" v-validate="'required'" name="usuario" class="form-control" id="username" />
          <span v-show="errors.has('usuario')" class="text-danger">Complete el usuario correctamente.</span><br><br>
          <label>Clave</label><br>
          <input type="password" v-model="clave" placeholder="Ingrese la clave" v-validate="'required'" name="clave" class="form-control" id="password" />
          <span v-show="errors.has('clave')" class="text-danger">Complete la clave correctamente.</span><br><br>
          <label>Departamento</label><br>
          <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>-->
          <select class="custom-select" style="width:100px; height:30px;" v-model="departamento">
            <option v-for="cuerpo in cuerpos" v-bind:value='cuerpo.ID' v-bind:key='cuerpo.ID'>{{cuerpo.Descripcion}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Tipo de Persona</label><br>
          <!--<input type="number" v-model="tipo_persona" class="form-control" placeholder="Seleccione el tipo de persona" min="1" required><br><br>-->
          <select class="custom-select" style="width:100px; height:30px;" v-model="tipo_persona">
            <option v-for="Tipocuerpo in Tiposcuerpos" v-bind:value='Tipocuerpo.ID' v-bind:key='Tipocuerpo.ID'>{{Tipocuerpo.Tipo_Persona1}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Fecha de Ingreso</label><br>
          <input type="date" v-validate="'required'" name="fecha" v-model="fecha_ingreso" class="form-control" placeholder="Seleccione la fecha" >
          <span v-show="errors.has('fecha')" class="text-danger">La fecha de ingreso es requerida.</span><br><br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="estado"><br><br>          
          <button v-on:click.prevent ="post" class="btn btn-primary" :disabled="errors.any()">Enviar</button><br><br>
      </div>
      </form>
      </div>
  </div> 
</template>

<script>
import { Validator } from 'vee-validate';
Validator.extend('cedula', {
    getMessage: field => `The password must contain at least: 1 uppercase letter, 1 lowercase letter, 1 number, and one special character (E.g. , . _ & ? etc)`,
    validate: value => {
        var ced=value;
	                                var c = ced.replace(/-/g,'');  
	                                var cedula = c.substr(0, c.length - 1);  
	                                var verificador = c.substr(c.length - 1, 1);  
	                                var suma = 0;  
		                            var cedulaValida = 0;
	                                if(ced.length < 11) { return false; }  
	                                    for (i=0; i < cedula.length; i++) {  
	                                           mod = "";  
	                                           if((i % 2) == 0){mod = 1} else {mod = 2}  
	         res = cedula.substr(i,1) * mod;  
	         if (res > 9) {  
	              res = res.toString();  
	              uno = res.substr(0,1);  
	              dos = res.substr(1,1);  
	              res = eval(uno) + eval(dos);  
	         }  
	         suma += eval(res);  
	    }  
	    el_numero = (10 - (suma % 10)) % 10;  
	    if (el_numero == verificador && cedula.substr(0,3) != "000") {  
	      cedulaValida = 1;
	    }  
	    else   {  
	     cedulaValida = 0;
	    }  
		return cedulaValida;
    }
});

export default {
  name: 'Empleados',
  data () {
    return {
     nombre:"",
     cedula:"",
     departamento: 1,
     tipo_persona: 1,
     fecha_ingreso: Date,
     estado: false,
     cuerpos:[],
     Tiposcuerpos:[],
     usuario: "",
     clave: "" 
    }
  },
  methods:{
    post:function()
    {
      this.$validator.validateAll().then(res=>{
                if(res) {
      this.$http.post('http://activosfijo20180720102414.azurewebsites.net/api/Empleados',{
        Nombre:this.nombre,
        Cedula:this.cedula,
        Username:this.usuario,
        Password:this.clave,
        Departamento:this.departamento,
        Tipo_Persona:this.tipo_persona,
        Fecha_Ingreso:this.fecha_ingreso,
        Estado:this.estado
      }).then(function(data){
        console.log(data);
        this.$router.go(-1);
      });
      }})
    }
  },

   created()
    {
        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Departamentos', {params: {activos: true}}).then(function(data){
           this.cuerpos = data.body;
        })

        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Tipo_Persona', ).then(function(data){
           this.Tiposcuerpos = data.body;
        })
  }
}
</script>

<style scoped>

#caja{
  padding-right: 5px;
}



</style>