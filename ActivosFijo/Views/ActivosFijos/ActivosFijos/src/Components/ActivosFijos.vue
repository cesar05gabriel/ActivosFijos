<template>
  <div id="ActivosFijos">
      <div class = "container">
      <h3>Activos Fijos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="descripcion" v-validate="'required'" name="descripcion" class="form-control" placeholder="Ingrese la descripcion" >
          <span v-show="errors.has('descripcion')" class="text-danger">La descripcion es requerida.</span><br><br>
          <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>
          <label>Tipo de Activos</label><br>
          <input type="number" v-model="tipo_activo" class="form-control" placeholder="Seleccione el tipo de activo" min="1" required><br><br>-->
           <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>-->
           <label>Departamento</label><br>
          <select class="custom-select" style="width:100px; height:30px;" v-model="departamento">
            <option v-for="cuerpo in cuerpos" v-bind:value='cuerpo.ID' v-bind:key='cuerpo.ID'>{{cuerpo.Descripcion}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Tipo de Activo</label><br>
          <select class="custom-select" style="width:100px; height:30px;" v-model="tipo_activo">
            <option v-for="Tipocuerpo in Tiposcuerpos" v-bind:value='Tipocuerpo.ID' v-bind:key='Tipocuerpo.ID'>{{Tipocuerpo.Descripcion}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Fecha de Registro</label><br>
          <input type="date" v-model="fecha_registro" v-validate="'required'" name="fecha" class="form-control" placeholder="Seleccione la fecha">
          <span v-show="errors.has('fecha')" class="text-danger">La fecha de registro es requerida.</span><br><br>
          <label>Valor de Compra</label><br>
          <input type="number" v-model="valor_compra" v-validate="'required|min_value:1'" name="compra" class="form-control" placeholder="Ingrese el valor de compra">
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
     Tiposcuerpos:[]
     
    }
  },

  computed:{
      monto: function()
      {
        return this.valor_compra - this.depreciacion_acu;
      }
  },

  methods:{
    post:function()
    {
       this.$validator.validateAll().then(res=>{
                if(res) {
      this.$http.post('http://activosfijo20180720102414.azurewebsites.net/api/Ac_Fijos',{
        Descripcion:this.descripcion,
        Departamento:this.departamento,
        Tipos_Activos:this.tipo_activo,
        Fecha_Registro:this.fecha_registro,
        Valor_Compra:this.valor_compra,
        Depreciacion_Acumulada:this.depreciacion_acu,
        Periodo:this.periodo,
        Monto_Despreciado:this.monto
      }).then(function(data){
        console.log(data);
        this.$router.go(-1);
      });
  }})
    }
  },

  created()
    {
        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Departamentos', {params: {activos: true}}).then(function(data){
           this.cuerpos = data.body;
           console.log(data);
        })

        this.$http.get('http://activosfijo20180720102414.azurewebsites.net/api/Tipos_Activos', {params: {tipos: true}}).then(function(data){
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