using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class ServerConnect : MonoBehaviour
{
    public Text testText;
    // Start is called before the first frame update
    void Start()
    {
        DataTable dt = Select("SELECT * FROM [dbo].[Accounts]");

        for(int i = 0; i < dt.Rows.Count; i++)
        {
            testText.text += dt.Rows[i][0] + "|" + dt.Rows[i][1] + "\n";
        }
    }

    public DataTable Select(string selectSQL)
    {
        DataTable dataTable = new DataTable("dataBase");
        SqlConnection sqlConnection = new SqlConnection(@"server=DESKTOP-LFGSKN7\SQLEXPRESS01;Trusted_Connection=Yes;DataBase=Grade Zero;");
        sqlConnection.Open();

        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = selectSQL;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        sqlDataAdapter.Fill(dataTable);
        return dataTable;
    }
}
