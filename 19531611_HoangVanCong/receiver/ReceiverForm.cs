
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Student1.Student1;

namespace receiver
{
    public partial class ReceiverForm : Form
    {
        public ReceiverForm()
        {
            InitializeComponent();
            init_queue();
        }
        Label lb;

        private MessageQueue queue;
 
        void init_queue()
        {
            string path = @".\private$\phongkehoach";
            queue = new MessageQueue(path);
            queue.BeginReceive();
            queue.ReceiveCompleted += Queue_ReceiveCompleted;

        }

        private void Queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = e.Message;
            int type = msg.BodyType;
            XmlMessageFormatter fmt = new XmlMessageFormatter(new System.Type[] { typeof(string), typeof(Student1.Student1) }
            );
            msg.Formatter = fmt;
            var result = msg.Body;
            var t = result.GetType();
            if (t.Equals(typeof(Student1.Student1)))
            {
                Student1.Student1 st = (Student1.Student1)msg.Body;
                Console.WriteLine(st.ToString());
                string text = "Message: " + st.ToString();
                SetText(st.ToString());
            }
            else
            {
                SetText(""+result);

            }
            queue.BeginReceive();//loop back
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                SetTextCallback callback = new SetTextCallback(SetText);
                this.Invoke(callback, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
            lb = new Label();
            
            lb.Text = "Message print at here";
            this.Controls.Add(lb);

        }
    }
}
