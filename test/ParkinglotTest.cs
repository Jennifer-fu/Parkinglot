using NUnit.Framework;

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

        [Test, ExpectedException(typeof(ParkinglotFullException))]
        public void should_return_null_when_parkinglot_is_full()
        {
            var parkinglot = new Parkinglot(1);
            parkinglot.Park(new Car());
            parkinglot.Park(new Car());
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

        [Test,ExpectedException(typeof(WrongTicketException))]
        public void should_not_pick_up_if_provide_a_wrong_ticket()
        {
            var parkinglot = new Parkinglot(1);
            var car = new Car();
            parkinglot.Park(car);

            parkinglot.PickUp(new Ticket());
        }
        
        [Test,ExpectedException(typeof(WrongTicketException))]
        public void should_return_null_when_pick_up_car_twice()
        {
            var parkinglot = new Parkinglot(1);
            var car = new Car();
            var ticket = parkinglot.Park(car);

            parkinglot.PickUp(ticket);
            parkinglot.PickUp(ticket);
        }

    }
}
