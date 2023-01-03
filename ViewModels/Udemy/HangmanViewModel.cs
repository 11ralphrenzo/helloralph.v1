using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;

namespace helloralph.ViewModels
{
	public partial class HangmanViewModel : BaseViewModel
	{
        List<string> words = new List<string>()
		{
			"Nivea",
			"Vaseline",
			"Cetaphil"
		};
		List<string> guessed = new List<string>();

		string answer;
		Random r = new Random();

		[ObservableProperty]
        List<LetterButtonModel> letters = new List<LetterButtonModel>();

        [ObservableProperty]
		string spotlight;

		public HangmanViewModel()
		{
			PickWord();
			CalculateWord(answer, guessed);
			GenerateLetters();
		}

		void PickWord()
		{
			answer = words[r.Next(words.Count)];
		}

		void CalculateWord(string word, List<string> guessed)
		{
			var temp = answer.Select(x => (guessed.IndexOf(x.ToString()) >= 0 ? x : '_'))
				.ToArray();
			Spotlight = string.Join(' ', temp);
		}

		void GenerateLetters()
		{
			for (var l = 'A'; l <= 'Z'; l++)
				Letters.Add(new LetterButtonModel(l));
		}

		[RelayCommand]
		void SelectLetter(string letter)
		{
			//var l = Convert.ToChar(letter);
		}
	}
}

