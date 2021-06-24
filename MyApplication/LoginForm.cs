using System.Linq;

namespace MyApplication
{
    public partial class LoginForm : Infrastructure.BaseForm
    {
        public LoginForm() : base()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
           if (string.IsNullOrWhiteSpace(usernameTextBox.Text)||
                string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                System.Windows.Forms.MessageBox.Show("username and password are required!");

                if (usernameTextBox.Text.Replace(" ",string.Empty)==string.Empty)
                {
                    usernameTextBox.Focus();
                }
                else
                {
                    passwordTextBox.Focus();
                }

                return;
            }

            Models.DatabaseContext databasecontext = null;

            try
            {
                databasecontext = new Models.DatabaseContext();

                Models.User foundeduser =
                    databasecontext.Users.Where(current =>
                    current.Username.ToLower()==usernameTextBox.Text.ToLower()).FirstOrDefault();

                //if (foundeduser == null || passwordTextBox.Text!= foundeduser.Password)
                //{
                //    System.Windows.Forms.MessageBox.Show("username or/and password is not correct!");
                //    usernameTextBox.Focus();

                //    return;
                //}

                if (foundeduser==null)
                {
                    System.Windows.Forms.MessageBox.Show("username or/and password is not correct!");
                    usernameTextBox.Focus();
                    return;
                }

                if (string.Compare(foundeduser.Password,passwordTextBox.Text,ignoreCase: false)!=0)
                {
                    System.Windows.Forms.MessageBox.Show("username or/and password is not correct!");
                    usernameTextBox.Focus();
                    return;
                }

                if (foundeduser.IsActive == false)
                {
                    System.Windows.Forms.MessageBox.Show
                        ("You can not login to this application! Please contact supportteam.");
                    usernameTextBox.Focus();

                    return;
                }

                System.Windows.Forms.MessageBox.Show("Welcome!");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);                
            }
            finally
            {
                if(databasecontext != null)
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

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            ResetForm();
            Hide();
            Infrastructure.Utility.RegisterForm.Show();
        }  
        
        private void ResetForm()
        {
            usernameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
            usernameTextBox.Focus();
        }
    }
}
