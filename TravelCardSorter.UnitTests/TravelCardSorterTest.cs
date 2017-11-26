using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelCardSorter.Domain;

namespace TravelCardSorter.UnitTests
{
    [TestClass]
    public class TravelCardSorterTest
    {
        // Сортировка небольшого списка
        [TestMethod]
        public void SortingShortCorrectList()
        {
            // Arrange
            var cards = new List<TravelCard>
            {
                new TravelCard {Departure = "Москва", Destination = "Париж"},
                new TravelCard {Departure = "Мельбурн", Destination = "Кельн"},
                new TravelCard {Departure = "Кельн", Destination = "Москва"}
            };
            var cardSorter = new TravelCardSorter.Domain.TravelCardSorter();

            // Act
            var cardsSorted = cardSorter.Sort(cards);

            // Assert
            var cardToAssert = new List<TravelCard>
            {
                new TravelCard {Departure = "Мельбурн", Destination = "Кельн"},
                new TravelCard {Departure = "Кельн", Destination = "Москва"},
                new TravelCard {Departure = "Москва", Destination = "Париж"}
            };
            CollectionAssert.AreEqual((List<TravelCard>)cardsSorted, cardToAssert);
        }

        // ----------------------------------------------------------------------------------

        // Сортировка большего списка
        [TestMethod]
        public void SortingLongerCorrectList()
        {
            // Arrange
            var cards = new List<TravelCard>
            {
                new TravelCard {Departure = "Саратов", Destination = "Омск"},
                new TravelCard {Departure = "Челябинск", Destination = "Казань"},
                new TravelCard {Departure = "Омск", Destination = "Тюмень"},
                new TravelCard {Departure = "Казань", Destination = "Саратов"},
                new TravelCard {Departure = "Тюмень", Destination = "Тобольск"},
                new TravelCard {Departure = "Екатеринбург", Destination = "Челябинск"}
            };
            var cardSorter = new TravelCardSorter.Domain.TravelCardSorter();

            // Act
            var cardsSorted = cardSorter.Sort(cards);

            // Assert
            var cardToAssert = new List<TravelCard>
            {
                new TravelCard {Departure = "Екатеринбург", Destination = "Челябинск"},
                new TravelCard {Departure = "Челябинск", Destination = "Казань"},
                new TravelCard {Departure = "Казань", Destination = "Саратов"},
                new TravelCard {Departure = "Саратов", Destination = "Омск"},
                new TravelCard {Departure = "Омск", Destination = "Тюмень"},
                new TravelCard {Departure = "Тюмень", Destination = "Тобольск"}
            };
            CollectionAssert.AreEqual((List<TravelCard>)cardsSorted, cardToAssert);
        }

        // ----------------------------------------------------------------------------------

        // Сортировка пустого списка
        [ExpectedException(typeof(EmptyListException))]
        [TestMethod]
        public void SortingEmptyList()
        {
            // Arrange
            var cards = new List<TravelCard>();
            var cardSorter = new TravelCardSorter.Domain.TravelCardSorter();

            // Act
            var cardsSorted = cardSorter.Sort(cards);

            // Assert
        }

        // ----------------------------------------------------------------------------------

        // Сортировка списка с повторением
        [ExpectedException(typeof(PointOfDepartureRepeatedException))]
        [TestMethod]
        public void SortingDepartureRepeatedList()
        {
            // Arrange
            var cards = new List<TravelCard>
            {
                new TravelCard {Departure = "Саратов", Destination = "Омск"},
                new TravelCard {Departure = "Челябинск", Destination = "Казань"},
                new TravelCard {Departure = "Омск", Destination = "Тюмень"},
                new TravelCard {Departure = "Челябинск", Destination = "Саратов"},
                new TravelCard {Departure = "Тюмень", Destination = "Тобольск"},
                new TravelCard {Departure = "Екатеринбург", Destination = "Челябинск"}
            };
            var cardSorter = new TravelCardSorter.Domain.TravelCardSorter();

            // Act
            var cardsSorted = cardSorter.Sort(cards);

            // Assert
        }

        // ----------------------------------------------------------------------------------

        // Сортировка списка с дублированием последней карточки
        [ExpectedException(typeof(LastCardNotOnlyOne))]
        [TestMethod]
        public void SortingLastCardRepeatedList()
        {
            // Arrange
            var cards = new List<TravelCard>
            {
                new TravelCard {Departure = "Саратов", Destination = "Омск"},
                new TravelCard {Departure = "Челябинск", Destination = "Казань"},
                new TravelCard {Departure = "Омск", Destination = "Тюмень"},
                new TravelCard {Departure = "Казань", Destination = "Иркутск"},
                new TravelCard {Departure = "Тюмень", Destination = "Тобольск"},
                new TravelCard {Departure = "Екатеринбург", Destination = "Челябинск"}
            };
            var cardSorter = new TravelCardSorter.Domain.TravelCardSorter();

            // Act
            var cardsSorted = cardSorter.Sort(cards);

            // Assert
        }

        // ----------------------------------------------------------------------------------

        // Сортировка списка без первой карточки
        [ExpectedException(typeof(FirstCardNotFound))]
        [TestMethod]
        public void SortingNoFirstCardList()
        {
            // Arrange
            var cards = new List<TravelCard>
            {
                new TravelCard {Departure = "Саратов", Destination = "Омск"},
                new TravelCard {Departure = "Омск", Destination = "Тюмень"},
                new TravelCard {Departure = "Казань", Destination = "Саратов"},
                new TravelCard {Departure = "Тюмень", Destination = "Казань"}
            };
            var cardSorter = new TravelCardSorter.Domain.TravelCardSorter();

            // Act
            var cardsSorted = cardSorter.Sort(cards);

            // Assert
        }
    }
}
