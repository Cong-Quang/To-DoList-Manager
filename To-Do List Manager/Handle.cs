using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_Manager
{
    public partial class Handle : Form
    {
        private User currentUser;
        private DataManager dataManager;
        DataTable DataTable;
        int index = 0;
        public Handle(User user, DataManager manager)
        {
            currentUser = user;
            dataManager = manager;
            InitializeComponent();
            DataTable = new DataTable("listBox");

            DataTable.Columns.Add("sweeping");
            DataTable.Columns.Add("washing-dish");
            DataTable.Columns.Add("cooking");
        }

        private void Handle_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadTasks()
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
