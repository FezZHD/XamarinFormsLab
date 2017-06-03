using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFLab.Model.Types;
using XFLab.Views;

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
            if (people.Image == null)
            {
                Picture = ImageSource.FromFile("gachi.jpg");
            }
            else
            {
                Picture = people.Image;
            }
            ButtonText = "Edit";
            IsEditable = false;
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
            ChangeImageCommand = new Command(async () =>
            {
                if (IsEditable)
                {
                    MessagingCenter.Subscribe<AddingImageViewModel, ImageSource>(this, "image", (model, source) =>
                    {
                        Picture = source;
                        MessagingCenter.Unsubscribe<AddingImageViewModel, ImageSource>(this, "image");
                    });
                    await navigation.PushAsync(new SelectImageView());
                }
            });
            UpdateProfession = new Command(async () =>
            {
                MessagingCenter.Subscribe<ChangeProfessionViewModel, string>(this, "job", (model, source) =>
                {
                    Profession = source;
                    MessagingCenter.Unsubscribe<AddingImageViewModel, ImageSource>(this, "job");
                });
                await navigation.PushAsync(new UpdateProfessionView());
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


        private ICommand imageCommand;

        public ICommand ChangeImageCommand
        {
            get { return imageCommand; }
            set { imageCommand = value; }
        }


        public ICommand UpdateProfession { get; set; }
    }
}
