namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Organization : BaseClass
    {
        public string? Name { get; set; }
        public override string ToString()
        {
            return $"Id : {Id}, Name: {Name}";
        }
    }
}
