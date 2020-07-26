namespace SharpLog.FrontEnd.Models.DTOs
{
    public class SearchedGame : BaseModel
    {
        public string Name { get; set; } = "";

        public int? ReleaseYear { get; set; }
    }
}