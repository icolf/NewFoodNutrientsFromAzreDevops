# NewFoodNutrients Project

### Introduction

I created this project to expose some of my skills as a software engineer and to show how would I architech and build a new application or refactor an existing one.  
This is a very simple web application that let me cover a number of modern technologies and architechture patterns and principles commonly used by top engineers and architechs in building cutting edge applications.
To reach a required level of complexity to meet those goals, I created a simple cooking recipes .Net MVC web application, where each recipe (parent) could contains one or multiple ingredients (children).  The application lets users logging in, adding, updating and deleting cooking recipes.  
I follow code-first aproach and used MS SQL Server as database in a VisualStudio 2017 environment and Team Foundation 2017 with Git as source control manager.

### Architecture
#### Backend
To be able to demonstrate some __SOLID__ architecture principles I've incorporated into the solution a unit testing project which needs to mock MVC controllers.  To mocked this controllers I needed to decoupled them from its context calls _(in this case from EF 6 calls)_ by using the __Repository and Unit of Work Patterns__ described by Martin Fowler in his book __Patterns of Enterprise Application and Architechture__. 

First, I made a repository for each entity type _(i.e. Recipe, RecipeIngredient, etc.)_.  These repositories would consist mainly of all query calls to the data base and adding entities to the ChangeTracking _("Attach(entity)")_ system of the context.  Removing those queries from the controllers and putting them into the repositories left controllers with less responsibilities __(Single Responsibility Principle)__ and a better __separation of concerns__.  This also lets other controllers call this queries giving the benefit of reusing queries. 

To continue the process of decoupling controllers from _context_ calls, I needed a __UnitOfWork__ class which contains references (public properties) to all the repositories.  This class _"UnitOfWork"_, will also contains a Complete() method, which calls the SaveChanges method of EF to persist all changes made to all entities in a transaction. In other words, now the controller don't need to make any direct call to context _("context.SaveChanges()" )_ instead it'll be calling _unitOFWork.RepositoryName.Complete().  

Now I can apply the __Dependecy Inversion Principle__ to totally decouple controllers from Entity Framework context.  So, I extracted interfaces from each Repository and from my UnitOfWork classes.  Next I configured Ninject _(IoC for Dependency Injection)_ to inject to the controller's constructor a concrete class of IUnitOfWork interface.  
#### Frontend
In this area I used the __Immediately Invoked Function Expression__ pattern to be able of modularizing my knockOutjs view models and other objects.  This pattern permitts a better separation of concerns by letting for example segregate ViewModels from the Models as you can see in _scripts\app\_ folders in this solution.  
I have also integrated some Bootstrap.css classes' overwitting to have a standard look of all pages in the project using some LESS commands as you can see in Site.LESS file in the _content_ folder of this solution.   
#### Definitions And References
> __Repository Pattern__  
> Mediates between the domain and data maping layers using a collection-like interface for accessing domain objects.

>__Unit of Work__  
>Maintains a list of objects affected by a business transaction and coordinates the writing out of changes.	

>__Dependency Inversion Principle__  
>> A: High level modules should not depend on low-level modules. Both should depend on abstractions.  
>> B: Abstractions should not depend on details.  Details should depend on abstractions.




### Architecture

The solution contains 3 projects
1. NewFoodNutrients
2. NewFoodNutrients.Tests
3. NewFoodNutrients.Integration.Tests
### Features
#### NewFoodNutrients Project
##### Architecture Patterns and 



### Tools

#### Microsoft Tools/Packages
- Microsoft Visual Studio 2017
- Framework .Net 4.5.2
- Microsoft.AspNet.Mvc version="5.2.6"
- EntityFramework version="6.2.0"
- Microsoft.AspNet.Razor version="3.2.6"
- Microsoft.AspNet.WebApi version="5.0.0"

#### External Packages
-   _Inversion Of Control Container_ = Ninject version="3.3.4"  


##### Testing
-	FluentAssertions
-	Moq version =  4.9.0
-	MSTest version ="1.3.2"
-	NUnit Version = "3.10.1"
-	JetBrains dotCover _(Code Coverage Tool)

##### CSS
- Bootstrap version="3.3.7"
- BuilWebCompiler	version = "1.11" _Less Compiler_
- 

##### JavaScript
- jQuery version = "3.3.1"
- jQuery.Validation 
- knockOutjs version ="3.4.2"
- knockOut.Mapping version = "2.4.0"
- lodash version = "4.17.0" _Utility library_



