using Лаб4.Entities;
using System.Collections.Generic;

namespace Лаб4.DbContext
{ 
    public class DbContext
    {
        public List<PlayerEntity> Players { get; set; }
        public List<GameEntity> Games { get; set; }

        public DbContext()
        {
            Players = new List<PlayerEntity>();
            Games = new List<GameEntity>();
            Players.Add(new PlayerEntity { Id = 1, UserName = "Max", CurrentRating = 110, GamesCount = 0 });
            Players.Add(new PlayerEntity { Id = 2, UserName = "Bot", CurrentRating = 110, GamesCount = 0 });
        }
    }
}