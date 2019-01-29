using Systech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systech
{
    public partial class Form1 : Form
    {
        InhDBContext DataContext = new InhDBContext();

		//combobox с датами не сделаны точно для просто ты по этому comboBox с дня всегда содержит 31 день что не реально, но сверять каждый раз при смене месяца было бы лишними усилиями поэтому упростил таким образом, по этому вводить только реальные даты
        public Form1()
        {           
            
            InitializeComponent();
            var dataSource = DataContext.People.ToList();
            comboBox4.DataSource = dataSource;
            comboBox4.DisplayMember = "Fullname";
            comboBox4.ValueMember = "pid";
            comboBox4.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int persId = (int)comboBox4.SelectedValue;
            var empl = DataContext.People.Where(b => b.pid == persId).Single();
            double sal = 0;
            if (empl.Position == "employee")
            {
                Employee emp = new Employee(empl);               
                sal = emp.calculateSal(new DateTime(int.Parse(comboBox3.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox1.SelectedItem.ToString())));
            }
            if (empl.Position == "manager")
            {
                Manager man = new Manager(empl);
                sal = man.calculateSal(new DateTime(int.Parse(comboBox3.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox1.SelectedItem.ToString())));
            }
            if (empl.Position == "salesman")
            {
                Salesman sale = new Salesman(empl);
                sal = sale.calculateSal(new DateTime(int.Parse(comboBox3.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox1.SelectedItem.ToString())));
            }

            textBox1.Text = sal.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> peop = DataContext.People.ToList();
            double finSal = 0;
            foreach(var pers in peop)
            {
                double sal = 0;
                if (pers.Position == "employee")
                {
                    Employee emp = new Employee(pers);
                    sal = emp.calculateSal(new DateTime(int.Parse(comboBox3.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox1.SelectedItem.ToString())));
                }
                if (pers.Position == "manager")
                {
                    Manager man = new Manager(pers);
                    sal = man.calculateSal(new DateTime(int.Parse(comboBox3.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox1.SelectedItem.ToString())));
                }
                if (pers.Position == "salesman")
                {
                    Salesman sale = new Salesman(pers);
                    sal = sale.calculateSal(new DateTime(int.Parse(comboBox3.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox1.SelectedItem.ToString())));
                }
                finSal += sal;
            }
            textBox2.Text = finSal.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int persId = (int)comboBox4.SelectedValue;
            var empl = DataContext.People.Where(b => b.pid == persId).Single();
            var grSource = DataContext.People.Where(p => p.Boss.pid == persId).ToList();
            dataGridView1.DataSource = grSource;
            dataGridView1.Visible = true;
        }
    }
}
