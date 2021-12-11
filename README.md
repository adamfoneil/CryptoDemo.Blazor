This is a very small [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) demo I did as a reply to a React demo a colleague [McNair](https://github.com/tmcnairbledsoe) did. This is aimed at those who know little or nothing about Blazor.

## Why Blazor?
Blazor is a single-page app framework made for .NET that lets you build truly full-stack web apps in C# instead of JavaScript. This is dear to me because I have a very unhappy relationship with JavaScript. Blazor's appeal, therefore, is that it lets me leverage my C# skills within a familiar and powerful debugging experience. It's component-based fundamentally, and should be conceptually familiar to React developers. Blazor uses Razor as its markup language -- also a familiar hybrid of regular html and C# going back a decade, I think.

The tools and component ecosystem are continually improving, and several vendors offer compelling suites -- [Telerik](https://www.telerik.com/blazor-ui), [Syncfusion](https://www.syncfusion.com/blazor-components), and [Radzen](https://blazor.radzen.com/), for example. .NET6 added [hot reload](https://devblogs.microsoft.com/dotnet/introducing-net-hot-reload/#best-in-visual-studio-2022-net-6) capability, but I've personally had mixed results with this in Visual Studio 2022. Blazor seems to be positioned on Microsoft's roadmap to enrich [desktop development](https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-1/#blazor-desktop-apps) as well.

But the main reason I'm into Blazor is because it makes me relevant and productive in the front-end space again, and breaks JavaScript's monopoly over web development. I know there are legions of capabable devs who do great things in JavaScript, so I hesitate to say what I'm about to say. JavaScript makes me feel stupid. I see it as a _funhouse mirror_ version of C#, an excruciating context switch from C#. JavaScipt has its own ecosystem of runtimes (Node.js, Deno), build tools, packages, libraries, and most crucially, its own grammar. Companies that seriously introspect on their tech silos should be thinking about justifying this schism

## Why Not Blazor?
Blazor has not really caught on, and is still relatively unproven in the market. JavaScript has a lot of developer mindshare, and C# fights an uphill battle to compete in that space.

Developing Blazor apps requires you, in effect, to commit to a component vendor. I've used Radzen because they have a free tier with a pretty capable suite. I don't love every aspect of it, and with Radzen at least it's hard to style and theme your app, I've found.


- Startup and options [configuration](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Blazor/Program.cs#L10-L11)
- Very simple [CoinAPI](https://www.coinapi.io/) integration 


showing a [single method](https://github.com/adamfoneil/CryptoDemo.Blazor/blob/master/CryptoDemo.Services/Interfaces/ICoinApi.cs#L9)
