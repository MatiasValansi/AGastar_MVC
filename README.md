# AGastar_MVC ???? (Divisi�n de gastos entre amigos)

**AGastar_MVC** es una aplicaci�n web desarrollada en ASP.NET MVC que permite registrar y dividir gastos en juntadas entre amigos. Ya sea que hayan pedido comida, llevado bebidas o compartido un viaje en Uber, la app calcula cu�nto gast� cada persona en funci�n de lo que consumi�.

---

## ?? Objetivo

Esta aplicaci�n busca resolver un problema com�n en reuniones sociales: �qui�n puso qu� y cu�nto debe pagar cada uno?

Con AGastar pod�s:
- Crear un pedido (por ejemplo, una juntada o evento).
- A�adir a las personas que participaron.
- Registrar los distintos gastos y asignarlos a quienes formaron parte de cada uno.
- Ver cu�nto gast� cada persona en total.

---

## ??? Tecnolog�as utilizadas

- ASP.NET Core MVC (.NET 6+)
- C#
- Entity Framework Core
- Razor Pages
- SQL Server (en la rama principal)
- `MockContext` para simular datos en memoria (rama secundaria)

---

## ?? Modos de ejecuci�n

### Rama principal (`main`)
Usa **Entity Framework** con una base de datos real (**SQL Server**). Ideal para desarrollo local completo.  
Requiere:
- Visual Studio 2022 o superior
- .NET 6 SDK o superior
- SQL Server

### Rama `deploy-mockcontext`
Utiliza un **contexto simulado (`MockContext`)**, con listas est�ticas en memoria, para permitir un deploy r�pido sin necesidad de base de datos.

> Esta rama fue pensada como una demo funcional. Los datos **no se guardan** al cerrar la app.

---

## ?? Funcionalidades principales

- ? Crear un nuevo **Pedido** (evento)
- ? A�adir personas que participan del evento
- ? Registrar **gastos** y seleccionar qu� personas participaron en cada gasto
- ? Calcular autom�ticamente cu�nto gast� cada persona


---

## ?? C�mo correr el proyecto

1. Clonar el repositorio  
   ```bash
   git clone https://github.com/MatiasValansi/AGastar_MVC.git
