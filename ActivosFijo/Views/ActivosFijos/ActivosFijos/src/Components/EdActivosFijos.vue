<template>
  <div id="ActivosFijos">
      <div class = "container">
      <h3>Activos Fijos</h3>
      <br>
      <form name="myform">
      <div class = "form-group">
          <label>Descripcion</label><br>
          <input type="text" v-model="cuerpos.Descripcion" class="form-control" placeholder="Ingrese la descripcion" required><br><br>
          <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>
          <label>Tipo de Activos</label><br>
          <input type="number" v-model="tipo_activo" class="form-control" placeholder="Seleccione el tipo de activo" min="1" required><br><br>-->
           <!--<input type="number" v-model="departamento" class="form-control" placeholder="Seleccione el departamento" min="1" required><br><br>-->
           <label>Departamento</label><br>
          <select class="custom-select" style="width:100px; height:30px;" v-model="cuerpos.Departamento">
            <option v-for="cuerpo in cuerpos">{{cuerpos.Departamento}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Tipo de Activo</label><br>
          <select class="custom-select" style="width:100px; height:30px;" v-model="cuerpos.Tipos_Activos">
            <option v-for="Tipocuerpo in Tiposcuerpos">{{cuerpos.Tipos_Activos}}</option>
          </select>
          <br>
          <br>
          <br>
          <label>Fecha de Registro</label><br>
          <input type="date" v-model="cuerpos.Fecha_Registro" class="form-control" placeholder="Seleccione la fecha" min="2018-07-01" required><br><br>
          <label>Valor de Compra</label><br>
          <input type="number" v-model="cuerpos.Valor_Compra" class="form-control" placeholder="Ingrese el valor de compra" min="1" required><br><br>
          <label>Depreciacion Acumulada</label><br>
          <input type="number" v-model="cuerpos.Depreciacion_Acumulada" class="form-control" placeholder="Ingrese la depreciacion acumulada" min="1" required><br><br>        
          <label>Periodo</label><br>
          <input type="date" v-model="cuerpos.Periodo" class="form-control" placeholder="Seleccione el periodo" min="2018-07-01" required><br><br>   
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
     Tiposcuerpos:[],
     id: null
     
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
      this.$http.put('http://localhost:61542/Api/Ac_Fijos' + this.id,{
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
      });

      
      alert("Activo fijo editado exitosamente");
      window.location.href = "/CAF";

      
    }
  },

  created()
    {
        this.id = this.$route.params.id
        if(this.id != null){
          this.modo = 'E';
        this.$http.get('http://localhost:61542/Api/Ac_Fijos/' + this.id).then(function(data){
           this.cuerpos = data.body;
          console.log(data);
        });
    }

        this.$http.get('http://localhost:61542/Api/Departamentos').then(function(data){
           
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