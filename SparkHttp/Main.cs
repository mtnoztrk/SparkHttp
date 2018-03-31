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
        private List<Request> requestList;
        public SparkHttp()
        {
            requestList = new List<Request>();

            InitializeComponent();
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            Request request = RequestParser.Parse(requestTextBox.Text);
            if (request != null)
            {
                IService service = ServiceFactory.GetService(request.RequestType);
                var response = await service.Send(request);
                responseTextBox.Text = response;
                tabControl1.SelectedTab = tabResponse;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Request request = RequestParser.Parse(requestTextBox.Text);
            if (request != null)
            {
                //simulating data source
                requestList.Add(request);
                requestGridView.Rows.Add(request.TypeIcon, request.TargetAddress, request.Id);
            }
        }

        private void requestGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = requestGridView.Rows[e.RowIndex];
            //getting the request with same GUID and use its body.
            requestTextBox.Text = requestList.FirstOrDefault(c => c.Id.Equals(row.Cells[2].Value)).RawText;
            tabControl1.SelectedTab = tabRequest;
        }
    }
}
