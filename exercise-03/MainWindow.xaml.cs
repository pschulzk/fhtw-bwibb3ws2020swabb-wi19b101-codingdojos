using exercise_03.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exercise_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Student> Students = new List<Student>();
        List<string> ProgList = new List<string>();
        private int changePos = -1; //stores the pos of the changed element;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveBtnClicked(object sender, RoutedEventArgs e)
        {
            if (cboProg.SelectedItem == null)
            {
                MessageBox.Show("Fehler: Feld Studiengang nicht gewählt.", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Students.Add(new Student()
            {
                Age = int.Parse(tboAge.Text),
                Firstname = tboFName.Text,
                Lastname = tboLName.Text,
                HasPaid = chkPaid.IsChecked.GetValueOrDefault(),
                Program = cboProg.SelectedItem.ToString()
            });
            UpdateStudentDataGrid();
        }

        private void UpdateStudentDataGrid()
        {
            dtgStudentData.ItemsSource = null;
            dtgStudentData.ItemsSource = Students;
        }

        private void EditBtnClicked(object sender, RoutedEventArgs e)
        {
            Student selected = dtgStudentData.SelectedItem as Student;
            changePos = dtgStudentData.SelectedIndex;

            if (selected != null)
            {
                tboAge.Text = selected.Age + "";
                tboFName.Text = selected.Firstname;
                tboLName.Text = selected.Lastname;
                chkPaid.IsChecked = selected.HasPaid;
                cboProg.SelectedItem = selected.Program;

                //deletes the entry from the list
                Students.RemoveAt(dtgStudentData.SelectedIndex);
                UpdateStudentDataGrid();
            }
        }
        private void MasterDataSaveBtnClicked(object sender, RoutedEventArgs e)
        {
            ProgList.Add(tboNewProg.Text);
            UpdateProgList();

        }

        private void UpdateProgList()
        {
            lboProgs.ItemsSource = null;
            lboProgs.ItemsSource = ProgList;
            cboProg.ItemsSource = null;
            cboProg.ItemsSource = ProgList;
        }

        private void DeleteBtnClicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DeleteBtnClicked -> dtgStudentData.SelectedIndex: " + dtgStudentData.SelectedIndex.ToString());
            if (dtgStudentData.SelectedIndex == -1 || Students.Count == 0) return;
            if (dtgStudentData.SelectedIndex + 1 > dtgStudentData.Items.Count) return;
            Students.RemoveAt(dtgStudentData.SelectedIndex);
            UpdateStudentDataGrid();
        }
    }
}
