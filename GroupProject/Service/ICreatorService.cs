using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Service
{
    public interface ICreatorService
    {
        public void CreateCreator(Creator creator);

        public Creator ReadCreator(int id);

        public List<Creator> ReadCreator();
    }
}
