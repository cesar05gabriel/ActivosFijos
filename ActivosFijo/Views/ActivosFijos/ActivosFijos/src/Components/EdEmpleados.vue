<template>
  <div id="Empleados">
      <div class = "container">
      <h3>Empleados</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Nombre</label><br>
          <input type="text" v-model="cuerpos.Nombre" class="form-control" placeholder="Ingrese el nombre" required><br><br>
          <label>Cedula</label><br>
          <input type="text" v-model="cuerpos.Cedula" class="form-control" placeholder="Ingrese la cedula" required><br><br>
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
          <input type="date" v-model="cuerpos.Fecha_Ingreso" class="form-control" placeholder="Seleccione la fecha" min="2018-07-01" required><br><br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="cuerpos.Estado"><br><br>          
          <button v-on:click.prevent ="post" class="btn btn-primary">Enviar</button><br><br>
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
     id:null 
    }
  },

  methods:{
    post:function()
    {
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
      });
      alert("Empleado editado exitosamente!");
      window.location.href = "/CEm";
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