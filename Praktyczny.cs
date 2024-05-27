using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace prawo_jazdy
{
    public partial class Praktyczny : Form
    {
        private string[] allTasks = new string[]
        {
            "poziom oleju w silniku",
            "poziom płynu chłodzącego",
            "poziom płynu hamulcowego",
            "obecność płynu w zbiorniku spryskiwaczy",
            "działanie sygnału dźwiękowego",
            "działanie świateł pozycyjnych",
            "działanie świateł mijania",
            "działanie świateł drogowych",
            "działanie świateł hamowania 'STOP'",
            "działanie świateł cofania",
            "działanie świateł kierunkowskazów",
            "działanie świateł awaryjnych",
            "Ruszanie z miejsca oraz jazda pasem ruchu do przodu i tyłu",
            "Włączanie się do ruchu",
            "Jazda drogami jednokierunkowymi o różnej liczbie pasów ruchu",
            "Przejazd przez skrzyżowania równorzędne",
            "Przejazd przez skrzyżowania z sygnalizacją świetlną",
            "Przejazd przez skrzyżowania, na których ruch odbywa się wokół wyspy",
            "Przejazd przez węzeł (wjazd i zjazd)",
            "Przejazd przez przejścia dla pieszych",
            "Przejazd przez torowisko tramwajowe i kolejowe",
            "Przejazd przez tunel",
            "Przejazd obok przystanku tramwajowego i autobusowego",
            "Wykonanie manewru wyprzedzania - jeżeli jest to możliwe",
            "Wykonanie manewru omijania - jeżeli jest to możliwe",
            "Wykonanie manewru wymijania",
            "Wykonanie manewru zmiany pasa ruchu",
            "Wykonanie manewru zmiany kierunku jazdy w prawo",
            "Wykonanie manewru zmiany kierunku jazdy w lewo",
            "Wykonanie manewru zawracania na skrzyżowaniu"
        };

        private string[] selectedTasks = new string[12];
        private List<Tuple<string, string>> completedTasks = new List<Tuple<string, string>>();

        public Praktyczny()
        {
            InitializeComponent();
        }

        private void Praktyczny_Load(object sender, EventArgs e)
        {
            this.Text = "Egzamin Praktyczny na Prawo Jazdy";
            this.Size = new Size(800, 900);

            Label infoLabel = new Label();
            infoLabel.Text = "Informacje o Egzaminie Praktycznym:";
            infoLabel.Location = new Point(10, 10);
            infoLabel.AutoSize = true;
            this.Controls.Add(infoLabel);

            Label nameLabel = new Label();
            nameLabel.Text = "Imię i Nazwisko:";
            nameLabel.Location = new Point(10, 40);
            nameLabel.AutoSize = true;
            this.Controls.Add(nameLabel);

            TextBox nameTextBox = new TextBox();
            nameTextBox.Location = new Point(170, 40);
            nameTextBox.Width = 200;
            this.Controls.Add(nameTextBox);

            Label dateLabel = new Label();
            dateLabel.Text = "Data Egzaminu:";
            dateLabel.Location = new Point(10, 70);
            dateLabel.AutoSize = true;
            this.Controls.Add(dateLabel);

            DateTimePicker datePicker = new DateTimePicker();
            datePicker.Location = new Point(170, 70);
            this.Controls.Add(datePicker);

            Label timeLabel = new Label();
            timeLabel.Text = "Godzina rozpoczęcia:";
            timeLabel.Location = new Point(10, 100);
            timeLabel.AutoSize = true;
            this.Controls.Add(timeLabel);

            DateTimePicker timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            timePicker.Location = new Point(170, 100);
            this.Controls.Add(timePicker);

            Label endTimeLabel = new Label();
            endTimeLabel.Text = "Godzina zakończenia:";
            endTimeLabel.Location = new Point(10, 130);
            endTimeLabel.AutoSize = true;
            this.Controls.Add(endTimeLabel);

            DateTimePicker endTimePicker = new DateTimePicker();
            endTimePicker.Format = DateTimePickerFormat.Time;
            endTimePicker.ShowUpDown = true;
            endTimePicker.Location = new Point(170, 130);
            this.Controls.Add(endTimePicker);

            Label tasksLabel = new Label();
            tasksLabel.Text = "Zadania do wykonania:";
            tasksLabel.Location = new Point(10, 160);
            tasksLabel.AutoSize = true;
            this.Controls.Add(tasksLabel);

            FlowLayoutPanel tasksPanel = new FlowLayoutPanel();
            tasksPanel.Location = new Point(10, 190);
            tasksPanel.Size = new Size(800, 600);
            tasksPanel.AutoScroll = true;
            this.Controls.Add(tasksPanel);

            SelectTasks();

            foreach (string task in selectedTasks)
            {
                Panel taskPanel = new Panel();
                taskPanel.Size = new Size(740, 40);

                Label taskLabel = new Label();
                taskLabel.Text = task;
                taskLabel.AutoSize = true;
                taskLabel.Location = new Point(5, 10);
                taskPanel.Controls.Add(taskLabel);

                RadioButton zeroPointsRadio = new RadioButton();
                zeroPointsRadio.Text = "0 pkt";
                zeroPointsRadio.Location = new Point(480, 10);
                zeroPointsRadio.AutoSize = true;
                taskPanel.Controls.Add(zeroPointsRadio);

                RadioButton onePointRadio = new RadioButton();
                onePointRadio.Text = "1 pkt";
                onePointRadio.Location = new Point(550, 10);
                onePointRadio.AutoSize = true;
                taskPanel.Controls.Add(onePointRadio);

                RadioButton twoPointsRadio = new RadioButton();
                twoPointsRadio.Text = "2 pkt";
                twoPointsRadio.Location = new Point(620, 10);
                twoPointsRadio.AutoSize = true;
                taskPanel.Controls.Add(twoPointsRadio);

                tasksPanel.Controls.Add(taskPanel);
            }

            Button confirmButton = new Button();
            confirmButton.Text = "Potwierdź";
            confirmButton.Location = new Point(10, 800);
            confirmButton.Size = new Size(100, 50);
            confirmButton.Click += (s, ea) =>
            {
            completedTasks.Clear();
            foreach (Panel taskPanel in tasksPanel.Controls)
            {
                Label taskLabel = (Label)taskPanel.Controls[0];
                RadioButton zeroPointsRadio = (RadioButton)taskPanel.Controls[1];
                RadioButton onePointsRadio = (RadioButton)taskPanel.Controls[2];
                    RadioButton twoPointsRadio = (RadioButton)taskPanel.Controls[3];

                    string points = "0 pkt";
                    if (onePointsRadio.Checked)
                    {
                        points = "1 pkt";
                    }
                    else if (twoPointsRadio.Checked)
                    {
                        points = "2 pkt";
                    }
                    completedTasks.Add(new Tuple<string, string>(taskLabel.Text, points));
                }
                ConfirmationForm confirmationForm = new ConfirmationForm(completedTasks, nameTextBox.Text, datePicker.Value, timePicker.Value, endTimePicker.Value);
                confirmationForm.ShowDialog();
            };
            this.Controls.Add(confirmButton);

            Button cancelButton = new Button();
            cancelButton.Text = "Anuluj";
            cancelButton.Location = new Point(120, 800);
            cancelButton.Size = new Size(100, 50);
            cancelButton.Click += (s, ea) => this.Close();
            this.Controls.Add(cancelButton);
        }

        private void SelectTasks()
        {
            Random rand = new Random();
            
            string[] firstThreeTasks = allTasks.Take(12).OrderBy(x => rand.Next()).Take(3).ToArray();
            int index = 0;
            foreach (string task in firstThreeTasks)
            {
                selectedTasks[index++] = task;
            }

            
            selectedTasks[index++] = allTasks[12];

            
            string[] remainingTasks = allTasks.Skip(13).OrderBy(x => rand.Next()).Take(8).ToArray();
            foreach (string task in remainingTasks)
            {
                selectedTasks[index++] = task;
            }
        }
    }

    public class ConfirmationForm : Form
    {
        public ConfirmationForm(List<Tuple<string, string>> completedTasks, string name, DateTime examDate, DateTime startTime, DateTime endTime)
        {
            this.Text = "Potwierdzenie";
            this.Size = new Size(800, 800);

            Label nameLabel = new Label();
            nameLabel.Text = $"Imię i Nazwisko: {name}";
            nameLabel.Location = new Point(10, 10);
            nameLabel.AutoSize = true;
            this.Controls.Add(nameLabel);

            Label dateLabel = new Label();
            dateLabel.Text = $"Data Egzaminu: {examDate.ToShortDateString()}";
            dateLabel.Location = new Point(10, 40);
            dateLabel.AutoSize = true;
            this.Controls.Add(dateLabel);

            Label startTimeLabel = new Label();
            startTimeLabel.Text = $"Godzina rozpoczęcia: {startTime.ToShortTimeString()}";
            startTimeLabel.Location = new Point(10, 70);
            startTimeLabel.AutoSize = true;
            this.Controls.Add(startTimeLabel);

            Label endTimeLabel = new Label();
            endTimeLabel.Text = $"Godzina zakończenia: {endTime.ToShortTimeString()}";
            endTimeLabel.Location = new Point(10, 100);
            endTimeLabel.AutoSize = true;
            this.Controls.Add(endTimeLabel);

            ListView listView = new ListView();
            listView.View = View.Details;
            listView.Columns.Add("Zadanie", 600);
            listView.Columns.Add("Punkty", 50);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Location = new Point(10, 130);
            listView.Size = new Size(700, 400);

            foreach (var task in completedTasks)
            {
                ListViewItem item = new ListViewItem(task.Item1);
                item.SubItems.Add(task.Item2);
                listView.Items.Add(item);
            }

            this.Controls.Add(listView);

            
            int totalPoints = 0;
            foreach (var task in completedTasks)
            {
                if (task.Item2 == "1 pkt")
                {
                    totalPoints += 1;
                }
                else if (task.Item2 == "2 pkt")
                {
                    totalPoints += 2;
                }
            }

            Label resultLabel = new Label();
            resultLabel.Text = $"Wynik: {totalPoints} punktów / 24 punktów";
            resultLabel.Location = new Point(10, 600);
            resultLabel.AutoSize = true;
            resultLabel.TextAlign = ContentAlignment.TopRight; 
            this.Controls.Add(resultLabel);

            Label passOrFailLabel = new Label();
            passOrFailLabel.Text = totalPoints >= 23 ? "Zdałeś!" : "Nie zdałeś.";
            passOrFailLabel.ForeColor = totalPoints >= 23 ? Color.Green : Color.Red;
            passOrFailLabel.Font = new Font(passOrFailLabel.Font, FontStyle.Bold);
            passOrFailLabel.Location = new Point(10, 630);
            passOrFailLabel.AutoSize = true;
            passOrFailLabel.TextAlign = ContentAlignment.MiddleCenter; 
            this.Controls.Add(passOrFailLabel);

            Button closeButton = new Button();
            closeButton.Text = "Zamknij";
            closeButton.Location = new Point(150, 700);
            closeButton.Click += (s, e) => this.Close();
            closeButton.Size = new Size(100, 40);
            this.Controls.Add(closeButton);
        }
    }
}

