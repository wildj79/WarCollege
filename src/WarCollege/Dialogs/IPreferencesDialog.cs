using Eto.Forms;
using System.Threading.Tasks;

namespace WarCollege.Dialogs
{
    public interface IPreferencesDialog
    {
        void ShowModal(Control parent = null);
        Task ShowModalAsync(Control parent = null);
    }
}
