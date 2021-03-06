using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1._1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string Name;
        public int Discount, Item_Quantity;
        public double Item_Price, totaldiscount, finaltotaldiscount;
        private void compute_Click(object sender, EventArgs e)
        {

            if (Text == "")
            {
                MessageBox.Show("Enter Discount");
            }
            else if (itemprice.Text == "")
            {
                MessageBox.Show("Enter Price");
            }
            else if (itemquantity.Text == "")
            {
                MessageBox.Show("Enter Item Quantity");
            }
            else
            {
                this.Discount = Convert.ToInt32(Text);

                Name = itemname.Text.ToString();
                Item_Price = Convert.ToDouble(itemprice.Text);
                Item_Quantity = Convert.ToInt32(itemquantity.Text);
                Discount = Convert.ToInt32(Text);

                DiscountedItem items = new DiscountedItem(Name, Item_Price, Item_Quantity);
                items.setPayment(Item_Quantity);

                totaldiscount = (items.getTotalPrice() * Discount) / 100;
                this.finaltotaldiscount = items.getTotalPrice() - totaldiscount;
                total.Text = "total amount : " + finaltotaldiscount;
            }

        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (Text == "")
            {
                MessageBox.Show("Enter Discount");
            }
            else if (itemprice.Text == "")
            {
                MessageBox.Show("Enter Price");
            }
            else if (itemquantity.Text == "")
            {
                MessageBox.Show("Enter Item Quantity");
            }
            else
            {

                double payments_ = Convert.ToDouble(payment.Text);
                DiscountedItem items = new DiscountedItem(Name, Item_Price, Item_Quantity);
                items.setChange(payments_);

                double pay = items.getChange();
                double pai = payments_ - this.finaltotaldiscount;
                change.Text = " " + pai;

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    class Item
    {
        protected string item_name;
        protected double item_price;
        protected int item_quantity;
        private double total_price;

        public Item(string name, double price, int quantity)
        {
            this.item_name = name; this.item_price = price; this.item_quantity = quantity;
        }
        public double getTotalPrice()
        {
            return this.total_price;
        }
        public void setPayment(double amount)
        {
            amount = this.item_price * this.item_quantity;
            this.total_price = amount;
        }

    }

    class DiscountedItem : Item
    {
        private double item_discount;
        private double discounted_price;
        private double payment_amount;
        private double change;

        private double disc;//getting discount
        public DiscountedItem(string name, double price, int quantity) : base(name, price, quantity) { }

        public void setPayment(double payment)
        {
            double price; int quantity;
            price = this.item_price;
            quantity = this.item_quantity;
            this.item_discount = price * quantity;
            this.discounted_price = item_discount;
        }

        public double getTotalPrice()
        {
            return this.discounted_price;
        }

        public void setChange(double paymentamont)
        {
            paymentamont = this.payment_amount;
            this.change = paymentamont;
        }
        public double getChange()
        {
            return this.change;
        }
    }
}
