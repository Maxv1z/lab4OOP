using System;
using System.Linq;
using Лаб4.Service.Base;
using Лаб4.Commands.Base;

namespace Лаб4.Commands
{
    public class DisplayPlayerGamesCommand : ICommand
    {
        private IPlayerService _playerService;
        private IGameService _gameService;

        public DisplayPlayerGamesCommand(IPlayerService playerService, IGameService gameService)
        {
            _playerService = playerService;
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гравця");
            var playerId = int.Parse(Console.ReadLine() ?? string.Empty);
            var selectedPlayer = _playerService.GetPlayerById(playerId);

            if (selectedPlayer == null)
            {
                Console.WriteLine("Такого гравця не існує");
                return;
            }

            Console.WriteLine($"Список ігор гравця {selectedPlayer.UserName}:");

            var games = _gameService.GetAllGames().Where(game => game.PlayerId == playerId);
            foreach (var game in games)
            {
                Console.WriteLine(
                    $"ID гри {game.Id}, Рейтинг гри {game.GameRating}, Тип гри {game.GameType}, Тип аккаунта {game.AccountType}, Перемога: {game.IsWin}");
            }
        }

        public string GetCommandInfo()
        {
            return "Вивід списку ігор гравця";
        }
    }
}