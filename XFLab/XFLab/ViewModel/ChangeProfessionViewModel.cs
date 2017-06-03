using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFLab.Model;
using XFLab.Model.Types;

namespace XFLab.ViewModel
{
    public class ChangeProfessionViewModel:BaseViewModel
    {


        public ObservableCollection<Job> JobsList { get; set; }
        public ChangeProfessionViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            JobsList = new ObservableCollection<Job>(JobsSingletone.Instance.JobsList);
            SelectProfession = new Command(async (o) =>
            {
                var job = o as Job;
                if (job != null)
                {
                    MessagingCenter.Send(this, "job", job.Profession);
                    await navigation.PopAsync(true);
                }
            });
        }

        private Job item;

        public Job Item
        {
            get { return item; }
            set
            {
                if (value == null)
                {
                    return;
                }
                item = value;
                OnPropertyChanged();
                SelectProfession.Execute(item);
            }
        }


        public ICommand SelectProfession { get; set; }
    }
}
