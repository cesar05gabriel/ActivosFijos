<template>
  <div id="AsientoContable">
      <div class = "container">
  
      <h3>Asientos Contables</h3>
      
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>ID Asiento</label><br>
          <input type="number" v-model="idasiento" v-validate="'required|min_value:1'" name="idasiento" class="form-control" placeholder="Ingrese el id del asiento">
          <span v-show="errors.has('idasiento')" class="text-danger" id="error">Complete el id del asiento correctamente.</span><br><br>
          <label>Fecha de Asiento</label><br>
          <input type="date" v-validate="'required'" name="fecha" v-model="fecha_asiento" class="form-control" placeholder="Seleccione la fecha" >
          <span v-show="errors.has('fecha')" class="text-danger">La fecha es requerida.</span><br><br>
          <label>Descripcion</label><br>
          <input type="text" v-model="descripcion" v-validate="'required'" name="descripcion" class="form-control" placeholder="Ingrese la descripcion" >
          <span v-show="errors.has('descripcion')" class="text-danger">La descripcion es requerida.</span><br><br>
          <label>ID de Tipo de Inventario</label><br>
          <input type="number" v-model="idinventario" v-validate="'required|min_value:1'" name="idinventario" class="form-control" placeholder="Ingrese el id del tipo de inventario">
          <span v-show="errors.has('idinventario')" class="text-danger" id="error">Complete el id del tipo de inventario correctamente.</span><br><br>
          <label>Cuenta Contable</label><br>
          <input type="number" v-validate="'required|min_value:1'" name="compra" v-model="contable_compra" class="form-control" placeholder="Ingrese la cuenta del contable">
          <span v-show="errors.has('fecha')" class="text-danger">La fecha de asiento es requerida.</span><br><br>
          <label>Monto Asiento</label><br>
          <input type="text" v-model="monto" v-validate="'required|min_value:0'" name="monto" class="form-control">  
          <span v-show="errors.has('monto')" class="text-danger" id="error">Complete el monto del asiento correctamente</span><br><br>      
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="estado"><br><br>          
          <button v-on:click.prevent ="post" class="btn btn-primary" :disabled="errors.any()">Enviar</button><br><br>
      </div>
      </form>
      </div>
  </div> 
</template>

<script>
export default {
  name: 'AsientoContable',
  data () {
    return {
     idasiento:1,
     descripcion:"",
     idinventario: 1,
     contable_compra: 1,
     fecha_asiento: Date,
     monto: 1,
     estado: false,
     cuerpos:[],
     Tiposcuerpos:[], 
    }
  },

  methods:{
    post:function()
    {
      this.$validator.validateAll().then(res=>{
                if(res) {
      this.$http.post('https://simpleaccountingapp-api.azurewebsites.net/journalEntries',{
        id:this.idasiento,
        date:this.fecha_asiento,
        description:this.descripcion,
        auxiliaryId:this.idinventario,
        currencyId:this.contable_compra,
        exchangeRate:this.monto,
        status  :this.estado
      }).then(function(data){
        console.log(data);
        this.$router.go(-1);
      });
      }})
    }
  }
}
</script>

<style scoped>

#caja{
  padding-right: 5px;
}



</style>