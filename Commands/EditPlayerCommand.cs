using System;
using Лаб4.Service.Base;
using Лаб4.Commands.Base;

namespace Лаб4.Commands
{
    public class EditPlayerCommand : ICommand
    {
        private IPlayerService _playerService;

        public EditPlayerCommand(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гравця");
            var playerId = int.Parse(Console.ReadLine() ?? string.Empty);
            var player = _playerService.GetPlayerById(playerId);

            if (player == null)
            {
                Console.WriteLine("Такого гравця не існує");
                return;
            }

            Console.WriteLine("Виберіть, що ви хочете змінити:");
            Console.WriteLine("1. Ім'я гравця");
            Console.WriteLine("2. Поточний рейтинг");
            Console.WriteLine("3. Кількість ігор");
            var editChoice = GetChoice(1, 3);

            switch (editChoice)
            {
                case 1:
                    Console.WriteLine("Введіть нове ім'я гравця");
                    var newName = Console.ReadLine();
                    player.UserName = newName;
                    break;
                case 2:
                    Console.WriteLine("Введіть новий рейтинг гравця");
                    var newRating = int.Parse(Console.ReadLine() ?? string.Empty);
                    player.CurrentRating = newRating;
                    break;
                case 3:
                    Console.WriteLine("Введіть нову кількість ігор гравця");
                    var newGamesCount = int.Parse(Console.ReadLine() ?? string.Empty);
                    player.GamesCount = newGamesCount;
                    break;
            }

            _playerService.UpdatePlayer(player);
            Console.WriteLine("Гравець був успішно оновлений");
        }

        public string GetCommandInfo()
        {
            return "Редагувати гравця";
        }

        private static int GetChoice(int minValue, int maxValue)
        {
            int choice;
            while (true)
            {
                Console.Write($"Введіть число від {minValue} до {maxValue}: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
                {
                    break;
                }

                Console.WriteLine("Некоректне введення. Спробуйте ще раз.");
            }

            return choice;
        }
    }
}