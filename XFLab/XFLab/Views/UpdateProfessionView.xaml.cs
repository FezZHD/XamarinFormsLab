using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFLab.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateProfessionView : ContentPage
    {
        public UpdateProfessionView()
        {
            BindingContext = new ChangeProfessionViewModel(Navigation);
            InitializeComponent();
        }
    }
}