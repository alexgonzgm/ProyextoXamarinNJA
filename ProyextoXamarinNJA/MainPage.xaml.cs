using ProyextoXamarinNJA.MenuItems;
using ProyextoXamarinNJA.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyextoXamarinNJA
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList
        {
            get;
            set;
        }
        public MainPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();
            // Adding menu items to menuList and you can define title ,page and icon  
            menuList.Add(new MasterPageItem()
            {
                Title = "Home",
                Icon = "login.png",
                TargetType = typeof(LoginPage)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Mi perfil",
                Icon = "usuario.png",
                TargetType = typeof(CochesView)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Mis coches",
                Icon = "parking.png",
                TargetType = typeof(CochesView)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Foro",
                Icon = "foro.png",
                TargetType = typeof(ForoView)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Logout",
                Icon = "logout.png",
                TargetType = typeof(CochesView)
            });
            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(LoginPage)));
        }
        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
