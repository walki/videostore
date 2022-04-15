using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videostore
{
	public abstract class Movie
	{
		private String title;

		public Movie(String title)
        {
			this.title = title;
		}

		public String GetTitle()
		{
			return title;
		}

		public abstract double GetAmount(int daysRented);

		public abstract int GetPoints(int daysRented);
	}
}
