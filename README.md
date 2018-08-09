# NewFoodNutrients Project

### Introduction

I created this project to demonstrate some of my skills as a software engineer.  I also wanted to show how would I architech and build a new application or refactor an existing one based on my mentioned skills and knowledges.  
It Is a very simple web application that let me cover a number of modern technologies and architechture patterns and principles commonly used by top engineers and architechs in building cutting edge applications.

### NewFooNutrients Description

To be able to demonstrate some __SOLID__ architecture principles in practice I incorporated into the solution a unit testing project which needs to mocks MVC controllers.  To mocked this controllers I decoupled them from the context _(in this case from EF 6)_ by using the __Repository Pattern__ of Martin Fowler described in his book __Patterns of Enterprise Application and Architechture__. 

So, I made a repository for each entity type _(i.e. Recipe, RecipeIngredient, etc.)_.  These repositories would consists mainly of all query calls to the data base.  Removing those queries and putting them into the repository left the controllers with less responsibilities __(Single Responsibility Principle)__ and a better separation of concerns, and at the same time let me reuse those queries since they can now be called from different methods/controllers. 

#### Definitions And References
> __Repository Pattern__
> Mediates between the domain and data maping layers using a collection-like interface for accessing domain objects.

>__Unit of Work__
>Maintains a list of objects affected by a business transaction and coordinates the writing out of changes.	


So, I came out with a simple cooking recipes web application, where each recipe (parent) could contain one or multiple ingredients (children).  The application lets users adding, updating and deleting cooking recipes.

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



