using Crowdfunding.dto;
using Crowdfunding.Model;
using System.Collections.Generic;

namespace Crowdfunding.Service
{
    public interface IBackerService
    {
        // BACKERS
        public ApiResponse<Backer> CreateBacker(Backer backer);

        public Backer ReadBacker(int id);

        public Backer ReadBacker(string username);

        public List<Backer> ReadBacker();

        public Backer UpdateBacker(int backerId, Backer backer);

        public bool DeleteBacker(int backerId);

        public List<BackerPackage> GetBackerFundingPackages(int backerId);




    }
}
