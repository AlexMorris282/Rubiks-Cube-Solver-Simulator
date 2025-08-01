using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using ADOX;

namespace WindowsFormsApp1
{
    class DataBase
    {

        private const string name = "Database.mdb";
        private const string ConnectionString = @"Provider = Microsoft Jet 4.0 OLE DB Provider;Data Source = Database.mdb;";
        string user; 
        string pass;
        string file;
        char[,,] faces;

        public DataBase(string x, string y, string z, char[,,] c)
        {
            user = x;
            pass = y;
            file = z;
            faces = c;
            CreateDataBase();
            InsertData();
        }

        private void CreateDataBase()
        {
            CatalogClass cat = new CatalogClass();

            if (!File.Exists(name))
            {
                cat.Create(ConnectionString);
                CreateTable();
            }
            cat = null;
        }

        public void ExecuteSQL(string SQLstring)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand(SQLstring))
                {
                    command.Connection = connection;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        if (file.Substring(file.Length - 4, 4) == ".txt")
                        {
                            Rotations.SaveCubeToFile(faces, file + ".txt");
                        }
                        else
                        {
                            Rotations.SaveCubeToFile(faces, file + ".txt");
                        }
                        MessageBox.Show("Saved successfully");
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "The changes you requested to the table were not successful because they would create duplicate values in the index, primary key," +
                            " or relationship.  Change the data in the field or fields that contain duplicate data, remove the index, or redefine the index to permit duplicate" +
                            " entries and try again.")
                        {
                            MessageBox.Show("That username is already taken");
                        }
                    }
                }
            }
        }

        private void CreateTable()
        {
            string SQLstring;

            SQLstring = "CREATE TABLE PersonDetails("
                + "UserName VARCHAR(25),"
                + "pWord VARCHAR(20),"
                + "Filename VARCHAR(15),"
                + "PRIMARY KEY(UserName)"
                + ")";

            ExecuteSQL(SQLstring);
        }

        private void InsertData()
        {

            string SQLstring = "INSERT INTO PersonDetails(UserName, pWord, Filename) " + "Values('" + user + "','" + pass + "','" + file + "')";
            ExecuteSQL(SQLstring);

        }

    }
}
