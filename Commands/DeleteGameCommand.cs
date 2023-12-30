using System;
using Лаб4.Service.Base;
using Лаб4.Commands.Base;

namespace Лаб4.Commands
{
    public class DeleteGameCommand : ICommand
    {
        private IGameService _gameService;

        public DeleteGameCommand(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Введіть ID гри");
            var gameId = int.Parse(Console.ReadLine());
            _gameService.DeleteGame(gameId);
            Console.WriteLine("Гру було успішно видалено");
        }

        public string GetCommandInfo()
        {
            return "Видалити гру";
        }
    }
}