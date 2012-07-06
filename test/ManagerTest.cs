using NUnit.Framework;

namespace ParkingLot
{
    [TestFixture]
    public class ManagerTest
    {
        private Manager manager;

        [SetUp]
        public void SetUp()
        {
            manager = new Manager();
        }

        [Test]
        public void should_park_car_if_only_manage_parkinglot()
        {
            manager.Manage(new Parkinglot(1));
            var ticket = manager.Park(new Car());

            Assert.IsNotNull(ticket);
        }

        [Test]
        public void should_park_car_if_only_manage_parkingboy()
        {
            var parkingBoy = new ParkingBoy(new AnyNotFull());
            var parkinglot = new Parkinglot(1);
            parkingBoy.Manage(parkinglot);

            manager.Manage(parkingBoy);
            var ticket = manager.Park(new Car());

            Assert.IsNotNull(ticket);
        }

        [Test]
        public void should_park_car_if_manage_parkinglots_and_parkingboys()
        {
            var parkingBoy = new ParkingBoy(new AnyNotFull());
            var parkinglot = new Parkinglot(1);
            parkingBoy.Manage(parkinglot);

            manager.Manage(parkingBoy);
            manager.Manage(new Parkinglot(2));
            var ticket = manager.Park(new Car());

            Assert.IsNotNull(ticket);
        }

        [Test]
        public void manager_can_pick_up_car_with_right_ticket()
        {
            var parkingBoy = new ParkingBoy(new AnyNotFull());
            var parkinglot = new Parkinglot(1);
            parkingBoy.Manage(parkinglot);

            manager.Manage(parkingBoy);
            manager.Manage(new Parkinglot(2));
            var car = new Car();
            var ticket = manager.Park(car);
            var pickCar = manager.PickUp(ticket);

            Assert.AreSame(car,pickCar);
        }

        [Test,ExpectedException(typeof(WrongTicketException))]
        public void should_not_pick_up_car_with_wrong_ticket()
        {
            var parkingBoy = new ParkingBoy(new AnyNotFull());
            var parkinglot = new Parkinglot(1);
            parkingBoy.Manage(parkinglot);

            manager.Manage(parkingBoy);
            manager.Manage(new Parkinglot(2));
            var car = new Car();
            manager.Park(car);
            manager.PickUp(new Ticket());
        }
    }
}