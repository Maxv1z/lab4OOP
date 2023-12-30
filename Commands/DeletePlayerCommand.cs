using System;
using Лаб4.Commands.Base;
using Лаб4.Service.Base;

namespace Лаб4.Commands
{
    public class DeletePlayerCommand : ICommand
    {
        private IPlayerService _playerService;

        public DeletePlayerCommand(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гравця");
            var answer = Console.ReadLine();

            if (!int.TryParse(answer, out var id))
            {
                Console.WriteLine("Такого гравця не існує");
            }

            var getPlayer = _playerService.GetPlayerById(id);

            if (getPlayer == default)
            {
                Console.WriteLine("Такого гравця не існує");
            }

            _playerService.DeletePlayer(id);
            Console.WriteLine("Ви видалили гравця");
        }

        public string GetCommandInfo()
        {
            return "Видалити гравця";
        }
    }
}