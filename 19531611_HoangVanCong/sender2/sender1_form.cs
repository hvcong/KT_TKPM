using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using static Person.Person;
namespace sender2
{
    public partial class sender1_form : Form
    {
        IMessageProducer producer = null;
        ISession session = null;
        public sender1_form()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            // create factory and connection
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            
            IConnection con = factory.CreateConnection("admin", "admin");
            // connect to MOM
            con.Start();
            // create session
             session = con.CreateSession(AcknowledgementMode.AutoAcknowledge);
            //create producer
            ActiveMQQueue activeMQQueue = new ActiveMQQueue("hoangVanCong");
             producer = session.CreateProducer(activeMQQueue);
        }



        private void sender1_form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //init();
            Person.Person p = new Person.Person(1, "cong");
            string xml = objectToXML(p);

            IMessage msg = new ActiveMQTextMessage(xml);
            producer.Send(msg);
            //session.Close();
            Console.WriteLine("send ok");
            
        }

        public string objectToXML<T> (T p)
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
