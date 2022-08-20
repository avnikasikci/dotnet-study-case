using Infrastructure.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class NewsAgency
    {
        public int Id { get; set; }
        //public int NewsAgencyTranslateId { get; set; }
        public string Name { get; set; }
        public string JsonTranslate { get; set; }
        public virtual IList<NewsAgencyTranslate> translateList { get => (UtilityJson.JsonDeserialize<IList<NewsAgencyTranslate>>(JsonTranslate)); set { JsonTranslate = UtilityJson.JsonSerialize(value); } }


        //public virtual ICollection<NewsAgencyTranslate> translateList { get; set; }
        //public NewsAgency()
        //{
        //    translateList = new List<NewsAgencyTranslate>();
        //}

    }
    [NotMapped]
    public class NewsAgencyTranslate
    {
        //public int Id { get; set; }
        //public int NewsAgencyId { get; set; }
        public int LocaleId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrls { get; set; }
        //public string Category { get; set; }
        //public bool Active { get; set; }
        //public virtual NewsAgency NewsAgency { get; set; }
    }
    public class NewsAgencyCategory
    {
        public int Id { get; set; }
        public string Key { get; set; }

        public string JsonTranslate { get; set; }
        public virtual IList<NewsAgencyCategoryTranslate> translateList { get => (UtilityJson.JsonDeserialize<IList<NewsAgencyCategoryTranslate>>(JsonTranslate)); set { JsonTranslate = UtilityJson.JsonSerialize(value); } }
        //public virtual ICollection<NewsAgencyCategory> translateList { get; set; }
        //public NewsAgencyCategory()
        //{
        //    translateList = new List<NewsAgencyCategory>();
        //}
    }
    [NotMapped]
    public class NewsAgencyCategoryTranslate
    {
        //public int Id { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
        //public virtual NewsAgencyCategoryTranslate newsAgencyCategoryTranslate { get; set; }

    }
}
