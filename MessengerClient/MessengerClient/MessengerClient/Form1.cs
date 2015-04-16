using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace MessengerClient
{
    public partial class Form1 : Form, 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var instsanseContext = new InstanceContext(this);
            var client = new ServiceReference1.User();


        }

        private void label2_Click(object sender, EventArgs e)
        {
  
            /*<system.serviceModel>
    <bindings>
      <netTcpBinding>
        <binding name="NetTcpBinding_ICoreService"/>
      </netTcpBinding>
      
    </bindings>
    <client>
      <endpoint address="net.tcp://localhost:8081/MessengerCoreLib" binding="netTcpBinding" bindingConfiguration="NetTcpBinding_ICoreService">
        <name>NetTcpBinding_ICoreService</name>
        <behaviorConfiguration>Messenger.ICoreService</behaviorConfiguration>
        <identity>
          <userPrincipalName value="Gygabyte-U2442F\gygabyte-vpn"/>
        </identity>
      </endpoint>
    </client>
   
    </system.serviceModel>*/
        }
    }
}
