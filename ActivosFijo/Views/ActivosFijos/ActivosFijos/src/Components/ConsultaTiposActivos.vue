<template>
  <div id="ConsultaTiposActivos">



  <div class = "container-fluid">
<h3>Tipos de Activos</h3>
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
      </tr>
    </thead>
    <tbody>
      <tr v-for="cuerpo in cuerpos" class="table-responsive">
        <td>{{cuerpo.ID}}</td>
        <td>{{cuerpo.Descripcion}}</td>
        <td>{{cuerpo.Contable_Compra}}</td>
        <td>{{cuerpo.Contable_Depreciacion}}</td>
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
  name: 'ConsultaTiposActivos',
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


</style>