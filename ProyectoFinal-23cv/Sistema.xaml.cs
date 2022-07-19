using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23cv.Context;
using ProyectoFinal_23cv.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ProyectoFinal_23cv
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public List<Rol> Roles { get; set; }
        public Sistema()
        {
            InitializeComponent();
            GetUser();
            GetRoles();




        }


        public void GetUser()
        {
            using (var _context = new AplicationdbContext())
            {
                UserTable.ItemsSource = _context.Usuarios.ToList();

            }
        }


        public void GetRoles()
        {

            using (var _context = new AplicationdbContext())
            {
                var rol = _context.Roles.ToList();

                Roles = rol;


            }

            SelectRol.ItemsSource = Roles;
            //SelectRol.DisplayMemberPath = "Nombre";

        }

        private void SelectItem(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = (sender as FrameworkElement).DataContext as Usuario;

                txtId.Text = usuario.Id.ToString();
                txtNombre.Text = usuario.Nombre.ToString();
                txtUser.Text = usuario.User.ToString();
                txtPassword.Text = usuario.Password.ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Error interno: " + ex.Message);
            }

        }


        private void EliminarUser(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }

        }

        private void Button_Editar(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario user = new Usuario();

                if (txtId.Text == "")
                {
                    using (var _context = new AplicationdbContext())
                    {
                        user.Nombre = txtNombre.Text;
                        user.User = txtUser.Text;
                        user.Password = txtPassword.Text;
                     


                            
                        _context.Usuarios.Add(user);
                        _context.SaveChanges();

                    }

                    GetUser();

                }
                else
                {


                    user.Id = int.Parse(txtId.Text);

                    using (var _context = new AplicationdbContext())
                    {
                        user = _context.Usuarios.Find(user.Id);
                        user.Nombre = txtNombre.Text;
                        user.User = txtUser.Text;
                        user.Password = txtPassword.Text;

                        _context.Entry(user).State = EntityState.Modified;
                        _context.SaveChanges();




                    }

                    GetUser();
                }




            }
            catch (Exception ex)
            {

                throw;
            }
           
        }


        
    }
}
