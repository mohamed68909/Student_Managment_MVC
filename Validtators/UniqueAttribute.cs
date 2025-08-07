using Student_Managmet_MVC.Data;
using System.ComponentModel.DataAnnotations;

namespace Student_Managmet_MVC.Validtators
{
    public class UniqueAttribute  :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = (AppsContext)validationContext.GetService(typeof(AppsContext));

            string name = value as string;

            var emp = db.Dapartmant.FirstOrDefault(e => e.Name == name);
            if (emp != null)
            {
                return new ValidationResult("Name already Exist !!!");
            }
            return ValidationResult.Success;


        }
    }
}
