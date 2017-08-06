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
    
    public partial class PeopleList : ContentPage
    {
        public PeopleList()
        {
            BindingContext = new PeopleViewModel(Navigation);
            InitializeComponent();
        }

     
        

        private void ListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = sender as ListView;
            if (list != null)
            {
                list.SelectedItem = null;
            }
        }
    }
}