using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.Course
{
    public class CreateorUpdateCourseVM
    {
        public string TItle { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string SkillLevel { get; set; }
        public decimal Price { get; set; }
        public string Requirments { get; set; }
    }
}
