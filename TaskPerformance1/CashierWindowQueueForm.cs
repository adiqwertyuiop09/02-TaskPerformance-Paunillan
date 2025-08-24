using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TaskPerformance1.QueuingForm;

namespace TaskPerformance1
{
    public partial class CashierWindowQueueForm : Form
    {
        CustomerView customerView = new CustomerView();
        public CashierWindowQueueForm()
        {
            InitializeComponent();
            AutoRefresh();
           
            customerView.Show();
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(QueuingForm.CashierClass.CashierQueue);
        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {             
                listCashierQueue.Items.Add(obj.ToString());               
            }
            

        }

        public void AutoRefresh() 
        {
            Timer timer = new Timer(); timer.Interval = (1 * 1000); 
            timer.Tick += new EventHandler(timer1_Tick); 
            timer.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(QueuingForm.CashierClass.CashierQueue);
        }


        public void Dequeue()
        {
            if (QueuingForm.CashierClass.CashierQueue.Count > 0)
            {              
                QueuingForm.CashierClass.CashierQueue.Dequeue();
            }
            else
            {
                MessageBox.Show("Queue is empty!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DisplayCashierQueue(QueuingForm.CashierClass.CashierQueue);
        }

        public void showCurrent(CustomerView customerView) { 
            
           
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

           
            if (QueuingForm.CashierClass.CashierQueue.Count > 0)
            {
                string nextCustomer = QueuingForm.CashierClass.CashierQueue.Peek().ToString();

                if (QueuingForm.CashierClass.CashierQueue.Contains(nextCustomer)) {
                 
                    customerView.Now(nextCustomer);

                }
            }

            Dequeue();

        }

        //asd
    }
}
