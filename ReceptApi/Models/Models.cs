namespace ReceptApi.Models
{
    public class Foetel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public int TimeMinutes { get; set; }
    }

    public class Leves
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public int TimeMinutes { get; set; }
    }

    public class Desszert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public int TimeMinutes { get; set; }
    }
}
