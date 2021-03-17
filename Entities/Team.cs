namespace Entities
{
    public class Team
    {
        public string Id { get; set; }
        public TeamName Name { get; set; }

        public int Born { get; set; }
    }

    public class TeamName
    {
        public string First { get; set; }
        public string Last { get; set; }
    }
}