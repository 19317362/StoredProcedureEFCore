﻿using StoredProcedure.Extensions;
using System.Collections.Generic;

namespace StoredProcedure
{
  public class DataAccessBase
  {
    /// <summary>
    /// Stored procedure that list, with a limit, the Table1's rows
    /// </summary>
    /// <param name="limit">Rows limit</param>
    /// <returns></returns>
    public List<Dbo.ResultProc> ListRowsFromTable1(long limit)
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.Exec<Dbo.ResultProc>("[dbo].[ListAll]", ("limit", limit));
      }
    }

    public long FirstId()
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.ExecScalar<long>("[dbo].[ListAll]");
      }
    }

    public Dbo.ResultProc FirstRow(long limit)
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.ExecFirst<Dbo.ResultProc>("[dbo].[ListAll]", ("limit", limit));
      }
    }

    public Dbo.ResultProc SingleRow(long limit)
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.ExecSingle<Dbo.ResultProc>("[dbo].[ListAll]", ("limit", limit));
      }
    }

    public List<long> Column(long limit)
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.ExecColumn<long>("[dbo].[ListAll]", ("limit", limit));
      }
    }

    public Dictionary<long, Dbo.ResultProc> Dictionary(long limit)
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.ExecDictionary<long, Dbo.ResultProc>("[dbo].[ListAll]", ("limit", limit));
      }
    }

    public Dictionary<long, List<Dbo.ResultProc>> Lookup(long limit)
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.ExecLookup<long, Dbo.ResultProc>("[dbo].[ListAll]", ("limit", limit));
      }
    }

    public HashSet<long> Set(long limit)
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.ExecSet<long>("[dbo].[ListAll]", ("limit", limit));
      }
    }

    /// <summary>
    /// Stored procedure that return the parameter
    /// </summary>
    /// <param name="boolToReturn"></param>
    /// <returns></returns>
    public bool IsSomething(bool boolToReturn)
    {
      using (DataAccess.TestContext ctx = new DataAccess.TestContext())
      {
        return ctx.Exec("[dbo].[ReturnBoolean]", ("boolean_to_return", boolToReturn));
      }
    }
  }
}
