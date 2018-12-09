﻿using System;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace virtual_receptionist
{
    /// <summary>
    /// Adatbázis konfigurációra szolgáló ablak
    /// </summary>
    public partial class FormDatabaseConfiguration : Form
    {
        #region Adattagok

        /// <summary>
        /// XmlTextReader osztály egy példánya
        /// </summary>
        private XmlTextReader xmlTextReader;
        /// <summary>
        /// StreamReader osztály egy példánya
        /// </summary>
        private StreamReader streamReader;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Adatbázis konfigurációra szolgáló ablak konstruktora
        /// </summary>
        public FormDatabaseConfiguration()
        {
            InitializeComponent();
            xmlTextReader = new XmlTextReader("dbconfig.xml");
            streamReader = new StreamReader("dbconfig.txt");
        }

        #endregion

        #region UI események

        private void FormDatabaseConfiguration_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxConnectionType.SelectedIndex)
            {
                case 1:
                    ProcessTxtFile();
                    break;
                case 2:
                    ProcessXMLFile();
                    break;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Metódusok

        private void ProcessTxtFile()
        {
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                try
                {
                    string[] config = line.Split(';');
                    textBoxServer.Text = config[0];
                    textBoxDatabase.Text = config[1];
                    textBoxUsername.Text = config[2];
                    textBoxPassword.Text = config[3];
                    textBoxPort.Text = config[4];
                }
                catch (IOException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessXMLFile()
        {
            throw new NotImplementedException();
        }

        private void SetLocalDatabasePath()
        {
            throw new NotImplementedException();
        }

        private void SetRemoteDatabasePath()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
