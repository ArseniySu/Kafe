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
    /// Логика взаимодействия для StCookWindow.xaml
    /// </summary>
    public partial class StCookWindow : Window
    {
        private DishOrder cook;      
        public StCookWindow(DishOrder cook)
        {
            InitializeComponent();
            StCookCbox.ItemsSource = Helper.db.StatusCook.ToList();
            this.cook = cook;
            StCookCbox.SelectedValue = cook.IdStCook;
            NumberOrderTBox.Text = cook.Order.Id.ToString();
            DishTBox.Text = cook.Dish.DishName;
            PriseTBox.Text = cook.Dish.Prise;
            TimeTBox.Text = cook.Dish.Time;
            StTBox.Text = cook.StatusOrder.Status;
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit(cook);
        }
        private void Edit(DishOrder cook)
        {
            cook.IdStCook = Int32.Parse(StCookCbox.SelectedValue.ToString());

            Helper.db.SaveChanges();
            Close();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
