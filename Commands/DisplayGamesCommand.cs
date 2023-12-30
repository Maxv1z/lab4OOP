using System;
using Лаб4.Commands.Base;
using Лаб4.Service.Base;

namespace Лаб4.Commands
{
    public class DisplayGamesCommand : ICommand
    {
        private IGameService _gameService;

        public DisplayGamesCommand(IGameService gameService)Я
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Список усіх ігор:");

            foreach (var gameEntity in _gameService.GetAllGames())
            {
                Console.WriteLine(
                    $"ID гри {gameEntity.Id}, Рейтинг гри {gameEntity.GameRating}, Тип гри {gameEntity.GameType}, Тип аккаунта {gameEntity.AccountType}, Перемога: {gameEntity.IsWin}");
            }
        }

        public string GetCommandInfo()
        {
            return "Вивід списку ігор";
        }
    }
}