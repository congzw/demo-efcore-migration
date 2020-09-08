# Markdown File

## how to

```sh

# init
dotnet ef migrations add InitialCreate

# add column CreatedTimestamp
dotnet ef migrations add AddBlogCreatedTimestamp

# add table
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

```