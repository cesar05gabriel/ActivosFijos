<template>
<div id="Home">
<div class="container-fluid">
<div class="row">
<div class="col-sm-8">
<h2>Sobre nosotros</h2>
<br>
<p>La Universidad APEC es la Institución primogénita de Acción Pro Educación y Cultura (APEC), constituida en 1964 cuando empresarios, comerciantes, profesionales y hombres de iglesia, 
deciden crear una entidad sin fines de lucro, impulsadora de la educación superior en la República Dominicana.
</p>
</div>
<div class="col-sm-4">
<span class="glyphicon glyphicon-education logo"></span>
</div>
</div>
</div>
<br>
<div class="container-fluid dividir">
<div class="row">
<div class="col-sm-4">
<span class="glyphicon glyphicon-blackboard logo"></span>
</div>
<div class="col-sm-8">
<h2>Sobre la plataforma</h2>
<br>
<p>
Esta plataforma permitira al usuario crear, editar consultar y borrar los diferentes registros de los activos fijos de la universidad.
</p>
<br>
</div>
</div>
</div>

</div>
</template>

<script>
export default {
  name: 'home',
 
  data () {
    return {
      
    }
  }
}
</script>

<style scoped>

.logo{
font-size: 200px;
color: #0158A7;
}

.dividir{
background-color: #f6f6f6;
}

.container-fluid{
padding: 70px 50px;
}

</style>
