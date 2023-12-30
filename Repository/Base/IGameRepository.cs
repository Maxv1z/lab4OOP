using System.Collections.Generic;
using Лаб4.Entities;


namespace Лаб4.Repository.Base
{
    public interface IGameRepository
    {
        void Create(GameEntity game);
        List<GameEntity> ReadAll();
        GameEntity ReadById(int gameId);
        void Update(GameEntity game);
        void Delete(int gameId);
    }
}