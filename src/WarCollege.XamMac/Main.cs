/* War College - Copyright(c) 2017 James Allred (wildj79@gmail.com)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge, 
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit
 * persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 */

using AppKit;
using Eto;
using Eto.Mac.Forms;
using Eto.Mac.Forms.Controls;
using Autofac;
using Eto.Mac.Forms.Menu;
using WarCollege;

namespace WarCollege.XamMac
{
    /// <summary>
    /// Main entry point for the Mac version of the application.
    /// </summary>
    static class MainClass
    {
        static void Main(string[] args)
        {
            Style.Add<FormHandler>("MainWindow", handler =>
            {
                handler.Control.CollectionBehavior |= NSWindowCollectionBehavior.FullScreenPrimary;
            });

            //Style.Add<ProgressBarHandler>("ProgressBar", (handler) =>
            //{
            //    handler.Control.ControlTint = NSControlTint.Blue;
            //    handler.Control.Bezeled = true;
            //});

            Style.Add<ButtonMenuItemHandler>(null, handler =>
            {
                handler.ShowImage = true;
            });
            
            var container = IocBootstraper.InitializeContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                //var app = scope.Resolve<Eto.Forms.Application>();
                //app.Run();
            }
        }
    }
}
