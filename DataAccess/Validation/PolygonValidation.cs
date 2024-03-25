using System.ComponentModel.DataAnnotations;
using BusinessLogic;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccess.Validation;

public class PolygonValidation : ValidationAttribute
{

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var latitude = (double)value;
            var longitude = (double)validationContext.ObjectType.GetProperty("Longitude").GetValue(validationContext.ObjectInstance, null);

            if (!ValidationLogic.IsPointInsidePolygon(latitude, longitude))
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }

}