using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCETNChapter.Models.DataAccess
{
    public class MemberDA
    {
        public static List<string> GetCountryList()
        {
            var countryList = new List<string>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetCountryList().ToList();

                if (response.Count >= 1)
                {
                    countryList.Add("-- Select Country --");
                    for (int i = 0; i < response.Count; i++)
                    {
                        countryList.Add(response.ElementAt(i).Country);
                    }
                }
            }
            return countryList;
        }


        public static List<string> GetGenderList()
        {
            var genderList = new List<string>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetGenderList().ToList();

                if (response.Count >= 1)
                {
                    genderList.Add("-- Select Gender --");
                    for (int i = 0; i < response.Count; i++)
                    {
                        genderList.Add(response.ElementAt(i).Gender);
                    }
                }
            }
            return genderList;
        }


        public static List<string> GetBranchList()
        {
            var branchList = new List<string>();
            using (GCE_TN_ChapterEntities db = new GCE_TN_ChapterEntities())
            {
                var response = db.prcGetBranchList().ToList();

                if (response.Count >= 1)
                {
                    branchList.Add("-- Select Branch --");
                    for (int i = 0; i < response.Count; i++)
                    {
                        branchList.Add(response.ElementAt(i).Branch);
                    }
                }
            }
            return branchList;
        }
    }
}