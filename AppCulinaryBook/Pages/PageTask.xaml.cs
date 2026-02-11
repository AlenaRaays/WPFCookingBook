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
        List<Recipes> recipes;
        public PageTask()
        {
            InitializeComponent();
            ProductsList.ItemsSource = AppConnect.culinary_book_entities1.Recipes.ToList();
            SortBox.Items.Add("gj dhtvtyb");
            SortBox.Items.Add("По возрастанию");
            SortBox.Items.Add("По убыванию");

            var category = AppConnect.culinary_book_entities1.Categories;
            FilterBox.Items.Add("Категория");
            foreach (var categoryItem in category)
            {
                FilterBox.Items.Add(categoryItem.CategoryName);
            }
            FilterBox.SelectedIndex = 0;
            SortBox.SelectedIndex = 0;

        }

        Recipes[] SearchRecipe()
        {
            try
            {
                recipes = AppConnect.culinary_book_entities1.Recipes.ToList();
                if (SearchBox != null)
                {
                    recipes = recipes.Where(x => x.RecipeName.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
                }

                if (FilterBox.SelectedIndex > 0)
                {
                    switch(FilterBox.SelectedIndex)
                    {
                        case 1:
                            recipes = recipes.Where(x => x.CategoryID == 1).ToList(); 
                            break;
                        case 2:
                            recipes = recipes.Where(x => x.CategoryID == 2).ToList();
                            break;
                        case 3:
                            recipes = recipes.Where(x => x.CategoryID == 3).ToList();
                            break;
                        case 4:
                            recipes = recipes.Where(x => x.CategoryID == 4).ToList();
                            break;
                        case 5:
                            recipes = recipes.Where(x => x.CategoryID == 5).ToList();
                            break;
                        case 6:
                            recipes = recipes.Where(x => x.CategoryID == 6).ToList();
                            break;

                    }
                }

                if (SortBox.SelectedIndex > 0)
                {
                    switch (SortBox.SelectedIndex)
                    {
                        case 1:
                            recipes = recipes.OrderBy(x => x.CookingTime).ToList();
                            break;
                        case 2:
                            recipes = recipes.OrderByDescending (x => x.CookingTime).ToList();
                            break;
                    }
                }
                return recipes.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
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
        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
           
            ProductsList.ItemsSource = SearchRecipe();
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
         
           
            ProductsList.ItemsSource = SearchRecipe(); 
        }
    }
}
