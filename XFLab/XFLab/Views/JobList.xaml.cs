using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFLab.ViewModel;

namespace XFLab.Views
{
    
    public partial class JobList : ContentPage
    {
        public JobList()
        {
            BindingContext = new JobViewModel(Navigation);
            InitializeComponent();
        }
    }
}