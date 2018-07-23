<template>
  <div id="ConsultaTiposActivos">



  <div class = "container-fluid">
<div class="row">
<div class="col-sm-2">
<h3>Tipos de Activos</h3>
</div>
<div class="col-sm-13">
<router-link v-bind:to="'/TiAc'"><button class="btn" id="mas"><i class="fa fa-plus"></i></button></router-link>
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
        <th>Cuenta Contable Compra</th>
        <th>Cuenta Contable Depreciacion</th>
        <th>Estado</th>
        <th>Acciones</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(cuerpo, index) in cuerpos" class="table-responsive">
        <td>{{cuerpo.ID}}</td>
        <td>{{cuerpo.Descripcion}}</td>
        <td>{{cuerpo.Contable_Compra}}</td>
        <td>{{cuerpo.Contable_Depreciacion}}</td>
        <td>{{cuerpo.Estado}}</td>
        <td>
         <button v-on:click="Eliminar(cuerpo.ID, index)" class='btn' id="eliminar"><i class="fa fa-trash"></i></button>
        <router-link v-bind:to="'/ET/' + cuerpo.ID"><button class="btn"><i class="fa fa-pencil"></i></button></router-link>
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
  name: 'ConsultaTiposActivos',
  data () {
    return {
     descripcion:"",
     estado: false,
     cuerpos: [],
     desechado: true

    }
  },

  methods:{

    Eliminar:function(IdEliminado, index)
    {
      var txt;
      var quitar = this.cuerpos;
    var r = confirm("Desea eliminar el tipo de activo seleccionado ?" );
    if (r == true) {
        this.$http.delete('http://localhost:61542/Api/Tipos_Activos/' + IdEliminado,{
        ID: IdEliminado,

      }).then(Response => quitar.splice(index, 1))
        
    }
    }

    },

    created()
    {
        this.$http.get('http://localhost:61542/Api/Tipos_Activos').then(function(data){
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