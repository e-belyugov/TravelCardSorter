using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelCardSorter.Domain
{
    /// <summary>
    /// Сортировщик карточек
    /// </summary>
    public class TravelCardSorter
    {
        // Словарь карточек с ключом по пункту отправления
        private readonly Dictionary<string, string> _cardsDeparture = new Dictionary<string, string>();

        // Словарь карточек с ключом по пункту назначения
        private readonly Dictionary<string, string> _cardsDestination = new Dictionary<string, string>();

        // Отсортированный список карточек
        private readonly List<TravelCard> _cardsSorted = new List<TravelCard>();

        // ----------------------------------------------------------------------------------

        // Сортировка карточек
        public IList<TravelCard> Sort(IList<TravelCard> travelCards)
        {
            // Проверка на null
            if (travelCards == null) throw new ArgumentNullException("Список карточек не инициализирован");
            
            // Проверка на пустой список карточек
            if (!travelCards.Any()) throw new EmptyListException("Пустой список для сортировки");

            // Заполнение словарей
            _cardsDeparture.Clear();
            _cardsDestination.Clear();
            foreach (var card in travelCards)
            {
                // Пункты назначения
                if (!_cardsDestination.ContainsKey(card.Destination))
                {
                    _cardsDestination.Add(card.Destination, card.Departure);
                }
                else
                {
                    throw new PointOfDestinationRepeatedException("Пункт назначения повторяется");
                }

                // Пункты отправления
                if (!_cardsDeparture.ContainsKey(card.Departure))
                {
                    _cardsDeparture.Add(card.Departure, card.Destination);
                }
                else
                {
                    throw new PointOfDepartureRepeatedException("Пункт отправления повторяется");
                }
            }
            
            // ----------------------------------------------------------------------------------

            // Поиск оконечных карточек
            TravelCard firstCard = null;
            TravelCard lastCard = null;
            foreach (var card in travelCards)
            {
                // Пункт отправления первой карточки не должен содержаться в словаре пунктов назначений
                string departure;
                if (!_cardsDestination.TryGetValue(card.Departure, out departure))
                {
                    if (firstCard != null)
                    {
                        throw new FirstCardNotOnlyOne("Первая карточка должна быть единственной в списке");
                    }
                    firstCard = card;
                };

                // Пункт назначения последней карточки не должен содержаться в словаре пунктов отправление
                string destination;
                if (!_cardsDeparture.TryGetValue(card.Destination, out destination))
                {
                    if (lastCard != null)
                    {
                        throw new LastCardNotOnlyOne("Последняя карточка должна быть единственной в списке");
                    }
                    lastCard = card;
                };
            }

            // Проверка оконечных карточек
            if (firstCard == null)
            {
                throw new FirstCardNotFound("Не найдена первая карточка");
            }
            if (lastCard == null)
            {
                throw new LastCardNotFound("Не найдена последняя карточка");
            }

            // ----------------------------------------------------------------------------------

            // Создание отсортированного списка

            // Добавление первой карточки
            _cardsSorted.Clear();
            _cardsSorted.Add(new TravelCard { Departure = firstCard.Departure, Destination = firstCard.Destination });

            // Цикл до последней карточки
            int index = 0;
            while (!_cardsSorted[index].Equals(lastCard))
            {
                // Текущая карточка
                TravelCard card = _cardsSorted[index];

                // Поиск следующей по цепочке карточки
                string destination;
                if (_cardsDeparture.TryGetValue(card.Destination, out destination))
                {
                    // Добавление следующей карточки
                    _cardsSorted.Add(new TravelCard { Departure = card.Destination, Destination = destination });
                    index++;
                }
            }

            // Возвращение отсортированного списка
            return _cardsSorted;
        }
    }
}
