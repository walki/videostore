namespace videostore
{
    internal class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) : base(title)
        {
        }

		public override double GetAmount(int daysRented)
		{
			return daysRented * 3;
		}

		public override int GetPoints(int daysRented)
		{
			return daysRented > 1 ? 2 : 1;
		}
	}
}