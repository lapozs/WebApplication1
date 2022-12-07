using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace WinFormsAppExcel
{
    public partial class Form1 : Form
    {
        Excel.Application xlApp; // A Microsoft Excel alkalmaz�s
        Excel.Workbook xlWB;     // A l�trehozott munkaf�zet
        Excel.Worksheet xlSheet; // Munkalap a munkaf�zeten bel�l
        public Form1()
        {
            InitializeComponent();
        }

        void CreateTable()
        {
            xlSheet.Cells[1, 1] = "K�rd�s";
            xlSheet.Cells[1, 2] = "V�lasz1";
            xlSheet.Cells[1, 3] = "V�lasz2";
            xlSheet.Cells[1, 4] = "V�lasz3";
            xlSheet.Cells[1, 5] = "Helyes v�lasz";

            Models.HajosContext context = new Models.HajosContext();
            var adatok = context.Questions.ToList();

            object[,] adatT�mb = new object[adatok.Count(), 6];

            for (int i = 0; i < adatok.Count(); i++)
            {
                adatT�mb[i, 0] = adatok[i].Question1;
                adatT�mb[i, 1] = adatok[i].Answer1;
                adatT�mb[i, 2] = adatok[i].Answer2;
                adatT�mb[i, 3] = adatok[i].Answer3;
                adatT�mb[i, 4] = adatok[i].CorrectAnswer;
                adatT�mb[i, 5] = adatok[i].Image;
            }

            int sorokSz�ma = adatT�mb.GetLength(0);
            int oszlopokSz�ma = adatT�mb.GetLength(1);

            Excel.Range adatRange = xlSheet.get_Range("A2", Type.Missing).get_Resize(sorokSz�ma, oszlopokSz�ma);
            adatRange.Value2 = adatT�mb;

            adatRange.Columns.AutoFit();

            //FormatTable();
            Excel.Range elsooszlop = xlSheet.get_Range("A1", Type.Missing).get_Resize(sorokSz�ma, 1);
            elsooszlop.Font.Bold = true;
            elsooszlop.Interior.Color = Color.LightYellow;

            Excel.Range fejll�cRange = xlSheet.get_Range("A1", Type.Missing).get_Resize(1, oszlopokSz�ma);
            fejll�cRange.Font.Bold = true;
            fejll�cRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            fejll�cRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            fejll�cRange.EntireColumn.AutoFit();
            fejll�cRange.RowHeight = 40;
            fejll�cRange.Interior.Color = Color.Bisque;
            fejll�cRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range egesztablazat = xlSheet.get_Range("A1", Type.Missing).get_Resize(sorokSz�ma, oszlopokSz�ma);
            egesztablazat.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            //int lastRowID = xlSheet.UsedRange.Rows.Count;
            //Excel.Range utolsooszlop = xlSheet.get_Range("A1", Type.Missing).get_Resize(1,lastRowID);
            //utolsooszlop.Interior.Color = Color.LightGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Excel elind�t�sa �s az applik�ci� objektum bet�lt�se
                xlApp = new Excel.Application();

                // �j munkaf�zet
                xlWB = xlApp.Workbooks.Add(Missing.Value);

                // �j munkalap
                xlSheet = xlWB.ActiveSheet;

                // T�bla l�trehoz�sa
                CreateTable(); // Ennek meg�r�sa a k�vetkez� feladatr�szben k�vetkezik

                // Control �tad�sa a felhaszn�l�nak
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex) // Hibakezel�s a be�p�tett hiba�zenettel
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                // Hiba eset�n az Excel applik�ci� bez�r�sa automatikusan
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        void FormatTable()
        {
            Excel.Range fejll�cRange = xlSheet.get_Range("A1", Type.Missing).get_Resize(1, 6);
            fejll�cRange.Font.Bold = true;
            fejll�cRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            fejll�cRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            fejll�cRange.EntireColumn.AutoFit();
            fejll�cRange.RowHeight = 40;
            fejll�cRange.Interior.Color = Color.Bisque;
            fejll�cRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range egesztablazat = xlSheet.get_Range("A1", Type.Missing).get_Resize(860, 6);
            egesztablazat.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range elsooszlop = xlSheet.get_Range("A1", Type.Missing).get_Resize(860, 2);
            elsooszlop.Font.Bold = true;
            elsooszlop.Interior.Color = Color.LightYellow;

            Excel.Range utolsooszlop = xlSheet.get_Range("A1", Type.Missing).get_Resize(860, 6);


        }
    }
}