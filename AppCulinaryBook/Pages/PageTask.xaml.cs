using AppCulinaryBook.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppCulinaryBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTask.xaml
    /// </summary>
    public partial class PageTask : Page
    {
        public PageTask()
        {
            InitializeComponent();
            ProductsList.ItemsSource = AppConnect.culinary_book_entities1.Recipes.ToList();
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new AddRecipe(null));
        }

        private void ProductsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductsList.SelectedItem is Recipes selrecipes)
            {
                NavigationService.Navigate(new AddRecipe(selrecipes));
                ProductsList.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выделете рецепт");
            }
        }
    }
}
