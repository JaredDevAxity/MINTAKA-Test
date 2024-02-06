# Generator NetCore 3.1

Proyecto generado para la configuración automática de microservicios con netcore 3.1

## Requisitos

* [Instalar NodeJs LTS](https://nodejs.org/es/)
* Instalar Yeoman
    `npm install -g yo`
* Descargar dependencias 
    `npm install`
* Ejecutar dentro de generator-netcore6/
    `npm link`

## Instalar proyecto

- Ejecutar el comando: `yo netcore3`  

- Aparece un prompt donde debemos colocar el nombre de nuestro proyecto en formato PascalCase sin espacios

- Esto genera un proyecto llamado: [nombre ingresado]-service

## Docker

Docker automatiza el despliegue de aplicaciones dentro de contenedores.

El archivo Dockerfile contiene las instrucciones para crear la imagen.

Pasos para desplegar la aplicación:
1. **Generar imagen**
```sh
docker build -t nameImage --build-arg NUGET_AUTH_TOKEN="xxxxxxxxxx" --build-arg NUGET_USER_NAME="xxxxxxxxxx" .
```
2. **Consultar imagenes**
```sh
docker images
```
3. **Ejecutar imagen**
```sh
docker run -p 9090:9090 -e ASPNETCORE_ENVIRONMENT="Development" -e ASPNETCORE_URLS="http://+:9090" -e MSSQL_DEPLOYMENT_SERVICE_HOST="111.111.1.11" -e MSSQL_DATABASE="xxxxxxxxxx" -e MSSQL_USER="xxxxxxxxxx" -e MSSQL_PWD="xxxxxxxxxx" -d nameImage
```
4. **Mostrar contenedores en ejecución**
```sh
docker ps
```
5. **Obtener los registros de un contenedor**
```sh
docker container logs [containerid]
```
6. **Aplicación desplegada**
- Validar que la aplicación se este ejecutando por el puerto 9090 http://localhost:9090/

## Configuración

1. **Configurar variables de entorno**  
En el archivo **launchSettings.json** configure las variables de entorno para su proyecto.
```json
{
    "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development", // Indicar el entorno en tiempo de ejecución
        "REDISDATA_SVC_SERVICE_HOST": "101.10.101.1", // Host para la base de redis
        "REDISDATA_SVC_SERVICE_PORT": "8080", // Puerto para la base de redis
        "MSSQL_DEPLOYMENT_SERVICE_HOST": "101.10.101.1", // Host para la base de datos
        "MSSQL_DATABASE": "Name_Database", // Nombre de la base de datos
        "MSSQL_USER": "admin", // Usuario para la base de datos
        "MSSQL_PWD": "password", // Contraseña para la base de datos
      }
}
```
## ¿Cómo usarlo?

1. **Redis:** Con redis almacenamos estructuras de datos de valores de clave en memoria.
- Obtiene el valor de la clave, si la clave no existe devuelve nulo.
```csharp
var redisKey = $"List-ProjectResponseDto";
var result = await this.database.StringGetAsync(redisKey);
```
- Almacena el valor de la cadena estableciendo un tiempo de vencimiento. Si la clave ya tiene un valor, se sobrescribe.
```csharp
var redisKey = $"List-ProjectResponseDto";
var response = await this.projectFacade.GetAllAsync();
await this.database.StringSetAsync(redisKey, JsonConvert.SerializeObject(response), TimeSpan.FromHours(1));
```
2. **Operaciones a la base de datos**
  - Consulta de datos por llave primaria
```csharp
/// <inheritdoc/>
public async Task<ExampleModel> GetExampleAsync(int id)
{
    return await this.databaseContext.CatExample.FirstOrDefaultAsync(p => p.Id.Equals(id));
}
```
  - Consulta de una lista de datos
```csharp
/// <inheritdoc/>
public async Task<IEnumerable<ExampleModel>> GetAllExampleAsync()
{
    return await this.databaseContext.CatExample.ToListAsync();
}
```
  - Inserción a base de datos
```csharp
/// <inheritdoc/>
public async Task<bool> InsertExample(ExampleModel model)
{
    var response = await this.databaseContext.CatExample.AddAsync(model);
    bool result = response.State.Equals(EntityState.Added);
    await ((DatabaseContext)this.databaseContext).SaveChangesAsync();
    return result;
}
```
## Capas del proyecto
1. **Api:** Se manejan únicamente controladores y configuración.
2. **Facade:** Orquestador de servicios, en esta capa se utiliza la menor lógica posible y solo se manda llamar la capa de servicios.
3. **Services:** Integración de servicios a terceros, reglas de negocio y llamados hacia DAO.
4. **DataAccess:** Se encuentra el DAO (Data Access Object).
5. **Entities:** Marco de mapeo relacional para acceder a base de datos y contexto para base de datos.
6. **Dto:** En esta capa se encuentran DTO (Data Transfer Object).
7. **Test:** Capa para pruebas unitarias (TDD).

## Colaboradores

**Hugo Meraz**  
*[hugo.meraz@axity.com]*  
**Javier Rodríguez**  
*[francisco.rodriguez@axity.com]*  

## Licencia

[MIT](https://opensource.org/licenses/MIT)