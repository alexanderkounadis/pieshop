using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext ctx;

        public PieRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IEnumerable<Pie> AllPies { 
            get 
            {
                return ctx.Pies.Include(c => c.Category);
            } 
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return ctx.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return ctx.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
