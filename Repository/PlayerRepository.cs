using System.Collections.Generic;
using System.Linq;
using Лаб4.Entities;
using Лаб4.Repository.Base;

namespace Лаб4.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private DbContext.DbContext _dbContext;

        public PlayerRepository(DbContext.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(PlayerEntity player)
        {
            player.Id = _dbContext.Players.Count + 1;
            player.UserName = "Гравець" + (_dbContext.Players.Count + 1);
            _dbContext.Players.Add(player);
        }

        public List<PlayerEntity> ReadAll()
        {
            return _dbContext.Players;
        }

        public PlayerEntity ReadById(int playerId)
        {
            return _dbContext.Players.FirstOrDefault(p => p.Id == playerId);
        }

        public void Update(PlayerEntity player)
        {
            var existingPlayer = _dbContext.Players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.UserName = player.UserName;
                existingPlayer.CurrentRating = player.CurrentRating;
                existingPlayer.GamesCount = player.GamesCount;
            }
        }

        public void Delete(int playerId)
        {
            var playerToDelete = _dbContext.Players.FirstOrDefault(p => p.Id == playerId);
            if (playerToDelete != null)
            {
                _dbContext.Players.Remove(playerToDelete);
            }
        }
    }
}