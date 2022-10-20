using System;
using System.Windows.Forms;
using System.Messaging;
using static Student1.Student1;



namespace sender
{
    internal static class F_sender
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Sender_Form());



        }
    }
}
