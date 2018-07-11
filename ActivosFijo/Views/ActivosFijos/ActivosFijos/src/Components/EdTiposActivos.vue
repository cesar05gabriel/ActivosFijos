<template>
  <div id="TiposActivos">
      <div class = "container">
      <h3>Tipos de Activos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="cuerpos.Descripcion" class="form-control" placeholder="Ingrese la descripcion" required><br><br>
          <label>Cuenta Contable Compra</label><br>
          <input type="number" v-model="cuerpos.Contable_Compra" class="form-control" placeholder="Ingrese la cuenta del contable" min="1" required><br><br>
          <label>Cuenta Contable Depreciacion</label><br>
          <input type="number" v-model="cuerpos.Contable_Depreciacion" class="form-control" placeholder="Ingrese la cuenta de depreciacion" min="1" required><br><br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="cuerpos.Estado"><br><br>          
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
     estado: false,
     cuerpos: [],
     id: false, 
    }
  },

  methods:{
    post:function()
    {
      this.$http.put('http://localhost:61542/Api/Tipos_Activos/' + this.id,{
        ID:this.id,
        Descripcion:this.cuerpos.Descripcion,
        Contable_Compra:this.cuerpos.Contable_Compra,
        Contable_Depreciacion:this.cuerpos.Contable_Depreciacion,
        Estado:this.cuerpos.Estado
      }).then(function(data){
        console.log(data);
      });
      alert("Tipo editado exitosamente");
      window.location.href = "/CTA";
    }
  },

  created()
    {
        this.id = this.$route.params.id
        if(this.id != null){
          this.modo = 'E';
        this.$http.get('http://localhost:61542/Api/Tipos_Activos/' + this.id).then(function(data){
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