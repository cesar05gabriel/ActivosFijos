<template>
  <div id="ConsultaActivosFijos">



  <div class = "container-fluid">
<h3>Activos Fijos</h3>
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
        <th>Periodo</th>
        <th>Monto Depreciacion</th>
        <th>Acciones</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="cuerpo in cuerpos" class="table-responsive">
        <td>{{cuerpo.ID}}</td>
        <td>{{cuerpo.Descripcion}}</td>
        <td>{{cuerpo.Departamento}}</td>
        <td>{{cuerpo.Tipos_Activos}}</td>
        <td>{{cuerpo.Fecha_Registro}}</td>
        <td>{{cuerpo.Valor_Compra}}</td>
        <td>{{cuerpo.Depreciacion_Acumulada}}</td>
        <td>{{cuerpo.Periodo}}</td>
        <td>{{cuerpo.Monto_Despreciado}}</td>
        <td>
        <button v-on:click.prevent="Eliminar(cuerpo.ID), Actualizar" class='btn btn-danger btn-sm'>Eliminar</button>
        <button onclick="TestingIt()" class="btn btn-primary btn-sm">Editar</button>        
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
    Eliminar:function(IdEliminado)
    {
      this.$http.put('http://localhost:61542/Api/Ac_Fijos/' + IdEliminado,{
        Desechado:this.desechado

      }).then(function(data){
        console.log(data);
      });
    },

    Actualizar:function()
    {
      this.$http.get('http://localhost:61542/Api/Ac_Fijos').then(function(data){
           this.cuerpos = data.body;
          console.log(data);
        })
    }

    },

    created()
    {
        this.$http.get('http://localhost:61542/Api/Ac_Fijos').then(function(data){
           this.cuerpos = data.body;
          console.log(data);
        })
  }
}

function TestingIt(){
  alert("we");
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