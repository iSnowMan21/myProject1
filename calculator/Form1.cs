using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ConnectionAPIGUI
{
    public partial class Form1 : Form
    {
        private ConnectionWithDataBase con = new ConnectionWithDataBase();

        private DataTable dataTable;
        public Form1()
        {
            InitializeComponent();

            LoadData();
            
        }
        
        private void LoadData()
        {

            dataTable = new DataTable();
            con.LoadDataForDataGridView().Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            /* DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
             checkBoxColumn.Name = "CheckBoxColumn";
             checkBoxColumn.HeaderText = "Select";
             checkBoxColumn.Width = 50;
             //if col[0] != ckeckbox insert
             if (dataGridView1.Columns[0] != checkBoxColumn) { 
                 dataGridView1.Columns.Insert(0, checkBoxColumn);
             }*/
            bool checkBoxColumnExists = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "CheckBoxColumn")
                {
                    checkBoxColumnExists = true;
                    break;
                }
            }
            if (!checkBoxColumnExists)
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.Name = "CheckBoxColumn";
                checkBoxColumn.HeaderText = "Select";
                checkBoxColumn.Width = 50;
                dataGridView1.Columns.Insert(0, checkBoxColumn);
            }


        }
        /*
         * 
         * dataGridView1.Rows -> foreach 
         * button
         * row checkbox == true
         *      row.title -> label4
         * 
         */
        private void LoadDataInfoYear(string year)
        {
            
            dataGridView1.Columns.Add("title", "Title");
            dataGridView1.Columns.Add("year", "Year");
            dataGridView1.Columns.Add("imdbID", "IMDb ID");
            dataGridView1.Columns.Add("type", "Type");
            dataGridView1.Columns.Add("poster", "Poster");
            //dataTable = new DataTable();
            //con.InfoYear(year).Fill(dataTable);
            //dataGridView1.DataSource = dataTable;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedItem != null)
            {
                textBox1.Visible = true;
                label2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                dataGridView1.Visible = true;
                LoadData();
                dataGridView1.ForeColor = Color.Red;
                dataGridView1.GridColor = Color.Green;
            }
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Add Film")
            {
                label2.Text = "Введите ключевое слово для добавление фильма " + comboBox2.Text;
                label3.Text = "";
            }


            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Remove Film")
            {
                
                label2.Text = "Введите фильм который хотите удалить";
                label3.Text = "";
                textBox1.Visible = false;
                button1.Visible = false;
                label2.Visible = false;
            }
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Info")
            {
                label2.Text = "Введите дату выхода фильма для просмотра информации";
                textBox1.Visible = true;
                label2.Visible = true;
                dataGridView1.Visible = true;
                label3.Text = "";
            }
            

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (comboBox2.Text == "Add Film")
            {

                //button1.Visible = true;
                //int[] theData = new int[] { -14, 17, 5, 11, 2 };
                //dataGridView1.DataSource = theData.Where(x => x > 0).Select((x, index) =>
                //   new { RecNo = index + 1, ColumnName = x }).OrderByDescending(x => x.ColumnName).ToList();

                //dataGridView1.Rows.Clear();
                //dataGridView1.Columns.Clear();



                label4.Text = "Movies:\n";
                Commands.addFilm(textBox1.Text);
                //label4.Text += Commands.ans.Search[1].Title;
                dataGridView1.DataSource = Commands.films;
                dataGridView1.Update();
                foreach (var film in Commands.films)
                {
                    //str += film.Title + "\n";

                    //dataGridView1.Rows.Add(false, film.Title, film.Year, film.ImdbID, film.Type, film.Poster);

                    label4.Text += film.Title + "\n";
                }
                label4.Text += "End.";
                textBox1.Enabled = true;
                button1.Visible = true;
                
                textBox1.Text = "";
               

            }

            if (comboBox2.Text == "Remove Film")
            {

                label3.Text = Commands.DeleteMovie(con, textBox1.Text);
                LoadData();
                
            }
            if (comboBox2.Text == "Info")
            {
                textBox1.Enabled = true;
                LoadDataInfoYear(textBox1.Text);
            }
            
        }

        public static void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Add Film")
            {
                label4.Text = "Selected:\n";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.Equals(true))
                    {
                        label4.Text += dataGridView1.Rows[i].Cells[1].Value;
                        con.Insert(Commands.films, i);
                    }
                }
            }
            if (comboBox2.Text == "Remove Film")
            {
                label4.Text = "Selected for Deletion:\n";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.Equals(true))
                    {
                        string titleToDelete = dataGridView1.Rows[i].Cells["Title"].Value.ToString();
                        con.Delete(titleToDelete);
                        label4.Text += titleToDelete + "\n";
                    }
                }
                LoadData();
            }
        }
        }

    }


//gamma
//subject subscribe gamma
//subject -> gamma
