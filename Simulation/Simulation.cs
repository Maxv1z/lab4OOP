using System;
using Лаб4.Repository;
using Лаб4.Commands;
using Лаб4.Service.Base;
using Лаб4.Service;

namespace Лаб4.Simulation
{
    public abstract class Simulation
    {
        private static DbContext.DbContext _dbContext = new DbContext.DbContext();
        private static PlayerRepository _playerRepository = new PlayerRepository(_dbContext);
        private static GameRepository _gameRepository = new GameRepository(_dbContext);
        private static GameFactory _gameFactory = new GameFactory();
        private static CommandManager _commandManager = new CommandManager();

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IPlayerService playerService = new PlayerService(_playerRepository);
            IGameService gameService = new GameService(_gameRepository);

            _commandManager.AddCommand(new CreatePlayerCommand(playerService));
            _commandManager.AddCommand(new DisplayPlayersCommand(playerService));
            _commandManager.AddCommand(new DeletePlayerCommand(playerService));
            _commandManager.AddCommand(new EditPlayerCommand(playerService));
            _commandManager.AddCommand(new DisplayPlayerGamesCommand(playerService, gameService));
            _commandManager.AddCommand(new DisplayGamesCommand(gameService));
            _commandManager.AddCommand(new EditGameCommand(gameService));
            _commandManager.AddCommand(new DeleteGameCommand(gameService));
            _commandManager.AddCommand(new StartGameCommand(playerService, gameService, _gameFactory));

            Start();
        }

        private static void Start()
        {
            while (true)
            {
                Console.WriteLine("Запуск:");
                _commandManager.DisplayCommands();

                var startChoice = GetChoice(1, _commandManager.Commands.Count);
                _commandManager.ExecuteCommand(startChoice - 1);
            }
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