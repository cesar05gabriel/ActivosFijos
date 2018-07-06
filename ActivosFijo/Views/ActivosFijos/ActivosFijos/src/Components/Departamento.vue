<template>
  <div id="Departamento">
      <div class = "container">
      <h3>Departamentos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="descripcion" class="form-control" placeholder="Ingrese la descripcion"><br><br>
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
  name: 'Departamento',
  data () {
    return {
     descripcion:"",
     estado: false,
     id: "",
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
      alert("Departamento guardado exitosamente");
      window.location.href = "/Con";
    }
  }
}
</script>

<style scoped>

#caja{
  padding-right: 5px;
}

</style>