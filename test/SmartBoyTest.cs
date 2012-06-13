﻿using NUnit.Framework;

namespace ParkingLot
{
    [TestFixture]
    public class SmartBoyTest
    {
        [Test]
        public void should_park_car_to_parking_lot_which_has_most_empty_positions()
        {
            var smartBoy = new SmartBoy();
            var parkinglot1 = new Parkinglot(1);
            smartBoy.Manage(parkinglot1);
            var parkinglot2 = new Parkinglot(2);
            smartBoy.Manage(parkinglot2);
            var ticket = smartBoy.Park(new Car());

            Assert.IsNotNull(ticket);
            Assert.AreEqual(1,parkinglot1.AvailablePosition());
            Assert.AreEqual(1,parkinglot2.AvailablePosition());
        }

        [Test]
        public void should_return_null_if_all_the_parkinglot_has_no_avalibale_positions()
        {
            var smartBoy = new SmartBoy();
            var parkinglot1 = new Parkinglot(0);
            smartBoy.Manage(parkinglot1);
            var parkinglot2 = new Parkinglot(0);
            smartBoy.Manage(parkinglot2);
            var ticket = smartBoy.Park(new Car());

            Assert.IsNull(ticket);
        }

        [Test]
        public void should_pick_up_cat_with_right_ticket()
        {
            var smartBoy = new SmartBoy();
            var parkinglot1 = new Parkinglot(1);
            smartBoy.Manage(parkinglot1);
            var car = new Car();
            var ticket = smartBoy.Park(car);
            var pickCar = smartBoy.PickUp(ticket);

            Assert.AreSame(car, pickCar);
        }

        [Test]
        public void should_return_null_if_use_wrong_ticket()
        {
            var smartBoy = new SmartBoy();
            var parkinglot1 = new Parkinglot(1);
            smartBoy.Manage(parkinglot1);
            var car = new Car();
            smartBoy.Park(car);
            var pickCar = smartBoy.PickUp(new Ticket());

            Assert.IsNull(pickCar);
        }

    }
}