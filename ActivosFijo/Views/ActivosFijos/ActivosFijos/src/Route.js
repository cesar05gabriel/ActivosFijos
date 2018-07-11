import Departamento from './components/Departamento.vue';
import Home from './components/Home.vue';
import TiposActivos from './Components/TiposActivos.vue';
import Empleados from './Components/Empleados.vue';
import ActivosFijos from './Components/ActivosFijos.vue';
import Consulta from './Components/Consulta.vue';
import ConsultaTiposActivos from './Components/ConsultaTiposActivos.vue';
import ConsultaEmpleados from './Components/ConsultaEmpleados.vue';
import ConsultaActivosFijos from './Components/ConsultaActivosFijos.vue';
import EdDepartamento from './Components/EdDepartamento.vue';
import EdTiposActivos from './Components/EdTiposActivos.vue';
import EdEmpleado from './Components/EdEmpleados.vue';
import EdActivosFijos from './Components/EdActivosFijos.vue';

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
    {path: '/ED/:id?', component: EdDepartamento},
    {path: '/ET/:id?', component: EdTiposActivos},
    {path: '/EE/:id?', component: EdEmpleado},
    {path: '/EAF/:id?', component: EdActivosFijos}
]