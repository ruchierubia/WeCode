using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCode.Models
{
    public class TalentRepository : ITalentRepository
    {
        private readonly AppDBContext _context;
        private readonly ILogger<TalentRepository> _logger;

        public TalentRepository(AppDBContext context,
            ILogger<TalentRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public Talent Add(Talent talent)
        {
            _context.Add(talent);
            _context.SaveChanges();
            return talent;
        }

        public Talent Delete(int id)
        {
            Talent talent = _context.Talents.Find(id);
            if(talent != null)
            {
                _context.Talents.Remove(talent);
                _context.SaveChanges();
            }
            return talent;
        }

        public Talent GetTalent(int id)
        {
            _logger.LogTrace("Trace Log");
            _logger.LogDebug("Debug Log");
            _logger.LogInformation("Information Log");
            _logger.LogWarning("Warning Log");
            _logger.LogError("Error Log");
            _logger.LogCritical("Critical Log");
            return _context.Talents.Find(id);
        }

        public IEnumerable<Talent> GetTalentList()
        {
            return _context.Talents;
        }

        public Talent Update(Talent talentChanges)
        {
            var talent = _context.Talents.Attach(talentChanges);
            talent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return talentChanges;

        }
    }
}
