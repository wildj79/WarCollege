// War College - Copyright (c) 2017 James Allred (wildj79@gmail.com)
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
using Autofac.Extras.NLog;
using System;
using Autofac.Features.AttributeFilters;

namespace WarCollege
{
    /// <summary>
    /// Convience class used to contian all of the Inversion of Control 
    /// container initialization.
    /// </summary>
    public class IocBootstraper
    {
        /// <summary>
        /// Registers NLog for use in the application.
        /// </summary>
        /// <param name="builder">The Autofac <see cref="T:Autofac.ContainerBuilder" /></param>
        protected virtual void RegisterLogging(ContainerBuilder builder)
        {
            builder.RegisterModule<NLogModule>();

            //builder.RegisterType<Logging.NLogStartup>()
            //       .As<IStartable>()
            //       .SingleInstance();
        }

        /// <summary>
        /// Registers the configuration management and settings mechanisms.
        /// </summary>
        /// <param name="builder">The Autofac <c>ContainerBuilder</c></param>
        protected virtual void RegisterConfig(ContainerBuilder builder)
        {
            builder
                .RegisterType<Config.ConfigManager>()
                .As<Config.IConfigManager>()
                .SingleInstance();

            builder
                .Register(ctx => ctx.Resolve<Config.IConfigManager>().LoadConfig())
                .As<Config.IConfigSettings>()
                .SingleInstance();
        }

        /// <summary>
        /// Registers menu and tool bar commands used by the forms.
        /// </summary>
        /// <param name="builder">The Autofac <c>ContainerBuilder</c></param>
        protected virtual void RegisterCommands(ContainerBuilder builder)
        {
            builder
                .RegisterType<Commands.About>()
                .Keyed<Eto.Forms.Command>("aboutCommand")
                .WithAttributeFiltering();
            
            builder
                .RegisterType<Commands.Quit>()
                .Keyed<Eto.Forms.Command>("quitCommand");
            
            builder
                .RegisterType<Commands.Preferences>()
                .Keyed<Eto.Forms.Command>("preferencesCommand")
                .WithAttributeFiltering();

            builder
                .RegisterType<Commands.NewCharacter>()
                .Keyed<Eto.Forms.Command>("newCharacterCommand")
                .WithAttributeFiltering();

            builder
                .RegisterType<Commands.OpenCharacter>()
                .Keyed<Eto.Forms.Command>("openCharacterCommand")
                .WithAttributeFiltering();

            builder
                .RegisterType<Commands.SaveCharacter>()
                .Keyed<Eto.Forms.Command>("saveCharacterCommand")
                .WithAttributeFiltering();

            builder
                .RegisterType<Commands.SaveCharacterAs>()
                .Keyed<Eto.Forms.Command>("saveCharacterAsCommand")
                .WithAttributeFiltering();

            builder
                .RegisterType<Commands.SaveAllCharacters>()
                .Keyed<Eto.Forms.Command>("saveAllCharactersCommand")
                .WithAttributeFiltering();
        }

        /// <summary>
        /// Registers the modal dialogs.
        /// </summary>
        /// <param name="builder">The Autofac <c>ContainerBuilder</c></param>
        protected virtual void RegisterDialogs(ContainerBuilder builder)
        {
            builder
                .RegisterType<Dialogs.About>()
                .Keyed<Eto.Forms.Dialog>("aboutDialog");
            
            builder
                .RegisterType<Dialogs.Preferences>()
                .Keyed<Eto.Forms.Dialog>("preferencesDialog");
        }

        /// <summary>
        /// Builds the IoC container.
        /// </summary>
        /// <returns>An <c>IContainer</c></returns>
        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Program>()
                   .As<Eto.Forms.Application>()
                   .SingleInstance()
                   .OnActivated(e => e.Instance.Run());

            builder.RegisterType<MainForm>()
                   .As<Eto.Forms.Form>();

            RegisterLogging(builder);
            RegisterConfig(builder);
            RegisterCommands(builder);
            RegisterDialogs(builder);

            builder.RegisterBuildCallback(container => container.Resolve<Eto.Forms.Application>());

            return builder.Build();
        }
    }
}
