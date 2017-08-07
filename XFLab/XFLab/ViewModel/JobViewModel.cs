using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using XFLab.Model;
using XFLab.Model.Types;
using XFLab.Views;

namespace XFLab.ViewModel
{
    public class JobViewModel:BaseViewModel
    {

        public ObservableCollection<Job> JobsList { get; set; }
        public JobViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            JobsSingletone.Instance.CreateList(JsonWorker.GetJobs());
            JobsList = new ObservableCollection<Job>(JobsSingletone.Instance.JobsList);
            AddCommand = new Command(async (o) =>
            {
                var job = o as Job;
                if (job == null)
                {
                    MessagingCenter.Subscribe<PopUpViewModel, string>(this, "jobUpdate", (model, s) =>
                    {
                        var newJob = new Job
                        {
                            Profession = s
                        };
                        JobsSingletone.Instance.Add(newJob);
                        JobsList.Add(newJob);
                        MessagingCenter.Unsubscribe<PopUpViewModel, string>(this, "jobUpdate");
                    });
                    await navigation.PushPopupAsync(new ProfessionPopUp(new Job()));
                }
                else
                {
                    var index = JobsList.IndexOf(job);
                    MessagingCenter.Subscribe<PopUpViewModel, string>(this, "jobUpdate", (model, s) =>
                    {
                        var newJob = new Job
                        {
                            Profession = s
                        };
                        JobsSingletone.Instance.JobsList[index] = newJob;
                        JobsList[index] = newJob;
                        MessagingCenter.Unsubscribe<PopUpViewModel, string>(this, "jobUpdate");
                    });
                    
                    await navigation.PushPopupAsync(new ProfessionPopUp(job));
                }
                Item = null;
            });
        }


        private Job item;

        public Job Item
        {
            get { return item; }
            set
            {
                item = value;
                if (item != null)
                {
                    AddCommand.Execute(item);
                }
                
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; set; }
    }
}
