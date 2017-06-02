using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFLab.Model;
using XFLab.Model.Types;
using XFLab.Views;

namespace XFLab.ViewModel
{
    public class PeopleViewModel:BaseViewModel
    {


        public ObservableCollection<PeopleListType> PeopleLists { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }


        public PeopleViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            Name = "kek";
            PeopleLists = new ObservableCollection<PeopleListType>();
            var list = JsonWorker.GetPeoples();
            AddToCollection(list);
    
        }


        private void AddToCollection(List<JsonPeopleType> list)
        {
            foreach (var man in list)
            {
                PeopleLists.Add(new PeopleListType
                {
                    Description = man.Description,
                    Name = man.Name,
                    Profession = man.Profession,
                    Image = ImageSource.FromFile(man.ImageLink)
                });
            }
        }
    }
}
