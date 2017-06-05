using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory
{
  public class ScarfTest : IDisposable
  {
    public ScarfTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=inventory_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Scarf.DeleteAll();
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Scarf.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {
      //Arrange, Act
      Scarf firstScarf = new Scarf("RedDrum", 2016, "Fundraiser for drum");
      Scarf secondScarf = new Scarf("RedDrum", 2016, "Fundraiser for drum");

      //Assert
      Assert.Equal(firstScarf, secondScarf);
    }
  }
}
