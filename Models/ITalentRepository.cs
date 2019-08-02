using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCode.Models
{
    public interface ITalentRepository
    {
        Talent GetTalent(int id);
        IEnumerable<Talent> GetTalentList();
        Talent Add(Talent talent);
        Talent Update(Talent talentChanges);
        Talent Delete(int id);
    }
}
