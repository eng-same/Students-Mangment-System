using developmentSpace1.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace developmentSpace1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        IStudentRepository studentRepository =new StudentRepository();
        private int ItemId=0;
        public Window1()
        {
            InitializeComponent();
            Show_Data();
        }

        private void clear()
        {
            txtStudentName.Clear(); 
            txtFinancialDues.Clear();
            datepic.SelectedDate = DateTime.Now;
            state.Text= string.Empty;
        }

        private void Show_Data()
        {
            StudentListView.ItemsSource = studentRepository.GetAll();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            double financialDues;

            if (double.TryParse(txtFinancialDues.Text, out financialDues))
            {
                studentRepository.Add(new Student
                {
                    Name = txtStudentName.Text,
                    FiniceDue = financialDues,
                    CreatedDate = datepic.SelectedDate ?? DateTime.Now, // إذا لم يتم تحديد تاريخ، استخدم التاريخ الحالي
                    status = state.Text
                });
                clear();
                MessageBox.Show("تمت إضافة الطالب بنجاح!");

                // تحديث القائمة بعد الإضافة
                Show_Data();
            }
            else
            {
                MessageBox.Show("الرجاء إدخال قيمة رقمية صحيحة للحقل المالي.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            double financialDues;

            if (double.TryParse(txtFinancialDues.Text, out financialDues) &&ItemId!=0)
            {
                Student std1 = new Student
                {
                    Name = txtStudentName.Text,
                    FiniceDue = financialDues,
                    CreatedDate = datepic.SelectedDate ?? DateTime.Now, // إذا لم يتم تحديد تاريخ، استخدم التاريخ الحالي
                    status = state.Text
                };
                Window3 widow3 = new Window3(ItemId);
                //widow3.nital(std1.Name, financialDues, std1.CreatedDate ,std1.status);
                widow3.ShowDialog ();
                Show_Data();
                clear();
                Add_Mode();
            }   
        }

        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (ItemId!=0)
            {
                studentRepository.Delete(ItemId);
                clear();
                Add_Mode();
                MessageBox.Show("تمت حذف الطالب بنجاح!");

                // تحديث القائمة بعد الحذف
                Show_Data();
            }
            else
            {
                MessageBox.Show("fffff.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var Item=studentRepository.GetById(ItemId);
            double financialDues;

            if (double.TryParse(txtFinancialDues.Text, out financialDues) && Item != null)
            {
                Item.Name = txtStudentName.Text;
                Item.FiniceDue = financialDues;
                Item.CreatedDate = datepic.SelectedDate ?? DateTime.Now;
                Item.status = state.Text;
                studentRepository.Update(Item);
                clear();
                Add_Mode();
                MessageBox.Show("تمت تعديل بيانات الطالب بنجاح!");
                // تحديث القائمة بعد الإضافة
                Show_Data();
            }
            else
            {
                MessageBox.Show(" الرجاء إدخال قيمة رقمية صحيحة للحقل المالي.", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StudentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentListView.SelectedItem is Student std)
            {
                txtStudentName.Text = std.Name;
                txtFinancialDues.Text = std.FiniceDue.ToString();
                datepic.SelectedDate = std.CreatedDate;
                state.Text =std.status;
                ItemId=std.Id;
                Edit_Mode();
            }
        }
        public void Edit_Mode()
        {
            btnUpdate.IsEnabled = true;
            btnPayment.IsEnabled = true;
            btnDeleteStudent.IsEnabled = true;
            btnAddStudent.IsEnabled = false;
        }
        public void Add_Mode()
        {
            btnUpdate.IsEnabled = false;
            btnPayment.IsEnabled = false;
            btnDeleteStudent.IsEnabled = false;
            btnAddStudent.IsEnabled = true;
        }
    }
}
