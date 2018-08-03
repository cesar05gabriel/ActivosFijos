<template>
  <div id="Departamento">
      <div class = "container">
      <h3>Departamentos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="cuerpos.Descripcion" class="form-control" placeholder="Ingrese la descripcion"  v-validate="'required'" name="descripcion">
          <span v-show="errors.has('descripcion')" class="text-danger">La descripcion es requerida.</span><br><br> 
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
  name: 'Departamento',
  data () {
    return {
     descripcion:"",
     estado: false,
     id: null,
     modo: 'C',
     cuerpos: []
    }
  },

  methods:{
    post:function()
    {
      this.$validator.validateAll().then(res=>{
                if(res) {
      
      this.$http.put('http://activosfijo20180720102414.azurewebsites.net/api/Departamentos/' + this.id,{
        ID:this.id,
        Descripcion:this.cuerpos.Descripcion,
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
        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Departamentos/' + this.id).then(function(data){
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