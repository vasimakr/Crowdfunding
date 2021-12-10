using Crowdfunding.Model;
using System.Collections.Generic;

namespace Crowdfunding.Service
{
    public interface IFundingPackageService
    {
        public FundingPackage CreateFundingPackage(int projectId, FundingPackage fundingPackage);

        public FundingPackage UpdateFundingPackage(int fundingPackageId, FundingPackage fundingPackage);

        public BackerPackage BuyFundingPackage(int backerId, int fundingPackageId);

        public bool DeleteFundingPackage(int fundingPackageId);

        public FundingPackage GetFundingPackage(int fundingPackageId);

        public List<FundingPackage> GetFundingPackageList(int id);
    }
}

