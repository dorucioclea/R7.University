﻿using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Linq;

using DotNetNuke.UI.UserControls;
using DotNetNuke.UI.WebControls;
using DotNetNuke.Web.UI.WebControls;

namespace R7.University.DivisionDirectory 
{
    public partial class ViewDivisionDirectory
    {    
        protected GridView gridDivisions;
        protected TextBox textSearch;
        protected LinkButton linkSearch;
        protected DnnTreeView treeDivisions;
        protected CheckBox checkIncludeSubdivisions;
    }
}
