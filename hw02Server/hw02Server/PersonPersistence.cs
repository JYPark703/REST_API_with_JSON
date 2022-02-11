using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hw02Server.Models;
using MySql.Data;
using System.Collections;
using System.Configuration;

namespace hw02Server
{
    public class PersonPersistence
    {


        public ArrayList getPerson()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

                ArrayList personArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                String sqlSting = "SELECT * FROM tblpersonnel";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlSting, conn);

                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    Person p = new Person();
                    p.ID = mySQLReader.GetInt32(0);
                    p.FirstName = mySQLReader.GetString(1);
                    p.LastName = mySQLReader.GetString(2);
                    p.PayRate = mySQLReader.GetDouble(3);
                    p.StartDate = mySQLReader.GetDateTime(4);
                    p.EndDate = mySQLReader.GetDateTime(5);
                    personArray.Add(p);
                }
                return personArray;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Person getPerson(long ID)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

                Person p = new Person();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                String sqlSting = "SELECT * FROM tblpersonnel WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlSting, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    p.ID = mySQLReader.GetInt32(0);
                    p.FirstName = mySQLReader.GetString(1);
                    p.LastName = mySQLReader.GetString(2);
                    p.PayRate = mySQLReader.GetDouble(3);
                    p.StartDate = mySQLReader.GetDateTime(4);
                    p.EndDate = mySQLReader.GetDateTime(5);
                    return p;
                }
                else
                {
                    return null;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;

            }
            finally
            {
                conn.Close();
            }
        }


        public bool deletePerson(long ID)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();
                Person p = new Person();
                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                String sqlSting = "SELECT * FROM tblpersonnel WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlSting, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();
                    sqlSting = "DELETE FROM tblpersonnel WHERE ID = " + ID.ToString();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlSting, conn);

                    cmd.ExecuteNonQuery();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;

            }
            finally
            {
                conn.Close();
            }
        }


        public bool updatePerson(long ID, Person personToSave)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

                String sqlSting = "SELECT * FROM tblpersonnel WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlSting, conn);

                mySQLReader = cmd.ExecuteReader();
                if (mySQLReader.Read())
                {
                    mySQLReader.Close();

                    sqlSting = "UPDATE tblpersonnel SET FirstName='" + personToSave.FirstName + "', LastName='" + personToSave.LastName + "', PayRate=" + personToSave.PayRate + ", StartDate='" + personToSave.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "', EndDate='" + personToSave.EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE ID = " + ID.ToString();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlSting, conn);
                    cmd.ExecuteNonQuery();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public long savePerson(Person personToSave)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

                String sqlString = "INSERT INTO tblpersonnel (FirstName, LastName, PayRate, StartDate, EndDate) VALUES ('" + personToSave.FirstName + "','" + personToSave.LastName + "'," + personToSave.PayRate + ",'" + personToSave.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + personToSave.EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}