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

namespace bacSi
{
    public partial class Form1 : Form
    {
        ArrayList ds = new ArrayList();
        ISession session;
        IMessageConsumer consumer;
        int indexSelected = -1;
        public Form1()
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
            consumer.Listener += Consumer_Listener;

        }

        void Consumer_Listener(IMessage message)
        {
            if(message is ActiveMQTextMessage )
            {
                ActiveMQTextMessage msg = (ActiveMQTextMessage) message;
                XmlSerializer serializer = new XmlSerializer(typeof(BenhNhan.BenhNhan));
                StringReader rdr = new StringReader(msg.Text);
                BenhNhan.BenhNhan p = (BenhNhan.BenhNhan)serializer.Deserialize(rdr);
                ds.Add(p);
                listBox1.Items.Add(p.name);
                
            }
      
        }

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

                indexSelected = listBox1.SelectedIndex;

            if (indexSelected == -1) return;
               
                BenhNhan.BenhNhan bn = (BenhNhan.BenhNhan)ds[indexSelected];

                textBox1.Text = "" + bn.id;
                textBox2.Text = bn.name;
                textBox3.Text = bn.cmnd;
            
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (indexSelected == -1) return;
            ds.RemoveAt(indexSelected);
            listBox1.Items.RemoveAt(indexSelected);
            if(listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }
    }
}
