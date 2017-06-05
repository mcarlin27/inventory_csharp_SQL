using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Inventory
{
  public class Scarf
  {
    private int _id;
    private string _name;
    private int _year;
    private string _description;

    public Scarf(string Name, int Year, string Description)
    {
      _id = 0;
      _name = Name;
      _year = Year;
      _description = Description;
    }
    public override bool Equals(System.Object otherScarf)
    {
      if (!(otherScarf is Scarf))
      {
        return false;
      }
      else
      {
        Scarf newScarf = (Scarf) otherScarf;
        bool nameEquality = (this.GetName() == newScarf.GetName());
        return (nameEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetYear()
    {
      return _year;
    }
    public void SetYear(int newYear)
    {
      _year = newYear;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM scarves;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
    public static List<Scarf> GetAll()
    {
      List<Scarf> allScarves = new List<Scarf>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM scarves;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int scarfId = rdr.GetInt32(0);
        string scarfName = rdr.GetString(1);
        int scarfYear = rdr.GetInt32(2);
        string scarfDescription = rdr.GetString(3);
        Scarf newScarf = new Scarf(scarfName, scarfYear, scarfDescription);
        allScarves.Add(newScarf);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allScarves;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO scarves (name) OUTPUT INSERTED.id VALUES (@ScarfName);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ScarfName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

  }
}
