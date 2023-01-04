using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using helloralph.Models;
using static helloralph.Utilities.Enums;

namespace helloralph.ViewModels
{
	public partial class HangmanViewModel : BaseViewModel
	{
        List<string> words = new List<string>()
		{
			"nivea",
			"vaseline",
			"cetaphil"
		};
		List<string> guessed = new List<string>();
		string answer;
		Random r = new Random();

		[ObservableProperty]
        ObservableCollection<LetterButtonModel> letters = new ObservableCollection<LetterButtonModel>();

        [ObservableProperty]
		string spotlight;

		[ObservableProperty]
		string message;

		[ObservableProperty]
        int mistakes = 0;

        [ObservableProperty]
        int maxAttempt = 6;

		[ObservableProperty]
		GameStatus status = GameStatus.Start;

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

		void HandleGuess(string letter)
		{
			Status = GameStatus.Playing;
            if (!guessed.Contains(letter))
			{
				guessed.Add(letter);
			}

			if (answer.Contains(letter))
			{
				CalculateWord(answer, guessed);
				CheckIfWon();
			}
			else if (!answer.Contains(letter))
			{
				Mistakes++;
				CheckIfLost();
			}
		}

		void CheckIfWon()
		{
			if (string.Equals(Spotlight.Replace(" ", ""), answer))
			{
				Status = GameStatus.Won;
				Message = "You Win!";
			}
		}

		void CheckIfLost()
		{
			if (Mistakes == MaxAttempt)
			{
                Status = GameStatus.Lost;
                Message = "You Lost!";
			}
		}

		void EnableButtons()
		{
			for (int i = 0; i < Letters.Count(); i++)
			{
				if (!Letters[i].IsEnabled)
				{
					var m = Letters[i];
					m.IsEnabled = true;
					Letters[i] = m;
				}
			}
		}

		[RelayCommand]
		void SelectLetter(LetterButtonModel model)
		{
			HandleGuess(model.Letter.ToLower());
            var index = Letters.IndexOf(model);
            model.IsEnabled = false;
            Letters[index] = model;
        }

		[RelayCommand]
		void Reset()
		{
			Status = GameStatus.Start;
			Mistakes = 0;
			guessed.Clear();
			PickWord();
			CalculateWord(answer, guessed);
			EnableButtons();
			Message = string.Empty;
		}
	}
}

