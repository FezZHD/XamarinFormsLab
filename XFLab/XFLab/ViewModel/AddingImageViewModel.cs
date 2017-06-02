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
    public class AddingImageViewModel:BaseViewModel
    {

        public ObservableCollection<ImageList> ImageList { get; set; }
        public AddingImageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            ImageList = new ObservableCollection<ImageList>();
            var list = JsonWorker.GetImages();
            AddToCollection(list);
        }


        private ImageList item;

        public ImageList Item
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
            }
        }

        private void AddToCollection(List<ImageListJson> list)
        {
            foreach (var image in list)
            {
                ImageList.Add(new ImageList
                {
                    Name = image.Name,
                    Image = ImageSource.FromFile(image.ImageSource)
                });
            }
        }
    }
}
