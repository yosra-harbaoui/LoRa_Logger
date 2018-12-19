using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using LoRa_Logger.Models;

namespace LoRa_Logger
{
    public partial class MainForm : Form
    {
        private List<Floor> floors;
        private List<Gateway> gateways;
        private List<Entry> entries;
        private List<Measure> measures;        

        private BindingSource bindingSource;

        private enum UL { One, Two};

        public MainForm()
        {
            InitializeComponent();

            floors = new List<Floor>();
            gateways = new List<Gateway>();
            entries = new List<Entry>();
            measures = new List<Measure>();            

            floors.Add(new Floor("A"));
            floors.Add(new Floor("B"));
            floors.Add(new Floor("C"));
            floors.Add(new Floor("D"));
            floors.Add(new Floor("E"));
            floors.Add(new Floor("F"));
            floors.Add(new Floor("G"));
            floors.Add(new Floor("H"));
            floors.Add(new Floor("J"));
            floors.Add(new Floor("K"));

            gateways.Add(new Gateway("K01a", "7276FF003903094E"));
            gateways.Add(new Gateway("F07", "7276FF003903094F"));
            gateways.Add(new Gateway("B40", "7276FF0039030950"));
            gateways.Add(new Gateway("C22", "7276FF003903097C"));
            gateways.Add(new Gateway("A02b", "7276FF00390309F5"));
            gateways.Add(new Gateway("D60", "7276FF003903097D"));
            gateways.Add(new Gateway("H06", "7276FF0039030977"));

            foreach (Floor floor in floors)
            {
                floorsComboBox.Items.Add(floor);
            }

            bindingSource = new BindingSource { DataSource = entries };
            dataGridView1.DataSource = bindingSource;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void addEntryButton_Click(object sender, EventArgs e)
        {
            if(floorsComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select a floor !");

                return;
            }

            Entry newEntry = new Entry();
            
            int index = floors.FindIndex(obj => obj.Name == floorsComboBox.SelectedItem.ToString());

            //newEntry.Floor = floors[index];
            newEntry.Floor = floors[index].ToString();
            newEntry.Number = (int)numericUpDown1.Value;
            newEntry.UL1 = (int)numericUpDown2.Value;
            newEntry.UL2 = (int)numericUpDown3.Value;
            newEntry.Time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffZ");

            bindingSource.Add(newEntry);

            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;

            if (checkBox1.Checked)
            {
                numericUpDown1.Value += 1;
            }

            if (checkBox2.Checked)
            {
                numericUpDown2.Value += 1;
            }

            if (checkBox3.Checked)
            {
                numericUpDown3.Value += 1;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            FileUtils.WriteCSV(entries);                     
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = !checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = !checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = !checkBox3.Checked;
        }
        
        private void loadButton_Click(object sender, EventArgs e)
        {
            List<Entry> csvEntries = FileUtils.ReadCSV<Entry>();

            if(csvEntries != null)
            {
                if(checkBox4.Checked)
                {
                    entries.Clear();
                }

                entries.AddRange(csvEntries);
                bindingSource.ResetBindings(false);
            }            
        }

        private void matchButton_Click(object sender, EventArgs e)
        {
            Match(UL.One);
        }
        
        private void matchUL2Button_Click(object sender, EventArgs e)
        {
            Match(UL.Two);
        }
        
        private void vectorButton_Click(object sender, EventArgs e)
        {            
            string json = FileUtils.ReadJSON();

            if (json.Equals(""))
            {
                return;
            }

            List<Vector> vectors = new List<Vector>();
            List<Entry> entries = JsonConvert.DeserializeObject<List<Entry>>(json);

            foreach (Entry entry in entries)
            {
                Vector vector = new Vector(entry.Floor, entry.Number);

                foreach (Gateway gateway in gateways)
                {
                    Gateway temp = new Gateway(gateway.Name, gateway.Eui);

                    foreach (Measure measure in entry.Measures)
                    {
                        if (measure.gwName.Equals(temp.Name))
                        {
                            temp.Rssi = measure.gwRssi;
                        }
                    }

                    if (temp.Rssi != -999)
                    {
                        vector.Gateways.Add(temp);
                    }
                }

                vectors.Add(vector);
            }

            FileUtils.WriteJSON(vectors);
        }

        private void formulaButton_Click(object sender, EventArgs e)
        {
            string[] filePaths = FileUtils.GetFilePaths();

            if(filePaths == null || filePaths.Length == 0)
            {
                return;
            }

            TextReader textReader_a = File.OpenText(filePaths[0]);
            TextReader textReader_b = File.OpenText(filePaths[1]);
            TextReader textReader_c = null;

            string json_a = textReader_a.ReadToEnd();
            string json_b = textReader_b.ReadToEnd();
            string json_c = "";

            List<Vector> mesures_1 = JsonConvert.DeserializeObject<List<Vector>>(json_a);
            List<Vector> mesures_2 = JsonConvert.DeserializeObject<List<Vector>>(json_b);
            List<Vector> mesures_3 = null;

            if (filePaths.Length == 3)
            {
                textReader_c = File.OpenText(filePaths[2]);
                json_c = textReader_c.ReadToEnd();
                mesures_3 = JsonConvert.DeserializeObject<List<Vector>>(json_c);
            }

            List<Formula> formulas = new List<Formula>();

            #region 1ère avec 2ème
            foreach (Vector mesure_1 in mesures_1)
            {
                Formula formula = formulas.Where(i => i.Number == mesure_1.Number).FirstOrDefault();

                if (formula == null)
                {
                    formula = new Formula(mesure_1.Floor, mesure_1.Number);
                    formulas.Add(formula);
                }

                Vector mesure_2 = mesures_2.Where(i => i.Number == mesure_1.Number).FirstOrDefault();

                if (mesure_2 == null)
                {
                    continue;
                }

                List<double> pows = new List<double>();

                foreach (Gateway firstGateway in mesure_1.Gateways)
                {
                    Gateway secondGateway = mesure_2.Gateways.Where(i => i.Name.Equals(firstGateway.Name)).FirstOrDefault();

                    if (secondGateway != null)
                    {
                        double pow = Math.Pow(firstGateway.Rssi - secondGateway.Rssi, 2);

                        pows.Add(pow);
                    }
                }

                double result = FormulaUtils.SumSqrt(pows);

                if (pows.Count != 0)
                {
                    formula.Distances.Add(result);
                }
            }
            #endregion

            if (mesures_3 != null)
            {
                #region 1ère avec 3ème  
                foreach (Vector mesure_1 in mesures_1)
                {
                    Formula formula = formulas.Where(i => i.Number == mesure_1.Number).FirstOrDefault();

                    if (formula == null)
                    {
                        formula = new Formula(mesure_1.Floor, mesure_1.Number);
                        formulas.Add(formula);
                    }

                    Vector mesure_3 = mesures_3.Where(i => i.Number == mesure_1.Number).FirstOrDefault();

                    List<double> pows = new List<double>();

                    foreach (Gateway firstGateway in mesure_1.Gateways)
                    {
                        if (mesure_3 == null)
                        {
                            break;
                        }

                        Gateway secondGateway = mesure_3.Gateways.Where(i => i.Name.Equals(firstGateway.Name)).FirstOrDefault();

                        if (secondGateway != null)
                        {
                            double pow = Math.Pow(firstGateway.Rssi - secondGateway.Rssi, 2);

                            pows.Add(pow);
                        }
                    }

                    double result = FormulaUtils.SumSqrt(pows);

                    if (pows.Count != 0)
                    {
                        formula.Distances.Add(result);
                    }
                }
                #endregion

                #region 2ème avec 3ème
                foreach (Vector mesure_2 in mesures_2)
                {
                    Formula formula = formulas.Where(i => i.Number == mesure_2.Number).FirstOrDefault();

                    if (formula == null)
                    {
                        formula = new Formula(mesure_2.Floor, mesure_2.Number);
                        formulas.Add(formula);
                    }

                    Vector mesure_3 = mesures_3.Where(i => i.Number == mesure_2.Number).FirstOrDefault();

                    List<double> pows = new List<double>();

                    foreach (Gateway firstGateway in mesure_2.Gateways)
                    {
                        if (mesure_3 == null)
                        {
                            break;
                        }

                        Gateway secondGateway = mesure_3.Gateways.Where(i => i.Name.Equals(firstGateway.Name)).FirstOrDefault();

                        if (secondGateway != null)
                        {
                            double pow = Math.Pow(firstGateway.Rssi - secondGateway.Rssi, 2);

                            pows.Add(pow);
                        }
                    }

                    double result = FormulaUtils.SumSqrt(pows);

                    if (pows.Count != 0)
                    {
                        formula.Distances.Add(result);
                    }

                    // formulas.Add(formula);
                }
                #endregion
            }

            FileUtils.WriteJSON(formulas);
        }

        private void maximumButton_Click(object sender, EventArgs e)
        {
            string[] filePaths = FileUtils.GetFilePaths(2, 10);

            if (filePaths == null || filePaths.Length == 0)
            {
                return;
            }

            List<dynamic> entries = new List<dynamic>();

            foreach (string file in filePaths)
            {
                using (TextReader textReader = File.OpenText(file))
                {
                    string json = textReader.ReadToEnd();

                    List<Formula> formulas = JsonConvert.DeserializeObject<List<Formula>>(json);

                    foreach (Formula formula in formulas)
                    {
                        if (formula.Distances.Count > 0)
                        {
                            double max = -1;

                            foreach (double distance in formula.Distances)
                            {
                                if (distance > max)
                                {
                                    max = distance;
                                }
                            }

                            dynamic entry = new ExpandoObject();

                            entry.Floor = formula.Floor;
                            entry.Number = formula.Number;
                            entry.MaxDistance = max;

                            entries.Add(entry);
                        }
                    }
                }
            }

            FileUtils.WriteJSON(entries);
        }

        private void heatMapButton_Click(object sender, EventArgs e)
        {
            string[] filePaths = FileUtils.GetFilePaths(2, 3);

            if (filePaths == null || filePaths.Length == 0)
            {
                return;
            }

            TextReader textReader_a = File.OpenText(filePaths[0]);
            TextReader textReader_b = File.OpenText(filePaths[1]);
            TextReader textReader_c = null;

            string json_a = textReader_a.ReadToEnd();
            string json_b = textReader_b.ReadToEnd();
            string json_c = "";

            List<Vector> mesures_1 = JsonConvert.DeserializeObject<List<Vector>>(json_a);
            List<Vector> mesures_2 = JsonConvert.DeserializeObject<List<Vector>>(json_b);
            List<Vector> mesures_3 = null;

            if (filePaths.Length == 3)
            {
                textReader_c = File.OpenText(filePaths[2]);
                json_c = textReader_c.ReadToEnd();
                mesures_3 = JsonConvert.DeserializeObject<List<Vector>>(json_c);
            }

            List<Maximum> maximums = new List<Maximum>();

            foreach (Vector mesure_1 in mesures_1)
            {
                int max = -150;

                foreach (Gateway gateway in mesure_1.Gateways)
                {
                    int rssi = gateway.Rssi;

                    if (rssi > max)
                    {
                        max = rssi;
                    }
                }

                Vector mesure_2 = mesures_2.Where(i => i.Number == mesure_1.Number).FirstOrDefault();

                if (mesure_2 != null)
                {
                    foreach (Gateway gateway in mesure_2.Gateways)
                    {
                        int rssi = gateway.Rssi;

                        if (rssi > max)
                        {
                            max = rssi;
                        }
                    }
                }

                if (mesures_3 != null)
                {
                    Vector mesure_3 = mesures_3.Where(i => i.Number == mesure_1.Number).FirstOrDefault();

                    if (mesure_3 != null)
                    {
                        foreach (Gateway gateway in mesure_3.Gateways)
                        {
                            int rssi = gateway.Rssi;

                            if (rssi > max)
                            {
                                max = rssi;
                            }
                        }
                    }
                }

                Maximum maximum = maximums.Where(i => i.Number.Equals(mesure_1.Number)).FirstOrDefault();

                if (maximum == null)
                {
                    maximum = new Maximum(mesure_1.Number, max);
                    maximums.Add(maximum);
                }
                else
                {
                    if (max > maximum.Rssi)
                    {
                        maximum.Rssi = max;
                    }
                }
            }

            foreach (Vector mesure_2 in mesures_2)
            {
                int max = -150;

                foreach (Gateway gateway in mesure_2.Gateways)
                {
                    int rssi = gateway.Rssi;

                    if (rssi > max)
                    {
                        max = rssi;
                    }
                }

                Vector mesure_1 = mesures_1.Where(i => i.Number == mesure_2.Number).FirstOrDefault();

                if (mesure_1 != null)
                {
                    foreach (Gateway gateway in mesure_1.Gateways)
                    {
                        int rssi = gateway.Rssi;

                        if (rssi > max)
                        {
                            max = rssi;
                        }
                    }
                }

                if (mesures_3 != null)
                {
                    Vector mesure_3 = mesures_3.Where(i => i.Number == mesure_2.Number).FirstOrDefault();

                    if (mesure_3 != null)
                    {
                        foreach (Gateway gateway in mesure_3.Gateways)
                        {
                            int rssi = gateway.Rssi;

                            if (rssi > max)
                            {
                                max = rssi;
                            }
                        }
                    }
                }

                Maximum maximum = maximums.Where(i => i.Number.Equals(mesure_2.Number)).FirstOrDefault();

                if (maximum == null)
                {
                    maximum = new Maximum(mesure_2.Number, max);
                    maximums.Add(maximum);
                }
                else
                {
                    if (max > maximum.Rssi)
                    {
                        maximum.Rssi = max;
                    }
                }
            }

            if (mesures_3 != null)
            {
                foreach (Vector mesure_3 in mesures_3)
                {
                    int max = -150;

                    foreach (Gateway gateway in mesure_3.Gateways)
                    {
                        int rssi = gateway.Rssi;

                        if (rssi > max)
                        {
                            max = rssi;
                        }
                    }

                    Vector mesure_1 = mesures_1.Where(i => i.Number == mesure_3.Number).FirstOrDefault();

                    if (mesure_1 != null)
                    {
                        foreach (Gateway gateway in mesure_1.Gateways)
                        {
                            int rssi = gateway.Rssi;

                            if (rssi > max)
                            {
                                max = rssi;
                            }
                        }
                    }

                    Vector mesure_2 = mesures_3.Where(i => i.Number == mesure_3.Number).FirstOrDefault();

                    if (mesure_2 != null)
                    {
                        foreach (Gateway gateway in mesure_2.Gateways)
                        {
                            int rssi = gateway.Rssi;

                            if (rssi > max)
                            {
                                max = rssi;
                            }
                        }
                    }

                    Maximum maximum = maximums.Where(i => i.Number.Equals(mesure_2.Number)).FirstOrDefault();

                    if (maximum == null)
                    {
                        maximum = new Maximum(mesure_2.Number, max);
                        maximums.Add(maximum);
                    }
                    else
                    {
                        if (max > maximum.Rssi)
                        {
                            maximum.Rssi = max;
                        }
                    }
                }
            }

            string json = FileUtils.ReadJSON();

            if(json.Equals(""))
            {
                return;
            }

            dynamic geojson = JObject.Parse(json);

            JArray features = geojson.features;

            double pourcentage_max = 100d;
            double poucentage_min = 0d;

            double rssi_max = Math.Abs(-150d);
            double rssi_min = Math.Abs(0d);

            double m = (pourcentage_max - poucentage_min) / (rssi_min - rssi_max);
            double b = poucentage_min - m * rssi_max;

            foreach (dynamic feature in features)
            {
                Maximum maximum = maximums.Where(i => i.Number.Equals((int)feature.properties.id)).FirstOrDefault();

                if (maximum != null)
                {
                    double pourcentage = b - m * maximum.Rssi;

                    feature.properties.value = pourcentage;

                    Vector mesure_1 = mesures_1.Where(i => i.Number.Equals((int)feature.properties.id)).FirstOrDefault();
                    Vector mesure_2 = mesures_2.Where(i => i.Number.Equals((int)feature.properties.id)).FirstOrDefault();

                    string mesure_1_array = "";
                    if (mesure_1 != null)
                    {
                        foreach (Gateway gateway in mesure_1.Gateways)
                        {
                            mesure_1_array += gateway.Name + ":" + gateway.Rssi;
                            if (!mesure_1.Gateways.LastOrDefault().Equals(gateway))
                            {
                                mesure_1_array += ";";
                            }
                        }
                    }
                    feature.properties.measure_1 = mesure_1_array;

                    string mesure_2_array = "";
                    if (mesure_2 != null)
                    {

                        foreach (Gateway gateway in mesure_2.Gateways)
                        {
                            mesure_2_array += gateway.Name + ":" + gateway.Rssi;
                            if (!mesure_2.Gateways.LastOrDefault().Equals(gateway))
                            {
                                mesure_2_array += ";";
                            }
                        }
                    }
                    feature.properties.measure_2 = mesure_2_array;

                    string mesure_3_array = "";
                    if (mesures_3 != null)
                    {
                        Vector mesure_3 = mesures_3.Where(i => i.Number.Equals((int)feature.properties.id)).FirstOrDefault();

                        if (mesure_3 != null)
                        {

                            foreach (Gateway gateway in mesure_3.Gateways)
                            {
                                mesure_3_array += gateway.Name + ":" + gateway.Rssi;
                                if (!mesure_3.Gateways.LastOrDefault().Equals(gateway))
                                {
                                    mesure_3_array += ";";
                                }
                            }
                        }
                    }
                    feature.properties.measure_3 = mesure_3_array;
                }
                else
                {
                    feature.properties.value = -1;
                }
            }

            FileUtils.WriteJSON(geojson);
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            // Read Unknown
            string unknown_json = FileUtils.ReadJSON();

            if(unknown_json.Equals(""))
            {
                return;
            }

            Vector unknown = JsonConvert.DeserializeObject<Vector>(unknown_json);

            // Read Maximums
            string maximums_json = FileUtils.ReadJSON();

            if (maximums_json.Equals(""))
            {
                return;
            }

            List<Maximum2> maximums = JsonConvert.DeserializeObject<List<Maximum2>>(maximums_json);
                      
            string[] filePaths = FileUtils.GetFilePaths(1, 9999);

            if (filePaths == null || filePaths.Length == 0)
            {
                return;
            }

            List<Candidate> candidates = new List<Candidate>();

            foreach (string filePath in filePaths)
            {
                string json = File.OpenText(filePath).ReadToEnd();

                List<Vector> mesures = JsonConvert.DeserializeObject<List<Vector>>(json);

                foreach (Vector mesure in mesures)
                {
                    List<double> pows = new List<double>();

                    bool flag = true;

                    if (unknown.Gateways.Count > mesure.Gateways.Count)
                    {
                        flag = false;
                    }

                    foreach (Gateway firstGateway in mesure.Gateways)
                    {
                        Gateway seccondGateway = unknown.Gateways.Where(i => i.Name.Equals(firstGateway.Name)).FirstOrDefault();

                        if (seccondGateway == null)
                        {
                            flag = false;
                        }
                    }

                    if (flag == false)
                    {
                        continue;
                    }

                    foreach (Gateway firstGateway in mesure.Gateways)
                    {
                        Gateway secondGateway = null;

                        foreach (dynamic gateway in unknown.Gateways)
                        {
                            if (gateway.Name == firstGateway.Name)
                            {
                                secondGateway = gateway;
                                break;
                            }
                        }

                        if (secondGateway != null)
                        {
                            double pow = Math.Pow(firstGateway.Rssi - secondGateway.Rssi, 2);

                            pows.Add(pow);
                        }
                    }

                    double result = FormulaUtils.SumSqrt(pows);

                    if (pows.Count != 0)
                    {
                        Maximum2 maximum2 = maximums.Where(i => i.Number == mesure.Number && i.Floor.Equals(mesure.Floor)).FirstOrDefault();

                        if (maximum2 != null)
                        {
                            if (result <= maximum2.MaxDistance)
                            {
                                Candidate candidate = candidates.Where(i => i.Number == mesure.Number && i.Floor.Equals(mesure.Floor)).FirstOrDefault();

                                if (candidate == null)
                                {
                                    candidate = new Candidate(mesure.Floor, mesure.Number, result);
                                    candidates.Add(candidate);
                                }
                            }
                        }
                    }
                }
            }

            var sorted = candidates.OrderBy(o => o.Result);

            FileUtils.WriteJSON(sorted);
        }               

        private void Match(UL ul)
        {
            measures = FileUtils.ReadCSV<Measure>();

            if(measures != null && entries != null)
            {
                foreach (Entry entry in entries)
                {
                    DateTime timeEntry = DateTime.Parse(entry.Time);

                    List<Measure> canditates = new List<Measure>();

                    foreach (Measure measure in measures)
                    {
                        DateTime timeMeasure = DateTime.Parse(measure.time);

                        if (timeMeasure.Year == timeEntry.Year
                            && timeMeasure.Month == timeEntry.Month
                            && timeMeasure.Day == timeEntry.Day
                            && timeMeasure.Hour == timeEntry.Hour
                            && (timeMeasure.Minute >= timeEntry.Minute - 2 || timeMeasure.Minute <= timeEntry.Minute + 2)
                            && measure.devUplinkCounter == (ul == UL.One ? entry.UL1 : entry.UL2) % 256)
                        {
                            canditates.Add(measure);
                        }
                    }

                    foreach (Measure canditate in canditates)
                    {
                        entry.Measures.Add(canditate);
                    }
                }

                FileUtils.WriteJSON(entries);
            }
        }
    }
}