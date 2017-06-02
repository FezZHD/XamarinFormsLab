using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFLab.Model;
using XFLab.Model.Types;

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
        }
    }
}
