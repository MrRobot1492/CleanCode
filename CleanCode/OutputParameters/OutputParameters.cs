using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    //AVOID OUT PARAMETERS,
    //USE SPECIFIC CLASS INSTEAD
    public class GetCustomersResult
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int TotalCount { get; set; }
    }

    public class OutputParameters
    {
        public void DisplayCustomers()
        {
            const int pageIndex = 1;
            var result = GetCustomers(pageIndex: pageIndex);
            Console.WriteLine("Total customers: " + result.TotalCount);
            foreach (var customer in result.Customers)
                Console.WriteLine(customer);
        }

        public GetCustomersResult GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomersResult
            {
                Customers = (IEnumerable<Customer>) new List<Customer>(),
                TotalCount = totalCount
            };
        }
    }
}