using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }


        public EFBowlersRepository(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        
        public IQueryable<Team> Teams => _context.Teams;

        public void SaveBowler(Bowler b)
            {
            _context.SaveChanges();
            }
        public void CreateBowler(Bowler b)
            {
            _context.Add(b);
            _context.SaveChanges();
            }

        public void DeleteBowler(Bowler b)
            {
            _context.Remove(b);
            _context.SaveChanges();
            }

        public void EditBowler(Bowler b)
            {
            _context.Update(b);
            _context.SaveChanges();
            }
    }


}
