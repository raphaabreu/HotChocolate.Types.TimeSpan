# HotChocolate.Types.TimeSpan

Simple extension to the original HotChocolate Type system to include basic support for `TimeSpan`s.

To use, install package then add to your schema builder:

    services.AddGraphQL(SchemaBuilder.New()
        .AddQueryType<YourQuery>()
        .AddTimeSpanScalar()
        .Create());

