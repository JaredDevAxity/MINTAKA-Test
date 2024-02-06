# MINTAKA
MINTAKA es un arquetipo que fue generado sin lógica de negocio por lo que puede aplicarse en cualquier escenario donde se necesite un microservicio backend Net Core 6.

## Conceptos

## ¿Qué es un arquetipo?
Un arquetipo es un patrón o modelo original donde a partir de este se generan otros elementos del mismo tipo.  
El arquetipo pretende ser un punto de partida para la estructura de proyectos.
En desarrollo nos apoyamos de estos para reutilizar código y arquitecturas.

## ¿Qué es un generador?
Un generador nos permite crear de manera rápida aplicaciones, de esta manera nos concentramos en la solución en lugar de establecer la base para el proyecto.

Yeoman es una herramienta de código abierto para aplicaciones y combina varias funciones, como generar una plantilla de inicio, ejecutar pruebas unitarias, etc. Con Yeoman, un generador es un complemento que se puede ejecutar con el comando `yo` para crear proyectos completos o partes útiles.

## Proyecto MINTAKA Basado en .NetCore 6

**NetCore 6.0:** Proyecto generado para la configuración automática de microservicios con netcore 6.0.  

1. **Tecnologías y Funcionalidades:**  
    - **Operaciones Bulk:** Nos ayudan a mejorar el rendimiento en operaciones masivas sobre la base de datos.
    - **Redis:** Redis almacena estructuras de datos de valores de clave en memoria.
    - **Kafka:** Permite la comunicación entre servicios diferentes.
    - **MediatR:** Es un patrón de diseño de comportamiento que reduce el acoplamiento entre los componentes de un programa haciendo que se comuniquen a través de un objeto mediador y  permite la comunicación dentro del mismo servicio.
    - **Logs:** Nos permiten detectar y analizar errores en eventos.
     - **Paquetes:** Cuenta con paquetes que estan disponibles para implementar en un proyecto:
       1. **Azure Storage:** Paquete con funciones comunes para implementar Azure Storage.
       2. **Kafka:** Paquete con funciones para implementar Kafka.
       3. **Payments:** Paquete con funciones de métodos de pago.
       4. **Common:** Paquete con funciones comunes o genéricas para un proyecto.

### Creación y Configuración del Servicio

Para más información de la creación, configuración y contenido adicional del servicio, revise [Ficha Técnica](/generator/6.0/Generator/generator-netcore6/README.md)


## Colaboradores

**Hugo Meraz**  
*[hugo.meraz@axity.com]*  
**Jesus Alejandro Hernandez Martinez**  
*[jesus.hernandezm@axity.com]*  
**Pamela Jocelyn Rivera Gil**  
*[pamela.rivera@axity.com]*  
**Ingrid Mendoza Cabrera**  
*[ingrid.mendoza@axity.com]*  

## Licencia

[MIT](https://opensource.org/licenses/MIT)

![Audience](/assets/CReA.png)

### Este ARTE forma parte del CReA de Axity, para más información visitar [CReA](https://intellego365.sharepoint.com/sites/CentralAxity/M%C3%A9xico/Consultoria/Arquitectura/SitePages/CReA.aspx)
