﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AqueaductoApp.CapaDatos;
using AqueaductoApp.CapaModelos;

namespace AqueaductoApp
{
    public partial class Login : Form

    {
        int rol;
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                MessageBox.Show("Ingresar el Usuario");
                txtUsuario.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    MessageBox.Show("Ingrese la contraseña");
                }
                else
                {
                   
                        try
                        {


                            //Conexión Desde casa
                            CapaDatos.DataSet1TableAdapters.USUARIOSTableAdapter tU = new CapaDatos.DataSet1TableAdapters.USUARIOSTableAdapter();

                            string pass;

                            rol = (int)tU.verRol(this.txtUsuario.Text, pass = CapaModelos.Encript.GetSHA256(this.txtPassword.Text));
                            if (rol == 1)
                            {
                                this.Hide();
                                menuAdmin admi = new menuAdmin();
                                admi.Show();

                            }
                            else
                            {
                                if (rol == 2)
                                {
                                    menuDigitador digitador = new menuDigitador();
                                    this.Hide();
                                    digitador.Show();

                                }
                                else
                                {
                                    menuFacturador facturador = new menuFacturador();
                                    this.Hide();
                                    facturador.Show();
                                }
                            }

                        }
                        catch
                        {
                        //CapaDatos.DataSet1TableAdapters.USUARIOSTableAdapter userExist = new CapaDatos.DataSet1TableAdapters.USUARIOSTableAdapter();
                        //int cedula = (int)userExist.validarExistencia(this.txtUsuario.Text, this.txtPassword.Text);
                        //if (cedula == 0)
                        //{
                        //    labelErrorUsuario.Text = "No se encuentra en el Sistema";
                        //    labelErrorUsuario.Visible = true;
                        //}
                        MessageBox.Show("nADA");

                        }
                        
                    
                   


                }












            }

                    
        }


        private void pictureClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text == "Usuario")
            {
                this.txtUsuario.Text = "";
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text == "")
            {
                this.txtUsuario.Text = "Usuario";
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (this.txtPassword.Text == "Contraseña")
            {
                this.txtPassword.UseSystemPasswordChar = true;
                this.txtPassword.Text = "";
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (this.txtPassword.Text == "")
            {
                this.txtPassword.Text = "Contraseña";
                this.txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {

        }

        private void btnUser_Leave(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}