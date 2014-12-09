using System;
using System.Collections.Generic;

namespace _01_Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        public Customer(string firstName, string middleName, string lastName,
            string address, string id, string phone, string email, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Address = address;
            this.Id = id;
            this.Phone = phone;
            this.Email = email;
            this.CustomerType = customerType;
            this.Payments = new List<Payment>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Id { get; private set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public CustomerType CustomerType { get; set; }

        public List<Payment> Payments { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName); }
        }

        public override bool Equals(object obj)
        {
            Customer otherCustomer = obj as Customer;

            if (otherCustomer == null)
            {
                return false;
            }

            if (this.FirstName != otherCustomer.FirstName)
            {
                return false;
            }

            if (this.MiddleName != otherCustomer.MiddleName)
            {
                return false;
            }

            if (this.LastName != otherCustomer.LastName)
            {
                return false;
            }

            if (this.Id != otherCustomer.Id)
            {
                return false;
            }

            if (this.Address != otherCustomer.Address)
            {
                return false;
            }

            if (this.Phone != otherCustomer.Phone)
            {
                return false;
            }

            if (this.Email != otherCustomer.Email)
            {
                return false;
            }

            if (!Equals(this.CustomerType, otherCustomer.CustomerType))
            {
                return false;
            }

            if (otherCustomer.Payments.Count != this.Payments.Count)
            {
                return false;
            }

            for (int i = 0; i < this.Payments.Count; i++)
            {
                if (!Equals(this.Payments[i], otherCustomer.Payments[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = (this.FirstName != null ? this.FirstName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.MiddleName != null ? this.MiddleName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.LastName != null ? this.LastName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.Address != null ? this.Address.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.Phone != null ? this.Phone.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.Email != null ? this.Email.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int) this.CustomerType;
            hashCode = (hashCode * 397) ^ (this.Payments != null ? this.Payments.GetHashCode() : 0);
            return hashCode;
        }

        public static bool operator ==(Customer customer, Customer otherCustomer)
        {
            return Equals(customer, otherCustomer);
        }

        public static bool operator !=(Customer customer, Customer otherCustomer)
        {
            return !Equals(customer, otherCustomer);
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Id: {1}, Address: {2}, Phone: {3}, Email: {4}, CustomerType: {5}",
                this.FullName, this.Id, this.Address, this.Phone, this.Email, this.CustomerType);
        }
        
        public int CompareTo(Customer otherCustomer)
        {
            if (this.FullName != otherCustomer.FullName)
            {
                return string.Compare(this.FullName, otherCustomer.FullName, StringComparison.InvariantCulture);
            }

            return string.Compare(this.Id, otherCustomer.Id, StringComparison.InvariantCulture);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Customer Clone()
        {
            List<Payment> payments = new List<Payment>();
            this.Payments.ForEach(x => payments.Add(x.Clone()));

            Customer result = new Customer(string.Copy(this.FirstName), string.Copy(this.MiddleName), string.Copy(this.LastName),
                string.Copy(this.Address), string.Copy(this.Id), string.Copy(this.Phone), string.Copy(this.Email), this.CustomerType)
            {
                Payments = payments
            };

            return result;
        }
    }
}
