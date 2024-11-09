## ���� AuthController � Postman

�����������
```json
https://localhost:44364/api/auth
body - raw - json

{
    "LastName" : "nameddd"
}
```


���������� ��������
```json
https://localhost:44364/api/product
body - raw - json

{
    "Name" : "������� �������� 1",
    "Article" : "111111",
    "Category" : 2,
    "Amount" : 111,
    "UnitOfMeasurement" : 4,
    "StoragePlace" : "111-111-111"
}
```
---
*��� � ����� WebAPI ����������� asp core mvc ��������� ��������� �������*

� ����� ����������� Web API � ASP.NET Core �� ������ ���������� ��������� ������� � ��������� �������, ��������� �������� �������������,
����� ��� `[HttpPost]`, `[HttpGet]`, `[HttpPut]`, `[HttpDelete]` � �.�. ��� ��������� ��� ������������ ��������� HTTP-������
� ����� �����������. �������� ��������, ��� ������ ����� ������ ����� ���������� ������� ��� ������������ �� �� ��������, �� ����������� �� ������ HTTP.
- AddNewProduct: ������������ HTTP POST ������� ��� ���������� ������ ��������. ���� ���������� �� �������, ���������� `BadRequest`, ����� ���������� `Ok` � �����������.
- GetAllProducts: ������������ HTTP GET ������ ��� ��������� ������ ���� ���������. ���������� ������ ��������� � ����� ������ `Ok`.
- DeleteProduct: ������������ HTTP DELETE ������� ��� �������� �������� �� ID. ���� ������� �� ������, ���������� `NotFound`, ����� ���������� `Ok` � ����������� ��������.
- GetProductById: ������������ HTTP GET ������� ��� ��������� ����������� �������� �� ��� ID. ���� ������� �� ������, ���������� `NotFound`, ����� ���������� ��� ������� � ����� ������ `Ok`.

�������� ���������:
- ����� `AddNewProduct` ����� �������� �� ������ `/api/product` � ����� ������������ POST �������.
- ����� `GetAllProducts` ����� �������� �� ������ `/api/product` � ����� ������������ GET �������.
- ����� `DeleteProduct` ����� �������� �� ������ `/api/product/{id}` � ����� ������������ DELETE �������, ��� `{id}` � ��� ������������� ��������.
- ����� `GetProductById` ����� �������� �� ������ `/api/product/{id}` � ����� ������������ GET �������.

---

*���������������� ������������ Web API � ASP.NET Core � �� ���������� � Swagger ��������� ���������� ����������
� ����������� ������ API ��� ������������� � �������������. Swagger ������������� ���������� ������������ ��
������ ���������, ������������ ��� �������� ������� � ������� API.*

��� ��������� ����������� �� ���������� ������������ ��� ������ API � �������������� Swagger:

### ��� 1: ���������� `Swashbuckle.AspNetCore`

�������� ����� `Swashbuckle.AspNetCore` � ��� ������. �� ������ ������� ��� � ������� NuGet Package Manager ��� �������� ��� ����� ��������� ������:

```
dotnet add package Swashbuckle.AspNetCore
```

### ��� 2: ��������� Swagger � `Startup.cs`

� ����� ����� `Startup.cs` �������� ������������ ��� Swagger � ������� `ConfigureServices` � `Configure`:

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // ��������� Swagger
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
        { 
            Title = "My API", 
            Version = "v1" 
        });
        
        // ��������� ��������� XML ������������, ���� ��� �������������
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

    // �������� Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // ������ � Swagger UI �� ������ "http://<host>:<port>/"
    });

    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

### ��� 3: ����������� XML-�����������

����� �������� Xml-����������� � Swagger, ��� ���������� �������� �� ��������� � ����� ������� `.csproj`:

```
<PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

### ��� 4: �������� ����������� � ������� �����������

������ �� ������ ��������� ����������� � ������� ����� ������������ � �������������� XML-����������. ��������:

```
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    /// <summary>
    /// ��������� ����� �������.
    /// </summary>
    /// <param name="newProduct">������ ������ ��������.</param>
    /// <returns>��������� �������� ����������.</returns>
    [HttpPost]
    public ActionResult<bool> AddNewProduct([FromBody] Product newProduct)
    {
        // ������ ���������� ��������...
        return Ok(true);
    }

    /// <summary>
    /// �������� ������ ���� ���������.
    /// </summary>
    /// <returns>������ ���������.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        // ������ ��������� ���� ���������...
        return Ok(new List<Product>());
    }

    /// <summary>
    /// ������� ������� �� ��������������.
    /// </summary>
    /// <param name="id">������������� ��������.</param>
    /// <returns>��������� ��������.</returns>
    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteProduct(int id)
    {
        // ������ �������� ��������...
        return Ok(true);
    }
}
```

### ��� 5: ����������� �������� Swagger ��� ���������� ���������

�� ����� ������ ������������ ��������� �������� `Swagger` ��� ����� ��������� ���������. ��� ��������� �� ���:

- **`[ProducesResponseType]`** - ��� �������� ����� �������:
  
```
[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public ActionResult<Product> GetProductById(int id)
{
    // ������...
}
```

- **`[Consumes]`** � **`[Produces]`** - ��� �������� �������� �������� � ��������� ������:

```
[HttpPost]
[Consumes("application/json")]
[Produces("application/json")]
public ActionResult<bool> AddNewProduct([FromBody] Product newProduct)
{
    // ������...
}
```

### ��� 6: ��������� ���� ����������

����� ���� ��� ��� ��������� ���������, ��������� ����������, � ��������� �� ������ `http://localhost:/`, ����� ������� Swagger UI. �� ������ ������� ������������ ������ API � ����������, ������������� �� ����� XML-������������.

### ����������

��������� Swagger ��� ���������������� ������ ASP.NET Core Web API, �� ������� ������ � ������ ����������� ���� API ������������� � �������������, ������� ��� ������������� � �������� ��� ����� ���������. �������� � XML-����������� ������� ������������ ���������� � ������ ���������� � ����� API.