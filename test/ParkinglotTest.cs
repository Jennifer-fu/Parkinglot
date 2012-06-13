﻿using NUnit.Framework;

namespace ParkingLot
{
    [TestFixture]
    class ParkinglotTest
    {
        [Test]
        public void should_return_ticket_when_parking_car_successfully()
        {
            var parkinglot = new Parkinglot(1);
            
            var ticket = parkinglot.Park(new Car());

            Assert.IsNotNull(ticket);
        }

        [Test]
        public void should_return_car_when_use_right_ticket()
        {
            var parkinglot = new Parkinglot(1);
            var car = new Car();
            var ticket = parkinglot.Park(car);

            var pickedCar = parkinglot.PickUp(ticket);

            Assert.AreSame(pickedCar,car);
        }

        [Test]
        public void should_not_pick_up_if_provide_a_wrong_ticket()
        {
            var parkinglot = new Parkinglot(1);
            var car = new Car();
            parkinglot.Park(car);

            var pickedCar = parkinglot.PickUp(new Ticket());

            Assert.IsNull(pickedCar);
        }
        
        [Test]
        public void should_return_null_when_pick_up_car_twice()
        {
            var parkinglot = new Parkinglot(1);
            var car = new Car();
            var ticket = parkinglot.Park(car);

            parkinglot.PickUp(ticket);
            var pickedCar = parkinglot.PickUp(ticket);

            Assert.IsNull(pickedCar);
        }

    }
}