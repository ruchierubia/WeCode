using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCode.Models
{
    public class TalentRepository : ITalentRepository
    {
        private readonly AppDBContext _context;

        public TalentRepository(AppDBContext context)
        {
            this._context = context;
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
