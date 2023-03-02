﻿using pwdvault.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pwdvault.Forms
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBoxUser.Text) &&
                !String.IsNullOrWhiteSpace(txtBoxPwd.Text)
                )
            {
                //Test
                /*RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                byte[] key = new byte[32];
                randomNumberGenerator.GetBytes(key);
                string text = "c'est le texte";
                // Encrypt password and store it, success message and hide the form
                byte[] encryptedpss = EncryptionService.EncryptPassword(text, key);
                MessageBox.Show("Password : " + text + ",\n key : " + Encoding.UTF8.GetString(key) + ",\n encrypted pass : " + Encoding.UTF8.GetString(encryptedpss));

                string pass = EncryptionService.DecryptPassword(encryptedpss, key);
                MessageBox.Show("Encrypted Password : " + Encoding.UTF8.GetString(encryptedpss) + ", key : " + Encoding.UTF8.GetString(key) + ", decrypted pass : " + pass);
                MessageBox.Show("Meme mdp ? : " + (text == pass).ToString());
                */
                //Create database with name : PasswordVault
                // Success message to user
                MessageBox.Show("New account and database created successfully !", "Successful creation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Close();
            }
            else
            {
                MessageBox.Show("Please complete all fields.", "Incomplete form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtBoxPwd.Text = PasswordService.GeneratePassword();
        }

        private void txtBoxPwd_TextChanged(object sender, EventArgs e)
        {
            if (!PasswordService.IsPasswordStrong(txtBoxPwd.Text))
            {
                errorProvider.SetError(txtBoxPwd, "Password must be atleast 16 characters long and contain the following : " + Environment.NewLine +
                        "- Uppercase" + Environment.NewLine + "- Lowercase" + Environment.NewLine + "- Numbers" + Environment.NewLine + "- Symbols");
            }
            else
            {
                errorProvider.SetError(txtBoxPwd, String.Empty);
                errorProvider.Clear();
            }
        }
    }
}