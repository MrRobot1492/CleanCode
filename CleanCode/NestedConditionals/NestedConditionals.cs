using System;

namespace CleanCode.NestedConditionals
{
    //The more conditionals the code has
    //The more execution paths it has
    //Many combination to testing
    //I.
    //if (a)
    //{
    //    c = someValue;
    //}
    //else
    //{
    //    c = anotherValue;
    //}
    //c= (a)? someValue : anotherValue; //only once conditional per time

    //II.
    //if (a)
    //{
    //    b = true;
    //}
    //else
    //{
    //    b = false;
    //}
    //b= (a);

    //III.
    //if (a)
    //{
    //  if(b)
    //   {
    //     statement
    //   }
    //}
    //if(a && b)
    //{
    //    statement
    //}
    //if(!a || !b)
    //  return;
    //statement

    //IV.Combine
    //if (a)
    //{
    //    if (b)
    //    {
    //        isValid = true;
    //    }
    //} 
    //if (c)
    //{
    //    if (b)
    //    {
    //        isValid = true;
    //    }
    //}
    //if( b && (a || c) )
    //{
    //  isValid = true;
    //}
    //No go over the board
    //Code is clean is someone understand it

    //Move instance Method change the method to the Expert which belongs it
    //Create UNIT TESTS before to refactor the code

    public class Customer
    {
        public int LoyaltyPoints { get; set; }

        public bool IsGoldCustomer()
        {
            return this.LoyaltyPoints > 100;
        }
    }

    public class Reservation
    {
        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }

        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public void Cancel()
        {
            if (IsCancellationPeriodOver())
                throw new InvalidOperationException("It's too late to cancel.");
            IsCanceled = true;
        }

        private bool IsCancellationPeriodOver()
        {
            return (Customer.IsGoldCustomer() && LessThan(24))
                   || (!Customer.IsGoldCustomer() && LessThan(48));
        }

        private bool LessThan(int maxHours)
        {
            return ((From - DateTime.Now).TotalHours < maxHours);
        }
    }
}