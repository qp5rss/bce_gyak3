using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                richTextBox.Text += "Adatok betöltése...\n";
                var folder = tbFile.Text;
                Progress<string> progress = new Progress<string>();
                progress.ProgressChanged += (_, newText) => richTextBox.Text += newText;
                await Task.Run(() => LoadData(folder, progress));
                richTextBox.Text += "Adatok betöltve.\n";
                bStart.Enabled = true;
            }
        }

        private void LoadData(string folder, IProgress<string> progress)
        {
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            progress.Report("\tSzületési esélyek betöltve.\n");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
            progress.Report("\tHalálozási esélyek betöltve.\n\tVárakozás a populáció betöltésére...\n");
            Population = GetPopulation(folder);
            progress.Report("\tPopuláció betöltve.\n\n");
        }

        private async void bStart_Click(object sender, EventArgs e)
        {
            Progress<string> progress = new Progress<string>();
            progress.ProgressChanged += (_, newText) => richTextBox.Text += newText;
            Progress<int> percentage = new Progress<int>(percent => progressBar.Value = percent);
            await Task.Run(() => Simulation((int)nudYear.Value, progress, percentage));
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
                progress.Report(string.Format("Szimulációs év: {0}\n\tFérfiak: {1}\n\tNők: {2}\n\n", year, nbrOfMales, nbrOfFemales));
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

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = byte.Parse(line[2])
                    });
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
