<template>
  <div id="TiposActivos">
      <div class = "container">
      <h3>Tipos de Activos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="cuerpos.Descripcion" v-validate="'required'" name="descripcion" class="form-control" placeholder="Ingrese la descripcion" >
          <span v-show="errors.has('descripcion')" class="text-danger">La descripcion es requerida.</span><br><br>
          <label>Cuenta Contable Compra</label><br>
          <input type="number" v-model="cuerpos.Contable_Compra" v-validate="'required|min_value:1'" name="compra" class="form-control" placeholder="Ingrese la cuenta del contable">
          <span v-show="errors.has('compra')" class="text-danger" id="error">Complete la cuenta de compra correctamente.</span><br><br>
          <label>Cuenta Contable Depreciacion</label><br>
          <input type="number" v-model="cuerpos.Contable_Depreciacion" v-validate="'required|min_value:1'" name="depre" class="form-control" placeholder="Ingrese la cuenta de depreciacion">
          <span v-show="errors.has('depre')" class="text-danger">Complete la cuenta de depreciacion correctamente.</span><br><br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="cuerpos.Estado"><br><br>          
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
     estado: false,
     cuerpos: [],
     id: false, 
    }
  },

  methods:{
    post:function()
    {
        this.$validator.validateAll().then(res=>{
                if(res) {
      this.$http.put('http://activosfijo20180720102414.azurewebsites.net/api/Tipos_Activos/' + this.id,{
        ID:this.id,
        Descripcion:this.cuerpos.Descripcion,
        Contable_Compra:this.cuerpos.Contable_Compra,
        Contable_Depreciacion:this.cuerpos.Contable_Depreciacion,
        Estado:this.cuerpos.Estado
      }).then(function(data){
        console.log(data);
        this.$router.go(-1);
      });
      }}) 
    }
  },

  created()
    {
        this.id = this.$route.params.id
        if(this.id != null){
          this.modo = 'E';
        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Tipos_Activos/' + this.id).then(function(data){
           this.cuerpos = data.body;
          console.log(data);
        });
    }
    }
}
</script>

<style scoped>

#caja{
  padding-right: 5px;
}

</style>