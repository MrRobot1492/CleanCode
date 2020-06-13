using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace CleanCode.Comments
{
    //I.BAD COMMENTS 
    //Explain What's
    //Just set comments such really add value to the code
    //For instance:
    //Create a new connection to the database
    //var connection = new SqlConnection();
    //Do not comment the obvious
    //The code itself is the best comment, self explanatory
    //Do not comment version history, the Version Control System do that
    //Dead code, commented code is not required

    //II. GOOD COMMENTS Explain why's and how's
    //VS Summary Comments are only required in the case you are working with 
    //An external or HTML API such 3rd parties
    //TO DO are good comments
    //With you have some constraints, is a good Comment
    //Legacy reasons, 
    //problem with database
    //3rd party component with some problems

    //For the cases where a method make many operations, instead of set 
    //a comment for each operation, is better to generate a particular method
    //by setting the name as self descriptive as possible

    //1.DO NOT WRITE COMMENTS, RE WRITE YOUR CODE
    //2.DO NOT EXPLAIN 'WHATS' (Obvious)
    //3.EXPLAIN WHY's AND HOW's
    
    public class Comments
    {
        private int _payFrequency;
        private DbContext _dbContext;

        public Comments()
        {
            _dbContext = new DbContext();
        }

        public List<Customer> GetCustomers(int countryCode)
        {
            //TODO: We need to get rid of abcd once we revisit this method. Currently, it's 
            // creating a coupling betwen x and y and because of that we're not able to do 
            // xyz. 

            throw new NotImplementedException();
        }

        public void SubmitOrder(Order order)
        {
            SaveOrder(order);

            NotifyCustomer(order);
        }

        private void SaveOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        private static void NotifyCustomer(Order order)
        {
            var client = new SmtpClient();
            var message = new MailMessage("noreply@site.com", order.Customer.Email, "Your order was successfully placed.", ".");
            client.Send(message);
        }
    }

    public class DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public void SaveChanges()
        {


        }
    }

    public class DbSet<T>
    {
        public void Add(Order order)
        {


        }
    }
    public class Order
    {
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public string Email { get; set; }
    }
}
