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


# Controllers

Attributes are used to describe which HTTP Method is used to activate the ActionMethod
```cs
[HttpGet]
public string[] GetDishes() 
{
	string[] dishes = { "vaca atolada", "lasanha"};
	return dishes;
}

```

## Web API CRUD Conventions

| Action | Method | Success | Failure | 
|---|---|---|---|
| Create  | POST  |  201(Created) | 400 (Bad request)  |
| Read  | GET  | 200(Ok)  | 404(Not Found)  |
| Update  | PUT/PATCH  | 204 (No Content)  | 404 (Not Found)  |
| Delete  | DELETE  | 204 (No Content)  |  400 (Bad Request) |

To Update a document two ways are possible: Put or Patch. Put will replace the entire document while patch wil replace a specific portion of the document.
Patch is not active by default in AspNet Core, To use Patch it is necessary to add nuget-packages: `Microsoft.AspNetCore.JsonPatch` and `Microsoft.AspNetCore.Mvc.NewtonSoftJson`.
Then on the Startup ConfigureServices add `AddNewtonsoftJson`:
```cs
public void ConfigureServices(IServiceCollection services)
{

	services.AddControllers().AddNewtonsoftJson();
}
```

Then on the controller, include the patch:
```cs
public class RecipesController : ControllerBase {
	[HttpPatch("{id}")]
	public async Task<ActionResult> UpdateRecipe(string int, JsonPatchDocument<Recipe> recipeUpdates)
	{
		var recipe = await _recipeData.GetRecipeById(id);
		if (recipe is null)
			return NotFound();
		
		recipeUpdates.ApplyTo(recipe);
		await _recipeData.UpdateRecipe(recipe);
		return NoContent();
	}
}
```

a patch document `JsonPatchDocument<Recipe>` payload to update a recipe`s title would look like:  
```json
[
	{
		"path": "/title",
		"op": "replace",
		"value": "My new recipe title"
	}
]
```


### Helper Methods from ApiController Attribute
| Method | Status Code | Parameter |
|---|---|---|
| Ok() | 200 | value to be returned..| 
| NoContent()| 204 | - | 
| NotFound()| 404| - |
|Created()| ?? | 1, 2|

TODO: completar essa tabela!!


## Routing

URL `https://graph.microsoft.com/v1.0/me` is composde of: 
> Scheme `https://`  
> host name: `graph.microsoft.com`  
> path: `/v1.0/me`  

The recommended way to apply routing to ASPNET Core WebAPIs is through Attributes.  
We can controll the routing in the controller level, as demonstrated below
```cs
[Route("api/[controller]")] //our controller will listen to anything that comes from the path /api/recipes
//[Route("api/recipes")] //this also works and can be used when we want a different class name from the path
[ApiController]
public class RecipesController : ControllerBase {}
```

and also controll routing it at method level:
```cs
[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase 
{
	//this would make the method be activated by calling /api/recipes/all
	[HttpDelete("all")]
	pubic ActionResult DeleteRecipes() 
	{
		//...
	}

	//we can also define tokens of variables we want to receive:
	[HttpDelete("{id}}")] //api/recipes/1
	pubic ActionResult DeleteRecipe(string id) // the framework automagically maps the token to the parameter with same name
	{
		//...
	}
}
```

## Return Types - Action Results

ActionResult allow us to return our data and configure which status-code we want to return.

## Binding - pull information from the http-request

Binding Sources

| Source | Attribute |
|---|---|
| Request Body | [FromBody] |
| From data in the request body | [FromForm] |
| Headers | [FromHeader] |
| Query string parameter | [FromQuery] |

```cs
[HttpGet]
public ActionResult GetRecipes([FromQuery] int count)
{
	string[] recipes = { "vaca atolada", "lasanha"};
	return Ok(recipes.Take(count));
}
```

## Validate HTTP Request Payloads

There are built-in validation attributes inside AspNetCore `System.ComponentModel.DataAnnotations`, some are:
- Required
- MaxLenght
- MinLength
- Phone
- Email
- CreditCard
- Range
- Compare

Problem Details for HTTP APIs, RFC 7807 is already configured in AspNetCore
https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?WT.mc_id=beginwebapis-c9-cephilli&view=aspnetcore-3.1


## Handling Exceptions

We can create a Controller specifically to handle exceptions, as shown in: https://www.youtube.com/watch?v=DkEwPquIurI&list=PLdo4fOcmZ0oVjOKgzsWqdFVvzGL2_d72v&index=14

## OpenAPI / Swagger

To display documentation on Swagger it is necessary to enable XML documentatino on the project, more info: https://www.youtube.com/watch?v=IBw3ONR1d7E&list=PLdo4fOcmZ0oVjOKgzsWqdFVvzGL2_d72v&index=15  
To display status code / return types of an Action Method inside a controller we need to add a few attributes.  
First, add `[Consumes(MediaTypeNames.Application.Json)]`and `[Produces(MediaTypeNames.Application.Json)]` to the controller.  
Then add `[ProducesResponseType(StatusCodes.Status200Ok)]` or another status code to the Action Method. Ex.:  

```cs

[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiController]
public class RecipesController : ControllerBase
{

	[HttpGet("{id}")]
	[ProducesResponseType(StatusCodes.Status200Ok)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> GetRecipeById(string id)
	{
		//...code
	}

}
```

## Unit Testing Controllers

Great explanation on how to use _FakeItEasy_ to mock controller dependencies.  
https://www.youtube.com/watch?v=RgoytbbYbr8&list=PLdo4fOcmZ0oVjOKgzsWqdFVvzGL2_d72v&index=18
Also, more documentation on how to do it:  https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?WT.mc_id=beginwebapis-c9-cephilli&view=aspnetcore-3.1