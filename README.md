# AGastar_MVC 💸🍕 (División de gastos entre amigos)

**AGastar_MVC** es una aplicación web desarrollada en ASP.NET MVC que permite registrar y dividir gastos en juntadas entre amigos. Ya sea que hayan pedido comida, llevado bebidas o compartido un viaje en Uber, la app calcula cuánto gastó cada persona en función de lo que consumió.

---

## 🎯 Objetivo

Esta aplicación busca resolver un problema común en reuniones sociales: ¿quién puso qué y cuánto debe pagar cada uno?

Con AGastar podés:
- Crear un pedido (por ejemplo, una juntada o evento).
- Añadir a las personas que participaron.
- Registrar los distintos gastos y asignarlos a quienes formaron parte de cada uno.
- Ver cuánto gastó cada persona en total.

---

## 🛠️ Tecnologías utilizadas

- ASP.NET Core MVC (.NET 6+)
- C#
- Entity Framework Core
- Razor Pages
- SQL Server (en la rama principal)
- `MockContext` para simular datos en memoria (rama secundaria)

---

## 🚀 Modos de ejecución

### Rama principal (`main`)
Usa **Entity Framework** con una base de datos real (**SQL Server**). Ideal para desarrollo local completo.  
Requiere:
- Visual Studio 2022 o superior
- .NET 6 SDK o superior
- SQL Server

### Rama `deploy-mockcontext`
Utiliza un **contexto simulado (`MockContext`)**, con listas estáticas en memoria, para permitir un deploy sin necesidad de base de datos.

> Esta rama fue pensada como una demo funcional. Los datos **no se guardan** al cerrar la app, si no que solamente para probarla.

---

## ⚙️ Funcionalidades principales

- ✅ Crear un nuevo **Pedido** (que será el evento)
- ✅ Añadir personas que participan del evento
- ✅ Registrar **gastos** y seleccionar qué personas participaron en cada gasto
- ✅ Calcular automáticamente cuánto gastó cada persona

---

## 📷 Vista previa 

<img width="1919" height="1027" alt="image" src="https://github.com/user-attachments/assets/8d8140a1-36ee-4d74-840c-8bff3db612db" />
<img width="1919" height="1029" alt="image" src="https://github.com/user-attachments/assets/fab84c47-411a-4c6e-ae04-5367cb1ddaa6" />
<img width="1916" height="1031" alt="image" src="https://github.com/user-attachments/assets/8fefcfb0-ad1f-415f-807c-c53eb805390d" />
<img width="1919" height="1031" alt="image" src="https://github.com/user-attachments/assets/38d6e75e-a338-4e54-bc50-c2d54d6f7c71" />
<img width="1918" height="1032" alt="image" src="https://github.com/user-attachments/assets/29e6f5fe-98be-4e74-8056-2c360f70f2b6" />
<img width="1919" height="1032" alt="image" src="https://github.com/user-attachments/assets/aa700243-20a4-4fd7-948f-8c3733cf7afc" />
<img width="1336" height="759" alt="image" src="https://github.com/user-attachments/assets/476a2d16-c126-4a4d-a4df-e010284085f5" />

---

## 🧪 Cómo correr el proyecto

1. Clonar el repositorio  
   ```bash
   git clone https://github.com/MatiasValansi/AGastar_MVC.git

---

## 🟢 Deploy

https://agastar-mvc.onrender.com
