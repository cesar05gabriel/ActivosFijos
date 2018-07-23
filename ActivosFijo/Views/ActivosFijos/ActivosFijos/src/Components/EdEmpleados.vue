<template>
  <div id="Empleados">
      <div class = "container">
      <h3>Empleados</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Nombre</label><br>
          <input type="text" v-model="cuerpos.Nombre" v-validate="'required'" name="nombre" class="form-control" placeholder="Ingrese el nombre">
          <span v-show="errors.has('nombre')" class="text-danger">El nombre es requerido.</span><br><br>
          <label>Cedula</label><br>
          <input type="text" v-model="cuerpos.Cedula" v-validate="'required'" name="cedula" class="form-control" placeholder="Ingrese la cedula" required><br><br>
          <label>Departamento</label><br>
          <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>-->
          <select class="custom-select" style="width:100px; height:30px;" v-model="cuerpos.Departamento">
            <option v-for="cuerpo in cuerpos">{{cuerpos.Departamento}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Tipo de Persona</label><br>
          <!--<input type="number" v-model="tipo_persona" class="form-control" placeholder="Seleccione el tipo de persona" min="1" required><br><br>-->
          <select class="custom-select" style="width:100px; height:30px;" v-model="cuerpos.Tipo_Persona">
            <option v-for="cuerpo in cuerpos">{{cuerpos.Tipo_Persona}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Fecha de Ingreso</label><br>
          <input type="date" v-model="cuerpos.Fecha_Ingreso" v-validate="'required'" name="fecha" class="form-control" placeholder="Seleccione la fecha">
          <span v-show="errors.has('fecha')" class="text-danger">La fecha de ingreso es requerida.</span><br><br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="cuerpos.Estado"><br><br>          
          <button v-on:click.prevent ="post" class="btn btn-primary" :disabled="errors.any()">Enviar</button><br><br>
      </div>
      </form>
      </div>
  </div> 
</template>

<script>
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
     id:null,
     editar:[] 
    }
  },

  methods:{
    post:function()
    {
      this.$validator.validateAll().then(res=>{
                if(res) {
      this.$http.put('http://localhost:61542/Api/Empleados/' + this.id,{
        ID:this.id,
        Nombre:this.cuerpos.Nombre,
        Cedula:this.cuerpos.Cedula,
        Departamento:this.cuerpos.Departamento,
        Tipo_Persona:this.cuerpos.Tipo_Persona,
        Fecha_Ingreso:this.cuerpos.Fecha_Ingreso,
        Estado:this.cuerpos.Estado
      }).then(function(data){
        console.log(data);
        this.$router.go(-1);
      });
      }})
    }
  },

   created()
    {
         this.id = this.$route.params.id
        if(this.id != null){
          this.modo = 'E';
        this.$http.get('http://localhost:61542/Api/Empleados/' + this.id).then(function(data){
           this.cuerpos = data.body;
          console.log(data);
        });
    }

    this.$http.get('http://localhost:61542/Api/Empleados').then(function(data){
           this.editar = data.body;
          console.log(data);
        });

        this.$http.get('http://localhost:61542/Api/Tipo_Persona').then(function(data){
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