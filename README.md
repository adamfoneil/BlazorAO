Most of my Blazor work is closed source, but I have a lot I want to share. This repo is here to give you ideas about how to approach Blazor from a tech standpoint, but also for myself to be a real data modeling exercise, as I rethink a classic application to make it better. In a nutshell:

- This is a Blazor Server app, not WASM
- I use a Dapper-based data access approach using my [DapperCX](https://github.com/adamfoneil/Dapper.CX) project. I don't use EF or migrations. [Why?](https://github.com/adamfoneil/Dapper.CX/wiki)
- For general purpose querying, I use my [DapperQX](https://github.com/adamfoneil/Dapper.QX) project. [Why?](https://github.com/adamfoneil/Dapper.QX/wiki) See the [Queries](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.App/Queries) folder here for examples of Dapper.QX in use.
- I use [Radzen](https://blazor.radzen.com/) components.
- I use a couple homegrown tools: [ModelSync](https://aosoftware.net/modelsync/) for migrating C# model classes to SQL Server, and [Zinger](https://github.com/adamfoneil/Postulate.Zinger), a SQL client for Dapper productivity. ModelSync is a paid app with a 30-day free trial. Zinger is free. [Radzen Grid Helper](https://github.com/adamfoneil/RadzenGridHelper) is a really specific and limited markup builder.

Please see my [Getting Started](https://github.com/adamfoneil/BlazorAO/wiki/Getting-Started) topic for info on cloning and running this for the first time.

## About the app
The sample app in this repo is a multi-tenant time entry, expense tracking and billing system intended for small companies. It's actually a from-scratch rebuild of my company's time entry system that I did originally in Classic ASP a long time ago and recently rewrote in Blazor Server. I couldn't share that app, and there were things I wanted to simplify about it for general-purpose consumption anyway.

In addition to showcasing my Blazor approaches in order to give you ideas for your own work, it's also a serious attempt at a time entry app. I've worked on time entry apps a lot in the past, but I'm using this opportunity to rethink and simplify a few things. I don't intend this to be a marketable application, but I do intend this as a real data modeling exercise. I'd started this repo using just throwaway, nonsense examples in order to demonstrate how to build data grids and forms. But building a real app digs up corner cases and nuances that I think are more useful to see done.

## Repo links
- The [App](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.App) project is a .NET5 Blazor Server project.
- The [Models](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.Models) project is a .NET Standard 2.0 project, and provides the database structure.
- I have a few modest custom [Components](https://github.com/adamfoneil/BlazorAO/tree/master/BlazorAO.App/Components), which are mainly small HTML helpers. But a few do something unique for this project:
    - [GitHubLink](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/GitHubLink.razor) causes a button to appear that links to the current page in GitHub. This is makes it easier to see the working page with the code side-by-side.

    ![img](https://adamosoftware.blob.core.windows.net/images/LHSJ2T6HAT.png)

    - [GridControls](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/GridControls.razor) is how I apply standard edit, delete, save, and cancel buttons across all my data grids.
    
    ![img](https://adamosoftware.blob.core.windows.net/images/KQOZGUNMUR.png)
    - Many of my model classes have a `bool IsActive` property grid's often need to filter by. [ActiveFilter](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/ActiveFilter.razor) provides a standard active/inactive filter control for use with all grids.

    ![img](https://adamosoftware.blob.core.windows.net/images/XZODWVFYVX.png)
    
    - [ErrorMessage](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/ErrorMessage.razor) provides my standard error display functionality used most everwhere.
    - [Pager](https://github.com/adamfoneil/BlazorAO/blob/master/BlazorAO.App/Components/Pager.razor) provides paging capability.    

## More
The [Wiki](https://github.com/adamfoneil/BlazorAO/wiki) goes into more detail, so please check there for more content.

If you want to see a feature implemented or have a question, please submit an issue.
