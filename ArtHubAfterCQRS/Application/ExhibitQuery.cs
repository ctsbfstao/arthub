using System.Collections.Generic;
using System.Data.Entity;
using ArtHub.Models;
using ArtHub.ViewModels;

namespace ArtHub.Application
{
    class ExhibitQuery : IExhibitQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ExhibitQuery()
        {
            _dbContext = new ApplicationDbContext();
        }

        public void Create(Exhibit exhibit)
        {
            _dbContext.Exhibits.Add(exhibit);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Exhibit> Get()
        {
            return _dbContext.Exhibits.Include(a => a.Type);
        }

        public IEnumerable<ExhibitType> GetExhibitTypes()
        {
            return _dbContext.ExhibitTypes;
        }
    }
}