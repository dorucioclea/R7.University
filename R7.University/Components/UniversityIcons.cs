﻿//
//  UniversityIcons.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2017 Roman M. Yagodin
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

using DotNetNuke.Entities.Icons;

namespace R7.University.Components
{
    public static class UniversityIcons
    {
        public static readonly string Edit = IconController.IconURL ("Edit", IconController.DefaultIconSize, "Gray");

        public static readonly string Add = IconController.IconURL ("Add");

        public static readonly string AddAlternate = IconController.IconURL ("Add", IconController.DefaultIconSize, "Gray");

        public static readonly string Delete = IconController.IconURL ("ActionDelete");

        public static readonly string Details = IconController.IconURL ("View");

        public static readonly string Rollback = "~/DesktopModules/MVC/R7.University/R7.University/images/Rollback_16x16_Gray.png";

        public static readonly string EditDocuments = IconController.IconURL ("EditDisabled");
    }
}
