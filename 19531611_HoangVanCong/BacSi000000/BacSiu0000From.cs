using System;
using System.Collections;
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

namespace BacSi000000
{
    public partial class BacSiu0000From : Form
    {

        ArrayList ds = new ArrayList();
        ISession session;
        IMessageConsumer consumer;
        public BacSiu0000From()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            init();
        }

        void init()
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection con = factory.CreateConnection("admin", "admin");
            con.Start();

            session = con.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue activeMQQueue = new ActiveMQQueue("benhnhan");
            consumer = session.CreateConsumer(activeMQQueue);


            void Consumer_Listener(IMessage message)
            {
                if (message is ActiveMQTextMessage)
                {
                    ActiveMQTextMessage msg = (ActiveMQTextMessage)message;
                    XmlSerializer serializer = new XmlSerializer(typeof(BenhNhanSpace.BenhNhan));
                    StringReader rdr = new StringReader(msg.Text);
                    BenhNhanSpace.BenhNhan p = (BenhNhanSpace.BenhNhan)serializer.Deserialize(rdr);
                    ds.Add(p);
                    //listBox1.Items.Add();

                }

            }
            consumer.Listener += Consumer_Listener;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
