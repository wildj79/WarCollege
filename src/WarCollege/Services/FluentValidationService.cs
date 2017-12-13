// FluentValidationService.cs
//
// Author:
//       James Allred <wildj79@gmail.com>
//
// Copyright (c) 2017 James Allred
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using FluentValidation;
using FluentValidation.Results;

namespace WarCollege.Services
{
    /// <summary>
    /// Service used to validate a model.
    /// </summary>
    public class FluentValidationService : IValidationService
    {
        private readonly IValidatorFactory _validatorFactory;

        /// <summary>
        /// Intializes an instance of the <see cref="FluentValidationService"/> class.
        /// </summary>
        /// <param name="validatorFactory">The factory class used to build the validator.</param>
        public FluentValidationService(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        /// <summary>
        /// Validates a model.
        /// </summary>
        /// <typeparam name="T">The model <c>Type</c>.</typeparam>
        /// <param name="entity">The model to validate.</param>
        /// <returns>A <c>ValidationResult</c> for the given model.</returns>
        public ValidationResult Validate<T>(T entity) where T : class
        {
            var validator = _validatorFactory.GetValidator(entity.GetType());
            var result = validator.Validate(entity);

            return result;
        }
    }
}
