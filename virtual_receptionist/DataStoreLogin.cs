﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace virtual_receptionist
{
    public partial class DataStore
    {
        #region Belépési folyamatot vezérlő és ellenőrző metódusok

        /// <summary>
        /// Metódus, amely ellenőrzi van-e felhasználói fiók létrehozva
        /// </summary>
        /// <returns>Ha van felhasználói fiók logikai true-val tér vissza, ellenkező esetben logikai false-szal tér vissza</returns>
        public bool IsAnyAccountExist()
        {
            bool existAnyAccount = false;

            Dictionary<string, string> account = new Dictionary<string, string>();

            string username = string.Empty;
            string password = string.Empty;

            mySqlConnection.Open();
            Debug.WriteLine("Sikeres adatbázis kapcsolódás...");

            mySqlCommand = new MySqlCommand()
            {
                CommandText = "SELECT * FROM account",
                Connection = mySqlConnection
            };

            mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                username = mySqlDataReader["username"].ToString();
                password = mySqlDataReader["password"].ToString();
                account.Add(username, password);
            }

            mySqlDataReader.Close();
            Debug.WriteLine("MySqlDataReader olvasás sikeresen befejeződött...");

            if (account.Count != 0)
            {
                existAnyAccount = true;
            }

            mySqlConnection.Close();
            Debug.WriteLine("Adatbázis kapcsolat sikeresen lezárult...");

            return existAnyAccount;
        }
        /// <summary>
        /// Metódus, amely összehasonlítja a felhasználó által megadott felhasználónevet és jelszót, egyezik-e az érvényes, előre regisztrált felhasználói fiókkal
        /// </summary>
        /// <param name="username">Felhasználó által megadott felhasználónév</param>
        /// <param name="password">Felhasználó által megadott jelszó</param>
        /// <param name="usernameTableField">Felhasználónevet tartalmazó mező neve</param>
        /// <param name="passwordTableField">Jelszót tartalmazó mező neve</param>
        /// <returns>Egyezés esetén logikai igazzal tér vissza a függvény, ellenkező esetben logikai hamissal</returns>
        public bool Authentication(string username, string password, string usernameTableField, string passwordTableField)
        {
            bool validEntry = false;

            mySqlConnection.Open();
            Debug.WriteLine("Sikeres adatbázis kapcsolódás...");

            mySqlDataReader = mySqlCommand.ExecuteReader();
            Debug.WriteLine("MySqlDataReader olvasás sikeresen elindult...");

            while (mySqlDataReader.Read())
            {
                string validUsername = string.Empty;
                string validPassword = string.Empty;

                validUsername = mySqlDataReader[usernameTableField].ToString();
                validPassword = mySqlDataReader[passwordTableField].ToString();

                if (username == validUsername && password == validPassword)
                {
                    validEntry = true;
                    break;
                }
            }

            mySqlDataReader.Close();
            Debug.WriteLine("MySqlDataReader olvasás sikeresen befejeződött...");

            mySqlConnection.Close();
            Debug.WriteLine("Adatbázis kapcsolat sikeresen lezárult...");

            return validEntry;
        }

        #endregion
    }
}
