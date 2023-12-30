using System;
using System.Collections.Generic;

namespace Лаб4.Simulation
{
    public abstract class GameAccount
    {
        private string _userName;
        public int CurrentRating;
        public int GamesCount;
        private List<Result> History { get; set; }

        protected GameAccount(string userName, int initialRating)
        {
            SetUserName(userName);
            if (initialRating < 1)
            {
                throw new ArgumentException("Рейтинг повинен бути більшим або дорівнювати 1.");
            }

            CurrentRating = 1000;
            GamesCount = 0;
            History = new List<Result>();
        }

        protected abstract int CalculateRatingForWin(int gameRating);

        protected abstract int CalculateRatingForLoss(int gameRating);

        public void WinGame(GameAccount opponent, int gameRating)
        {
            int ratingChange = CalculateRatingForWin(gameRating);
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            CurrentRating += ratingChange;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GamesCount++;
            History.Add(new Result(opponent.GetUserName(), true, ratingChange));
        }

        public void LoseGame(GameAccount opponent, int gameRating)
        {
            var ratingChange = CalculateRatingForLoss(gameRating);
            CurrentRating -= ratingChange;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }

            GamesCount++;
            History.Add(new Result(opponent.GetUserName(), false, ratingChange));
        }

        public void GetStats()
        {
            Console.WriteLine($"Статистика {_userName} ({GetAccountType()}):");
            for (var i = 0; i < History.Count; i++)
            {
                var result = History[i];
                var output = result.Victory ? "перемога" : "поразка";
                Console.WriteLine(
                    $"Гра #{i + 1}: Проти {result.OpponentName}, Результат: {output}, Зміна рейтингу: {result.RatingChange}");
            }

            Console.WriteLine($"Загальна кількість ігор: {GamesCount}, Поточний рейтинг: {CurrentRating}");
        }

        private string GetUserName()
        {
            return _userName;
        }

        public virtual string GetAccountType()
        {
            return "Базовий тип аккаунта";
        }

        private void SetUserName(string value)
        {
            _userName = value;
        }
    }
}