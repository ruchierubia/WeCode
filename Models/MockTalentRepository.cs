using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCode.Models
{
    public class MockTalentRepository : ITalentRepository
    {
        private List<Talent> _talentList;
        public MockTalentRepository() // In memory
        {
            _talentList = new List<Talent>()
            {
                new Talent(){Id=1,Name="James Rivers", Email="James_Rivers@gmail.com", Skills =Skills.C},
                new Talent(){Id=2,Name="Tommy Hood", Email="Tommy_Hood@gmail.com", Skills = Skills.JavaScript},
                new Talent(){Id=3,Name="Kyle Norris", Email="Kyle_Norris@gmail.com", Skills =Skills.PHP},
            };// Mock List of object
        }
        public Talent GetTalent(int id)
        {
            return _talentList.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Talent> GetTalentList()
        {
            return _talentList;
        }

        public Talent Add(Talent talent)
        {
            talent.Id = _talentList.Max(e => e.Id) + 1;
            _talentList.Add(talent);
            return talent;
        }

        public Talent Update(Talent talentChanges)
        {
            Talent talent = _talentList.FirstOrDefault(t => t.Id == talentChanges.Id);
            if (talent != null)
            {
                talent.Name = talentChanges.Name;
                talent.Email = talentChanges.Email;
                talent.Skills = talentChanges.Skills;
            }
            return talent;
        }

        public Talent Delete(int id)
        {
            Talent talent = _talentList.FirstOrDefault(t => t.Id == id);
            if (talent != null)
                _talentList.Remove(talent);
            return talent;
        }
    }
}
