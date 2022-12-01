using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using SytleAndCommands.Commands;

namespace SytleAndCommands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public class DataObject
        {
            public int TheValue { get; set; }
        }



        private int age;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(); }
        }

        private string userText;

        public string UserText
        {
            get { return userText; }
            set { userText = value; OnPropertyChanged(); }
        }


        public MessageCommand MessageCommand { get; set; }
        public MessageCommand OpenNewWindow { get; set; }

        public RelayCommand ShowDataCommand { get; set; }
        public RelayCommand UsernameEnterCommand { get; set; }
        public RelayCommand PasswordEnterCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new DataObject();
            this.DataContext = this;

            UserText = string.Empty;

            //MessageCommand = new MessageCommand(() =>
            //{
            //    MessageBox.Show("I clicked to Send Message");
            //});

            //OpenNewWindow = new MessageCommand(() =>
            //{
            //    MessageBox.Show("I opened New Window");
            //});

            //ShowDataCommand = new RelayCommand((o) =>
            //{
            //    MessageBox.Show("Test");
            //}, (o) =>
            //{
            //    return Age >= 18;
            //});


            //ShowDataCommand = new RelayCommand((o) =>
            //{
            //    MessageBox.Show("Test");
            //});
            UsernameEnterCommand = new RelayCommand((o) =>
            {
                var myStackPanel = o as StackPanel;
                var usernameTxtB = myStackPanel.Children[0] as TextBox;
                var button = myStackPanel.Children[2] as Button;
                if (usernameTxtB.Text.Trim() == String.Empty)
                {
                    usernameTxtB.BorderBrush = Brushes.Red;
                    usernameTxtB.BorderThickness = new Thickness(6);
                    button.Focus();
                }
                else
                {
                    usernameTxtB.BorderBrush = Brushes.SpringGreen;
                    usernameTxtB.BorderThickness = new Thickness(2);
         
                    var passwordTxtb=myStackPanel.Children[1] as TextBox;
                    passwordTxtb.Focus();
                }
            });

            PasswordEnterCommand = new RelayCommand((o) =>
            {
                var myStackPanel = o as StackPanel;
                var button = myStackPanel.Children[2] as Button;
                button.Focus();
            });


            SubmitCommand = new RelayCommand((o) =>
            {
                var text = o as string;
                if (text == "admin")
                {
                    MessageBox.Show("Correct");
                }
            }, (o) =>
            {
                return UserText.Length > 8;
            });

        }
    }
}
