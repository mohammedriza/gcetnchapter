using GCETNChapter.Models.ViewModels.ManageAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class AccessManagerDA
    {
        public List<AccessLevelsVO> GetUserAccessLevels(string AccessRole)
        {
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var accessLevels = new List<AccessLevelsVO>();
                var response = db.prcGetAccessLevelDetails(AccessRole).ToList();

                for (int x = 0; x < response.Count; x++)
                {
                    accessLevels.Add(new AccessLevelsVO()
                    {
                        AccessID = response.ElementAt(x).AccessID,
                        AccessLevel = response.ElementAt(x).AccessLevel,
                        AccessRole = response.ElementAt(x).AccessRole,
                        Page = response.ElementAt(x).Page,
                        GrantAccess = Convert.ToBoolean(response.ElementAt(x).GrantAccess),
                        CreatedBy = response.ElementAt(x).CreatedBy,
                        CreatedDate = response.ElementAt(x).CreatedDate,
                        ModifiedBy = response.ElementAt(x).ModifiedBy,
                        ModifiedDate = response.ElementAt(x).ModifiedDate
                    });
                }
                return accessLevels;
            }
        }
    }
}