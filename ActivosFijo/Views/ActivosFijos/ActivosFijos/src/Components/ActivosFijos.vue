<template>
  <div id="ActivosFijos">
      <div class = "container">
      <h3>Activos Fijos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="descripcion" class="form-control" placeholder="Ingrese la descripcion" required><br><br>
          <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>
          <label>Tipo de Activos</label><br>
          <input type="number" v-model="tipo_activo" class="form-control" placeholder="Seleccione el tipo de activo" min="1" required><br><br>-->
           <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>-->
           <label>Departamento</label><br>
          <select class="custom-select" style="width:100px; height:30px;" v-model="departamento">
            <option v-for="cuerpo in cuerpos" v-bind:value="cuerpo.ID">{{cuerpo.Descripcion}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Tipo de Activo</label><br>
          <select class="custom-select" style="width:100px; height:30px;" v-model="tipo_activo">
            <option v-for="Tipocuerpo in Tiposcuerpos" v-bind:value="Tipocuerpo.ID">{{Tipocuerpo.Descripcion}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Fecha de Registro</label><br>
          <input type="date" v-model="fecha_registro" class="form-control" placeholder="Seleccione la fecha" min="2018-07-01" required><br><br>
          <label>Valor de Compra</label><br>
          <input type="number" v-model="valor_compra" class="form-control" placeholder="Ingrese el valor de compra" min="1" required><br><br>
          <label>Depreciacion Acumulada</label><br>
          <input type="number" v-model="depreciacion_acu" class="form-control" placeholder="Ingrese la depreciacion acumulada" min="1" required><br><br>        
          <label>Periodo</label><br>
          <input type="date" v-model="periodo" class="form-control" placeholder="Seleccione el periodo" min="2018-07-01" required><br><br>   
          <label>Monto Depreciacion</label><br>
          <input type="text" v-model="monto" class="form-control" readonly><br><br><br><br>        
          <button v-on:click.prevent ="post" class="btn btn-primary">Enviar</button><br><br>
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
      this.$http.post('http://localhost:61542/Api/Ac_Fijos',{
        Descripcion:this.descripcion,
        Departamento:this.departamento.value,
        Tipos_Activos:this.tipo_activo.value,
        Fecha_Registro:this.fecha_registro,
        Valor_Compra:this.valor_compra,
        Depreciacion_Acumulada:this.depreciacion_acu,
        Periodo:this.periodo,
        Monto_Despreciado:this.monto
      }).then(function(data){
        console.log(data);
      });

      alert("Activo fijo guardado exitosamente");
      window.location.href = "/CAF";
    }
  },

  created()
    {
        this.$http.get('http://localhost:61542/Api/Departamentos').then(function(data){
           this.cuerpos = data.body;
           console.log(data);
        })

        this.$http.get('http://localhost:61542/Api/Tipos_Activos').then(function(data){
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