using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Model
{
    public enum Category
    {
        [Description("Movies")]
        MOVIES,
        [Description("Boardgames")]
        BOARDGAMES,
        [Description("Applications")]
        APPLICATIONS,
        [Description("Games")]
        GAMES,
        [Description("Technology and Electronics")]
        TECHNOLOGY,
        [Description("Nutrition")]
        NUTRITION,
        [Description("Other")]
        OTHER
    }
}
