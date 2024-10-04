using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.Lesson
{
    public class CreateLessonVM
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

    }
}
