using developmentSpace1.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace developmentSpace1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        IStudentRepository studentRepository = new StudentRepository();
        //AppDbContext _context= new AppDbContext();
        Student? std { set; get; }
        public int stdId { set; get; }
        public Window3 ( int id )
        {
            InitializeComponent();
            stdId = id;
            std = studentRepository.GetById(stdId);
            Show();
        }
        public void Show()
        {
            if (std != null) {
                show.Text = studentRepository.GetById(stdId).FiniceDue.ToString();


            }
        }
        //public void nital(string name, double finiceDue , DateTime? dta ,string status ) { 
        //    this.std=new Student();
        //    this.std.Name=name;
        //    this.std.FiniceDue =finiceDue;
        //    this.std.CreatedDate = dta;
        //    this.std.status = status;
        //}
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
            Close();

        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            if (std != null)
            {
                double payed;

                if (double.TryParse(edit.Text, out payed))
                {
                    std.FiniceDue -= payed;
                    studentRepository.Update(std);
                    //MessageBox.Show("تمت عمليه الدفع بنجاح!");
                    Show();

                }
            }
        }
    }
}
