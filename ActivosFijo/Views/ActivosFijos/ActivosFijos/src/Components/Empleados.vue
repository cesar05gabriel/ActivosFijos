<template>
  <div id="Empleados">
      <div class = "container">
      <h3>Empleados</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Nombre</label><br>
          <input type="text" v-model="nombre" class="form-control" placeholder="Ingrese el nombre" required><br><br>
          <label>Cedula</label><br>
          <input type="text" v-model="cedula" class="form-control" placeholder="Ingrese la cedula" required><br><br>
          <label>Departamento</label><br>
          <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>-->
          <select class="custom-select" style="width:100px; height:30px;" v-model="departamento">
            <option v-for="cuerpo in cuerpos">{{cuerpo.ID}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Tipo de Persona</label><br>
          <!--<input type="number" v-model="tipo_persona" class="form-control" placeholder="Seleccione el tipo de persona" min="1" required><br><br>-->
          <select class="custom-select" style="width:100px; height:30px;" v-model="tipo_persona">
            <option v-for="Tipocuerpo in Tiposcuerpos">{{Tipocuerpo.ID}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Fecha de Ingreso</label><br>
          <input type="date" v-model="fecha_ingreso" class="form-control" placeholder="Seleccione la fecha" min="2018-07-01" required><br><br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="estado"><br><br>          
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
     Tiposcuerpos:[] 
    }
  },

  methods:{
    post:function()
    {
      this.$http.post('http://localhost:61542/Api/Empleados',{
        Nombre:this.nombre,
        Cedula:this.cedula,
        Departamento:this.departamento,
        Tipo_Persona:this.tipo_persona,
        Fecha_Ingreso:this.fecha_ingreso,
        Estado:this.estado
      }).then(function(data){
        console.log(data);
      });
      alert("Empleado guardado exitosamente!");
      window.location.href = "/CEm";
    }
  },

   created()
    {
        this.$http.get('http://localhost:61542/Api/Departamentos').then(function(data){
           this.cuerpos = data.body;
        })

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