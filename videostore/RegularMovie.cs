namespace videostore
{
    internal class RegularMovie : Movie
    {
        public RegularMovie(string title, int priceCode) : base(title, priceCode)
        {
        }

		public override double GetAmount(int daysRented)
		{
			double detailAmount = 2;
			if (daysRented > 2)
            {
				detailAmount += (daysRented - 2) * 1.5;
            }

			return detailAmount;
		}
	}
}