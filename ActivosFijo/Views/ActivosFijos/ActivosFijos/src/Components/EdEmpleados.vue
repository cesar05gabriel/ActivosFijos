<template>
  <div id="Empleados">
      <div class = "container">
      <h3>Empleados</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Nombre</label><br>
          <input type="text" v-model="cuerpos.Nombre" v-validate="'required'" name="nombre" class="form-control" placeholder="Ingrese el nombre">
          <span v-show="errors.has('nombre')" class="text-danger">El nombre es requerido.</span><br><br>
          <label>Cedula</label><br>
          <input type="text" v-model="cuerpos.Cedula" v-validate="'required'" name="cedula" class="form-control" placeholder="Ingrese la cedula" required><br><br>
          <label>Departamento</label><br>
          <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>-->
          <select class="custom-select" style="width:100px; height:30px;" v-model="departamento">
            <option v-for="edita in editar" v-bind:value='edita.ID' v-bind:key='edita.ID'>{{edita.Descripcion}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Tipo de Persona</label><br>
          <!--<input type="number" v-model="tipo_persona" class="form-control" placeholder="Seleccione el tipo de persona" min="1" required><br><br>-->
          <select class="custom-select" style="width:100px; height:30px;" v-model="tipo_persona">
            <option v-for="Tipocuerpo in Tiposcuerpos" v-bind:value='Tipocuerpo.ID' v-bind:key='Tipocuerpo.ID'>{{Tipocuerpo.Tipo_Persona1}}</option>
          </select>
          <br>
          <br>
          <br>
          <label id="caja">Estado</label>
          <input type="checkbox" v-model="cuerpos.Estado"><br><br>          
          <button v-on:click.prevent ="post" class="btn btn-primary" :disabled="errors.any()">Enviar</button><br><br>
      </div>
      </form>
      </div>
  </div> 
</template>

<script>
export default {
  name: 'Empleados',
  data () {
    return {
     nombre:"",
     cedula:"",
     departamento: 1,
     tipo_persona: 1,
     fecha_ingreso: Date,
     estado: false,
     cuerpos:[],
     Tiposcuerpos:[],
     id:null,
     editar:[] 
    }
  },

  methods:{
    post:function()
    {
      this.$validator.validateAll().then(res=>{
                if(res) {
      this.$http.put('http://activosfijo20180720102414.azurewebsites.net/api/Empleados/' + this.id,{
        ID:this.id,
        Nombre:this.cuerpos.Nombre,
        Cedula:this.cuerpos.Cedula,
        Username:this.cuerpos.Username,
        Password:this.cuerpos.Password,
        Departamento:this.departamento,
        Tipo_Persona:this.tipo_persona,
        Fecha_Ingreso:this.cuerpos.Fecha_Ingreso,
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
        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Empleados/' + this.id).then(function(data){
           this.cuerpos = data.body;
          console.log(data);
        });
    }

     this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Departamentos', {params: {activos: true}}).then(function(data){
           this.editar = data.body;
        })

        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Tipo_Persona').then(function(data){
           this.Tiposcuerpos = data.body;
        })
  }
}
</script>

<style scoped>

#caja{
  padding-right: 5px;
}



</style>