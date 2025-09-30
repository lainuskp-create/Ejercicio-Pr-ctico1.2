# Ejercicio-Práctico1.2
Ejercicio Práctico 1.2

# Cache Demo - Prueba Técnica .NET 9

Este proyecto implementa un servicio de caché distribuido usando Redis y .NET 9 como parte de la prueba técnica para líder técnico .NET.

---

## Requisitos
- .NET 9 SDK
- Docker Desktop (para correr Redis en contenedor)

---

## Cómo ejecutar

1. **Levantar Redis con Docker**  
   Abre PowerShell o CMD y ejecuta:
   ```bash
   docker run -d --name redis -p 6379:6379 redis
   ```

2. **Ejecutar la API en la carpeta del proyecto**  
   Dentro de la carpeta raíz del proyecto (`CacheDemo`):
   ```bash
   dotnet run --project CacheDemo
   ```

3. **Abrir Swagger en el navegador**  
   Cuando la API esté corriendo, abre:
   ```
   http://localhost:5002/swagger
   ```

---
## Endpoints principales

### Set (guardar en caché)
```bash
curl.exe -X POST "http://localhost:5002/api/Cache/set/saludo" ^
     -H "Content-Type: application/json" ^
     -d "\"hola\""
```
**Respuesta:**
```
Key 'saludo' almacenada con éxito
```

### Get (obtener del caché)
```bash
curl.exe -X GET "http://localhost:5002/api/Cache/get/saludo"
```
**Respuesta:**
```json
"hola"
```

### Exists (validar si existe la clave)
```bash
curl.exe -X GET "http://localhost:5002/api/Cache/exists/saludo"
```
**Respuesta:**
```json
true
```

###  Remove (eliminar clave)
```bash
curl.exe -X DELETE "http://localhost:5002/api/Cache/remove/saludo"
```
**Respuesta:**
```
Key 'saludo' eliminada con éxito
```

---

## Tecnologías
- .NET 9
- Redis (StackExchange.Redis)
- Inyección de dependencias (DI)
- Logging estructurado
- Serialización con System.Text.Json

---

## Notas
- El servicio de caché es genérico (`ICacheService<T>`), permitiendo almacenar distintos tipos de objetos.
- Se utiliza `System.Text.Json` para serialización eficiente.
- La configuración (`connection string`, expiración por defecto, prefijo de claves) está en `appsettings.json`.
- El proyecto incluye un controlador `CacheController` para exponer los endpoints y probar las operaciones en Redis.



