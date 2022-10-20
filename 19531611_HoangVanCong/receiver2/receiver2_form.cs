using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace receiver2
{
    public partial class receiver2_form : Form
    {

        public receiver2_form()
        {
            InitializeComponent();
           
            init();
        }

        public void init()
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");

            IConnection con = factory.CreateConnection("admin", "admin");
            con.Start();

            ISession session = con.CreateSession(AcknowledgementMode.AutoAcknowledge);

            ActiveMQQueue activeMQ = new ActiveMQQueue("hoangVanCong");
            IMessageConsumer consumer = session.CreateConsumer(activeMQ);

            //listen message receive
            consumer.Listener += Consumer_Listener;
        }

        private void Consumer_Listener(IMessage message)
        {
            if (message is ActiveMQTextMessage)
            {
                ActiveMQTextMessage msg = message as ActiveMQTextMessage;

                XmlSerializer serializer = new XmlSerializer(typeof(Person.Person));
                StringReader rdr = new StringReader(msg.Text);
                Person.Person p = (Person.Person)serializer.Deserialize(rdr);

                

                SetText(p.name);
            }
        }

        private void receiver2_form_Load(object sender, EventArgs e)
        {
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                Console.WriteLine("call back");
                SetTextCallback callback = new SetTextCallback(SetText);
                this.Invoke(callback, new object[] { text });
            }
            else
            {
                this.richTextBox1.AppendText(text);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
