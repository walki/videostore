namespace videostore
{
    internal class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) : base(title)
        {
        }

		public override double GetAmount(int daysRented)
		{
			double amount =  1.5;
			if (daysRented > 3)
			{
				amount += (daysRented - 3) * 1.5;
			}

			return amount;
		}

		public override int GetPoints(int daysRented)
		{
			return 1;
		}
	}
}