    <template>
  <div id="Header">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
      <link rel="stylesheet" type="text/css" href="bootstrap\css\bootstrap.css">
  <nav class="navbar navbar-default navbar-fixed-top">
  <div class="container">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" >
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span> 
      </button>
      <router-link to="/" id="home" class="navbar-brand">SIGN OUT</router-link>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav navbar-right">
        <li><router-link to="/Con" id="mango">DEPARTAMENTOS</router-link></li>
        <li><router-link to="/CTA" id="mango">TIPOS DE ACTIVOS</router-link></li>
        <li><router-link to="/CEm" id="mango">EMPLEADOS</router-link></li>
        <li><router-link to="/CAF" id="mango">ACTIVOS FIJOS</router-link></li>
        <!--<li><router-link to="/Con" id="mango">CONSULTAS</router-link></li>-->   
        <!--<li><div class="dropdown">
    <button class="dropbtn">CONSULTAS 
    </button>
    <div class="dropdown-content">
      <router-link to="/Con">DEPARTAMENTOS</router-link>
      <router-link to="/CTA">TIPOS ACTIVOS</router-link>
      <router-link to="/CEm">EMPLEADOS</router-link>
      <router-link to="/CAF">ACTIVOS FIJOS</router-link>
    </div></div></li>-->
      </ul>
    </div>
  </div>
</nav>
<div class="jumbotron text-center">
<br>
<br>
<router-link to="/home" id="ruta"><header><strong><h1><a id="principal">Plataforma de Activos Fijos</a></h1></strong></header></router-link>
<p>Sistema de Contabilidad de UNAPEC</p>    
</div>

     
  </div> 
</template>

<script>
export default {
  name: 'Header',
  data () {
    return {
     
    }
  }
}
  
</script>

<style scoped>

.jumbotron {
color: #ffffff;
background-color: #0158A7;
padding: 40px 30px;
}

.container-fluid{
padding: 60px 50px;
}

#principal{
color: white;
}

#principal:hover{
color:white;
text-decoration: none;
}

#ruta:link{
  text-decoration: none;
}

#ruta:hover{
  text-decoration: none;
}

#ruta:visited{
  text-decoration: none;
}

#ruta:active  {
  text-decoration: none;
}

#mango{
color:white;
font-size: 16px;
}

#mango:hover, .dropdown:hover .dropbtn  {
color:#0158A7;
background-color: white;
}

.dropdown .dropbtn {
    font-size: 16px;    
    border: none;
    outline: none;
    color: white;
    padding: 14px 16px;
    background-color: inherit;
    font-family: inherit;
    margin: 0;
}

.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    z-index: 1;
}

.dropdown-content a {
    float: none;
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
    text-align: left;
}

.dropdown-content a:hover {
    background-color: #ddd;
}

.dropdown:hover .dropdown-content {
    display: block;
}


.h2 {
text-align: center;
}

.navbar {
background-color: #0158A7;
line-height: 1.42857143;
border: 0;
}

#home{
    color: #ffffff;
}

</style>
