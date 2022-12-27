using System;
namespace helloralph.Models
{
	public class ExperienceModel
	{
		public string Image { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public int NumYears { get; set; }
		public int NumMonths { get; set; }
		public bool HasExperience
		{
			get => NumYears != 0 || NumMonths != 0; 
		}
	}

	public class ExperienceGroup : List<ExperienceModel>
	{
		public string Name { get; set; }

		public ExperienceGroup(string name, List<ExperienceModel> exp) : base(exp)
		{
			this.Name = name;
		}
	}
}

