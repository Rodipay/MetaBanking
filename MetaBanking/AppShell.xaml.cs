using MetaBanking.ViewModel;
using MetaBanking.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MetaBanking
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }
    }
}
