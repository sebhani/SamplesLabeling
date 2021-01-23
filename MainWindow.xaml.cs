using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SamplesLabeling
{
    public partial class MainWindow : Window
    {
        const string sampleIdFilePath = "recentID.json";
        string printerName = "";
        SampleID currentID_used, currentID_A, currentID_B, currentID_C, currentID_D;
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(File.ReadAllText(sampleIdFilePath));
        IDictionary<string, int> specimenUsed = null;//used for printing the proper # of copies
        public MainWindow()
        {
            InitializeComponent();

            //initialize sampleID object with the ID value in recentID.json
            currentID_A = new SampleID((int)jsonObj["Id_A"]);
            currentID_B = new SampleID((int)jsonObj["Id_B"]);
            currentID_C = new SampleID((int)jsonObj["Id_C"]);
            currentID_D = new SampleID((int)jsonObj["Id_D"]);

            printerName = jsonObj["printer_name"];

            setDefaults();
        }

        //Update Specimen ComboBox according to the chosen area
        private void areaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            switch (cmb.SelectedIndex)
            {
                case 0:
                    setFieldsOnAreaListOptionSelection(SpecimenRepository.areaA, currentID_A);
                    break;
                case 1:
                    setFieldsOnAreaListOptionSelection(SpecimenRepository.areaB, currentID_B);
                    break;
                case 2:
                    setFieldsOnAreaListOptionSelection(SpecimenRepository.areaC, currentID_C);
                    break;
                case 3:
                    setFieldsOnAreaListOptionSelection(SpecimenRepository.areaD, currentID_D);
                    break;
            }
        }

        //Update currentID.json file with the recent id's
        private void Window_Closed(object sender, EventArgs e)
        {
            //update recentID.json file with the newest sample id
            jsonObj["Id_A"] = int.Parse(currentID_A.getId());
            jsonObj["Id_B"] = int.Parse(currentID_B.getId());
            jsonObj["Id_C"] = int.Parse(currentID_C.getId());
            jsonObj["Id_D"] = int.Parse(currentID_D.getId());
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(sampleIdFilePath, output);
        }

        private void aboutLink_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("This application is implemented by Faisal Al-Khalaf\nPhone Number: 0536415676\nE-mail: f.s.k.a@live.com");
        }

        //the printing functionality is taken from https://gist.github.com/albertbaldi/7b8d86a20430e101299fe8a4eccf5deb and
        //modified to suit our use case
        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            //ensure no area nor specimen empty field is chosen
            if (specimenList.SelectedItem == null || areaList.SelectedItem == null)
            {
                MessageBox.Show("Area and Specimen should be selected!");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = printerName;
            pd.DefaultPageSettings.Landscape = false;
            pd.DefaultPageSettings.PaperSize = new PaperSize("PaperA4", 826, 1169);
            pd.DefaultPageSettings.Margins = new Margins(15, 15, 15, 15);
            pd.OriginAtMargins = true;
            pd.PrinterSettings.Copies = (short)specimenUsed[specimenList.SelectedItem.ToString()];//# of copies to be printed

            pd.PrintPage += Pd_PrintPage;

            try {
                pd.Print();
                
                //if sampleID textbox != the id in the currentID object
                //and the updateSampleBox is checked, then update sampleID.json file with whatever was in the field
                bool update = !currentID_used.getId().Equals(sampleID.Text) && updateSampleIdBox.IsChecked==true;
                currentID_used.setId((update?int.Parse(sampleID.Text) + 1 : int.Parse(currentID_used.getId()) + 1));//increase the ID number by one
                setDefaults();

            }
            catch (InvalidPrinterException excep)
            {
                MessageBox.Show("Printer name is invalid. Set another printer name!");
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            float availableWidth = (float)Math.Floor(((PrintDocument)sender).OriginAtMargins
                ? e.MarginBounds.Width
                : (e.PageSettings.Landscape
                    ? e.PageSettings.PrintableArea.Height
                    : e.PageSettings.PrintableArea.Width));

            float availableHeight = (float)Math.Floor(((PrintDocument)sender).OriginAtMargins
                ? e.MarginBounds.Height
                : (e.PageSettings.Landscape
                    ? e.PageSettings.PrintableArea.Width
                    : e.PageSettings.PrintableArea.Height));

            string texto = string.Empty;
            Font font = new Font("Arial", 10);
            SizeF sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);

            //format the output sticker content
            string formattedDate = sampleDate.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ComboBoxItem selectedArea = (ComboBoxItem)areaList.SelectedItem;

            texto = $"{(selectedArea != null ? selectedArea.Content.ToString() : string.Empty)}-{sampleID.Text}\n{specimenList.SelectedItem}\n{formattedDate}";

            sizeF = e.Graphics.MeasureString(texto, font, (int)availableWidth);
            e.Graphics.DrawString(texto,
                                     font,
                                     new SolidBrush(System.Drawing.Color.Black),
                                     new RectangleF(new PointF(0.1F, 0.1F), sizeF)
                                    );
        }

        //Set both date and id fields to default values once the app is opened or printed a stickers
        private void setDefaults()
        {
            //default date
            sampleDate.SelectedDate = DateTime.Today;

            //default id
            if(currentID_used != null)
                sampleID.Text = currentID_used.getId();
        }

        //Used on area list field selection
        private void setFieldsOnAreaListOptionSelection(IDictionary<string, int> newSpecimenUsed, SampleID newCurrentID_used)
        {
            specimenList.ItemsSource = newSpecimenUsed.Keys;
            specimenUsed = newSpecimenUsed;
            sampleID.Text = newCurrentID_used.getId();
            currentID_used = newCurrentID_used;
        }
    }
}