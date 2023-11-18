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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DishOrder waite;
        public MainWindow(DishOrder waite)
        {
            InitializeComponent();
            StWaiteCbox.ItemsSource = Helper.db.StatusOrder.ToList();
            this.waite = waite;
            StWaiteCbox.SelectedValue = waite.IdStatus;
            NumberTBox.Text = waite.Order.Id.ToString();
            DishTBox1.Text = waite.Dish.DishName;
            PriseTBox1.Text = waite.Dish.Prise;
            TimeTBox1.Text = waite.Dish.Time;
            StCook.Text = waite.StatusCook.StCook;
        }
        private void Edit1(DishOrder waite)
        {
            waite.IdStatus = Int32.Parse(StWaiteCbox.SelectedValue.ToString());

            Helper.db.SaveChanges();
            Close();
        }
        private void editBtn1_Click(object sender, RoutedEventArgs e)
        {
            Edit1(waite);
        }

        private void BackBtn1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
