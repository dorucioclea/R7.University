//
//  RepeaterPositionsLogic.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2018 Roman M. Yagodin
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

using System.Web;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using R7.University.ModelExtensions;
using R7.University.Models;
using R7.University.Utilities;
using R7.University.ViewModels;

namespace R7.University.Employees.SharedLogic
{
    public static class RepeaterPositionsLogic
    {
        public static void ItemDataBound (PortalModuleBase module, object sender, RepeaterItemEventArgs e)
        {
            // exclude header & footer
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                var gop = (GroupedOccupiedPosition) e.Item.DataItem;
                var op = gop.OccupiedPosition;

                var labelPosition = (Label) e.Item.FindControl ("labelPosition");
                var labelDivision = (Label) e.Item.FindControl ("labelDivision");
                var linkDivision = (HyperLink) e.Item.FindControl ("linkDivision");

                labelPosition.Text = gop.Title;

                // don't display division title/link for single-entity divisions
                if (!op.Division.IsSingleEntity) {
                    var divisionShortTitle = UniversityFormatHelper.FormatShortTitle (
                        op.Division.ShortTitle,
                        op.Division.Title);

                    if (!string.IsNullOrWhiteSpace (op.Division.HomePage)) {
                        // link to division's homepage
                        labelDivision.Visible = false;
                        linkDivision.NavigateUrl = UniversityUrlHelper.FormatCrossPortalTabUrl (
                            module,
                            int.Parse (op.Division.HomePage),
                            false);
                        linkDivision.Text = divisionShortTitle;
                    }
                    else {   
                        // only division title
                        linkDivision.Visible = false;
                        labelDivision.Text = divisionShortTitle;
                    }

                    labelPosition.Text += ": "; // to prev label!
                }
                else {
                    labelDivision.Visible = false;
                    linkDivision.Visible = false;
                }

                if (!op.Division.IsPublished (HttpContext.Current.Timestamp)) {
                    labelPosition.CssClass = "u8y-not-published-element";
                    labelDivision.CssClass = "u8y-not-published-element";
                    linkDivision.CssClass = "u8y-not-published-element";
                }
            }
        }
    }
}

