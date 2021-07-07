using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Threading;

namespace Movie
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(CultureInfo cl)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = cl;
            Thread.CurrentThread.CurrentUICulture = cl;

            ResourceManager rmg = new ResourceManager("Movie.Form2",
                System.Reflection.Assembly.GetExecutingAssembly());

            this.Text = this.Text + "-" + DateTime.Now.ToLongDateString();
            button1.Text = rmg.GetString("button1.Text");
            button2.Text = rmg.GetString("button2.Text");
            button3.Text = rmg.GetString("button3.Text");
            label1.Text = rmg.GetString("label1.Text");
            label2.Text = rmg.GetString("label2.Text");
            label3.Text = rmg.GetString("label3.Text");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'supADBDataSet.MoviePrice' table. You can move, or remove it, as needed.
            this.moviePriceTableAdapter.Fill(this.supADBDataSet.MoviePrice);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            moviePriceTableAdapter.Insert(
                int.Parse(textBox1.Text),
                int.Parse(textBox2.Text),
                int.Parse(textBox3.Text)
                );

            MessageBox.Show("Movie Added!");
            this.moviePriceTableAdapter.Fill(this.supADBDataSet.MoviePrice);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moviePriceTableAdapter.Update(
                int.Parse(textBox2.Text),
                int.Parse(textBox3.Text),
                int.Parse(textBox1.Text)
                );

            MessageBox.Show("Movie Updated!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moviePriceTableAdapter.Delete(int.Parse(textBox1.Text));
        }
    }
}
