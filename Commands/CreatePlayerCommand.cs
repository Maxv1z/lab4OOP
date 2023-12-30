using System;
using Лаб4.Entities;
using Лаб4.Service.Base;
using Лаб4.Commands.Base;

namespace Лаб4.Commands
{
    public class CreatePlayerCommand : ICommand
    {
        private IPlayerService _playerService;

        public CreatePlayerCommand(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            var newPlayer = new PlayerEntity();
            _playerService.CreatePlayer(newPlayer.UserName, newPlayer.CurrentRating);

            Console.WriteLine($"Гравець був успішно створений");
        }

        public string GetCommandInfo()
        {
            return "Створити гравця";
        }
    }
}