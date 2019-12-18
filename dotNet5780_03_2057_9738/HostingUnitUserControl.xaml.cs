using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace dotNet5780_03_2057_9738
{
    public partial class HostingUnitUserControl : UserControl 
    {
        private HostingUnit m_CurrentUostingUnit;
        int imageIndex;
        Viewbox vbImage;
        Image MyImage;

        public Calendar MyCalender;
        public HostingUnit CurrentUostingUnit { get { return m_CurrentUostingUnit; } set { m_CurrentUostingUnit = value; } }
        private void SetBlackOutDates()
        {
            foreach (DateTime date in CurrentUostingUnit.AllOrders)
            {
                MyCalender.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }
        private Image CreateViewImage()
        {
            Image dynamicImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@CurrentUostingUnit.Uris[imageIndex]);
            bitmap.EndInit();
            // Set Image.Source
            dynamicImage.Source = bitmap;
            // Add Image to Window
            return dynamicImage;
        }
        public HostingUnitUserControl(HostingUnit hostUnit)
        {
            vbImage = new Viewbox();
            InitializeComponent();
            imageIndex = 0;
            vbImage.Width = 75;
            vbImage.Height = 75;
            vbImage.Stretch = Stretch.Fill;
            UserControlGrid.Children.Add(vbImage);
            Grid.SetColumn(vbImage, 2);
            Grid.SetRow(vbImage, 0);
            this.CurrentUostingUnit = hostUnit;
            MyImage = CreateViewImage();
            CurrentUostingUnit = hostUnit;
            UserControlGrid.DataContext = hostUnit;
            vbImage.Child = null;
            vbImage.Child = MyImage;
            MyCalender = CreateCalendar();
            VbCalander.Child = null;
            VbCalander.Child = MyCalender;
            SetBlackOutDates();
            vbImage.MouseUp += vbImage_MouseUp;
            vbImage.MouseEnter += vbImage_MouseEnter;
            vbImage.MouseLeave += vbImage_MouseLeave;
        }
       
        private void vbImage_MouseLeave(object sender, MouseEventArgs e)
        {
            vbImage.Width = 75;
            vbImage.Height = 75;
        }
        private void vbImage_MouseEnter(object sender, MouseEventArgs e)
        {
            vbImage.Width = this.Width / 3;
            vbImage.Height = this.Height;
        }
        private void vbImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            vbImage.Child = null;
            imageIndex =
           (imageIndex + CurrentUostingUnit.Uris.Count - 1) % CurrentUostingUnit.Uris.Count;
            MyImage = CreateViewImage();
            vbImage.Child = MyImage;
        }
        private Calendar CreateCalendar()
        {
            Calendar MonthlyCalendar = new Calendar();
            MonthlyCalendar.Name = "MonthlyCalendar";
            MonthlyCalendar.DisplayMode = CalendarMode.Month;
            MonthlyCalendar.SelectionMode = CalendarSelectionMode.SingleRange;
            MonthlyCalendar.IsTodayHighlighted = true;
            return MonthlyCalendar;
        }
       
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            List<DateTime> myList = MyCalender.SelectedDates.ToList();
            MyCalender = CreateCalendar();
            VbCalander.Child = null;
            VbCalander.Child = MyCalender;
            addCurrentList(myList);
            SetBlackOutDates();
        }
        private void addCurrentList(List<DateTime> tList)
        {
            foreach (DateTime d in tList)
            {
                CurrentUostingUnit.AllOrders.Add(d);
            }
        }
    }
}
