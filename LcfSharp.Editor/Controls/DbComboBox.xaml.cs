using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using LcfDatabase = LcfSharp.Rpg.Database;

namespace LcfSharp.Editor.Controls
{
    /// <summary>
    /// Interaction logic for DbComboBox.xaml
    /// </summary>
    public partial class DbComboBox : UserControl
    {
        public static readonly DependencyProperty DatabaseProperty = DependencyProperty.Register(
           nameof(Database), typeof(LcfDatabase), typeof(DbComboBox), new PropertyMetadata(null));

        public LcfDatabase Database
        {
            get => (LcfDatabase)GetValue(DatabaseProperty);
            set => SetValue(DatabaseProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
           nameof(ItemsSource), typeof(string), typeof(DbComboBox), new PropertyMetadata(null));

        public string ItemsSource
        {
            get => (string)GetValue(ItemsSourceProperty);
            set
            {
                SetValue(ItemsSourceProperty, value);
                UpdateSource();
            }
        }

        public DbComboBox()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateSource();
        }

        private void UpdateSource()
        {
            //if (Database != null && !string.IsNullOrEmpty(ItemsSource))
            //{
            //    var property = typeof(LcfDatabase).GetProperty(ItemsSource, BindingFlags.Public | BindingFlags.Instance);
            //    ComboBox.ItemsSource = (IEnumerable)property.GetValue(Database, null);
            //}
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateSource();
        }
    }
}
