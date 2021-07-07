# WebAPI - AspNetCore 3.1

## Startup Class

It is where: 
- Services required by the app are configured (ConfigServices method)
- The app's request handling pipeline is defined, as a series of middleware components (Configure method)

## Middleware

Compose the request handling pipeline. Each component performs operations on an `HttpContext` and either invokes the next middleware in the pipeline or terminates the request.  
By convention, a middleware component is added to the pipeline by invoking a `Use...` extension method in the Startup.Configure method

## Host

...?

## Configuration

Settings as name-value pair from an ordered set of configuration providers. 
Order:
- appSettings.json
- etc


## Environments

Execution environments, such as `Development`, `Staging`, and `Production`, are specified in the `ASPNETCORE_ENVIRONMENT`environment variable. That value is stored in an `IWebHostEnvironment` implementation that is available anywhere in an app via dependency Injection.  

```cs
Public void Configure(IapplicationBuilder app, IWebHostEnvironemnt env)
{
	if (env.IsDevelopment))
	{
		app.UseDeveloperExeptionPage();
	}
}
```

## Routing

...?

## HttpClientFactory

.. ??


## Return Objects
Production apps typically limit the data that's input and returned using a subset of the model. There are multiple reasons behind this and security is a major one. The subset of a model is usually referred to as a Data Transfer Object (DTO), input model, or view model.  
A DTO may be used to:  
- Prevent over-posting.
- Hide properties that clients are not supposed to view.
- Omit some properties in order to reduce payload size.
- Flatten object graphs that contain nested objects. Flattened object graphs can be more convenient for clients.