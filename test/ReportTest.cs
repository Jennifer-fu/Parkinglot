using NUnit.Framework;

namespace ParkingLot
{
    [TestFixture]
    public class ReportTest
    {
        [Test]
        public void parkinglot_should_print_its_avalibale_position()
        {
            var parkinglot = new Parkinglot(1);
            var report = parkinglot.Print(new Reporter(0));

            Assert.AreEqual("parkinglot: 1\r\n", report);
        }

        [Test]
        public void parkingboy_with_one_parkinglot_should_print_its_avaliable_position()
        {
            var parkingBoy = new ParkingBoy(new AnyNotFull());
            parkingBoy.Manage(new Parkinglot(1));
            var report = parkingBoy.Print(new Reporter(0));

            var expectedReport = "parkingboy:\r\n" +
                                 "	parkinglot: 1\r\n";
            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void parkingboy_with_multiple_parkinglots_should_print_its_avaliable_position()
        {
            var parkingBoy = new ParkingBoy(new AnyNotFull());
            parkingBoy.Manage(new Parkinglot(1));
            parkingBoy.Manage(new Parkinglot(2));
            var report = parkingBoy.Print(new Reporter(0));

            var expectedReport = "parkingboy:\r\n" +
                                 "	parkinglot: 1\r\n" +
                                 "	parkinglot: 2\r\n";
            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void manager_with_one_parking_lot_should_print_its_avaliable_position()
        {
            var manager = new Manager();
            manager.Manage(new Parkinglot(1));
            var report = manager.Print(new Reporter(0));

            var expectedReport = "manager:\r\n" +
                                 "	parkinglot: 1\r\n";
            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void manager_with_two_parking_lot_should_print_its_avaliable_position()
        {
            var manager = new Manager();
            manager.Manage(new Parkinglot(1));
            manager.Manage(new Parkinglot(2));
            var report = manager.Print(new Reporter(0));

            var expectedReport = "manager:\r\n" +
                                 "	parkinglot: 1\r\n" +
                                 "	parkinglot: 2\r\n";
            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void manager_with_two_parking_boys_should_print_its_avaliable_position()
        {
            var manager = new Manager();
            var parkingBoy1 = new ParkingBoy(new AnyNotFull());
            parkingBoy1.Manage(new Parkinglot(1));
            manager.Manage(parkingBoy1);

            var parkingBoy2 = new ParkingBoy(new MaxAvailableRate());
            parkingBoy2.Manage(new Parkinglot(2));
            parkingBoy2.Manage(new Parkinglot(3));
            manager.Manage(parkingBoy2);

            var report = manager.Print(new Reporter(0));
            var expectedReport = "manager:\r\n"
                                 + "	parkingboy:\r\n"
                                 + "		parkinglot: 1\r\n"
                                 + "	parkingboy:\r\n"
                                 + "		parkinglot: 2\r\n"
                                 + "		parkinglot: 3\r\n";
            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void managers_with_one_parkinglot_and_one_parking_boy_should_print_its_avaliable_position()
        {
            var manager = new Manager();
            manager.Manage(new Parkinglot(1));

            var parkingBoy = new ParkingBoy(new MaxAvailableRate());
            parkingBoy.Manage(new Parkinglot(2));
            manager.Manage(parkingBoy);

            var report = manager.Print(new Reporter(0));
            var expectedReport = "manager:\r\n"
                                 + "	parkinglot: 1\r\n"
                                 + "	parkingboy:\r\n"
                                 + "		parkinglot: 2\r\n";
            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void managers_with_two_parkinglots_and_two_parking_boys_should_print_its_avaliable_position()
        {
            var manager = new Manager();
            manager.Manage(new Parkinglot(1));
            manager.Manage(new Parkinglot(2));

            var parkingBoy = new ParkingBoy(new MaxAvailableRate());
            parkingBoy.Manage(new Parkinglot(2));
            manager.Manage(parkingBoy);

            var parkingBoy1 = new ParkingBoy(new MaxAvailableRate());
            parkingBoy1.Manage(new Parkinglot(2));
            parkingBoy1.Manage(new Parkinglot(3));
            manager.Manage(parkingBoy1);
            var report = manager.Print(new Reporter(0));
            var expectedReport = "manager:\r\n"
                                 + "	parkinglot: 1\r\n"
                                 + "	parkinglot: 2\r\n"
                                 + "	parkingboy:\r\n"
                                 + "		parkinglot: 2\r\n"
                                 + "	parkingboy:\r\n"
                                 + "		parkinglot: 2\r\n"
                                 + "		parkinglot: 3\r\n";
            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void managers_with_one_manager_should_print_its_avaliable_position()
        {
            var manager = new Manager();
            var manager1 = new Manager();
            manager1.Manage(new Parkinglot(1));
            manager1.Manage(new Parkinglot(2));

            var parkingBoy = new ParkingBoy(new MaxAvailableRate());
            parkingBoy.Manage(new Parkinglot(2));
            manager1.Manage(parkingBoy);

            var parkingBoy1 = new ParkingBoy(new MaxAvailableRate());
            parkingBoy1.Manage(new Parkinglot(2));
            parkingBoy1.Manage(new Parkinglot(3));
            manager1.Manage(parkingBoy1);

            manager.Manage(manager1);
            
            var report = manager.Print(new Reporter(0));
            var expectedReport = "manager:\r\n"
                                 + "	manager:\r\n"
                                 + "		parkinglot: 1\r\n"
                                 + "		parkinglot: 2\r\n"
                                 + "		parkingboy:\r\n"
                                 + "			parkinglot: 2\r\n"
                                 + "		parkingboy:\r\n"
                                 + "			parkinglot: 2\r\n"
                                 + "			parkinglot: 3\r\n";
            Assert.AreEqual(expectedReport, report);
        }

        [Test]
        public void manager_with_two_managers_should_print_its_avaliable_position()
        {
            var manager = new Manager();
            manager.Manage(new Manager());
            manager.Manage(new Manager());

            var report = manager.Print(new Reporter(0));

            var expectedReport = "manager:\r\n"
                                 + "	manager:\r\n"
                                 + "	manager:\r\n";

            Assert.AreEqual(expectedReport,report);
        }

        [Test]
        public void manager_with_manager_and_parkingboy_and_parkinglot_should_print_its_avaliable_position()
        {
            var manager = new Manager();
            var manager1 = new Manager();
            var parkingBoy = new ParkingBoy(new MaxAvailableRate());
            parkingBoy.Manage(new Parkinglot(1));
            manager1.Manage(parkingBoy);
            manager.Manage(manager1);

            var parkingBoy1 = new ParkingBoy(new AnyNotFull());
            parkingBoy1.Manage(new Parkinglot(2));
            manager.Manage(parkingBoy1);
            
            manager.Manage(new Parkinglot(3));

            var report = manager.Print(new Reporter(0));

            var expectedReport = "manager:\r\n"
                                 + "	manager:\r\n"
                                 + "		parkingboy:\r\n"
                                 + "			parkinglot: 1\r\n"
                                 + "	parkingboy:\r\n"
                                 + "		parkinglot: 2\r\n"
                                 + "	parkinglot: 3\r\n";
            Assert.AreEqual(expectedReport, report);
        }
    }
}