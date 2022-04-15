namespace videostore
{
    internal class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title, int priceCode) : base(title, priceCode)
        {
        }

		public override double GetAmount(int daysRented)
		{
			double detailAmount = 0;
			// determines the amount for each line
			switch (getPriceCode())
			{
				case Movie.NEW_RELEASE:
					detailAmount += daysRented * 3;
					break;
			}

			return detailAmount;
		}
	}
}