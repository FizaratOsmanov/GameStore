using GameStore.BL.Abstractions;
using GameStore.DAL;
using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BL.Concretes
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _appDbContext;
        public GameService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void CreateGame(Game game)
        {
            _appDbContext.Games.Add(game);
            int rows = _appDbContext.SaveChanges();

            if (rows != 1)
            {
                throw new Exception("Something went wrong.");
            }
        }
        public IEnumerable<Game> GetAllGames()
        {
            IEnumerable<Game> games = _appDbContext.Games;
            return games;
        }
        public Game GetGameById(int id)
        {
            Game? game = _appDbContext.Games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                throw new Exception("Game not found.");
            }
            return game;
        }
        public void HardDeleteGame(int id)
        {
            Game? game = _appDbContext.Games.Find(id);
            if (game == null)
            {
                throw new Exception("Game not found.");
            }
            _appDbContext.Games.Remove(game);
            _appDbContext.SaveChanges();
        }
        public void SoftDeleteGame(int id)
        {
            Game? baseGame = _appDbContext.Games.SingleOrDefault(x => x.Id == id);

            if (baseGame == null)
            {
                throw new Exception("Game not found.");

            }
            baseGame.IsDeleted= true;
            baseGame.DeletedDate = DateTime.Now;
            _appDbContext.SaveChanges();
        }

        public void UpdateGame(int id, Game game)
        {
            Game? baseGame = _appDbContext.Games.Find(id);
            baseGame.Title = game.Title;
            baseGame.Description = game.Description;
            baseGame.Price = game.Price;
            baseGame.GameID = game.GameID;
            baseGame.Img=game.Img;
            _appDbContext.SaveChanges();
        }
    }
}
