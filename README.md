In ASP.NET Core, middleware components are used to handle requests and responses as they flow through the application's pipeline. These middleware components can be chained together to process requests and responses in a specific order. Transferring data between middleware components can be achieved using various techniques. Here are a few commonly used methods:

1. **HttpContext.Items**: The `HttpContext` class in ASP.NET Core provides a dictionary-like collection (`Items`) that allows you to store and retrieve data within the scope of a single HTTP request. This data can be accessed by any middleware component in the request pipeline.

   ```csharp
   // In one middleware component
   context.Items["Key"] = value;

   // In another middleware component
   var data = context.Items["Key"];
   ```

   Keep in mind that the data stored in `HttpContext.Items` is only available for the duration of the current request.

2. **Using constructor injection**: You can pass data between middleware components using constructor injection. This approach is useful when you need to share data that is not specific to a single request.

   ```csharp
   public class MyMiddleware
   {
       private readonly RequestDelegate _next;
       private readonly SomeService _service;

       public MyMiddleware(RequestDelegate next, SomeService service)
       {
           _next = next;
           _service = service;
       }

       public async Task Invoke(HttpContext context)
       {
           // Use _service here
           await _next(context);
       }
   }
   ```

   In this example, `SomeService` is a service registered with the ASP.NET Core dependency injection container.

3. **Using request and response objects**: You can also pass data between middleware components by adding or modifying properties of the `HttpRequest` and `HttpResponse` objects.

   ```csharp
   // In one middleware component
   context.Request.Headers.Add("Key", value);

   // In another middleware component
   var data = context.Request.Headers["Key"];
   ```

   Similarly, you can modify response headers or content in one middleware component and access those modifications in subsequent middleware components.

4. **Custom middleware options**: If you have a significant amount of data to transfer between middleware components, you can create custom middleware options and configure them when registering your middleware in the application startup.

   ```csharp
   public class MyMiddlewareOptions
   {
       public string OptionValue { get; set; }
   }

   public class MyMiddleware
   {
       private readonly RequestDelegate _next;
       private readonly MyMiddlewareOptions _options;

       public MyMiddleware(RequestDelegate next, IOptions<MyMiddlewareOptions> options)
       {
           _next = next;
           _options = options.Value;
       }

       public async Task Invoke(HttpContext context)
       {
           // Use _options.OptionValue here
           await _next(context);
       }
   }
   ```

   You can configure `MyMiddlewareOptions` with the desired data and provide it when registering the middleware in `Startup.cs`.

These are some common approaches for transferring data between middleware components in ASP.NET Core. The choice of method depends on factors such as the scope of the data, the amount of data being transferred, and the specific requirements of your application.
