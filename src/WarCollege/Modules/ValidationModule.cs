// ValidationModule.cs
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

using Autofac;
using FluentValidation;
using System.Linq;
using WarCollege.Infrastructure;
using WarCollege.Services;

namespace WarCollege.Modules
{
    /// <summary>
    /// Module that registers various validation services.
    /// </summary>
    public class ValidationModule : Module
    {
        /// <summary>
        /// Loads the necessary <c>Type</c>'s into the contianer.
        /// </summary>
        /// <param name="builder">The builder for the applications service container.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();
            builder.RegisterType<FluentValidationService>().As<IValidationService>().SingleInstance();

            base.Load(builder);
        }
    }
}
