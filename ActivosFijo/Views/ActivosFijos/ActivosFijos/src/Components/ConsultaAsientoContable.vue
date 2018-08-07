<template>
<div id="ConsultaAsientoContable">



<div class = "container-fluid">
<div class="row">
      <div class="col-sm-2">
      <h3>Asiento Contable</h3>
      </div>
      <div class="col-sm-20">
      <router-link v-bind:to="'/AC'"><button class="btn" id="mas"><i class="fa fa-plus"></i></button></router-link>
      </div>
      </div>
<br>
<br>
<div class="table-responsive"> 

      <table class="table">
    <thead>
      <tr>
        <th>ID Asiento</th>
        <th>Fecha Asiento</th>
        <th>Descripcion</th>
        <th>ID Inventario</th>
        <th>Cuenta Contable</th>
        <th>Monto</th>
        <th>Estado</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(cuerpo, index) in cuerpos" class="table-responsive">
        <td>{{cuerpo.id}}</td>
        <td>{{cuerpo.date}}</td>
        <td>{{cuerpo.description}}</td>
        <td>{{cuerpo.auxiliaryId}}</td>
        <td>{{cuerpo.currencyId}}</td>
        <td>{{cuerpo.exchangeRate}}</td>
        <td>{{cuerpo.status}}</td>
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
     desechado: true
    }
  },

    created()
    {
        this.$http.get('https://simpleaccountingapp-api.azurewebsites.net/journalEntries').then(function(data){
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
    margin-right: 90px;
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