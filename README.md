This is a very small [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) demo I did as a reply to a React demo a colleague [McNair](https://github.com/tmcnairbledsoe) did. This is aimed at those who know little or nothing about Blazor.

It shows a simple API integration with [CoinAPI](https://www.coinapi.io/) and some basic CRUD operations on a SQL Server database.

## Why Blazor?
Blazor is a single-page app framework made for .NET that lets you build truly full-stack web apps in C# instead of JavaScript. This is dear to me because I have a very unhappy relationship with JavaScript. Blazor's appeal, therefore, is that it lets me leverage my C# skills within a familiar and powerful debugging experience. It's component-based fundamentally, and should be conceptually familiar to React developers. Blazor uses Razor as its markup language -- also a familiar hybrid of regular html and C# going back a decade or so.

The tools and component ecosystem are continually improving, and several vendors offer compelling suites -- [Telerik](https://www.telerik.com/blazor-ui), [Syncfusion](https://www.syncfusion.com/blazor-components), and [Radzen](https://blazor.radzen.com/), for example. .NET6 added [hot reload](https://devblogs.microsoft.com/dotnet/introducing-net-hot-reload/#best-in-visual-studio-2022-net-6) capability, but I've personally had mixed results with this in Visual Studio 2022. Blazor seems to be positioned on Microsoft's roadmap to enrich [desktop development](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-1/#blazor-desktop-apps) as well.

But the main reason I'm into Blazor is because it makes me relevant and productive in the front-end space again, and breaks JavaScript's monopoly over web development. I know there are legions of capabable devs who do great things in JavaScript, so I hesitate to say what I'm about to say.

JavaScript makes me feel stupid. I see it as a _funhouse mirror_ version of C#, an excruciating context switch from C#. JavaScipt has its own ecosystem of runtimes (Node.js, Deno), build tools, packages, libraries, and most crucially, its own grammar. Historically, companies had little choice but to support JavaScript in addition to .NET or other backend technology skillsets. Today, Blazor makes that dual focus and context switch harder to justify.

## Why Not Blazor?
Blazor has not really caught on, as far as I can tell, and is still relatively unproven in the market. JavaScript has a lot of developer mindshare, and C# fights an uphill battle to compete in that space. There's a lot of legacy code out there that won't "convert" to Blazor and must be re-written from scratch.

Developing Blazor apps requires you, in effect, to commit to a component vendor. I've used Radzen because they have a free tier with a pretty capable suite. But I don't love every aspect of it, and with Radzen at least I've found it's hard to style and theme your app to my liking.

The biggest annoyance I run into with Blazor is occasional mysterious null reference exceptions. When component layouts get complicated, null references may start happening for no discernable reason. The error is somewhere deep in the Blazor rendering logic, and there's nothing helpful in the stack trace that leads to an error you can fix. This  happened to me when working on this repo when I put two `RadzenGrids` on one [page](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Events.razor). I fixed it by extracting one of the grids to separate [component](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Components/UI/EventGrid.razor), but I never found the source of the original error.

## This Repo
I made this to echo McNair's [CoinAPI](https://www.coinapi.io/) integration, and is barely more than "hello world" functionality. Still, if you've never worked with Blazor at all, there are few things here that will demo some core concepts.

To clone and run this, you need an API key from [CoinAPI](https://www.coinapi.io/). I'll post a video walkthrough of how to set this in the project. To keep your key out of source control, you have to jump through a couple hoops.

### CoinApiClient
I used [Refit](https://github.com/reactiveui/refit) to implement my CoinAPI [client](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Services/CoinApiClient.cs). It gets added as a singleton at [startup](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Program.cs#L13) along with its corresponding [options](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Program.cs#L12) class [here](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Services/Models/CoinApiOptions.cs).

Blazor uses dependency injection everywhere, so I [inject](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L2) it into the page where I want to use it.

### Blazor in a Nutshell
Every piece of html markup in Blazor is implemented as a component (a .razor file), called a "Razor Component." A component with a **@page** directive, such as [this](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L1), can be navigated to in the browser, but is otherwise identical to other components.

Input controls such as text boxes typically use a `@bind-` syntax to support two-way binding between the control and a C# variable or property, such as this [text box](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L7) which binds to this [variable](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L26).

Blazor has rich event support. This [search button](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L10) calls this [event handler](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L29-L33), which executes a search for crypto exchange symbols. The search assigns this [allSymbols](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L32) variable, which is the data source for this [grid](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L13).

For html productivity, you can create components that encapsulate repeated code. For example this [Field](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Symbols.razor#L6) element looks like an html tag. It's really a Razor Component [Field](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Components/Field.razor), which makes it easy for me to pair a label and some other [contained content](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Components/Field.razor#L8).

I have more [components](https://github.com/adamfoneil/CryptoDemo.Blazor/tree/master/CryptoDemo.Blazor/Components) in this repo also.

### Data Access
Since data access is critical to just about any app, I felt this demo would be incomplete without some kind of data access. My example diverges completely from the crypto theme, however.

- The [Database](https://github.com/adamfoneil/CryptoDemo.Blazor/tree/master/CryptoDemo.Database) project has the model class tables.
- The [DataContext](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Services/DataContext.cs) object serves as the starting point for all data access, and is what's [injected](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Pages/Events.razor#L2) into components that need data access. It's initialized during [startup](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Program.cs#L15-L16). The `DataContext` provides access to all [tables](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Services/DataContext.cs#L27--L28) in the application. This powered by my [AO.Dapper.Repository](https://www.nuget.org/packages/AO.Dapper.Repository.SqlServer/) package.
- My examples use some [RadzenGrid](https://blazor.radzen.com/datagrid) controls, whose CRUD behaviors are handled by my [GridHelper](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Classes/GridHelper.cs) class. See its two derived classes: [VenueGridHelper](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Classes/GridHelpers/VenueGridHelper.cs) and [EventGridHelper](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Classes/GridHelpers/EventGridHelper.cs).
