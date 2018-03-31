using SparkHttp.Entity;
using SparkHttp.Helper;
using SparkHttp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SparkHttp
{
    public partial class SparkHttp : Form
    {
        public SparkHttp()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Request request = RequestParser.Parse(requestTextBox.Text);
            if (request != null)
            {
                IService service = ServiceFactory.GetService(request.RequestType);
                service.Send(request);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Request request = RequestParser.Parse(requestTextBox.Text);
            if (request != null)
            {

                requestGridView.Rows.Add(request.TypeIcon, request.TargetAddress);
            }
        }

        private void requestGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            requestTextBox.Text = "Meto";
        }
    }
}
