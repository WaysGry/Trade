using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using System.Reflection;

namespace Trade
{
    /// <summary>
    /// Логика взаимодействия для Trade.xaml
    /// </summary>
    public class SortItem
    {
        public string DName { get; set; }
        public string PName { get; set; }
        public bool AName { get; set; }

    }
    public partial class Trade : Page
    {
        public ObservableCollection<Product> Product { get; set; }

        public ObservableCollection<Category> Category { get; set; }

        public static TradeEntities connection = new TradeEntities();
        public ObservableCollection<SortItem> SortItems { get; set; } = new ObservableCollection<SortItem>()
        {
            new SortItem() { DName = "По возрастанию наименования", PName = "ProductName", AName = true},
            new SortItem() { DName = "По убыванию наименования", PName = "ProductName", AName = false},
            new SortItem() { DName = "По возрастанию остатка", PName = "ProductQuantityInStock", AName = true},
            new SortItem() { DName = "По убыванию остатка", PName = "ProductQuantityInStock", AName = false}

        };


        public Trade()
        {
            InitializeComponent();
            Product = new ObservableCollection<Product>();
            Category = new ObservableCollection<Category>();
            Filtration.ItemsSource = connection.Category.ToList();
            connection.Product.ToList().ForEach(material => Product.Add(material));
            DataContext = this;
        }


        private void SortByName(string property, bool asc = true)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Trades.ItemsSource);
            if (view == null) return;

            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(property, asc ? ListSortDirection.Ascending : ListSortDirection.Descending));
        }


        private void FilterByName(string Category)
        {
            ICollectionView view_2 = CollectionViewSource.GetDefaultView(Trades.ItemsSource);
            if (view_2 == null) return;

            view_2.Filter = new Predicate<object>(obj =>
            {
                if (Category == "Все типы")
                    return true;
                return ((Product)obj).ProductCategory == Category;
            });

        }

        private void SearchBy(string substring)
        {
            ICollectionView view_3 = CollectionViewSource.GetDefaultView(Trades.ItemsSource);
            if (view_3 == null) return;
            view_3.Filter = new Predicate<object>(obj =>
            {
                return (((Product)obj).ProductName.ToLower().Contains(substring.ToLower()));

            });

        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortItem sortItem = Sort.SelectedItem as SortItem;
            SortByName(sortItem.PName, sortItem.AName);

        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = Filtration.SelectedItem as Category;
            FilterByName(category.NameCategory);
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBy(Search.Text);
        }
    }
}
