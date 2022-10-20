using System;
using System.Collections;
using System.Collections.Concurrent;
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
using static BenhNhanSpace.BenhNhan;

namespace nhanVien0
{
    public partial class Form1 : Form
    {
        ISession session;
        IMessageProducer producer;
        ArrayList ds = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            IConnectionFactory connectionFactory = new ConnectionFactory("tcp://localhost:61616");
            IConnection connection = connectionFactory.CreateConnection("admin","admin");
            connection.Start();

            session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue activeMQ = new ActiveMQQueue("benhnhankhambenh");
            producer = session.CreateProducer(activeMQ);
           

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msbn = textBox1.Text;
            string cmnd = textBox2.Text;
            string hoten = textBox3.Text;
            string diachi = richTextBox1.Text;

            if(msbn == "" && cmnd == "" && hoten == "" && diachi == "")
            {
                Console.WriteLine("Vui long dien day du thong tin");
                return;
            }

            BenhNhanSpace.BenhNhan bn = new BenhNhanSpace.BenhNhan(msbn, cmnd, hoten, diachi);

            string xml = objectToXML(bn);
            IMessage msg = new ActiveMQTextMessage(xml);

            producer.Send(msg);


            
        }

        public string objectToXML<T>(T p)
        {
            string xml = "";
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.Serialize(ms, p);
                ms.Position = 0;
                xml = new StreamReader(ms).ReadToEnd();
            }
            return xml;
        }
    }
}
