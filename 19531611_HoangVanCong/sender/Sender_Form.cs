using System;
using System.Windows.Forms;
using System.Messaging;

namespace sender
{
    public partial class Sender_Form : Form
    {

        MessageQueue queue = null;
       
        public Sender_Form()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            string path = @".\private$\phongkehoach";
            //string path = @"hbmnl\private$\phongkehoach";
            if (MessageQueue.Exists(path))
            {
                queue = new MessageQueue(path, QueueAccessMode.Send);
            }
            else
                queue = MessageQueue.Create(path, true);
            queue.Label = "queue ở bên sender";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text;
            Student1.Student1 st = new Student1.Student1(12, "cong");
            MessageQueueTransaction transaction = new MessageQueueTransaction();

            transaction.Begin();
            queue.Send(message, transaction);
            transaction.Commit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student1.Student1 st = new Student1.Student1(12, "cong");

            MessageQueueTransaction transaction = new MessageQueueTransaction();
            transaction.Begin();
            queue.Send(st, transaction);
            transaction.Commit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
