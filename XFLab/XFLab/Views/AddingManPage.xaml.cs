using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFLab.Model.Types;
using XFLab.ViewModel;

namespace XFLab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddingManPage : ContentPage
    {
        public AddingManPage(PeopleListType people)
        {
            BindingContext = new AddManViewModel(Navigation, people);
            InitializeComponent();
        }
    }
}