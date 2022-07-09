using ProyectoFinal_23cv.Context;
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

namespace ProyectoFinal_23cv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string UserResult;
                string PasswordResult;

                UserResult = txtUser.Text;
                PasswordResult = txtPassword.Text;  
            

                using (var _context = new AplicationdbContext())
                {

                    var result = _context.Usuarios.FirstOrDefault(x => x.User == UserResult && x.Password == PasswordResult);
                    if (result != null)
                    {
                        Sistema sistema = new Sistema();
                       
                        Hide();
                        sistema.Show();

                    }
                    else
                    {
                        MessageBox.Show("Usuario ó contraseña incorrecto");
                    }
                }
     

            


            }
            catch (Exception ex)
            {

                throw new Exception("Error interno: "+ex.Message);
            }

        }
    }
}
