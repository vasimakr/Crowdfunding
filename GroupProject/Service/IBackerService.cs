using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Service
{
    public interface IBackerService
    {
        // BACKERS
        public void CreateBacker(Backer backer);

        public Backer ReadBacker(int id);

        public List<Backer> ReadBacker();





    }
}
