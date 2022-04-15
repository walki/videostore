namespace videostore
{
    internal class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title)
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

		public override int GetPoints(int daysRented)
		{
			return 1;
		}
	}
}