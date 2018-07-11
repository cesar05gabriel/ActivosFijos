<template>
  <div id="Consulta">

  <div class = "container-fluid">
 <div class="row">
<div class="col-sm-3">
<h3>Departamentos de Unapec</h3>
</div>
<div class="col-sm-16">
<router-link v-bind:to="'/Dep/'"><button class="btn" id="mas"><i class="fa fa-plus"></i></button></router-link>
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
        <th>Estado</th>
        <th>Acciones</th>
      </tr>
    </thead> 
    <tbody>
      <tr v-for="cuerpo in cuerpos" class="table-responsive">
        <td>{{cuerpo.ID}}</td>
        <td>{{cuerpo.Descripcion}}</td>
        <td>{{cuerpo.Estado}}</td>
        <td>
         <button v-on:click="Eliminar(cuerpo.ID)" class='btn' id="eliminar"><i class="fa fa-trash"></i></button>
        <router-link v-bind:to="'/ED/' + cuerpo.ID"><button class="btn"><i class="fa fa-pencil"></i></button></router-link>
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
  name: 'Consulta',
  data () {
    return {
     descripcion:"",
     estado: false,
     cuerpos: [],
     search: "",
     desechado:true
    }
  },

  methods:{
    Eliminar:function(IdEliminado)
    {
      this.$http.put('http://localhost:61542/Api/Departamentos/' + IdEliminado,{
        ID: IdEliminado,
        Desechado:this.desechado

      }).then(location.reload())
           
        
    }

    },

    created()
    {
        this.$http.get('http://localhost:61542/Api/Departamentos').then(function(data){
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