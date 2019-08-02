using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCode.Models
{
    public class MockTalentRepository : ITalentRepository
    {
        private List<Talent> _talentList;
        public MockTalentRepository()
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
    }
}
