using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fluent.Entities;

namespace fluent
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    var customer = new Customer
                    {
                        Name = "Ahmadianhhffffffffffffff"

                    };
                

                    session.Save(customer);
                    
                    transaction.Commit();
                    Console.WriteLine("Customer Created: " + customer.Name + "\t" +
                                      customer.Id);
                }

                Console.ReadKey();
            }
        }
    }
}