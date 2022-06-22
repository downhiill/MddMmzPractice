using System;

using Mdd.Mmz.Practice.Core;

namespace Mdd.Mmz.Practice.WinFormsApp
{

    public partial class EditForm : Form, IEditView
    {
        public Action<Person> SaveAction = (p) => { };

        private Person person;

        public EditForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        public void Open()
        {
            Open(new Person());

        }

        public void Open(Person person)
        {
            this.person = person;

            Set();

            ShowDialog();
            

        }

        private void Set()
        {
            textBox1.Text = person.Age.ToString();
            textBox2.Text = person.Name;
            textBox3.Text = person.Country;
            textBox4.Text = person.City;
            textBox5.Text = person.Phone.ToString();

        }

        private void Get()
        {
            person.Age = Convert.ToInt32(textBox1.Text);
            person.Name = textBox2.Text;
            person.Country = textBox3.Text;
            person.City = textBox4.Text;
            person.Phone = Convert.ToInt32(textBox5.Text);

        }

        public void Save()
        {
            Get();

            SaveAction(person);

            Close();
        }

    }
}
