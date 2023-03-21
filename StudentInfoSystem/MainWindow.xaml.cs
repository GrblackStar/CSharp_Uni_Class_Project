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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // partial means only one part of the class is defined in this file
    public partial class MainWindow : Window
    {
        public bool logged = false;

        public MainWindow()
        {
            InitializeComponent();

            // this.Title = "Студентска информационна система";

        }

        // add new object of type Student
        /*Добавете публично свойство на MainWindow от тип Student. 
        -Ако му се присвои попълнен обект да активира контролите и да ги попълва с неговите
        данни.
        -Ако му се присвои непопълнен обект (или null) да изчиства контролите и да ги
        деактивира.
        Преизползвайте съществуващите методи.
        За тестови цели може да поставите временни бутони, които да задават
        стойности.
        */

        private void clearAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }

        private void showStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentData.TestStudents[0];
            
            firstNameText.Text = student.familyname;
            middleNameText.Text = student.surname;
            lastNameText.Text = student.familyname;
            facultyText.Text = student.faculty;
            specialtyText.Text = student.specialty;
            educationDegreeText.Text = student.qualificationDegree;
            statusText.Text = student.statusOfStudying;
            facultyNumberText.Text = student.facultyNumber;
            courseText.Text = student.course.ToString();
            potokText.Text = student.potok.ToString();
            groupText.Text = student.group.ToString();
        }

        private void deactivateAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void activateAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //logged = true;
            if (!logged)
            {
                //logged = false;
                activateAllFieldsButton_Click(sender, e);
                //showStudentButton_Click(sender, e);
                int facN = Convert.ToInt32(StudentData.TestStudents[0].facultyNumber);
                foreach (Student s in StudentData.TestStudents)
                {
                    if (Convert.ToInt32(s.facultyNumber) < facN)
                    {
                        facN = Convert.ToInt32(s.facultyNumber);
                    }
                }

                Student student = new Student();
                student = StudentData.TestStudents.Where(x => x.facultyNumber == facN.ToString()).FirstOrDefault();

                firstNameText.Text = student.name;
                middleNameText.Text = student.surname;
                lastNameText.Text = student.familyname;
                facultyText.Text = student.faculty;
                specialtyText.Text = student.specialty;
                educationDegreeText.Text = student.qualificationDegree;
                statusText.Text = student.statusOfStudying;
                facultyNumberText.Text = student.facultyNumber;
                courseText.Text = student.course.ToString();
                potokText.Text = student.potok.ToString();
                groupText.Text = student.group.ToString();


                loginButton.Content = "Log Out";
                logged = true;
            }
            else
            {
                clearAllButton_Click(sender, e);
                loginButton.Content = "LOGIN";
                logged = false;
            }

            
            //logged = true;
            //Logout(logged);
        }

    }
}
