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
    /// Логика взаимодействия для AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Page
    {
        public Recipes recipes = new Recipes();
        StringBuilder sb = new StringBuilder();

        public AddRecipe(Recipes recipe)
        {
            InitializeComponent();

            Fill();
            if (recipe != null) {

                recipes = recipe;
            }

            DataContext = recipes;
        }

        public void Fill()
        {
            var category = AppConnect.culinary_book_entities1.Categories;
            cmbCategory.Items.Add("Категория");
            foreach (var categoryItem in category)
            {
                cmbCategory.Items.Add(categoryItem.CategoryName);
            }
            cmbCategory.SelectedIndex = 0;

            var author = AppConnect.culinary_book_entities1.Authors;
            cmbAuthor.Items.Add("Автор");
            foreach (var authorsItem in author)
            {
                cmbAuthor.Items.Add(authorsItem.AuthorName);
            }
            cmbAuthor.SelectedIndex = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(recipes.RecipeName))
            {
                sb.AppendLine("Не указано название!");
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                sb.Clear();
            }
            else
            {
                string msg = "Запись добавлена";

                if (recipes.RecipeID == 0)
                {
                    recipes.CategoryID = AppConnect.culinary_book_entities1.Categories.FirstOrDefault(x => x.CategoryName == cmbCategory.Text).CategoryID;
                    recipes.AuthorID = AppConnect.culinary_book_entities1.Authors.FirstOrDefault(x=> x.AuthorName == cmbAuthor.Text).AuthorID;

                    AppConnect.culinary_book_entities1.Recipes.Add(recipes);
                }
                try
                {
                    AppConnect.culinary_book_entities1.SaveChanges();
                    MessageBox.Show(msg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            AppFrame.FrameMain.Navigate(new PageTask());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.GoBack();
        }
    }
}
