﻿using Crowdfunding.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Service
{
    public class FundingPackageService : IFundingPackageService
    {
        private readonly FundRaiserContext dbContext;

        public FundingPackageService(FundRaiserContext adbContext)
        {
            dbContext = adbContext;
        }

        public FundingPackage CreateFundingPackage(int projectId, FundingPackage aFundingPackage)
        {
            var project = dbContext.Projects.Find(projectId);

            if (project == null)
            {
                return null;
            }

            //var fundingPackage = new FundingPackage
            //{
            //    Project = project,
            //    Tier = aFundingPackage.Tier,
            //    Name = aFundingPackage.Name,
            //    Price = aFundingPackage.Price,
            //    Description = aFundingPackage.Description
            //};

            dbContext.FundingPackages.Add(aFundingPackage);
            aFundingPackage.Project = project;
            dbContext.SaveChanges();
            return aFundingPackage;
        }

        public FundingPackage UpdateFundingPackage(int fundingPackageId, FundingPackage fundingPackage)
        {
            var dbFundingPackage = dbContext.FundingPackages.Find(fundingPackageId);

            if (dbFundingPackage == null)
            {
                return null;
            }


            dbFundingPackage.Project = fundingPackage.Project;
            dbFundingPackage.Tier = fundingPackage.Tier;
            dbFundingPackage.Name = fundingPackage.Name;
            dbFundingPackage.Price = fundingPackage.Price;
            dbFundingPackage.Description = fundingPackage.Description;


            dbContext.SaveChanges();
            return dbFundingPackage;
        }

        public BackerPackage BuyFundingPackage(int backerId, int fundingPackageId)
        {
            Backer dbBacker = dbContext.Backers.Find(backerId);
            var dbFundingPackage = dbContext.FundingPackages
                .Where(item=> item.Id==fundingPackageId).Include(item => item.Project).First();

           
            var backerPackage = new BackerPackage
            {
                Backer = dbBacker,
                FundingPackage = dbFundingPackage
            };
            var project= dbContext.Projects.Find(dbFundingPackage.Project.Id);
            project.Fundings += dbFundingPackage.Price;

            dbContext.BackerPackages.Add(backerPackage);
            dbContext.SaveChanges();
            return backerPackage;
        }

        public bool DeleteFundingPackage(int fundingPackageId)
        {
            var dbFundingPackage = dbContext.FundingPackages.Find(fundingPackageId);
            if (dbFundingPackage == null) return false;
            dbContext.Remove(dbFundingPackage);
            return dbContext.SaveChanges() == 1;
        }

        public FundingPackage GetFundingPackage(int fundingPackageId)
        {
            return dbContext.FundingPackages.Find(fundingPackageId);
        }

        public List<FundingPackage> GetFundingPackage()
        {
            return dbContext.FundingPackages.ToList();
        }
    } 
}