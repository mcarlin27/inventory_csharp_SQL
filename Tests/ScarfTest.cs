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
    // [Fact]
    // public void Test_Save_SavesToDatabase()
    // {
    //   //Arrange
    //   Scarf testScarf = new Scarf("RedDrum", 2016, "Fundraiser for drum");
    //
    //   //Act
    //   testScarf.Save();
    //   List<Scarf> result = Scarf.GetAll();
    //   List<Scarf> testList = new List<Scarf>{testScarf};
    //
    //   //Assert
    //   Assert.Equal(testList, result);
    // }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Scarf testScarf = new Scarf("RedDrum", 2016, "Fundraiser for drum");

      //Act
      testScarf.Save();
      Scarf savedScarf = Scarf.GetAll()[0];

      int result = savedScarf.GetId();
      int testId = testScarf.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
  }
}
