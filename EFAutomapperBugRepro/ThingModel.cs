namespace EFAutomapperBugRepro
{
    public class ThingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public ThingTypeModel Type { get; set; }
    }

    public class ThingWithoutTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }
    }

    public class ThingTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}