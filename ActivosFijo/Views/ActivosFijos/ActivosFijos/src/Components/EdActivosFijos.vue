<template>
  <div id="ActivosFijos">
      <div class = "container">
      <h3>Activos Fijos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="cuerpos.Descripcion" v-validate="'required'" name="descripcion" class="form-control" placeholder="Ingrese la descripcion">
          <span v-show="errors.has('descripcion')" class="text-danger">La descripcion es requerida.</span><br><br>
          <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>
          <label>Tipo de Activos</label><br>
          <input type="number" v-model="tipo_activo" class="form-control" placeholder="Seleccione el tipo de activo" min="1" required><br><br>-->
           <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>-->
           <label>Departamento</label><br>
          <select class="custom-select" style="width:100px; height:30px;" v-model="cuerpos.Departamento">
            <option v-for="edita in editar" v-bind:value='edita.ID' v-bind:key='edita.ID'>{{edita.Descripcion}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Tipo de Activo</label><br>
          <select class="custom-select" style="width:100px; height:30px;" v-model="cuerpos.Tipos_Activos">
            <option v-for="Tipocuerpo in Tiposcuerpos" v-bind:value='Tipocuerpo.ID' v-bind:key='Tipocuerpo.ID'>{{Tipocuerpo.Descripcion}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Valor de Compra</label><br>
          <input type="number" v-model="cuerpos.Valor_Compra" v-validate="'required|min_value:1'" name="compra" class="form-control" placeholder="Ingrese el valor de compra">
          <span v-show="errors.has('compra')" class="text-danger" id="error">Complete el valor de compra correctamente.</span><br><br>
          <button v-on:click.prevent ="post" class="btn btn-primary" :disabled="errors.any()">Enviar</button><br><br>
      </div>
      </form>
      </div>
  </div> 
</template>

<script>
export default {
  name: 'ActivosFijos',
  data () {
    return {
     descripcion:"",
     departamento: 1,
     tipo_activo: 1,
     fecha_registro: Date,
     valor_compra: 1,
     depreciacion_acu:1,
     periodo: Date,
     cuerpos:[],
     Tiposcuerpos:[],
     id: null,
     editar:[]
     
    }
  },

  computed:{
      monto: function()
      {
        return this.cuerpos.Valor_Compra - this.cuerpos.Depreciacion_Acumulada;
      }
  },

  methods:{
    post:function()
    {
      console.log(this.cuerpos);
      this.$validator.validateAll().then(res=>{
                if(res) {
      this.$http.put('https://activosfijo20180720102414.azurewebsites.net/Api/Ac_Fijos/' + this.id,{
        ID:this.id,
        Descripcion:this.cuerpos.Descripcion,
        Departamento:this.cuerpos.Departamento,
        Tipos_Activos:this.cuerpos.Tipos_Activos,
        Fecha_Registro:this.cuerpos.Fecha_Registro,
        Valor_Compra:this.cuerpos.Valor_Compra,
        Depreciacion_Acumulada:this.cuerpos.Depreciacion_Acumulada,
        Periodo:this.cuerpos.Periodo,
        Monto_Despreciado:this.monto
      }).then(function(data){
        console.log(data);
        this.$router.go(-1);
      }).catch(function(data){
        console.log(data);
      })

      }})

      
    }
  },

  created()
    {
        this.id = this.$route.params.id
        if(this.id != null){
          this.modo = 'E';
        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Ac_Fijos/' + this.id).then(function(data){
           this.cuerpos = data.body;
          console.log(data);
        });
    }

        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Departamentos').then(function(data){
           this.editar = data.body;
           console.log(data);
        })

        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Tipos_Activos').then(function(data){
           this.Tiposcuerpos = data.body;
           console.log(data);
        })
  }
}
</script>

<style scoped>

#caja{
  padding-right: 5px;
}

</style>