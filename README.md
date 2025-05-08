# RickAndMortyDDD Backend

API backend basada en **.NET 8** que consume la API pública de **Rick and Morty**, implementando los principios de **Domain-Driven Design (DDD)** y **Clean Architecture**.

Proporciona endpoints para obtener episodios y personajes de Rick and Morty, enriquecidos con información adicional, como imágenes representativas de los personajes.

## 🛠️ Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- DDD (Domain-Driven Design)
- Clean Architecture (Application / Domain / Infrastructure / API)
- Refit (para consumir la API externa de Rick and Morty)
- CORS habilitado para integración con Frontend (Angular)

## 🚀 **Clonar y correr en local**

### 1️⃣ Clona el repositorio

1. Clona el siguiente reposirotio con el comando:
   git clone https://github.com/Vrilli/RickAndMortyBack.git

2. Luego ingresa a la carpeta que acabas de clonar con el siguiente comando:
   cd RickAndMortyBack

3. Restaura las dependencias con el siguiente comando:
   dotnet restore

4. Finalmente corre tu backend con el siguiente comando:
   dotnet run --project RickAndMortyDDD.API

5. Ingresa a este link para que puedas ver las enpoints
   http://localhost:5000/swagger/index.html
