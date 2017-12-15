﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StoredProcedure
{
  public class Program
  {
    public static void Main(string[] args)
    {
      int count = 500;
      var da = new DataAccessBase();

      List<Dbo.ResultProc> rows = da.ListRowsFromTable1(count);
      Debug.Assert(rows.Count == count);
      CheckRow(rows[0]);

      Debug.Assert(da.IsSomething(true));
      Debug.Assert(!da.IsSomething(false));

      long l = da.FirstId();
      Debug.Assert(l != 0);

      Dbo.ResultProc first = da.FirstRow(1);
      CheckRow(first);
      first = da.FirstRow(2);
      CheckRow(first);

      try
      {
        da.FirstRow(0);
        Debug.Assert(false);
      }
      catch (Exception)
      {
      }

      first = da.FirstRow(1);
      CheckRow(first);
      first = da.FirstRow(2);
      CheckRow(first);

      Dbo.ResultProc single;

      try
      {
        single = da.SingleRow(0);
        Debug.Assert(false);
      }
      catch (Exception)
      {
      }

      try
      {
        single = da.SingleRow(2);
        Debug.Assert(false);
      }
      catch (Exception)
      {
      }

      single = da.SingleRow(1);
      CheckRow(single);
    }

    private static void CheckRow(Dbo.ResultProc row)
    {
      Debug.Assert(row.ExtraProperty == null);
      Debug.Assert(row.Name != null);
      Debug.Assert(row.Date != null);
    }
  }
}
