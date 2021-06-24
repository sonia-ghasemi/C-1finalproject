//namespace MyApplication.Infrastructure
namespace Infrastructure
{
	public static class Utility
	{
		static Utility()
		{
		}

		public static Models.User AuthenticatedUser { get; set; }

		private static MyApplication.StartupForm startupForm;
		public static MyApplication.StartupForm StartupForm
        {
			get
            {
                if (StartupForm == null || startupForm.IsDisposed)
                {
					startupForm = new MyApplication.StartupForm();
                }

				return startupForm;
            }
        }

		private static MyApplication.LoginForm loginForm;
		public static MyApplication.LoginForm LoginForm
        {
            get
            {
                if (loginForm == null || loginForm.IsDisposed)
                {
                    loginForm = new MyApplication.LoginForm();
                }

                return loginForm;
            }
        }

        private static MyApplication.RegisterForm registerForm;
        public static MyApplication.RegisterForm RegisterForm
        {
            get
            {
                if (registerForm == null || registerForm.IsDisposed)
                {
                    registerForm = new MyApplication.RegisterForm();
                }

                return registerForm;
            }
        }
	}
}
