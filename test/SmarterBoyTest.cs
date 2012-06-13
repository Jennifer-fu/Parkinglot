using NUnit.Framework;
using ParkingLot.src;

namespace ParkingLot
{
    [TestFixture]
    public class SmarterBoyTest
    {
        private ParkingBoy smarterBoy;

        [SetUp]
        public void SetUp()
        {
            smarterBoy = new ParkingBoy(new MaxAvailableRate());
        }

        [Test]
        public void should_park_car_to_parkinglot_which_has_max_avaliable_position_rate()
        {
            var parkinglot1 = new Parkinglot(3);
            parkinglot1.Park(new Car());
            parkinglot1.Park(new Car());
            smarterBoy.Manage(parkinglot1);
            
            var parkinglot2 = new Parkinglot(2);
            parkinglot2.Park(new Car());
            smarterBoy.Manage(parkinglot2);
            
            var ticket = smarterBoy.Park(new Car());

            Assert.IsNotNull(ticket);
            Assert.AreEqual(1, parkinglot1.AvailablePosition());
            Assert.AreEqual(0, parkinglot2.AvailablePosition());
        }

        [Test]
        public void should_return_null_if_all_parkinglot_are_full()
        {
            var parkinglot1 = new Parkinglot(0);
            smarterBoy.Manage(parkinglot1);
            var parkinglot2 = new Parkinglot(0);
            smarterBoy.Manage(parkinglot2);
            var ticket = smarterBoy.Park(new Car());

            Assert.IsNull(ticket);
        }

        [Test]
        public void should_pick_up_car_with_right_ticket()
        {
            var parkinglot = new Parkinglot(1);
            smarterBoy.Manage(parkinglot);
            var car = new Car();
            var ticket = smarterBoy.Park(car);
            var pickCar = smarterBoy.PickUp(ticket);

            Assert.AreSame(car, pickCar);           
        }
    }
}