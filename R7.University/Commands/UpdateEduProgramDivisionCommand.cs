//
//  UpdateEduProgramDivisionsCommand.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2017-2018 Roman M. Yagodin
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

using System.Collections.Generic;
using R7.Dnn.Extensions.Models;
using R7.University.EditModels;
using R7.University.ModelExtensions;
using R7.University.Models;

namespace R7.University.Commands
{
    public class UpdateEduProgramDivisionsCommand
    {
        protected readonly IModelContext ModelContext;

        public UpdateEduProgramDivisionsCommand (IModelContext modelContext)
        {
            ModelContext = modelContext;
        }

        public void Update (IEnumerable<IEditModel<EduProgramDivisionInfo>> epDocs, ModelType modelType, int itemId)
        {
            foreach (var epDoc in epDocs) {
                var epd = epDoc.CreateModel ();
                switch (epDoc.EditState) {
                case ModelEditState.Added:
                    epd.SetModelId (modelType, itemId);
                    ModelContext.Add (epd);
                    break;
                case ModelEditState.Modified:
                    ModelContext.UpdateExternal (epd);
                    break;
                case ModelEditState.Deleted:
                    ModelContext.RemoveExternal (epd);
                    break;
                }
            }
        }
    }
}

