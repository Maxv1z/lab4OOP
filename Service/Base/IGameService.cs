using System.Collections.Generic;
using Лаб4.Entities;

namespace Лаб4.Service.Base
{
    public interface IGameService
    {
        void CreateGame(int gameRating);
        List<GameEntity> GetAllGames();
        GameEntity GetGameById(int gameId);
        void UpdateGame(GameEntity game);
        void DeleteGame(int gameId);
    }
}