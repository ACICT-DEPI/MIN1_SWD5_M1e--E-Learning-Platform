using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.Note
{
    public class GetNoteVM
    {
        public string Text { get; set; }
        public DateTime NoteDate { get; set; } = DateTime.Now;
    }
}
