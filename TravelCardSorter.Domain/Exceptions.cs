using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardSorter.Domain
{
    // Классы исключений для сортировки списка карточек путешественника

    public class TravelCardSortingException : Exception
    {
        public TravelCardSortingException()
        {
        }

        public TravelCardSortingException(string message)
            : base(message)
        {
        }

        public TravelCardSortingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class EmptyListException : TravelCardSortingException
    {
        public EmptyListException(string message)
            : base(message)
        {
        }
    }

    public class PointOfDestinationRepeatedException : TravelCardSortingException
    {
        public PointOfDestinationRepeatedException(string message)
            : base(message)
        {
        }
    }

    public class PointOfDepartureRepeatedException : TravelCardSortingException
    {
        public PointOfDepartureRepeatedException(string message)
            : base(message)
        {
        }
    }

    public class FirstCardNotOnlyOne : TravelCardSortingException
    {
        public FirstCardNotOnlyOne(string message)
            : base(message)
        {
        }
    }

    public class LastCardNotOnlyOne : TravelCardSortingException
    {
        public LastCardNotOnlyOne(string message)
            : base(message)
        {
        }
    }

    public class FirstCardNotFound : TravelCardSortingException
    {
        public FirstCardNotFound(string message)
            : base(message)
        {
        }
    }

    public class LastCardNotFound : TravelCardSortingException
    {
        public LastCardNotFound(string message)
            : base(message)
        {
        }
    }
}
