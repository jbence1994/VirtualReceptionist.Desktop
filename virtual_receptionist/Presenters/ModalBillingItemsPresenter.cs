﻿using System;
using System.Windows.Forms;

namespace virtual_receptionist.Presenter
{
    /// <summary>
    /// Számlázó modul tételek felvételéhez szükséges modális ablak prezentere
    /// </summary>
    public class ModalBillingItemsPresenter : DefaultPresenter
    {
        #region Adattagok

        /// <summary>
        /// Számlázási tételek táblázat
        /// </summary>
        private ListView listViewBillingItems;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Számlázó modul tételek felvételéhez szükséges modális ablak prezenter konstruktora
        /// </summary>
        /// <param name="listViewBillingItems">Számlázási tételek táblázat</param>
        public ModalBillingItemsPresenter(ListView listViewBillingItems)
        {
            this.listViewBillingItems = listViewBillingItems;
        }

        #endregion

        #region Számlázási tételek modális ablak nézetfrissítései

        /// <summary>
        /// 
        /// </summary>
        public void SetForm()
        {

        }

        #endregion
    }
}
