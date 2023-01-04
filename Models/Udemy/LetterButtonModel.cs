using System;
namespace helloralph.Models
{
	public class LetterButtonModel
	{
		public string Letter { get; set; }

		public bool IsEnabled { get; set; }

		public LetterButtonModel(char letter)
		{
			Letter = letter.ToString();
			IsEnabled = true;
		}
	}
}

