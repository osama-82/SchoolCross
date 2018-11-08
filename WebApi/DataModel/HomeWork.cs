using System;
using System.Collections.Generic;

namespace WebApi.DataModel
{
    public partial class HomeWork
    {
        public HomeWork()
        {
            Hwatachment = new HashSet<Hwatachment>();
        }

        public int Id { get; set; }
        public int? EducationalCenterId { get; set; }
        public int ClassId { get; set; }
        public int CurriculumItemId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool? Deleted { get; set; }
        public string Domain { get; set; }

        public ICollection<Hwatachment> Hwatachment { get; set; }
    }
}
