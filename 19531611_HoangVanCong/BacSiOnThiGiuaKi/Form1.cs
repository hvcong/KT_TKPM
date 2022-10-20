using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using static BenhNhanSpace.BenhNhan;

namespace BacSiOnThiGiuaKi
{
    public partial class Form1 : Form
    {
        ArrayList ds = new ArrayList();
        ISession session;
        IMessageConsumer consumer;
        IMessageProducer producer;
        
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
            ActiveMQQueue activeMQQueue = new ActiveMQQueue("benhnhankhambenh");
            consumer = session.CreateConsumer(activeMQQueue);
            consumer.Listener += Consumer_Listener;

            producer = session.CreateProducer(activeMQQueue);


        }

        void Consumer_Listener(IMessage message)
        {
            if (message is ActiveMQTextMessage)
            {
                ActiveMQTextMessage msg = (ActiveMQTextMessage)message;
                XmlSerializer serializer = new XmlSerializer(typeof(BenhNhanSpace.BenhNhan));
                StringReader rdr = new StringReader(msg.Text);
                Console.WriteLine(rdr);
               BenhNhanSpace.BenhNhan p = (BenhNhanSpace.BenhNhan)serializer.Deserialize(rdr);

                 ds.Add(p);
                listBox1.Items.Add(p.hoten);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             indexSelected = listBox1.SelectedIndex;
            if(indexSelected >= 0)
            {
                textBox1.Text = ((BenhNhanSpace.BenhNhan)ds[indexSelected]).msbn;
                textBox2.Text = ((BenhNhanSpace.BenhNhan)ds[indexSelected]).cmnd;
                textBox3.Text = ((BenhNhanSpace.BenhNhan)ds[indexSelected]).hoten;
                richTextBox1.Text = ((BenhNhanSpace.BenhNhan)ds[indexSelected]).diachi;
            }
            
        }

        void updateListBox()
        {
            listBox1.Items.Clear();
            for(int i = 0; i<ds.Count; i++)
            {
                listBox1.Items.Add(((BenhNhanSpace.BenhNhan) ds[i]).hoten);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (indexSelected >= 0)
            {
                ds.RemoveAt(indexSelected);
                listBox1.ClearSelected();
                updateListBox();

            }
        }

   
    }
}
