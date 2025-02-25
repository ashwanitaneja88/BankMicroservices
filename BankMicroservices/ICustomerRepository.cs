using customersApi;

namespace CustomerApi
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomers();
        public string DeleteCustomer(string email);
        public string SaveCustomers(Customer customer);
        public Customer GetCustomer(string email);
        public string UpdateCustomer(Customer customer);

    }
}
