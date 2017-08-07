using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFLab.Annotations;
using XFLab.Model;
using XFLab.Model.Types;
using XFLab.Views;

namespace XFLab.ViewModel
{
    public class PeopleViewModel:BaseViewModel
    {


        public ObservableCollection<PeopleListType> PeopleLists { get; set; }



        public PeopleViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            PeopleLists = new ObservableCollection<PeopleListType>();
            var list = JsonWorker.GetPeoples();
            AddToCollection(list);
            AddCommand = new Command(async (o) =>
            { 
                var people = o as PeopleListType;
                if (o == null)
                {
                    MessagingCenter.Subscribe<AddManViewModel, PeopleListType>(this, "update", (model, type) =>
                    {
                        PeopleLists.Add(type);
                        MessagingCenter.Unsubscribe<AddManViewModel, PeopleListType>(this, "update");
                    });
                    var page = new AddingManPage(new PeopleListType());
                    await navigation.PushAsync(page);
                }
                else
                {
                    var index = PeopleLists.IndexOf(people);
                    MessagingCenter.Subscribe<AddManViewModel, PeopleListType>(this, "update", (model, type) =>
                    {
                        PeopleLists[index] = type;
                        MessagingCenter.Unsubscribe<AddManViewModel, PeopleListType>(this, "update");
                    });
                    var page = new AddingManPage(people);
                    await navigation.PushAsync(page);
                }
                Item = null;
            });
        }

        private PeopleListType item;

        public PeopleListType Item
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
