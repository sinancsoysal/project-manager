using System;
namespace ProjectsApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isFinished { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public int DevID { get; set; }
    }
}