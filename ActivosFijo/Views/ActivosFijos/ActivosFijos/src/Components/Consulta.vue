<template>
  <div id="Consulta">

  <div class = "container-fluid">
<h3>Departamentos de Unapec</h3>
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
          <button class="btn btn-primary">Editar</button>
          <button class="btn btn-danger">Eliminar</button>
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
     search: ""
    }
  },

  methods:{
    post:function()
    {
      this.$http.post('http://localhost:61542/Api/Departamentos',{
        Descripcion:this.descripcion,
        Estado:this.estado
      }).then(function(data){
        console.log(data);
      });
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


</style>