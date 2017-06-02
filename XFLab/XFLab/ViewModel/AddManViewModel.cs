using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFLab.Model.Types;

namespace XFLab.ViewModel
{
    public class AddManViewModel :BaseViewModel
    {


        private ImageSource image;

        public ImageSource Picture {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }


        public AddManViewModel(INavigation navigation, PeopleListType people)
        {
            this.navigation = navigation;
            ButtonText = "Edit";
            IsEditable = false;
            Picture = people.Image;
            Profession = people.Profession;
            Name = people.Name;
            Description = people.Description;
            EditCommand = new Command(() =>
            {
                if (!IsEditable)
                {
                    IsEditable = true;
                    ButtonText = "Save";
                }
                else
                {
                    ButtonText = "Edit";
                    var newPeople = new PeopleListType
                    {
                        Description = this.Description,
                        Image = Picture,
                        Name = this.Name,
                        Profession = this.Profession
                    };
                    MessagingCenter.Send(this, "update", newPeople);
                    IsEditable = false;
                }
            });
        }



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


        private string profession;

        public string Profession
        {
            get { return profession; }
            set
            {
                profession = value;
                OnPropertyChanged();
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }


        private string buttonTitle;

        public string ButtonText
        {
            get { return buttonTitle; }
            set
            {
                buttonTitle = value;
                OnPropertyChanged();
            }
        }


        private bool isEditable;

        public bool IsEditable
        {
            get { return isEditable; }
            set
            {
                isEditable = value;
                OnPropertyChanged();
            }
        }


        public ICommand EditCommand { get; set; }
    }
}
