using Entites.Data;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.ViweModel.Course
{
    public class UniqeNameAttriute:ValidationAttribute
    {
        private readonly ElearingDbcontext dbcontext;
        public UniqeNameAttriute(ElearingDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        
        protected override ValidationResult? IsValid(object? value,ValidationContext validationContext)
        {
            string title = value.ToString();
            var course= dbcontext.Courses.FirstOrDefault(c=>c.Title==title);
            if (course is null)
                return ValidationResult.Success;
            return ValidationResult.Success;

        }
    }
}
