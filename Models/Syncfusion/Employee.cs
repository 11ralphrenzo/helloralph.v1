using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloralph.Models
{
    public class Employee
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string imagesource;

		public string ImageSource
        {
			get { return imagesource; }
			set { imagesource = value; }
		}

		private Color colors;

		public Color Colors
		{
			get { return colors; }
			set { colors = value; }
		}

	}
}
