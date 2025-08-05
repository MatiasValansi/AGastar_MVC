# AGastar_MVC ???? (División de gastos entre amigos)

**AGastar_MVC** es una aplicación web desarrollada en ASP.NET MVC que permite registrar y dividir gastos en juntadas entre amigos. Ya sea que hayan pedido comida, llevado bebidas o compartido un viaje en Uber, la app calcula cuánto gastó cada persona en función de lo que consumió.

---

## ?? Objetivo

Esta aplicación busca resolver un problema común en reuniones sociales: ¿quién puso qué y cuánto debe pagar cada uno?

Con AGastar podés:
- Crear un pedido (por ejemplo, una juntada o evento).
- Añadir a las personas que participaron.
- Registrar los distintos gastos y asignarlos a quienes formaron parte de cada uno.
- Ver cuánto gastó cada persona en total.

---

## ??? Tecnologías utilizadas

- ASP.NET Core MVC (.NET 6+)
- C#
- Entity Framework Core
- Razor Pages
- SQL Server (en la rama principal)
- `MockContext` para simular datos en memoria (rama secundaria)

---

## ?? Modos de ejecución

### Rama principal (`main`)
Usa **Entity Framework** con una base de datos real (**SQL Server**). Ideal para desarrollo local completo.  
Requiere:
- Visual Studio 2022 o superior
- .NET 6 SDK o superior
- SQL Server

### Rama `deploy-mockcontext`
Utiliza un **contexto simulado (`MockContext`)**, con listas estáticas en memoria, para permitir un deploy rápido sin necesidad de base de datos.

> Esta rama fue pensada como una demo funcional. Los datos **no se guardan** al cerrar la app.

---

## ?? Funcionalidades principales

- ? Crear un nuevo **Pedido** (evento)
- ? Añadir personas que participan del evento
- ? Registrar **gastos** y seleccionar qué personas participaron en cada gasto
- ? Calcular automáticamente cuánto gastó cada persona


---

## ?? Cómo correr el proyecto

1. Clonar el repositorio  
   ```bash
   git clone https://github.com/MatiasValansi/AGastar_MVC.git
