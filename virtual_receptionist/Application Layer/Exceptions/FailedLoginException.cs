﻿using System;

namespace virtual_receptionist.ApplicationLayer.Exceptions
{
    /// <summary>
    /// Bejelentkezés kivétel
    /// </summary>
    public class FailedLoginException : Exception
    {
        #region Konstruktor

        /// <summary>
        /// Bejelentkezés kivétel
        /// </summary>
        public FailedLoginException() : base("Sikertelen bejelentkezés!\nHibás szálláshely azonosító vagy jelszó!")
        {
        }

        #endregion
    }
}
