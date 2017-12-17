 # Execute stored procedures with Entity Framework Core

This code add a static method to *DbContext* named *Exec*.
The latter calls a stored procedure and maps the result into a list of
the specified type. If the model type is not specified, it will return a
boolean gotten from the SQL Server return statement.

The *Exec* method handles :
- Extra column in result set
- Extra property in model
- Null values in result set
- Underscores or hypens in result set column names ("column_name" is mapped to ColumnName property)

```csharp
using (DbContext ctx = GetContext())
{
  List<ResultModel> res = ctx.Exec<ResultModel>("dbo.StoredProcedureName", ("param_name", value));
}
```

## API

### DbContext
```csharp
List<T> DbContext.Exec<T>(string name, params (string, object)[] parameters)
Dictionary<TKey, TValue> DbContext.ExecDictionary<TKey, TValue>(string name, params (string, object)[] parameters)
Dictionary<TKey, List<TValue>> DbContext.ExecLookup<TKey, TValue>(string name, params (string, object)[] parameters)
HashSet<T> DbContext.ExecSet<T>(string name, params (string, object)[] parameters)
List<T> ExecColumn<T>(string name, params (string, object)[] parameters)
T DbContext.ExecScalar<T>(string name, params (string, object)[] parameters)
T DbContext.ExecFirst<T>(string name, params (string, object)[] parameters)
T DbContext.ExecFirstOrDefault<T>(string name, params (string, object)[] parameters)
T DbContext.ExecSingle<T>(string name, params (string, object)[] parameters)
bool Exec(string name, params (string, object)[] parameters)
```

### IDataReader
```csharp
List<T> IDataReader.ToList<T>()
Dictionary<TKey, TValue> IDataReader.ToDictionary<TKey, TValue>()
Dictionary<TKey, List<TValue>> IDataReader.ToLookup<TKey, TValue>()
HashSet<T> IDataReader.ToSet<T>()
List<T> Column<T>()
T IDataReader.First<T>()
T IDataReader.FirstOrDefault<T>()
T IDataReader.Single<T>()
```

## Why ?

Stored procedure execution is not supported in entity framework core:
- [Raw store access APIs: Support for ad hoc mapping of arbitrary types #1862](https://github.com/aspnet/EntityFramework/issues/1862)
- [Stored procedure mapping support #245](https://github.com/aspnet/EntityFramework/issues/245)
