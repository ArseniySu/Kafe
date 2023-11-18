using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
using Document = iTextSharp.text.Document;

namespace Kafe
{
    /// <summary>
    /// Логика взаимодействия для WaiteWindow.xaml
    /// </summary>
    public partial class WaiteWindow : Window
    {
        public WaiteWindow()
        {
            InitializeComponent();
            InitData1();
        }
        private void InitData1()
        {
            WaiteDGrid.ItemsSource = Helper.db.DishOrder.ToList();
        }
        private void WaiteDGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            new MainWindow(WaiteDGrid.SelectedItem as DishOrder).ShowDialog();
            InitData1();
        }

        private void LogoutBtn1_Click(object sender, RoutedEventArgs e)
        {
            new AutoWindow().Show();
            this.Close();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            new NewOrderWindow().Show();
            this.Show();
        }

        private void DuwdBtn_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("F:\\Order.pdf", FileMode.Create);
            var document = new Document();
            PdfWriter.GetInstance(document, fs);
            BaseFont baseFont = BaseFont.CreateFont("F:\\RusFont.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
            document.Open();
            foreach (var i in Helper.db.DishOrder.ToList())
            {
                document.Add(new iTextSharp.text.Paragraph($"Номер заказа: {i.Id} | Блюдо: {i.Dish.DishName} | " +
                    $"Статус готовки: {i.StatusCook.StCook} | Статус оплаты: {i.StatusOrder.Status} | Количество порций: {i.Count} \n ", font));
            }
            document.Close();
            MessageBox.Show("успешно");
        }
    }
}
