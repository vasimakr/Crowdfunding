using Crowdfunding.dto;
using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Service
{
    public interface IProjectService
    {
        public ApiResponse<Project> CreateProject(Project project);
        public Project ReadProject(int id);
        public List<Project> ReadProject(int pageCount, int pageSize); // θα χρειαστεί για τις σελίδες browsing φαντάζομαι
        public Project UpdateProject(int projectId, Project project);
        public bool DeleteProject(int id);


    }
}
