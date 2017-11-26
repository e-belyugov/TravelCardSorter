using System;

namespace TravelCardSorter.Domain
{
    /// <summary>
    /// Карточка путешественника
    /// </summary>
    public class TravelCard
    {
        /// <summary>
        /// Пункт отправления
        /// </summary>
        public string Departure { get; set; }

        /// <summary>
        /// Пункт назначения
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Проверка на равенство двух карточек
        /// </summary>
        public override bool Equals(Object obj)
        {
            TravelCard other = obj as TravelCard;
            if (other == null)
                return false;

            return Departure == other.Departure && Destination == other.Destination;
        }

        ///// <summary>
        /// Переопределение хэш-кода
        /// </summary>
        public override int GetHashCode()
        {
            return Departure.GetHashCode() ^ Destination.GetHashCode();
        }    
    }
}
