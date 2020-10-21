using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table;
        public MainWindow()
        {
   
            InitializeComponent();
        }

        private void MainWindow_Load (object sender, RoutedEventArgs e)
        {
            table = new DataTable();

            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Message", typeof(String));
            table.AcceptChanges();
            dataGridView.DataContext = table;
         

        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            txtMessageBox.Clear();
            txtTitleBox.Clear();
        }
        private void bttSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitleBox.Text, txtMessageBox.Text);
            txtMessageBox.Clear();
            txtTitleBox.Clear();
        }
        private void bttRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView.SelectedIndex;
            if( index > -1)
            {
                txtTitleBox.Text = table.Rows[index].ItemArray[0].ToString();
                txtMessageBox.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }
        private void bttDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView.SelectedIndex;
            table.Rows[index].Delete();
        }

  
    }
}
