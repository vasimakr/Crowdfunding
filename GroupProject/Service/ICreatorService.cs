using Crowdfunding.Model;
using System.Collections.Generic;


namespace Crowdfunding.Service
{
    public interface ICreatorService
    {
        public void CreateCreator(Creator creator);

        public Creator ReadCreator(int id);
        public Creator ReadCreator(string username);
        public List<Creator> ReadCreator();
    }
}
