# a demo for migration database with ef core

## how to

edit proj

```xml

<ItemGroup>
	<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.2.6" />
	<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="2.2.6" />
</ItemGroup>

```

impl DesignTimeDbContextFactory to tell the Design tool


```sh

# change work dir to the project dir("src/DemoApp")

# init
dotnet ef migrations add InitialCreate

# add column CreatedTimestamp
dotnet ef migrations add AddBlogCreatedTimestamp

# change column CreateAt
dotnet ef migrations add ChangeCreateAt

# apply change or => "mainDbContext.Database.Migrate();
dotnet ef database update

```

##  history

```csharp


public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedTimestamp { get; set; }
}

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateAt { get; set; }
}

```

## refs

- [migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)