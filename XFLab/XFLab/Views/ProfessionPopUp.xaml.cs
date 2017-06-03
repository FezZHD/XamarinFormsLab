using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFLab.Model.Types;
using XFLab.ViewModel;

namespace XFLab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfessionPopUp : PopupPage
    {
        public ProfessionPopUp(Job job)
        {
            BindingContext = new PopUpViewModel(Navigation, job);
            InitializeComponent();
        }
    }
}