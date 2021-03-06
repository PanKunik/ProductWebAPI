# ProductWebAPI

Simple project which contains all necessary elements to host WebAPI and API Client (using .NET Framework MVC). It has been made using Visual Studio 2019 Community. This repository is divided into five projects, which are described down below. The API and Api Client doesn't have any type of authentication.

It has been made for learning purposes.

## Documentation
### PSMData
  It contains scripts that creates database tables using T-SQL and strored procedures, which are used to select data from and insert into database.

### PSMDataManager
  This is WebAPI project with Swagger addon. It has GET and POST methods to collect data from Database. All models used in this project are in the 'PSMDataManager.Library' to separate business logic from front-end application. Every controller retrieves data from a different table from database (for e.g. The `ProductsController` takes data from the `Product` table). 
  
#### Routing
In this API routes allow you to insert new, edit exisiting and retrieve data from tables. These operations are executed by using REST methods like GET, POST, PUT and DELETE. 
##### Products routes
Retrieving all existing products or insert new one (with data in body):
```
http://localhost:44339/api/products
```
Retrieve one specified product or delete one. If you add data in body you can edit the product. For e.g. to GET one product with Id = 1 you can use:
```
http://localhost:44339/api/products/1
```
You can search for products by using query parameters like:
- category -> allows you to search for products of specified category (search by id)
- brand -> allows you to search for products of specified brand (search by id)
- name -> allows you to search for products whose name is like: %name%
For e.g. To search for product with id category = 1, id brand = 3 and name containing "milk" you can use:
```
http://localhost:44339/api/products?category=1&brand=3&name=milk
```

### PSMDataManager.Library
  This project includes basic data access class `SqlDataAccess` and classes that load and save data in a database. It also contains models used in WebAPI application, because the API doesn't need separate models. It operates on complete data retrieved from the database.

### PSMDataManagerMVC
  This is API Client application project. Simple application made with .NET Framework MVC, which has controllers to collect data from the API using classes included in 'PSMDataManagerMVC.Library'. This project uses models from class library, but it has his own View model classes. These View models contain data for Views. They store data and have methods that connect to appropriate endpoints included in 'PSMDataMAnagerMVC.Library' (for e.g. `BrandViewModel` stores list of brands and has a method that connects to `IBrandEndpoint` to collect data from the API).

### PSMDataManagerMVC.Library
  This library contains all classes needed for connecting to the API application and models that matches data retrieved from the API. The `APIHelper` class is responsible for instantiating 'HttpClient' class and adding headers to the request. Every data model from the API has own class endpoint that connects to appropriate method in the API (for e.g. `IProductEndpoint` has methods that can connect to `GET` and `POST` methods in the API).

## Technologies used:
* ASP.NET Framework MVC - for writing API client application,
* ASP.NET Framework WebAPI - for writting web API application,
* Class Library (.NET Framework) - for separating data access classes and models used in data access, 
* T-SQL - for creating tables and writing stored procedures
