﻿using System;

namespace virtual_receptionist.Exceptions
{
    /// <summary>
    /// Adószám kivétel
    /// </summary>
    public class InvalidVATNumberException : Exception
    {
        #region Konstruktor

        /// <summary>
        /// Adószám kivétel
        /// </summary>
        /// <param name="message">Kivétel szövege</param>
        public InvalidVATNumberException(string message) : base(message)
        {
        }

        #endregion
    }
}