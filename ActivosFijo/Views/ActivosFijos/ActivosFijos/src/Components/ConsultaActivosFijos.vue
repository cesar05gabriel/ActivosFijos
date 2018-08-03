<template>
  <div id="ConsultaActivosFijos">



  <div class = "container-fluid">
<div class="row">
      <div class="col-sm-1">
      <h3>Activos</h3>
      </div>
      <div class="col-sm-13">
      <router-link v-bind:to="'/Af'"><button class="btn" id="mas"><i class="fa fa-plus"></i></button></router-link>
      </div>
      </div>
<br>
<br>
<div class="table-responsive"> 

      <table class="table">
    <thead>
      <tr>
        <th>ID</th>
        <th>Descripcion</th>
        <th>Departamento</th>
        <th>Tipos de Activos</th>
        <th>Fecha de Registro</th>
        <th>Valor de Compra</th>
        <th>Depreciacion Acumulada</th>
        <!--<th>Periodo</th>-->
        <th>Monto Depreciacion</th>
        <th>Acciones</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(cuerpo, index) in cuerpos" class="table-responsive">
        <td>{{cuerpo.ID}}</td>
        <td>{{cuerpo.Descripcion}}</td>
        <td>{{cuerpo.Departamento}}</td>
        <td>{{cuerpo.Tipos_Activos}}</td>
        <td>{{cuerpo.Fecha_Registro}}</td>
        <td>{{cuerpo.Valor_Compra}}</td>
        <td>{{cuerpo.Depreciacion_Acumulada}}</td>
        <!--<td>{{cuerpo.Periodo}}</td>-->
        <td>{{cuerpo.Monto_Despreciado}}</td>
        <td>
        <button v-on:click="Eliminar(cuerpo.ID, index)" class='btn' id="eliminar"><i class="fa fa-trash"></i></button>
        <router-link v-bind:to="'/EAF/' + cuerpo.ID"><button class="btn"><i class="fa fa-pencil"></i></button></router-link>
        <a :href="'http://localhost:61542/Depreciacion/Index/' + cuerpo.ID"><button class="btn"><i class="fa fa-list"></i></button></a>        
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
  name: 'ConsultaActivosFijos',
  data () {
    return {
     descripcion:"",
     desechado: true,
     cuerpos: []
    }
  },

  methods:{
    Eliminar:function(IdEliminado, index)
    {
     var txt;
      var quitar = this.cuerpos;
    var r = confirm("Desea eliminar el activo fijo seleccionado ?" );
    if (r == true) {
        this.$http.delete('http://activosfijo20180720102414.azurewebsites.net/api/Ac_Fijos/' + IdEliminado,{
        ID: IdEliminado,

      }).then(Response => quitar.splice(index, 1))

    } 
           
        
    },

    Actualizar:function()
    {
      this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Ac_Fijos').then(function(data){
           this.cuerpos = data.body;
          console.log(data);
        })
    }

    },

    created()
    {
        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Ac_Fijos').then(function(data){
           this.cuerpos = data.body;
          console.log(data);
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