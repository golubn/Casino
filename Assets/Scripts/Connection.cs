using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using System;


public class Connection : MonoBehaviour
{
    private static string path = @"C:\Users\Admin\source\CasinoUnity\Assets\StreamingAssets\DataBaseCasino.bytes";
    private static SqliteConnection dbconnection = new SqliteConnection("Data Source=" + path);
    public static void CloseBd()
    {
        dbconnection.Close();
    }

    public void SetConnection()
    {
        dbconnection.Open();

        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand command = dbconnection.CreateCommand();
            command.Connection = dbconnection;
            command.CommandText = "SELECT * FROM Player";
            SqliteDataReader r = command.ExecuteReader();
            while (r.Read())
                Debug.Log(String.Format("{0} {1} {2} {3}", r[0], r[1], r[2], r[3]));
        }
        else
        {
            Debug.Log("fuck");
        }
        dbconnection.Close();
    }
    public static void AddPlayer(string login, string password)
    {
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand command = dbconnection.CreateCommand();
            command.Connection = dbconnection;
            command.CommandText = "INSERT INTO Player (Login, Password, TotalPlayerBalance) VALUES (@login, @password, 50)";
            command.Parameters.Add(new SqliteParameter("@login", login));
            command.Parameters.Add(new SqliteParameter("@password", password));
        }
        else
        {
            Debug.Log("fuck add");
        }
        // dbconnection.Close();
    }

    public void UpdatePlayer()
    {

        string sqlExpression = "UPDATE Player SET Password='Update' WHERE Login='Maxim'";
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand command = new SqliteCommand(sqlExpression, dbconnection);
            int number = command.ExecuteNonQuery();
            Debug.Log($"В таблицу Player обновила игрока штук: {number}");
        }
        else
        {
            Debug.Log("fuck update");
        }
        dbconnection.Close();
    }
    public static string LoadData(string login, string password)
    {
        string sqlExpression = "SELECT Login,Password FROM Player WHERE Login='@login' AND Password = '@password'";
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand command = new SqliteCommand(sqlExpression, dbconnection);
            int number = command.ExecuteNonQuery();
            SqliteDataReader r = command.ExecuteReader();
            Debug.Log($"В таблицу Player таких игроков найдено: {number}");
            //dbconnection.Close();
            return String.Format("{0} {1} {2} {3}", r[0], r[1], r[2], r[3]);

        }
        else
        {
            Debug.Log("fuck loaddata");
            //dbconnection.Close();
            return "99";
        }

    }
    public void DeletePlayer()
    {

        string sqlExpression = "DELETE  FROM Player WHERE Login='Maxim'";
        dbconnection.Open();
        if (dbconnection.State == ConnectionState.Open)
        {
            SqliteCommand command = new SqliteCommand(sqlExpression, dbconnection);
            int number = command.ExecuteNonQuery();
            Debug.Log($"В таблице Player  удалила игрока: {number}");
        }
        else
        {
            Debug.Log("fuck delete");
        }
        dbconnection.Close();
    }

    public static string GetUserByLogin(string login)
    {
        dbconnection.Open();
        try
        {
            SqliteCommand command = dbconnection.CreateCommand();
            command.Connection = dbconnection;
            command.CommandText = "SELECT * FROM Player WHERE Login=@login";

            command.Parameters.Add(new SqliteParameter("@login", login));
            SqliteDataReader r = command.ExecuteReader();
            if (r.Read())
            {
                Debug.Log(String.Format("{0} {1} {2} {3}", r[0], r[1], r[2], r[3]));
                dbconnection.Close();
                return String.Format("{0} {1} {2} {3}", r[0], r[1], r[2], r[3]);
            }
            else { dbconnection.Close(); return null; }

        }
        catch (Exception ex)
        {
            dbconnection.Close();
            Debug.Log(ex.Message);
            return ex.Message;
        }

    }
    public static string GetLogin(string login)
    {
        dbconnection.Open();
        try
        {
            SqliteCommand command = dbconnection.CreateCommand();
            command.Connection = dbconnection;

            command.CommandText = "SELECT * FROM Player WHERE Login=@login";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqliteParameter("@login", login));
            SqliteDataReader r = command.ExecuteReader();

            if (r.Read())
            {
                return Convert.ToString(r["Login"]);

            }
            else
            {
                return null;
            }

        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message + "error((");
            return ex.Message;
        }

    }
    public static string GetLoginForMenu()
    {
        dbconnection.Open();
        //SqliteCommand command = dbconnection.CreateCommand();
        //command.Connection = dbconnection;

        //command.CommandText = "SELECT * FROM Player WHERE Login=@login";
        //command.CommandType = CommandType.Text;

        //SqliteDataReader r = command.ExecuteReader();

        //if (r.Read())
        //{
        //    //return Convert.ToString(r["Login"]);
        //    return "sddddfsdfs";

        //}
        //else
        //{
        //    return null;
        //}
        return "fferfer";

    }
    public static string GetPassword(string login)
    {
        dbconnection.Open();
        try
        {
            SqliteCommand command = dbconnection.CreateCommand();
            command.Connection = dbconnection;

            command.CommandText = "SELECT * FROM Player WHERE Login=@login";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqliteParameter("@login", login));
            SqliteDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                return Convert.ToString(r["Password"]);
            }

            return null;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message + "error((");
            return ex.Message;
        }

    }

    public static decimal GetBalance(string login)
    {
        if (dbconnection.State != ConnectionState.Open)
        {
            dbconnection.Open();
        }

        try
        {

            SqliteCommand command = dbconnection.CreateCommand();
            command.Connection = dbconnection;
            command.CommandText = "SELECT * FROM Player WHERE Login=@login";

            command.Parameters.Add(new SqliteParameter("@login", login));

            SqliteDataReader r = command.ExecuteReader();

            if (r.Read())
            {
                return Convert.ToDecimal(r["TotalPlayerBalance"]);
            }
            else
            {
                //dbconnection.Close(); 
                return 0;
            }


        }
        catch (Exception ex)
        {

            //dbconnection.Close();
            Debug.Log(ex.Message);
            return 0;
        }


    }

    public static decimal GetBalanceForMenu()
    {
        if (dbconnection.State != ConnectionState.Open)
        {
            dbconnection.Open();
        }

            SqliteCommand command = dbconnection.CreateCommand();
            command.Connection = dbconnection;
            command.CommandText = "SELECT * FROM Player WHERE Login=@login";

            SqliteDataReader r = command.ExecuteReader();

            if (r.Read())
            {
                return Convert.ToDecimal(r["TotalPlayerBalance"]);
            }
            else
            {
                return 0;
            }

    }
    public static decimal UpdateBalance(decimal balance, decimal bet, bool winOrNot, string login)
    {
        decimal newbalance = 0;
        if (winOrNot)
        {
            newbalance = balance + bet;
        }
        else
        {
            newbalance = balance - bet;
        }
        if (dbconnection.State != ConnectionState.Open)
        {
            Debug.Log(dbconnection.State);
            dbconnection.Open();
        }

        try
        {
            SqliteCommand command = dbconnection.CreateCommand();
            command.Connection = dbconnection;
            command.CommandText = "UPDATE Player SET TotalPlayerBalance=@newbalance WHERE Login=@login";

            command.Parameters.Add(new SqliteParameter("@login", login));
            command.Parameters.Add(new SqliteParameter("@newbalance", newbalance));
            int resault = command.ExecuteNonQuery();
            //dbconnection.Close();
            return resault;
        }
        catch (Exception ex)
        {
            //dbconnection.Close();
            Debug.LogException(ex);
            return 0;
        }

    }

}
