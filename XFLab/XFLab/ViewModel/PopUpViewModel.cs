using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using XFLab.Model.Types;

namespace XFLab.ViewModel
{
    public class PopUpViewModel: BaseViewModel
    {


        private string currentJob;

        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
            set
            {
                currentJob = value;
                OnPropertyChanged();
            }
        }




        public PopUpViewModel(INavigation navigation, Job currentJob)
        {
            this.navigation = navigation;
            CurrentJob = currentJob.Profession;
            CancelCommand = new Command(async () =>
            {
                await navigation.PopPopupAsync(true);
            });

            SaveCommand = new Command(async () =>
            {
                MessagingCenter.Send(this, "jobUpdate", CurrentJob);
                await navigation.PopPopupAsync(true);
            });

        }


        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }
    }
}
