﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFLab.ViewModel;

namespace XFLab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectImageView : ContentPage
    {
        public SelectImageView()
        {
            BindingContext = new AddingImageViewModel(Navigation);
            InitializeComponent();
        }
    }
}