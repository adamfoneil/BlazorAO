Most of my Blazor work is closed source, but I have a lot I want to share. This repo is still in its infancy, and will showcase all the techniques and approaches I use. In a nutshell:

- I use a Dapper-based data access approach using my [DapperCX](https://github.com/adamfoneil/Dapper.CX) project. I don't use EF or migrations. [Why?](https://github.com/adamfoneil/Dapper.CX/wiki)
- For general purpose querying, I use my [DapperQX](https://github.com/adamfoneil/Dapper.QX) project. [Why?](https://github.com/adamfoneil/Dapper.QX/wiki) See the [Queries](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.App/Queries) folder here for examples of Dapper.QX in use.
- I use [Radzen](https://blazor.radzen.com/) components.
- I use a couple homegrown tools: [ModelSync](https://aosoftware.net/modelsync/) for migrating C# model classes to SQL Server, and [Zinger](https://github.com/adamfoneil/Postulate.Zinger), a SQL client for Dapper productivity. ModelSync is a paid app with a 30-day free trial. Zinger is free.

Please see my [Getting Started](https://github.com/adamfoneil/BlazorAO/wiki/Getting-Started) topic for info on cloning and running this for the first time.

## About the app
The sample app in this repo is a multi-tenant time entry, expense tracking and billing system intended for small companies. It's actually a from-scratch rebuild of my company's time entry system that I did originally in Classic ASP a long time ago, and recently rewrote in Blazor Server. I couldn't share that app, and there were things I wanted to simplify about it for general-purpose consumption anyway.

## Repo links
- The [App](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.App) project is a .NET5 Blazor Server project.
- The [Models](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.Models) project is a .NET Standard 2.0 project, and provides the database structure.
- I have a few modest custom [Components](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.App/Components), which are mainly small HTML helpers. But a few do something unique for this project:
    - [GitHubLink](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/GitHubLink.razor) causes a button to appear that links to the current page in GitHub. This is makes it easier to see the working page with the code side-by-side, sort of.
    - [GridControls](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/GridControls.razor) is how I apply standard edit, delete, save, and cancel buttons across all my data grids.
    - Many of my model classes have a `bool IsActive` property grid's often need to filter by. [ActiveFilter](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/ActiveFilter.razor) provides a standard active/inactive filter control for use with all grids.
    - [ErrorMessage](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/ErrorMessage.razor) provides my standard error display functionality used most everwhere.
