using customersApi;

namespace CustomerApi
{
    public class CustomerRepository : ICustomerRepository
    {
        private static List<Customer> _customers = new()
        {
         new()
         {
             Name = "Ashwani Taneja",
                 Address = "as",
                 City = "Delhi",
                 email = "at@Gmail.com",
                 Phone = "0123456789"
         },
         new()
         {
              Name = "Ashwani 2",
                 Address = "as3",
                 City = "chd",
                 email = "a2@Gmail.com",
                 Phone = "1123456789"
         },
         new()
         {
             Name = "Ashwani 3",
                 Address = "as3",
                 City = "Hyderabad",
                 email = "a3@Gmail.com",
                 Phone = "2123456789"
         }
        };
        public List<Customer> GetCustomers() => _customers;
        public string DeleteCustomer(string email)
        {
            string response = "Customer do not exists";
            var customer = _customers.FirstOrDefault(s => s.email.ToLower() == email.ToLower());
            if (customer is not null)
            {
                _customers.Remove(customer);
                response = "Customer deleted successfully";
            }
            return response;
        }
        public string SaveCustomers(Customer customer)
        {            
            _customers.Add(customer);
            return "customer is saved successfully";
        }
        public Customer GetCustomer(string email) => _customers.FirstOrDefault(x => x.email.ToLower() == email.ToLower());

        public string UpdateCustomer(Customer customer)
        {
            string response = "Customer do not exists";
            var customerToUpdate = _customers.FirstOrDefault(x => x.email.ToLower() == customer.email.ToLower());
            if (customerToUpdate != null)
            {
                _customers.Remove(customerToUpdate);
                _customers.Add(customer);
                response = "Customer is updated";
            }
            return response;
        }

    }
}
