using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RawDataType = System.Collections.Generic.List<double>;//user defined type for the raw data

namespace DiscordDiscovery.Utils
{
    class IOFuncs
    {
        static public RawDataType readFile(string file_name, int lines_to_skip = 1)
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\", file_name);
            RawDataType data = new RawDataType();

            //read file
            string[] lines = System.IO.File.ReadAllLines(path);

            for (int i = 0; i < lines_to_skip; i++)
                //skip one line from the file
                lines = lines.Skip(1).ToArray();


            foreach (string line in lines)
            {
                data.Add(Convert.ToDouble(line)); //convert into a double list then add to 'data'
            }

            return data;
        }//end ReadFileIntoList function

        static public void writeFile(RawDataType data, int N_LENGTH, int best_so_far_loc)
        {
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Output\", "output_BitClustering.csv");
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(delimiter, new string[] { "index", "data", "is_discord" }));
            for (int index = 0; index < data.Count; index++)
            {
                string is_discord = "N";
                if (index >= best_so_far_loc && index <= best_so_far_loc + N_LENGTH - 1)
                    is_discord = "Y";
                sb.AppendLine(string.Join(delimiter, new string[] { index.ToString(), data[index].ToString(), is_discord }));
            }
            System.IO.File.WriteAllText(filePath, sb.ToString());
        }


        static public void writeFile_Cluster(RawDataType data, int N_LENGTH, int best_so_far_loc, List<int> cluster_belong)
        {
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Output\", "output_Cluster.csv");
            string delimiter = ",";

            List<int> cluster_belong_2 = new List<int>();
            for (int i = 0; i < data.Count - cluster_belong.Count; i++)
            {
                cluster_belong_2.Add(-1);
            }
            cluster_belong_2 = cluster_belong_2.Concat(cluster_belong).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(delimiter, new string[] { "index", "data", "is_discord", "cluster_belong" }));
            for (int index = 0; index < data.Count; index++)
            {
                string is_discord = "N";
                if (index >= best_so_far_loc && index <= best_so_far_loc + N_LENGTH - 1)
                    is_discord = "Y";
                sb.AppendLine(string.Join(delimiter, new string[] { index.ToString(), data[index].ToString(), is_discord, cluster_belong_2[index].ToString() }));
            }
            System.IO.File.WriteAllText(filePath, sb.ToString());
        }

        static public void WriteFile_Function(List<double> data, int N_LENGTH, int best_so_far_loc)
        {
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Output\", "output_SAX.csv");
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(delimiter, new string[] { "index", "data", "is_discord" }));
            for (int index = 0; index < data.Count; index++)
            {
                string is_discord = "N";
                if (index >= best_so_far_loc && index <= best_so_far_loc + N_LENGTH - 1)
                    is_discord = "Y";
                sb.AppendLine(string.Join(delimiter, new string[] { index.ToString(), data[index].ToString(), is_discord }));
            }
            System.IO.File.WriteAllText(filePath, sb.ToString());
        }

        static public void WriteFile_2(List<double> dist_pq, string name = "dist_pq.csv")
        {
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Output\", name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(name);
            for (int index = 0; index < dist_pq.Count; index++)
            {

                sb.AppendLine(dist_pq[index].ToString());
            }
            System.IO.File.WriteAllText(filePath, sb.ToString());
        }

        static public void rewriteStreamFile(string file_name, int num_line_to_skip = 0, int number_data = 2000)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data_Stream\", file_name);
            List<double> data_stream = new List<double>();

            //read file
            string[] lines = System.IO.File.ReadAllLines(path);

            //skip the header
            lines = lines.Skip(num_line_to_skip).ToArray();

            int i = 0;
            using (System.IO.StreamWriter file =
                                new System.IO.StreamWriter(path, false))
            {
                foreach (string line in lines)
                {
                    if (i < number_data)
                    {
                        string[] values = line.Split(',');
                        if (i + values.Count() <= number_data)
                        {
                            file.WriteLine(line);
                            i += values.Count();
                        }
                        else
                        {
                            file.WriteLine(String.Join(",", values.Take(number_data - i)));
                            i += number_data - i;
                        }

                    }
                }

            }

        }

        static public List<double> readFileIntoList(string file_name, int num_line_to_skip = 1)
        {

            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", file_name);
            List<double> data = new List<double>();

            //read file
            string[] lines = System.IO.File.ReadAllLines(path);

            //skip the header
            lines = lines.Skip(num_line_to_skip).ToArray();


            foreach (string line in lines)
            {
                data.Add(Convert.ToDouble(line)); //convert into a double list then add to 'data'
            }

            return data;
        }

        static public List<double> readStreamFile(string file_name, int num_line_to_skip = 1)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data_Stream\", file_name);
            List<double> data_stream = new List<double>();

            //read file
            string[] lines = System.IO.File.ReadAllLines(path);

            //skip the header
            lines = lines.Skip(num_line_to_skip).ToArray();


            foreach (string line in lines)
            {
                data_stream.Add(Convert.ToDouble(line)); //convert into a double list then add to 'data'
                //string[] values = line.Split(',');
                //foreach(string val in values)
                //    data_stream.Add(Convert.ToDouble(val));
            }

            return data_stream;
        }

        static public void readStatisticalFile(string file_name, string algorithm, ref List<double> dist, ref List<double> loc, ref double time)
        {
            dist = new List<double>();
            loc = new List<double>();
            string extension = System.IO.Path.GetExtension(file_name);
            file_name = System.IO.Path.GetFileNameWithoutExtension(file_name);
            string dist_path = Path.Combine(Environment.CurrentDirectory, @"Output\" + file_name + "\\" + algorithm + "\\", "dist" + extension);
            string loc_path = Path.Combine(Environment.CurrentDirectory, @"Output\" + file_name + "\\" + algorithm + "\\", "loc" + extension);
            string time_path = Path.Combine(Environment.CurrentDirectory, @"Output\" + file_name + "\\" + algorithm + "\\", "time" + extension);


            //read file
            string[] lines = System.IO.File.ReadAllLines(dist_path).ToArray();

            foreach (string line in lines)
            {
                dist.Add(Convert.ToDouble(line));
            }

            //read file
            lines = System.IO.File.ReadAllLines(loc_path).ToArray();

            foreach (string line in lines)
            {
                loc.Add(Convert.ToDouble(line));
            }

            //read file
            lines = System.IO.File.ReadAllLines(time_path).ToArray();
            time = Convert.ToDouble(lines[0]);
        }
    }
}
