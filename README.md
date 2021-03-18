Most of my Blazor work is closed source, but I have a lot I want to share. This repo is still in its infancy, and will showcase all the techniques and approaches I use. In a nutshell:

- I use a Dapper-based data access approach using my [DapperCX](https://github.com/adamfoneil/Dapper.CX) project. I don't use EF or migrations. [Why?](https://github.com/adamfoneil/Dapper.CX/wiki)
- For general purpose querying, I use my [DapperQX](https://github.com/adamfoneil/Dapper.QX) project. [Why?](https://github.com/adamfoneil/Dapper.QX/wiki) See the [Queries](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.App/Queries) folder here for examples of Dapper.QX in use.
- I use [Radzen](https://blazor.radzen.com/) components.
- I use a couple homegrown tools [ModelSync](https://aosoftware.net/modelsync/) for migrating C# model classes to SQL Server, and [Zinger](https://github.com/adamfoneil/Postulate.Zinger), a SQL client for Dapper productivity. ModelSync is a paid app with a 30-day free trial. Zinger is free.

Please see my [Getting Started](https://github.com/adamfoneil/BlazorAO/wiki/Getting-Started) topic for info on cloning and running this for the first time.

![img](https://adamosoftware.blob.core.windows.net/images/EEB8KLF1SX.png)
