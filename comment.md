## Тест AuthController в Postman

Авторизация
```json
https://localhost:44364/api/auth
body - raw - json

{
    "LastName" : "nameddd"
}
```


Добавление продукта
```json
https://localhost:44364/api/product
body - raw - json

{
    "Name" : "Продукт тестовый 1",
    "Article" : "111111",
    "Category" : 2,
    "Amount" : 111,
    "UnitOfMeasurement" : 4,
    "StoragePlace" : "111-111-111"
}
```
---
*Как в одном WebAPI контроллере asp core mvc содержать несколько методов*

В одном контроллере Web API в ASP.NET Core вы можете определять несколько методов с различной логикой, используя атрибуты маршрутизации,
такие как `[HttpPost]`, `[HttpGet]`, `[HttpPut]`, `[HttpDelete]` и т.д. Это позволяет вам обрабатывать различные HTTP-методы
в одном контроллере. Обратите внимание, что каждый метод должен иметь уникальный маршрут или использовать те же маршруты, но различаться по методу HTTP.
- AddNewProduct: Обрабатывает HTTP POST запросы для добавления нового продукта. Если добавление не удалось, возвращает `BadRequest`, иначе возвращает `Ok` с результатом.
- GetAllProducts: Обрабатывает HTTP GET запрос для получения списка всех продуктов. Возвращает список продуктов с кодом ответа `Ok`.
- DeleteProduct: Обрабатывает HTTP DELETE запросы для удаления продукта по ID. Если продукт не найден, возвращает `NotFound`, иначе возвращает `Ok` с результатом удаления.
- GetProductById: Обрабатывает HTTP GET запросы для получения конкретного продукта по его ID. Если продукт не найден, возвращает `NotFound`, иначе возвращает сам продукт с кодом ответа `Ok`.

Описание маршрутов:
- Метод `AddNewProduct` будет доступен по адресу `/api/product` и будет обрабатывать POST запросы.
- Метод `GetAllProducts` будет доступен по адресу `/api/product` и будет обрабатывать GET запросы.
- Метод `DeleteProduct` будет доступен по адресу `/api/product/{id}` и будет обрабатывать DELETE запросы, где `{id}` — это идентификатор продукта.
- Метод `GetProductById` будет доступен по адресу `/api/product/{id}` и будет обрабатывать GET запросы.

---

*Документирование контроллеров Web API в ASP.NET Core и их интеграция с Swagger позволяет обеспечить понятность
и доступность вашего API для разработчиков и пользователей. Swagger автоматически генерирует документацию на
основе атрибутов, используемых для описания методов и моделей API.*

Вот пошаговое руководство по добавлению документации для вашего API с использованием Swagger:

### Шаг 1: Установите `Swashbuckle.AspNetCore`

Добавьте пакет `Swashbuckle.AspNetCore` в ваш проект. Вы можете сделать это с помощью NuGet Package Manager или добавить его через командную строку:

```
dotnet add package Swashbuckle.AspNetCore
```

### Шаг 2: Настройте Swagger в `Startup.cs`

В вашем файле `Startup.cs` добавьте конфигурацию для Swagger в методах `ConfigureServices` и `Configure`:

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // Добавляем Swagger
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
        { 
            Title = "My API", 
            Version = "v1" 
        });
        
        // Добавляем поддержку XML комментариев, если они сгенерированы
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseRouting();

    // Включаем Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Доступ к Swagger UI по адресу "http://<host>:<port>/"
    });

    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

### Шаг 3: Генерируйте XML-комментарии

Чтобы включить Xml-комментарии в Swagger, вам необходимо включить их генерацию в файле проекта `.csproj`:

```
<PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

### Шаг 4: Добавьте комментарии к методам контроллера

Теперь вы можете добавлять комментарии к методам ваших контроллеров с использованием XML-синтаксиса. Например:

```
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    /// <summary>
    /// Добавляет новый продукт.
    /// </summary>
    /// <param name="newProduct">Данные нового продукта.</param>
    /// <returns>Результат операции добавления.</returns>
    [HttpPost]
    public ActionResult<bool> AddNewProduct([FromBody] Product newProduct)
    {
        // Логика добавления продукта...
        return Ok(true);
    }

    /// <summary>
    /// Получает список всех продуктов.
    /// </summary>
    /// <returns>Список продуктов.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        // Логика получения всех продуктов...
        return Ok(new List<Product>());
    }

    /// <summary>
    /// Удаляет продукт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <returns>Результат удаления.</returns>
    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteProduct(int id)
    {
        // Логика удаления продукта...
        return Ok(true);
    }
}
```

### Шаг 5: Используйте атрибуты Swagger для дальнейшей настройки

Вы также можете использовать различные атрибуты `Swagger` для более детальной настройки. Вот некоторые из них:

- **`[ProducesResponseType]`** - для указания типов ответов:
  
```
[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public ActionResult<Product> GetProductById(int id)
{
    // Логика...
}
```

- **`[Consumes]`** и **`[Produces]`** - для указания форматов входящих и исходящих данных:

```
[HttpPost]
[Consumes("application/json")]
[Produces("application/json")]
public ActionResult<bool> AddNewProduct([FromBody] Product newProduct)
{
    // Логика...
}
```

### Шаг 6: Запустите ваше приложение

После того как все настройки выполнены, запустите приложение, и перейдите по адресу `http://localhost:/`, чтобы увидеть Swagger UI. Вы должны увидеть документацию вашего API с описаниями, генерируемыми из ваших XML-комментариев.

### Заключение

Используя Swagger для документирования вашего ASP.NET Core Web API, вы сможете быстро и удобно представить ваше API пользователям и разработчикам, улучшая его тестируемость и делающие его более доступным. Атрибуты и XML-комментарии помогут обеспечивать актуальную и полную информацию о вашем API.