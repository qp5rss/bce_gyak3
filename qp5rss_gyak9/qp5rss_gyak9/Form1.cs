using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using qp5rss_gyak9.Entities;

namespace qp5rss_gyak9
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random rng = new Random(777);

        public Form1()
        {
            InitializeComponent();
        }

        private async void bBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = @"C:\\temp";
            ofd.Filter = "Comma separated values (*.csv)|*.csv";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                progressIcon.Image = Properties.Resources.progress_red;
                richTextBox.Text += "Adatok betöltése...\n";
                long mainFileLength = 0;

                var folder = tbFile.Text;
                Progress<string> progress = new Progress<string>();
                progress.ProgressChanged += (_, newText) => richTextBox.Text += newText;
                Progress<long> lineCount = new Progress<long>();
                lineCount.ProgressChanged += (_, lines) => mainFileLength = lines;
                Progress<int> percentage = new Progress<int>();
                percentage.ProgressChanged += (_, percent) => 
                {   
                    progressBar.Value = percent; 
                    progressLabel.Text = "Feladat fut. Betöltés állapota: " + 
                        (mainFileLength * (double)percent/100).ToString("0") 
                        + "/" + mainFileLength + " sor feldolgozva."; 
                };
                await Task.Run(() => LoadData(folder, progress, percentage, lineCount));

                progressLabel.Text = "Feladat kész. " + mainFileLength + " sor feldolgozva.";
                progressBar.Value = 100;
                richTextBox.Text += "Adatok betöltve.\n";
                bStart.Enabled = true;
                progressIcon.Image = Properties.Resources.progress_green;
            }
        }

        private void LoadData(string folder, IProgress<string> progress, IProgress<int> percentage, IProgress<long> fileSize)
        {
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            progress.Report("\tSzületési esélyek betöltve.\n");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
            progress.Report("\tHalálozási esélyek betöltve.\n\tVárakozás a populáció betöltésére...\n");
            Progress<int> percent= new Progress<int>();
            percent.ProgressChanged += (_, perc) => percentage.Report(perc);
            Progress<long> lines = new Progress<long>();
            lines.ProgressChanged += (_, line) => fileSize.Report(line);
            Population = GetPopulation(folder, percent, lines);
            progress.Report("\tPopuláció betöltve.\n\n");
        }

        private async void bStart_Click(object sender, EventArgs e)
        {
            progressIcon.Image = Properties.Resources.progress_red;

            Progress<string> progress = new Progress<string>();
            progress.ProgressChanged += (_, newText) => richTextBox.Text += newText;
            Progress<int> percentage = new Progress<int>();
            percentage.ProgressChanged += (_, percent) =>
            {
                progressBar.Value = percent;
                progressLabel.Text = "Feladat fut. Feldolgozás állapota: " + percent + "%. Populáció: " + String.Format("{0:n0}", Population.Count());
            };
            await Task.Run(() => Simulation((int)nudYear.Value, progress, percentage));

            progressIcon.Image = Properties.Resources.progress_green;
            progressLabel.Text = "Szimuláció elvégezve.";
        }

        private void Simulation(int maxYear, IProgress<string> progress, IProgress<int> percentage)
        {
            progress.Report("Szimuláció megkezdése...\n\n");
            for (int year = 2005; year <= maxYear; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                    if (i % (int)(Population.Count / 100000) == 0)
                    {
                        int percentComplete = (int)((i * 100) / Population.Count);
                        percentage.Report(percentComplete);
                    }
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                progress.Report(string.Format("Szimulációs év: {0}\n\tFérfiak: {1}\n\tNők: {2}\n\n", year, 
                    String.Format("{0:n0}", nbrOfMales), 
                    String.Format("{0:n0}", nbrOfFemales)));
            }
            percentage.Report(100);
            progress.Report("Sikeres futás.");
        }

        private void SimStep(int year, Person person)
        {
            if (!person.IsAlive) return;

            byte age = (byte)(year - person.BirthYear);
            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.P).FirstOrDefault();

            if (rng.NextDouble() <= pDeath)
                person.IsAlive = false;
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.P).FirstOrDefault();

                if (rng.NextDouble() <= pBirth)
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.NbrOfChildren = 0;
                    újszülött.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(újszülött);
                }
            }
        }

        public long CountFileLines(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None, 1024 * 1024);

            long lineCount = 0;
            byte[] buffer = new byte[1024 * 1024];
            int bytesRead;

            do
            {
                bytesRead = fs.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < bytesRead; i++)
                    if (buffer[i] == '\n')
                        lineCount++;
            }
            while (bytesRead > 0);

            fs.Close();

            return lineCount;
        }

        public List<Person> GetPopulation(string csvpath, IProgress<int> percentage, IProgress<long> lines)
        {
            List<Person> population = new List<Person>();

            long lineCount = CountFileLines(csvpath);
            lines.Report(lineCount);

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                int counter = 1;
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = byte.Parse(line[2])
                    });

                    if (counter % (int)(lineCount / 100000) == 0)
                    {
                        int percentComplete = (int)((counter * 100) / lineCount);
                        percentage.Report(percentComplete);
                    }
                    counter++;
                }
            }

            return population;
        }

        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbability> bProbabilities = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    bProbabilities.Add(new BirthProbability()
                    {
                        Age = byte.Parse(line[0]),
                        NbrOfChildren = byte.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return bProbabilities;
        }

        public List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbability> dProbabilities = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    dProbabilities.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = byte.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return dProbabilities;
        }
    }
}
