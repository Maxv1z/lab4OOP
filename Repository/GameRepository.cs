using System.Collections.Generic;
using System.Linq;
using Лаб4.Entities;
using Лаб4.Repository.Base;

namespace Лаб4.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DbContext.DbContext _dbContext;

        public GameRepository(DbContext.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(GameEntity game)
        {
            game.Id = _dbContext.Games.Count + 1;
            _dbContext.Games.Add(game);
        }

        public List<GameEntity> ReadAll()
        {
            return _dbContext.Games;
        }

        public GameEntity ReadById(int gameId)
        {
            return _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
        }

        public void Update(GameEntity game)
        {
            var existingGame = _dbContext.Games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame != null)
            {
                existingGame.GameRating = game.GameRating;
            }
        }

        public void Delete(int gameId)
        {
            var gameToDelete = _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
            if (gameToDelete != null)
            {
                _dbContext.Games.Remove(gameToDelete);
            }
        }
    }
}