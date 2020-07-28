using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public static String url = "Server=localhost;Database=member1;Uid=root;Pwd=0000;charset = utf8";
        private MySqlConnection mConnection;
        private MySqlCommand mCommand;
        private MySqlDataReader mDataReader;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            mConnection = new MySqlConnection(url); // DB접속
            mCommand = new MySqlCommand(); // 쿼리문 생성
            mCommand.Connection = mConnection; // DB에 연결
            mCommand.CommandText = "SELECT * FROM student"; // 쿼리문 작성
            mConnection.Open(); // DB 오픈
            mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행

            while (mDataReader.Read()) // 전부 다 읽어 옴
            {
                // 여기서 부터 원하는 데이터를 받아와서 처리
                string name = mDataReader["name"].ToString();
                string age = mDataReader["age"].ToString();
                textBox1.AppendText("이름 : " + name);
                textBox1.AppendText("\t나이 : " + age + Environment.NewLine);
            }
            mConnection.Close(); // 사용 후 객체 닫기
        }



        //조회 + 풀 네임
        private void button1_Click_1(object sender, EventArgs e)
        {
            //searchbox.Text = inputbox.Text;
            mConnection = new MySqlConnection(url); // DB접속
            mCommand = new MySqlCommand(); // 쿼리문 생성
            mCommand.Connection = mConnection; // DB에 연결
            mCommand.CommandText = "SELECT * FROM student WHERE name = "+"'"+inputbox.Text+"'"; // 쿼리문 작성
            mConnection.Open(); // db on
            mDataReader = mCommand.ExecuteReader();

            while (mDataReader.Read())
            {   // : 전체 값 읽어서 출력 
               // Console.WriteLine(mDataReader[0] + "----" + mDataReader[1]);
                string name = mDataReader["name"].ToString();
                string age = mDataReader["age"].ToString();
                searchbox.AppendText("이름 : " + name);
                searchbox.AppendText("\t나이 : " + age + Environment.NewLine);
            }
            MessageBox.Show((String msg) "Hello Mablang World!",(String title) "Mablang", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            mConnection.Close();
        }

        // 삽입
        private void button2_Click(object sender, EventArgs e)
        {
            mConnection = new MySqlConnection(url); // DB접속
            mCommand = new MySqlCommand(); // 쿼리문 생성
            mCommand.Connection = mConnection; // DB에 연결
            mCommand.CommandText = "insert into student(name,age) values(" + "'" + namebox.Text + "," + "'" + agebox.Text + "')";
            mConnection.Open();
            mDataReader = mCommand.ExecuteReader();
            //들어간 값 확인하기
            while (mDataReader.Read())
            {
               // MessageBox.Show((String msg) "Hello Mablang World!",(String title) "Mablang", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                string name = mDataReader["name"].ToString();
                string age = mDataReader["age"].ToString();
                searchbox.AppendText("이름 : " + name);
                searchbox.AppendText("\t나이 : " + age + Environment.NewLine);
            }
            mConnection.Close();
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
