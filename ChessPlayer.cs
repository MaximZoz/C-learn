namespace ConsoleApp1
{
    public class ChessPlayer
    {
        public string Country { get; set; }
        public string FirstName { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }


        public static ChessPlayer ParseFideCsv(string line)
        {
            var parts = line.Split(';');
            return new ChessPlayer()
            {
                Id = int.Parse(parts[0]),
                FirstName = parts[1].Trim(),
                Country = parts[3],
                Rating = int.Parse(parts[4]),
                BirthYear = int.Parse(parts[6]),
            };
        }
    }
}