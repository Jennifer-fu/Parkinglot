using NUnit.Framework;

namespace ParkingLot
{
    [TestFixture]
    public class ParkingBoyTest
    {
        private ParkingBoy parkingBoy;

        [SetUp]
        public void SetUp()
        {
            parkingBoy = new ParkingBoy(new AnyNotFull());
        }

        [Test]
        public void should_return_ticket_when_park_car_to_parking_boy()
        {
            var parkinglot = new Parkinglot(1);
            parkingBoy.Manage(parkinglot);

            var ticket = parkingBoy.Park(new Car());

            Assert.IsNotNull(ticket);
        }

        [Test]
        public void should_return_null_if_all_managed_parkinglot_are_full()
        {
            parkingBoy.Manage(new Parkinglot(1));
            parkingBoy.Manage(new Parkinglot(1));
            parkingBoy.Park(new Car());
            parkingBoy.Park(new Car());
            var ticket = parkingBoy.Park(new Car());

            Assert.IsNull(ticket);
        }

        [Test]
        public void should_return_car_if_use_right_ticket()
        {
            parkingBoy.Manage(new Parkinglot(1));
            var car = new Car();
            var ticket = parkingBoy.Park(car);
            var pickCar = parkingBoy.PickUp(ticket);

            Assert.AreSame(car,pickCar);
        }

        [Test, ExpectedException(typeof(WrongTicketException))]
        public void should_not_pick_up_car_if_use_wrong_ticket()
        {
            parkingBoy.Manage(new Parkinglot(1));
            parkingBoy.Park(new Car());
            parkingBoy.PickUp(new Ticket());
        }
    }
}