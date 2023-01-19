using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace helloralph.Models
{
	[ObservableObject]
	public partial class MyTask
	{
		public string Name { get; set; }
		public bool Completed { get; set; }
		public int CategoryId { get; set; }
		public Color Color { get; set; }
	}
}

