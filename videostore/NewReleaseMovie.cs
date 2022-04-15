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
	}
}