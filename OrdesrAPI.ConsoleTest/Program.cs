using OrdersAPI.Domain;
using OrdersAPI.Repositories;



namespace OrdesrAPI.ConsoleTest

{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintCustomers();

            Customer customerToInsert = new Customer();

            Console.WriteLine("Insira um utilizador;");
            Console.Write("Nome: ");
            customerToInsert.Name = Console.ReadLine();
            Console.Write("Nif: ");
            customerToInsert.Nif = Console.ReadLine();
            Console.Write("Email: ");
            customerToInsert.Email = Console.ReadLine();
            Console.Write("Phone: ");
            customerToInsert.Phone = Console.ReadLine();

            CustomerRepository.Insert(customerToInsert);

            PrintCustomers();

            Console.WriteLine("Atulize um utilizador;");
            Console.Write("Id: ");
            customerToInsert.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nome: ");
            customerToInsert.Name = Console.ReadLine();
            Console.Write("Nif: ");
            customerToInsert.Nif = Console.ReadLine();
            Console.Write("Email: ");
            customerToInsert.Email = Console.ReadLine();
            Console.Write("Phone: ");
            customerToInsert.Phone = Console.ReadLine();

            CustomerRepository.Update(customerToInsert);

            PrintCustomers();

            Console.WriteLine("Elimine um utilizador;");
            Console.Write("Id: ");
            int id = Convert.ToInt32 (Console.ReadLine());

            CustomerRepository.Delete(id);

            PrintCustomers();

        }
    
        public static void PrintCustomers()
        {


            List<Customer> customers = CustomerRepository.Select();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);

            }

        }
    }
}
