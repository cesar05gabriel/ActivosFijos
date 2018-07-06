<template>
<div id="ConsultaEmpleados">



<div class = "container-fluid">
<h3>Empleados</h3>
<br>
<br>
<div class="table-responsive"> 

      <table class="table">
    <thead>
      <tr>
        <th>ID</th>
        <th>Nombre</th>
        <th>Cedula</th>
        <th>Departamento</th>
        <th>Tipo de Persona</th>
        <th>Fecha de Ingreso</th>
        <th>Estado</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="cuerpo in cuerpos" class="table-responsive">
        <td>{{cuerpo.ID}}</td>
        <td>{{cuerpo.Nombre}}</td>
        <td>{{cuerpo.Cedula}}</td>
        <td>{{cuerpo.Departamento}}</td>
        <td>{{cuerpo.Tipo_Persona}}</td>
        <td>{{cuerpo.Fecha_Ingreso}}</td>
        <td>{{cuerpo.Estado}}</td>
      </tr>
    </tbody>
   
	  <br>
	  <br>
	  </table>
       </div>

  </div>
  </div>
  

 
</template>

<script>
export default {
  name: 'ConsultaEmpleados',
  data () {
    return {
     descripcion:"",
     estado: false,
     cuerpos: []
    }
  },

  methods:{

    },

    created()
    {
        this.$http.get('http://localhost:61542/Api/Empleados').then(function(data){
           this.cuerpos = data.body;
        })
  }
}
</script>

<style scoped>

#caja{
  padding-right: 5px;
}

.container-fluid{

padding: 60px 50px;
}


</style>