﻿//
//  EmployeeExtensions.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2018 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using R7.Dnn.Extensions.Text;
using R7.University.Models;

namespace R7.University.ModelExtensions
{
    public static class EmployeeExtensions
    {
        public static string GetSearchUrl (this IEmployee employee, ModuleInfo module, PortalSettings portalSettings)
        {
            return Globals.NavigateURL (module.TabID, false, portalSettings, "",
                portalSettings.PortalAlias.CultureCode, "", "mid", module.ModuleID.ToString ());
        }

        public static string FullName (this IEmployee employee)
        {
            return FormatHelper.JoinNotNullOrEmpty (" ", employee.LastName, employee.FirstName, employee.OtherName);
        }

        public static string SearchText (this IEmployee employee)
        {
            // TODO: Add positions and achievements to the search
            return FormatHelper.JoinNotNullOrEmpty (", ",
                employee.FullName (),
                employee.Phone,
                employee.CellPhone,
                employee.Fax,
                employee.Email,
                employee.SecondaryEmail,
                employee.WebSite,
                employee.Messenger,
                employee.WorkingPlace,
                employee.WorkingHours,
                HtmlUtils.ConvertToText (employee.Biography)
            );
        }
    }
}
