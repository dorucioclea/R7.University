//
//  UniversityConfig.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016-2017 Roman M. Yagodin
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

using R7.Dnn.Extensions.Configuration;

namespace R7.University.Components
{
    public static class UniversityConfig
    {
        static readonly ExtensionYamlConfig<UniversityPortalConfig> _config;

        static UniversityConfig ()
        {
            _config = new ExtensionYamlConfig<UniversityPortalConfig> ("R7.University.yml", null);
        }

        public static UniversityPortalConfig GetInstance (int portalId)
        {
            return _config.GetInstance (portalId);
        }

        public static UniversityPortalConfig Instance {
            get {        
                return _config.Instance;
            }
        }
    }
}
