using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.User
{
    public class UpadateProfileVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public IFormFile formFile { get; set; }
    }
}
