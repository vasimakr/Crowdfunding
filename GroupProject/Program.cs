using Crowdfunding.Model;
using Crowdfunding.Service;
using System;

namespace Crowdfunding
{
    class Program
    {
        static void Main(string[] args)
        {
            using var fundRaiserContext = new FundRaiserContext();

            var creatorService = new CreatorService(fundRaiserContext);
            var backerService = new BackerService(fundRaiserContext);
            var projectService = new ProjectService(fundRaiserContext);
            var fundPackageService = new FundingPackageService(fundRaiserContext);

            var creator = new Creator
            {
                FirstName = "Bob2",
                LastName = "Dod2",
                Email = "bobdod2@gmail.com",
            };
            creatorService.CreateCreator(creator);

            var project = new Project
            {
                Title = "Test",
                Description = "this is another test project",
                Goal = 300,
                Category = Category.BOARDGAMES,
                Creator = creator
            };
            projectService.CreateProject(project);

            var fundingPackage = new FundingPackage
            {
                Name = "aaaaaaaaaaaaaaaaaaaaaaaa",
                Tier = 3,
                Description = "help",
                Price = 10
            };
            Console.WriteLine($" Pre Create -- Funding Package: {fundingPackage.Id}");

            fundPackageService.CreateFundingPackage(project.Id, fundingPackage);
            Console.WriteLine($" Post Create -- Funding Package: {fundingPackage.Id}");

            var backer = new Backer
            {
                FirstName = "mark",
                LastName = "zucc",
                Email = "meta@gmail.com"
            };
            backerService.CreateBacker(backer);
            fundPackageService.BuyFundingPackage(1029, 1);
            Console.WriteLine($"Creator: {creator.Id} \n Backer: {backer.Id} \n Funding Package: {fundingPackage.Id}");
            fundPackageService.BuyFundingPackage(backer.Id, fundingPackage.Id);
        
    }

        public void Test1()
        {
            using var fundRaiserContext = new FundRaiserContext();
            Console.WriteLine("Commencing test 1: \n New Creator, new Project, add Funding Package to project.\n New backer, buys funding package.");

            var creator = new Creator
            {
                FirstName = "Bob",
                LastName = "Dod",
                Email = "bobdod@gmail.com",
            };
            fundRaiserContext.Creators.Add(creator);

            var project = new Project
            {
                Title = "Test",
                Description = "this is a test project",
                Goal = 100,
                Category = Category.MOVIES,
                Creator = creator
            };
            fundRaiserContext.Projects.Add(project);

            var fundingPackage = new FundingPackage
            {
                Name = "Testing stuff",
                Tier = 1,
                Description = "This is a test fp",
                Price = 5,
                Project = project
            };
            fundRaiserContext.FundingPackages.Add(fundingPackage);

            var backer = new Backer
            {
                FirstName = "jack",
                LastName = "dorsey",
                Email = "twitter@gmail.com"
            };
            fundRaiserContext.Backers.Add(backer);

            var service = new FundingPackageService(fundRaiserContext);
            service.BuyFundingPackage(0, 0);

            fundRaiserContext.SaveChanges();
        } //Simple creation by hand
        public void Test2()
        {
            using var fundRaiserContext = new FundRaiserContext();

            var creatorService = new CreatorService(fundRaiserContext);
            var backerService = new BackerService(fundRaiserContext);
            var projectService = new ProjectService(fundRaiserContext);
            var fundPackageService = new FundingPackageService(fundRaiserContext);

            var creator = new Creator
            {
                FirstName = "Bob2",
                LastName = "Dod2",
                Email = "bobdod2@gmail.com",
            };
            creatorService.CreateCreator(creator);

            var project = new Project
            {
                Title = "Test",
                Description = "this is another test project",
                Goal = 300,
                Category = Category.BOARDGAMES,
                Creator = creator
            };
            projectService.CreateProject(project);

            var fundingPackage = new FundingPackage
            {
                Name = "aaaaaaaaaaaaaaaaaaaaaaaa",
                Tier = 3,
                Description = "help",
                Price = 10
            };
            Console.WriteLine($" Pre Create -- Funding Package: {fundingPackage.Id}");

            fundPackageService.CreateFundingPackage(project.Id, fundingPackage);
            Console.WriteLine($" Post Create -- Funding Package: {fundingPackage.Id}");

            var backer = new Backer
            {
                FirstName = "mark",
                LastName = "zucc",
                Email = "meta@gmail.com"
            };
            backerService.CreateBacker(backer);
            fundPackageService.BuyFundingPackage(9, 1);
            Console.WriteLine($"Creator: {creator.Id} \n Backer: {backer.Id} \n Funding Package: {fundingPackage.Id}");
            fundPackageService.BuyFundingPackage(backer.Id, fundingPackage.Id);
        }//creation w/ services -- 
    }

}
