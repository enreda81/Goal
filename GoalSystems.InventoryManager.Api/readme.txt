Adjunto la prueba, aunque no se indicaba, lo he desarrollado en .NET Core.

Nada más abrir la solución, se puede ejecutar el API REST, que abrirá por defecto la url https://localhost:44369/api/Inventory que se corresponde con el método GET que retorna todos los elementos del inventario.
El API REST ha sido securizado con seguridad básica, las credenciales de acceso son:
User: goalsystems
Password: 12345

Estas credenciales están hardcodeadas en el código a efectos de la prueba.

En el repositorio de datos del inventario hay un método que agrega 3 elementos de prueba en el inventario.

Para el desarrollo, a pesar de ser un ejemplo sencillo, he optado por implementar el paradigma arquitectónico DDD (Domain Driven Design), aunque en este caso he obviado la capa de aplicación. Las capas implementadas son:
•	UI: tan solo el API REST, sin capa visual
	o	Proyecto: GoalSystems.InventoryManager.Api
	o	Tipo: API REST
	o	Pruebas unitarias: GoalSystems.InventoryManager.Api.Test
•	Domain: con las entidades y servicios de dominio
	o	Proyecto entidades: GoalSystems.InventoryManager.Domain.Entities
	o	Tipo: Class Library
	o	Pruebas unitarias: No necesario puesto que se trata de entidades POCO sin lógica de negocio.
	o	Proyecto servicios: GoalSystems.InventoryManager.Domain.Services
	o	Tipo: Class Library
	o	Pruebas unitarias: GoalSystems.InventoryManager.Domain.Services.Test
•	Infrastructure: con servicios de infraestructura y los repositorios de datos.
	o	Proyecto: GoalSystems.InventoryManager.Infrastructure
	o	Tipo: Class Library
	o	Pruebas unitarias: GoalSystems.InventoryManager.Infrastructure.Test
•	Crosscutting: con servicios transversales como logging y seguridad
	o	Proyecto: GoalSystems.InventoryManager.Infrastructure.Crosscutting
	o	Tipo: Class Library
	o	Pruebas unitarias: Sin pruebas unitarias

La nomenclatura de los proyectos sigue el patrón COMPAÑÍA.APLICACION.CAPA_TECNOLOGICA.

Para la instanciación de los servicios de dominio y los repositorios de datos he utilizado el inyector de dependencias nativo de Net Core, de manera que siempre se trabaje con la interfaz correspondiente en lugar de la implementación concreta.
El repositorio de datos donde se almacenan en memoria los elementos del inventario implementa el patrón Singleton, de manera que existe una única instancia de la variable en memoria. Se trata de un repositorio genérico que admite cualquier tipo de objeto.

Otros patrones implementados:
•	Unit of Work: en el repositorio en memoria, para que el guardado se realice en una única operación y sea transaccional.
•	Repository: En la capa de infraestructura correspondiente
•	Dispose: En el servicio de dominio

Los parámetros de los métodos públicos son siempre validados, y todas las clases métodos y propiedades públicas contienen su documentación correspondiente con el formato XML.

Los métodos del API REST retornan siempre JSON, y los 4 métodos existentes están securizados con autenticación básica mediante el uso del atributo “custom” BasicAuth.

Las pruebas unitarias del API REST contienen tanto pruebas de la parte servidor del controlador como también pruebas de la capa HTTP mediante el uso del paquete Nuget “RestSharp”.
El resto de proyectos de pruebas testea cada una de las capas arquitectónicas.
En total se disponen de 19 pruebas unitarias.

Se ha implementado también un manejador de errores no controlados mediante el uso del Midlleware de Net Core.

El servicio de dominio del inventario expone dos eventos que son disparados cada vez que un elemento es eliminado o está caducado, cualquier llamante puede suscribirse a dichos eventos para realizar las operaciones que estime necesarias. Esos eventos son comprobados cada vez que se accede al elemento en el repositorio, aunque lo ideal sería implementar una tarea que se ejecutara en background y que cada cierto tiempo realizara la comprobación (no implementado).

No he implementado la parte visual, puesto que no conozco el framework MaterializeCss.
