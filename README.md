# HotChocolate.Types.TimeSpan

Simple extension to the original HotChocolate Type system to include basic support for `TimeSpan`s.

[Nuget package](https://www.nuget.org/packages/HotChocolate.Types.TimeSpan).

To use, install package using ``dotnet add package HotChocolate.Types.TimeSpan`` then add to your schema builder:

    services.AddGraphQL(SchemaBuilder.New()
        .AddQueryType<YourQuery>()
        .AddTimeSpanScalar()
        .Create());

