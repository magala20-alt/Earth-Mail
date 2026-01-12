using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Postal_Management_System.Presentation.Presenter.Common
{
    public class EntitiyValidation
    {
        public void ValidateEntity(object model) 
        {
            string errorMessage ="";
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model, null, null);
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    errorMessage += validationResult.ErrorMessage + "\n";
                }
                throw new ValidationException(errorMessage);
            }
        }
    }
}
