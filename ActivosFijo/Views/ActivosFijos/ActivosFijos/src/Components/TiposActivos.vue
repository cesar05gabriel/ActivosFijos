<template>
  <div id="TiposActivos">
      <div class = "container">
      <h3>Tipos de Activos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="descripcion" class="form-control" placeholder="Ingrese la descripcion" required><br><br>
          <label>Cuenta Contable Compra</label><br>
          <input type="number" v-model="contable_compra" class="form-control" placeholder="Ingrese la cuenta del contable" min="1" required><br><br>
          <label>Cuenta Contable Depreciacion</label><br>
          <input type="number" v-model="contable_depreciacion" class="form-control" placeholder="Ingrese la cuenta de depreciacion" min="1" required><br><br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="estado"><br><br>          
          <button v-on:click.prevent="post" class="btn btn-primary">Enviar</button><br><br>
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
      this.$http.post('http://localhost:61542/Api/Tipos_Activos',{
        Descripcion:this.descripcion,
        Contable_Compra:this.contable_compra,
        Contable_Depreciacion:this.contable_depreciacion,
        Estado:this.estado
      }).then(function(data){
        console.log(data);
      });
      alert("Tipo guardado exitosamente");
      window.location.href = "/CTA";
    }
  }
}
</script>

<style scoped>

#caja{
  padding-right: 5px;
}

</style>