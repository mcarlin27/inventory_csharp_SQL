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

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Scarf testScarf = new Scarf("RedDrum", 2016, "Fundraiser for drum");

      //Act
      testScarf.Save();
      List<Scarf> result = Scarf.GetAll();
      List<Scarf> testList = new List<Scarf>{testScarf};

      //Assert
      Assert.Equal(testList[0], result[0]);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Scarf testScarf = new Scarf("RedDrum", 2016, "Fundraiser for drum");

      //Act
      testScarf.Save();
      int testId = testScarf.GetId();

      // Console.WriteLine(Scarf.GetAll()[0].GetId());
      int savedScarfId = Scarf.GetAll()[0].GetId();
      Console.WriteLine("after getAll"+Scarf.GetAll()[0].GetName());
      Console.WriteLine("after getAll"+Scarf.GetAll()[0].GetId());
      Console.WriteLine("after getAll"+Scarf.GetAll()[0].GetDescription());

      // int result = savedScarf.GetId();

      //Assert
      Assert.Equal(testId, savedScarfId);
    }
    public void Dispose()
    {
      Scarf.DeleteAll();
    }
  }
}
