// War College - Copyright (c) 2017 James Allred (wildj79 at gmail dot com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this 
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge, 
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
// persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or 
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
// OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
// OTHER DEALINGS IN THE SOFTWARE.

using Autofac;
using FluentValidation;
using System;

namespace WarCollege.Infrastructure
{
    /// <summary>
    /// Utility that returns a validator for a model.
    /// </summary>
    public  class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _context;

        /// <summary>
        /// Initializes an instance of the <see cref="AutofacValidatorFactory"/> class.
        /// </summary>
        /// <param name="context">The <see cref="IComponentContext"/> for the application.</param>
        public AutofacValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a validator for a model.
        /// </summary>
        /// <param name="validatorType">The <c>Type</c> that a validator needs to be created for.</param>
        /// <returns>A <see cref="IValidator"/> for the given type.</returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            if (_context.TryResolve(validatorType, out object instance))
            {
                var validator = instance as IValidator;

                return validator;
            }

            return null;
        }
    }
}
