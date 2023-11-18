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
using System.Windows.Shapes;

namespace Kafe
{
    /// <summary>
    /// Логика взаимодействия для CookWindow.xaml
    /// </summary>
    public partial class CookWindow : Window
    {
        public CookWindow()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            CookDGrid.ItemsSource = Helper.db.DishOrder.ToList();
        }
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            new AutoWindow().Show();
            this.Close();
        }

        private void UserDGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            new StCookWindow(CookDGrid.SelectedItem as DishOrder).ShowDialog();
            InitData();
        }
    }
}
