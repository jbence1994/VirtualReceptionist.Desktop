﻿using virtual_receptionist.Model.Entity;
using virtual_receptionist.Exceptions;
using MySQL_Interface;

namespace virtual_receptionist.Model.Repository
{
    public partial class DataRepository
    {
        #region Metódusok

        /// <summary>
        /// Metódus, amely beállítja az adatbáziskapcsolódás típusát és autentikációt végez az alkalmazásba belépéskor
        /// </summary>
        /// <param name="accomodationID">Szálláshely azonosító</param>
        /// <param name="password">Regisztrációhoz tartozó jelszó</param>
        /// <param name="connectionType">Adatbáziskapcsolódás típusa</param>
        /// <returns>Egyezés esetén logikai igazzal tér vissza a függvény, ellenkező esetben logikai hamissal</returns>
        /// <exception cref="FailedLoginException"></exception>
        /// <exception cref="InvalidConnectionTypeException"></exception>
        public bool Authentication(string accomodationID, string password, string connectionType)
        {
            try
            {
                bool entry = false;
                database.SetConnection(connectionType);

                UploadAccomodationList();

                foreach (Accomodation account in accomodations)
                {
                    if (account.AccomodationID == accomodationID && account.Password == password)
                    {
                        entry = true;
                        break;
                    }

                    throw new FailedLoginException();
                }

                return entry;
            }
            catch (InvalidConnectionTypeException)
            {
                throw new InvalidConnectionTypeException();
            }
        }

        #endregion
    }
}