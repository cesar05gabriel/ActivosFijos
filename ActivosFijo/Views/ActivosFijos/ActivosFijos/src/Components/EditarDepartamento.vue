<template>
    <div id="EditarDepartamento">
        <div class="container">
            <h3><b>Departamento</b> - Editar</h3>
            <hr />
            
            <table style="font-size: 15px;">
                <tr style="margin-top: 10px;">
                    <td>Descripcion: &nbsp;</td>
                    <td><input type="text" name="Descion" id="Descripcion" v-model="departamento.Descripcion" class="form-control form-control-sm" />    </td>
                </tr>                
                <tr style="margin-top: 10px;">
                    <td><br /> Estado:</td>
                    <td><br /><input type="checkbox" name="Estado" id="Estado" v-model="departamento.Estado" class="form-control form-control-sm" /></td>
                </tr>
            </table>
            <br />
            <button v-on:click.prevent="Save" class="btn btn-primary btn-sm">Guardar</button>
            <br />
            <br />            <br />            <br />
        </div>    
    </div>
</template>

<script>
export default {
  name: 'EditarDepartamento',
  data () {

        id = null,
        departamento = null,
        descripcion = "",
        estado = false

  },

    methods:{
        Save:function(){
            this.$http.put('http://localhost:61542/Api/Departamentos/' + id,{
        Descripcion:this.departamento.Descripcion,
        Estado:this.departamento.Estado

      }).then(function(data){
        console.log(data);
      });
        }
    },

    created(){
        this.id = this.$route.params.id      
        this.$http.get('http://localhost:61542/Api/Departamentos/' + this.id).then(function(data){
            this.departamento = data.body;
        });
    }

}
</script>
