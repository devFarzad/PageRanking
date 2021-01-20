using System;
using System.Windows;
using System.Windows.Documents;

namespace PageRanking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int[,] Path = new int[10, 10];
        public double[] PageRank = new double[10];


        // Function Calculate
        public void Calculation(double totalNodes)
        {

            double InitialPageRank;
            double OutgoingLinks = 0;
            double DampingFactor = 0.85;
            double[] TempPageRank = new double[10];
            int ExternalNodeNumber;
            int InternalNodeNumber;
            int i = 1;
            int Iteration = 1;
            InitialPageRank = 1 / totalNodes;

            out_Result.Text += " Total Number of Nodes: " + totalNodes + "\t Initial PageRank of All Nodes :" + InitialPageRank + "\n";
            for (i = 1; i <= totalNodes; i++)
            {
                this.PageRank[i] = InitialPageRank;
            }
            out_Result.Text += "\n Initial PageRank Values , 0 th Step \n";
            for (i = 1; i <= totalNodes; i++)
            {

                out_Result.Text += " Page Rank of " + i + " is :\t" + this.PageRank[i] + "\n";
            }

            while (Iteration <= 2)
            {

                for (i = 1; i <= totalNodes; i++)
                {
                    TempPageRank[i] = this.PageRank[i];
                    this.PageRank[i] = 0;
                }
                for (InternalNodeNumber = 1; InternalNodeNumber <= totalNodes; InternalNodeNumber++)
                {
                    for (ExternalNodeNumber = 1; ExternalNodeNumber <= totalNodes; ExternalNodeNumber++)
                    {
                        if (Path[ExternalNodeNumber, InternalNodeNumber] == 1)
                        {
                            i = 1;
                            OutgoingLinks = 0;
                            while (i <= totalNodes)
                            {
                                if (this.Path[ExternalNodeNumber, i] == 1)
                                {
                                    OutgoingLinks = OutgoingLinks + 1;
                                }
                                i = i + 1;
                            }

                            this.PageRank[InternalNodeNumber] += TempPageRank[ExternalNodeNumber] * (1 / OutgoingLinks);
                        }
                    }
                }
                out_Result.Text += "\n After " + Iteration + "th Step \n";
                for (i = 1; i <= totalNodes; i++)
                {
                    out_Result.Text += "Page Rank of " + i + " is :\t" + this.PageRank[i] + "\n";
                }

                Iteration = Iteration + 1;
            }

            for (i = 1; i <= totalNodes; i++)
            {
                this.PageRank[i] = (1 - DampingFactor) + DampingFactor * this.PageRank[i];
            }

            out_Result.Text += "\n Final Page Rank : \n";
            for (i = 1; i <= totalNodes; i++)
            {
                out_Result.Text += " Page Rank of " + i + " is :\t" + this.PageRank[i] + "\n";
            }


        }

        private void btn_Run_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                out_Result.Text = "";


                double nodes;
                int i, j, cost;
                TextRange textRange = new TextRange(in_Matrix.Document.ContentStart,

            in_Matrix.Document.ContentEnd);


                string ValueMatrix = textRange.Text.Trim();
                string[] InputMatrixString = ValueMatrix.Split('\n');
                //Remove Space in Array
                for (int k = 0; k < Convert.ToInt32(in_GruphNum.Text.Trim()); k++)
                {
                    InputMatrixString[k] = InputMatrixString[k].Replace(" ", "");
                }


                nodes = Convert.ToDouble(in_GruphNum.Text.Trim());

                for (i = 1; i <= nodes; i++)
                    for (j = 1; j <= nodes; j++)
                    {
                        string A = InputMatrixString[i - 1].Substring(j - 1, 1);

                        if (!string.IsNullOrWhiteSpace(A) && A != "\r")
                        {
                            Path[i, j] = Convert.ToInt32(InputMatrixString[i - 1].Substring(j - 1, 1));
                            if (j == i)
                                Path[i, j] = 0;
                        }




                    }
                Calculation(nodes);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Matrix Invalid");
            }



        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            in_Matrix.Document.Blocks.Clear();
            out_Result.Text = "";
            in_GruphNum.Text = "";
        }
    }
}
