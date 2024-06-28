namespace YuGiOh
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            start Start = new start();
            Start.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(Start);

            Init init = new Init();
            init.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(init);

            Login login = new Login();
            login.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(login);
        }
    }
}