<template>
  <div id="TiposActivos">
      <div class = "container">
      <h3>Tipos de Activos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-validate="'required'" name="descripcion" v-model="descripcion" class="form-control" placeholder="Ingrese la descripcion">
          <span v-show="errors.has('descripcion')" class="text-danger">La descripcion es requerida.</span><br><br>
          <label>Cuenta Contable Compra</label><br>
          <input type="number" v-validate="'required|min_value:1'" name="compra" v-model="contable_compra" class="form-control" placeholder="Ingrese la cuenta del contable">
          <span v-show="errors.has('compra')" class="text-danger" id="error">Complete la cuenta de compra correctamente.</span><br><br>
          <label>Cuenta Contable Depreciacion</label><br>
          <input type="number" v-validate="'required|min_value:1'" name="depre" v-model="contable_depreciacion" class="form-control" placeholder="Ingrese la cuenta de depreciacion">
          <span v-show="errors.has('depre')" class="text-danger">Complete la cuenta de depreciacion correctamente.</span><br><br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="estado"><br><br>          
          <button v-on:click.prevent="post" class="btn btn-primary" :disabled="errors.any()">Enviar</button><br><br>
      </div>
      </form>
      </div>
  </div> 
</template>

<script>
export default {
  name: 'TiposActivos',
  data () {
    return {
     descripcion:"",
     contable_compra: 1,
     contable_depreciacion: 1,
     estado: false 
    }
  },

  methods:{
    post:function()
    {
      this.$validator.validateAll().then(res=>{
                if(res) {
      this.$http.post('http://activosfijo20180720102414.azurewebsites.net/api/Tipos_Activos',{
        Descripcion:this.descripcion,
        Contable_Compra:this.contable_compra,
        Contable_Depreciacion:this.contable_depreciacion,
        Estado:this.estado
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

    .form-control.errors {
      border-color: #E84444;
      box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(232,68,68,.6);
    }


</style>