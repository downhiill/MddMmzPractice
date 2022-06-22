using Mdd.Mmz.Practice.Core;

namespace Mdd.Mmz.Practice.WinFormsApp
{
    public partial class Form1 : Form, IView
    {
        public Action GetAction = () => { };
        public Action AddAction = () => { };
        public Action<int> EditAction = (i) => { };
        public Action<int> DeleteAction = (i) => { };

        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAction();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAction();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditAction(GetSelectedId());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();

            var dialogResult = MessageBox.Show(
                "Удалить запись c Id " + id.ToString() + "?", 
                "Подтверждение", 
                MessageBoxButtons.YesNo
            );
            
            if (dialogResult == DialogResult.Yes)
            {

                DeleteAction(id);
            }

        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void Show(List<Person> people)
        {
            dataGridView1.DataSource = people;
        }

        private int GetSelectedId()
        {
            var person = (Person)dataGridView1.CurrentRow.DataBoundItem;

            var id = person.Id;

            return id.Value;

        }

    }

}