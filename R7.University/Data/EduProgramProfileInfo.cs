﻿//
//  EduProgramProfileInfo.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2016 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using DotNetNuke.ComponentModel.DataAnnotations;
using R7.University.Models;
using R7.University.ViewModels;

namespace R7.University.Data
{
    [TableName ("University_EduProgramProfiles")]
    [PrimaryKey ("EduProgramProfileID", AutoIncrement = true)]
    public class EduProgramProfileInfo: IEduProgramProfile
    {
        #region IEduProgramProfile implementation

        public int EduProgramProfileID { get; set; }

        public int EduProgramID { get; set; }

        public int EduLevelId { get; set; }

        public string ProfileCode { get; set; }

        public string ProfileTitle { get; set; }

        public string Languages { get; set; }

        public DateTime? AccreditedToDate { get; set; }

        public DateTime? CommunityAccreditedToDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int LastModifiedByUserID { get; set; }

        public DateTime LastModifiedOnDate { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime CreatedOnDate { get; set; }

        [IgnoreColumn]
        public IEduProgram EduProgram { get; set; }

        [IgnoreColumn]
        public IEduLevel EduLevel { get; set; }

        [IgnoreColumn] 
        public IList<IEduProgramProfileForm> EduProgramProfileForms { get; set; }

        [IgnoreColumn] 
        public IList<IDocument> Documents { get; set; }

        #endregion

        [IgnoreColumn]
        public string EduProgramProfileString
        {
            get {
                if (EduProgram != null) {
                    return FormatHelper.FormatEduProgramProfileTitle (
                        EduProgram.Code,
                        EduProgram.Title,
                        ProfileCode,
                        ProfileTitle); 
                }

                return FormatHelper.FormatEduProgramProfileTitle (
                    string.Empty,
                    string.Empty,
                    ProfileCode,
                    ProfileTitle);
            }
        }
    }
}

