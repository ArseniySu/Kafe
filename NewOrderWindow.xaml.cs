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
    /// Логика взаимодействия для NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        Order newOrder;

        public NewOrderWindow()
        {
            InitializeComponent();

            DisnNameTBox.ItemsSource = Helper.db.Dish.ToList();
        }
     
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(OrderTBox.Text))
            {
                if (newOrder == null)
                {
                    Order order = new Order()
                    {
                        OrName = OrderTBox.Text
                    };
                    Helper.db.Order.Add(order);
                    Helper.db.SaveChanges();

                    newOrder = Helper.db.Order.OrderByDescending(r => r.Id).First();
                }
                else
                {
                    if (int.Parse(CountDishTBox.Text) > 0)
                    {
                        DishOrder dishOrder = new DishOrder()
                        {
                            IdOrder = newOrder.Id,
                            IdStatus = 1,
                            IdStCook = 1,
                            Count = int.Parse(CountDishTBox.Text),
                            IdDish = int.Parse(DisnNameTBox.SelectedValue.ToString())
                        };
                        Helper.db.DishOrder.Add(dishOrder);
                        Helper.db.SaveChanges();
                        MessageBox.Show("add");
                    }
                }
            }
            else
            {
                MessageBox.Show("Поле пустое", "Поле", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
