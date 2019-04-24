using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

public class SQLConnector : MonoBehaviour {

    private string agr = "B69804AB5EAD8441323343D62BB987D2E889ED321AE0FC2C91663ED5531F6E5A";
    MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
    MySqlConnection con;
    // Use this for initialization
    void Start () {
        SetupConData();
        if (CanConnectToAutenticationServer())
        {
            Debug.Log("yay");
            IsCorrectUser();
        }
        else
        {
            Debug.Log("ney");
        }

    }

   
    private void SetupConData ()
    {
        conn_string.Server = "127.0.0.1";
        conn_string.UserID = "root";
        conn_string.Password = "";
        conn_string.Database = "astero_online";

        con = new MySqlConnection(conn_string.ToString());
    }


    public bool CanConnectToAutenticationServer ()
    {
        try
        {
            Debug.Log("Establishing Connection");
            con.Open();
            Debug.Log("Can Connect to Autentication Server");
            con.Close();
            return true;

        }
        catch (Exception e)
        {
            Debug.Log("No connection to Authentication Server.");
            return false;
        }
    }
    public bool IsCorrectUser ()
    {
        con.Open();
        string sql = "SELECT * FROM `Account Name`";
        MySqlCommand cmd = new MySqlCommand(sql, con);
        using (MySqlDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                /* iterate once per row */
                Debug.Log(rdr.GetString(1));
            }
        }
        con.Close();
        return true;
    }
}
