namespace videostore
{
    internal class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title, int priceCode) : base(title, priceCode)
        {
        }

		public override double GetAmount(int daysRented)
		{
			return daysRented * 3;
		}

		public override int GetPoints(int daysRented)
		{
			int points = 0;
			points++;

			if (getPriceCode() == Movie.NEW_RELEASE
					&& daysRented > 1)
				points++;

			return points;
		}
	}
}