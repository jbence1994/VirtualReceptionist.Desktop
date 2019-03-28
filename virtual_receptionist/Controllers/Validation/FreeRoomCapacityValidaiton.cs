﻿using virtual_receptionist.Controllers.Exceptions;
using virtual_receptionist.Repositories.Models;
using System.Collections.Generic;
using virtual_receptionist.Repositories;

namespace virtual_receptionist.Controllers.Validation
{
    /// <summary>
    /// Szabad szobakapacitás ellenőrző osztály
    /// </summary>
    public class FreeRoomCapacityValidaiton
    {
        #region Adattagok

        /// <summary>
        /// Szoba egyed
        /// </summary>
        private readonly Room room;

        /// <summary>
        /// Foglalás egyed
        /// </summary>
        private readonly Booking booking;

        /// <summary>
        /// 
        /// </summary>
        private readonly List<Booking> bookings;

        /// <summary>
        /// 
        /// </summary>
        private readonly BookingRepository repository;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Szabad szobakapacitás ellenőrző osztály konstruktora
        /// </summary>
        /// <param name="room"></param>
        /// <param name="booking"></param>
        public FreeRoomCapacityValidaiton(Room room, Booking booking)
        {
            this.room = room;
            this.booking = booking;

            repository = new BookingRepository();
            bookings = repository.GetBookings();
        }

        #endregion

        #region Metódusok

        /// <summary>
        /// Szabad szobakapcitást ellenőrző metódus adott napon
        /// </summary>
        public void ValidateFreeRoomCapacityOnSpecifiedArrivalDate()
        {
            foreach (Booking booking in bookings)
            {
                if (booking.ArrivalDate == this.booking.ArrivalDate && booking.Room.Number == this.booking.Room.Number)
                {
                    throw new InvalidFreeRoomCapacityException();
                }
            }
        }

        #endregion
    }
}