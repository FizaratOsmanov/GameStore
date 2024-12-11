using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BL.Abstractions
{
    public interface IGameService
    {
        public Game GetGameById(int id);
        public IEnumerable<Game> GetAllGames();
        public void CreateGame(Game game);
        public void UpdateGame(int id, Game game);
        public void SoftDeleteGame(int id);
        public void HardDeleteGame(int id);
    }
}
