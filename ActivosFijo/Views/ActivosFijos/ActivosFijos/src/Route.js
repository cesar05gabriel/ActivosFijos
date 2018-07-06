import Departamento from './components/Departamento.vue';
import Home from './components/Home.vue';
import TiposActivos from './Components/TiposActivos.vue';
import Empleados from './Components/Empleados.vue';
import ActivosFijos from './Components/ActivosFijos.vue';
import Consulta from './Components/Consulta.vue';
import ConsultaTiposActivos from './Components/ConsultaTiposActivos.vue';
import ConsultaEmpleados from './Components/ConsultaEmpleados.vue';
import ConsultaActivosFijos from './Components/ConsultaActivosFijos.vue';
import EditarDepartamento from './Components/EditarDepartamento.vue';

export default[
    {path: '/Dep', component: Departamento},
    {path: '/', component: Home} ,
    {path: '/TiAc', component: TiposActivos},
    {path: '/Em', component: Empleados},
    {path: '/Af', component: ActivosFijos},
    {path: '/Con', component: Consulta},
    {path: '/CTA', component: ConsultaTiposActivos},
    {path: '/CEm', component: ConsultaEmpleados},
    {path: '/CAF', component: ConsultaActivosFijos},
    {path: '/Eem/:id', component: EditarDepartamento}
]