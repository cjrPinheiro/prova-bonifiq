﻿namespace ProvaPub.Models
{
	public class Customer
	{
        public Customer()
        {

        }
        public Customer(string name)
        {

        }
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
