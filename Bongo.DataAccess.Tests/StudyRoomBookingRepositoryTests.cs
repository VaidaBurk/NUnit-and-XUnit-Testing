using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.DataAccess
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking studyRoomBooking_one;
        private StudyRoomBooking studyRoomBooking_two;
        private DbContextOptions<ApplicationDbContext> options;

        public StudyRoomBookingRepositoryTests()
        {
            studyRoomBooking_one = new StudyRoomBooking()
            {
                FirstName = "Ben1",
                LastName = "Spark1",
                Date = new DateTime(2023, 1, 1),
                Email = "ben1@gmail.coom",
                BookingId = 11,
                StudyRoomId = 1
            };

            studyRoomBooking_two = new StudyRoomBooking()
            {
                FirstName = "Ben2",
                LastName = "Spark2",
                Date = new DateTime(2023, 2, 2),
                Email = "ben2@gmail.coom",
                BookingId = 22,
                StudyRoomId = 2
            };
        }

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;
        }

        [Test]
        [Order(1)]
        public void SaveBooking_Booking_one_CheckTheValuesFromDatabase()
        {
            //arrange
            //var options moved to setup

            //act
            using(var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_one);
            }

            //assert
            using (var context = new ApplicationDbContext(options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u=>u.BookingId == 11);
                Assert.AreEqual(studyRoomBooking_one.FirstName, bookingFromDb.FirstName);
                Assert.AreEqual(studyRoomBooking_one.LastName, bookingFromDb.LastName);
                Assert.AreEqual(studyRoomBooking_one.Date, bookingFromDb.Date);
                Assert.AreEqual(studyRoomBooking_one.Email, bookingFromDb.Email);
                Assert.AreEqual(studyRoomBooking_one.BookingId, bookingFromDb.BookingId);
                Assert.AreEqual(studyRoomBooking_one.StudyRoomId, bookingFromDb.StudyRoomId);
            }
        }

        [Test]
        [Order(2)]
        public void GetAllBooking_BookingOneAndTwo_CheckBothBookingsFromDatabase()
        {
            //arrange (options moved to setup)
            var expectedResult = new List<StudyRoomBooking> { studyRoomBooking_one, studyRoomBooking_two };

            using(var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureDeleted();
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_one);
                repository.Book(studyRoomBooking_two);
            }

            //act
            List<StudyRoomBooking> actualList;
            using(var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                actualList = repository.GetAll(null).ToList();
            }

            //assert
            CollectionAssert.AreEqual(expectedResult, actualList, new BookingCompare());
        }

        private class BookingCompare : IComparer
        {
            public int Compare(object x, object y)
            {
                var booking1 = (StudyRoomBooking)x;
                var booking2 = (StudyRoomBooking)y;

                if (booking1.BookingId != booking2.BookingId)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
