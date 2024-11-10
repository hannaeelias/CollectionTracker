using CollectionTracker.Models;
using Microsoft.AspNetCore.Identity;  // Add this namespace for PasswordHasher
using System;
using System.Linq;
using System.Windows;

namespace CollectionTracker
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new CollectionContext())
            {
                // Find the user by username
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null && VerifyPassword(password, user.PasswordHash))
                {
                    // Successful login, open main window
                    MainWindow mainWindow = new MainWindow(user.UserId);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            var passwordHasher = new PasswordHasher<User>();
            var verificationResult = passwordHasher.VerifyHashedPassword(null, storedPasswordHash, enteredPassword);

            // Return true if the password matches, false otherwise
            return verificationResult == PasswordVerificationResult.Success;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (var context = new CollectionContext())
            {
                // Check if the user already exists
                var existingUser = context.Users.FirstOrDefault(u => u.Username == username);
                if (existingUser != null)
                {
                    MessageBox.Show("Username is already taken.");
                    return;
                }

                // Hash the password using PasswordHasher
                string hashedPassword = HashPassword(password);

                // Create a new user
                var newUser = new User
                {
                    Username = username,
                    PasswordHash = hashedPassword,
                    AccessKey = Guid.NewGuid().ToString()  // Generate a new access key
                };

                // Add the user to the database
                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("User registered successfully!");
                UsernameTextBox.Clear();
                PasswordBox.Clear();
            }
        }

        private string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            // Hash the password
            return passwordHasher.HashPassword(null, password);
        }
    }
}
