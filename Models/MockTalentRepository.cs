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
                new Talent(){Id=1,Name="Test Name 1", Email="Test Email 1", Skills ="Test Skills 1"},
                new Talent(){Id=2,Name="Test Name 2", Email="Test Email 2", Skills ="Test Skills 2"},
                new Talent(){Id=3,Name="Test Name 3", Email="Test Email 3", Skills ="Test Skills 3"},
                new Talent(){Id=4,Name="Test Name 4", Email="Test Email 4", Skills ="Test Skills 4"},
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
