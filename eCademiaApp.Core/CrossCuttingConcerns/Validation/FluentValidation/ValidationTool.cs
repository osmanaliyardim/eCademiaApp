﻿using FluentValidation;

namespace eCademiaApp.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    // Validation tool to automize FluentValidation operations
    public static class ValidationTool
    {
        /// <summary>This method validates entity.</summary>
        /// <param name="validator">validator object from FluentValidator</param>
        /// <param name="entity">entity object to check</param>
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid) throw new ValidationException(result.Errors);
        }
    }
}
