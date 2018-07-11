<template>
<div id="ConsultaEmpleados">



<div class = "container-fluid">
<div class="row">
      <div class="col-sm-1">
      <h3>Empleados</h3>
      </div>
      <div class="col-sm-9">
      <router-link v-bind:to="'/Em'"><button class="btn" id="mas"><i class="fa fa-plus"></i></button></router-link>
      </div>
      </div>
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
        <th>Acciones</th>
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
        <td>
         <button v-on:click="Eliminar(cuerpo.ID)" class='btn' id="eliminar"><i class="fa fa-trash"></i></button>
        <router-link v-bind:to="'/EE/' + cuerpo.ID"><button class="btn"><i class="fa fa-pencil"></i></button></router-link>
        </td>
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
     cuerpos: [],
     desechado: false
    }
  },

  methods:{

    Eliminar:function(IdEliminado)
    {
      this.$http.put('http://localhost:61542/Api/Empleados/' + IdEliminado,{
        ID: 2,
        Desechado:this.desechado

      }).then(location.reload())
           
        
    }

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

.btn{
    background-color:  #0158A7; /* Blue background */
    border: none; /* Remove borders */
    color:white; /* White text */
    padding: 12px 16px; /* Some padding */
    font-size: 16px; /* Set a font size */
    cursor: pointer; /* Mouse pointer on hover */
}

#mas{
  background-color:  #0158A7; /* Blue background */
    border: none; /* Remove borders */
    color:white; /* White text */
    padding: 5px 10px; /* Some padding */
    font-size: 16px; /* Set a font size */
    cursor: pointer;
    margin-top: 17px;
    margin-left: 26px;
}

#mas:hover{
  color:#0158A7;
    background-color: white;
}

.btn:hover {
    color:#0158A7;
    background-color: white;  
}


</style>