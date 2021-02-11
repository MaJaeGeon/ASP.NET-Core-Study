using RankingApp_Rookiss.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApp_Rookiss.Data.Services
{
    public class RankingService
    {
        ApplicationDbContext _context;

        public RankingService(ApplicationDbContext context)
        {
            _context = context;
        }


        // CREATE
        public Task<GameResult> AddGameResult(GameResult gameResult)
        {
            _context.GameResult.Add(gameResult);
            _context.SaveChanges();

            return Task.FromResult(gameResult);
        }

        // READ
        public Task<List<GameResult>> GetGameResultsAsync()
        {
            List<GameResult> results = _context.GameResult
                .OrderByDescending(item => item.Score)
                .ToList();

            return Task.FromResult(results);
        }

        // UPDATE
        public Task<bool> UpdateGameResult(GameResult gameResult)
        {
            var findResult = _context.GameResult
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findResult == null)
                return Task.FromResult(false);

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;

            _context.SaveChanges();

            return Task.FromResult(true);
        }

        // DELETE
        public Task<bool> DeleteGameResult(GameResult gameResult)
        {
            var findResult = _context.GameResult
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findResult == null)
                return Task.FromResult(false);

            _context.GameResult.Remove(gameResult);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
