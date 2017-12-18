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

namespace WarCollege
{
    /// <summary>
    /// Convience class used to contian all of the Inversion of Control 
    /// container initialization.
    /// </summary>
    public static class IocBootstraper
    {
        /// <summary>
        /// Registers the custom <see cref="Module"/>'s for the application.
        /// </summary>
        /// <param name="builder">The Autofac <see cref="T:Autofac.ContainerBuilder" /></param>
        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<Modules.NLogModule>();
            builder.RegisterModule<Modules.ValidationModule>();
        }

        /// <summary>
        /// Registers the configuration management and settings mechanisms.
        /// </summary>
        /// <param name="builder">The Autofac <c>ContainerBuilder</c></param>
        private static void RegisterConfig(ContainerBuilder builder)
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
        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder
                .RegisterType<Commands.About>()
                .As<Commands.IAboutCommand>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Commands.Quit>()
                .As<Commands.IQuitCommand>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Commands.Preferences>()
                .As<Commands.IPreferencesCommand>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Commands.NewCharacter>()
                .As<Commands.INewCharacterCommand>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Commands.OpenCharacter>()
                .As<Commands.IOpenCharacterCommand>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Commands.SaveCharacter>()
                .As<Commands.ISaveCharacterCommand>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Commands.SaveCharacterAs>()
                .As<Commands.ISaveCharacterAsCommand>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Commands.SaveAllCharacters>()
                .As<Commands.ISaveAllCharactersCommand>()
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Registers the modal dialogs.
        /// </summary>
        /// <param name="builder">The Autofac <c>ContainerBuilder</c></param>
        private static void RegisterDialogs(ContainerBuilder builder)
        {
            builder
                .RegisterType<Dialogs.About>()
                .As<Dialogs.IAboutDialog>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Dialogs.Preferences>()
                .As<Dialogs.IPreferencesDialog>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder
                .RegisterType<Services.CharacterInitializationService>()
                .As<Services.ICharacterInitializationService>()
                .SingleInstance();
        }

        /// <summary>
        /// Builds the IoC container.
        /// </summary>
        /// <returns>An <c>IContainer</c></returns>
        public static IContainer InitializeContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Program>()
                   .As<Eto.Forms.Application>()
                   .SingleInstance()
                   .OnActivated(e => e.Instance.Run());

            builder.RegisterType<MainForm>()
                   .As<Eto.Forms.Form>();

            RegisterModules(builder);
            RegisterConfig(builder);
            RegisterCommands(builder);
            RegisterDialogs(builder);
            RegisterServices(builder);

            builder.RegisterBuildCallback(container => container.Resolve<Eto.Forms.Application>());

            return builder.Build();
        }
    }
}
