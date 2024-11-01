using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BrowseHistory
    {
        private string cs = @"Data Source=C:\Users\USER\AppData\Local\Google\Chrome\User Data\Profile 4\History;Version=3;New=False;Compress=True;journal mode=Off";


        public void History()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cs,true))
                {

                    con.Open();

                    SQLiteCommand cmd = new SQLiteCommand("SELECT id,datetime(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime') as time,url FROM urls ORDER BY last_visit_time  DESC LIMIt 5", con);
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);

                    foreach(DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["id"]},{dr["time"]},{dr["url"]}");
                    }
                    



                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            

        }
    }
}
