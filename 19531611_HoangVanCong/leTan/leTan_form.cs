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
using static BenhNhan.BenhNhan;

namespace leTan
{
    public partial class leTan_form : Form
    {
        IMessageProducer producer;
        ISession session;

        public leTan_form()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection con = factory.CreateConnection("admin", "admin");
            con.Start();

             session = con.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue activeMQQueue = new ActiveMQQueue("benhnhan");
             producer = session.CreateProducer(activeMQQueue);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(richTextBox1.Text);
            string cmnd = richTextBox2.Text;
            string name = richTextBox3.Text;

            BenhNhan.BenhNhan bn = new BenhNhan.BenhNhan(id, name, cmnd);

            string xml = objectToXML(bn);
            IMessage msg = new ActiveMQTextMessage(xml);

            producer.Send(msg);
            //richTextBox1.Text = "";
            //richTextBox2.Text = "";
           // richTextBox3.Text = "";
           // MessageBox.Show("Thêm thành công");
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
