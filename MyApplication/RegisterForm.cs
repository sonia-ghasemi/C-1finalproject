using System.Linq;

namespace MyApplication
{
    public partial class RegisterForm : Infrastructure.BaseForm
    {
        public RegisterForm() : base()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                System.Windows.Forms.MessageBox.Show("Username and password are requierd.");

                //if (usernameTextBox.Text.Replace(" ", string.Empty) == string.Empty)
                //{                   
                //    usernameTextBox.Focus();
                //}
                //else
                //{                   
                //    passwordTextBox.Focus();
                //}

                usernameTextBox.Text = usernameTextBox.Text.Replace(" ", string.Empty);
                passwordTextBox.Text = passwordTextBox.Text.Replace(" ", string.Empty);

                if (usernameTextBox.Text == string.Empty)
                {
                    usernameTextBox.Focus();
                }
                else
                {
                    passwordTextBox.Focus();
                }

                return;
            }

            string errorMessages = string.Empty;

            if (usernameTextBox.Text.Length < 6)
                {
                    if (errorMessages != string.Empty)
                    {
                        errorMessages+= System.Environment.NewLine;
                    }
                    else
                    {
                        usernameTextBox.Focus();
                    }

                    errorMessages += "Username length should be at least 6 charectors;";
                }

                if (passwordTextBox.Text.Length < 8)
                {
                    if (errorMessages != string.Empty)
                    {
                        errorMessages += System.Environment.NewLine;                   
                    }
                else
                {
                    passwordTextBox.Focus();
                }

                    errorMessages += "Password length should be at least 8 charectors.";
                }

            if (errorMessages != string.Empty)
            {
                System.Windows.Forms.MessageBox.Show(errorMessages);
                return;
            }

            Models.DatabaseContext databasecontext = null;
            try
            {
                databasecontext = new Models.DatabaseContext();

                //if (databasecontext.Users.Any(Current =>
                //Current.Username.ToLower() == usernameTextBox.Text.ToLower()))
                //{
                //    System.Windows.Forms.MessageBox.Show
                //        ("This username already exists! Please choose anotherone...");
                //    usernameTextBox.Focus();

                //    return;
                //} 

                Models.User user =
                    databasecontext.Users.Where(current =>
                    current.Username.ToLower() == usernameTextBox.Text.ToLower())
                    .FirstOrDefault();

                if (user != null)
                {
                    System.Windows.Forms.MessageBox.Show
                        ("This username already exists! please choose anotherone...");
                    usernameTextBox.Focus();
                    return;
                }

                user = new Models.User
                {
                    FullName = fullnameTextBox.Text,
                    Username = usernameTextBox.Text,
                    Password = passwordTextBox.Text,
                    IsActive = true,
                    IsAdmin = false,
                };

                databasecontext.Users.Add(user);
                databasecontext.SaveChanges();

                ResetForm();

                System.Windows.Forms.MessageBox.Show("Registration Done!");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (databasecontext != null)
                {
                    databasecontext.Dispose();
                    databasecontext = null;
                }
            }          
        }

        private void ResetButton_Click(object sender, System.EventArgs e)
        {
            ResetForm();
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void loginButton_Click(object sender, System.EventArgs e)
        {
            ResetForm();
            Hide();            
            Infrastructure.Utility.LoginForm.Show();
        }

        private void ResetForm()
        {
            fullnameTextBox.Text = string.Empty;
            usernameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;

            usernameTextBox.Focus();
        }
    }
}
