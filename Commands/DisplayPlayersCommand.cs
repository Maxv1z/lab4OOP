using System;
using Лаб4.Service.Base;
using Лаб4.Commands.Base;

namespace Лаб4.Commands
{
    public class DisplayPlayersCommand : ICommand
    {
        private IPlayerService _playerService;

        public DisplayPlayersCommand(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            foreach (var player in _playerService.GetAllPlayers())
            {
                Console.WriteLine($"ID гравця {player.Id}, Імя {player.UserName}, Рейтинг {player.CurrentRating}, Кількість ігор гравця {player.GamesCount}");
            }
        }

        public string GetCommandInfo()
        {
            return "Список гравців";
        }
    }
}