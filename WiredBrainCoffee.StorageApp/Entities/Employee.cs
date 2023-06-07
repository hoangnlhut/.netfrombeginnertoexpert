﻿namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Employee : BaseClass
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, FirstName: {FirstName}, LastName: {LastName}";
        }
    }
}
