using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace PDFSplitter
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.PDFSplitterICO;

            // Metoda runTest() pokrece se samo pri prvom pokretanju programa kako bi se za dati racunar utvrdilo koji metod koristiti za split na osnovu broja stranica dokumenta.
            runTest();

        }


        // Metoda koja opsluzuje dogadjaj klika na button Reset fields. Omogucava da se sva polja ociste i vrate u pocetno stanje.
        private void btnResetFields_Click(object sender, EventArgs e)
        {
            textBoxSelectDestFolder.Clear(); // Resetovanje Text box-a u koji se unosi putanja foldera u koji se smjestaju rezultati Split funkcije.
            textBoxSelectPDF.Clear(); // Resetovanje Text box-a u koji se unosi putanja do zeljenog PDF fajla nad kojim se vrsi funkcija Split.
            radioButtonSequential.Checked = true; // Podesavanje defaultne vrijednosti za radio buttone koji se odnose na nacin na koji ce se izvrsavati funkcija Split.
            richTextBoxSplitResult.Text = "Split Result:"; // Resetovanje rich text boxa u koji se smjestaju informacije o rezultatima Split funkcije.
            textBoxSelectPDF.Focus();
        }

        // Metoda koja omogucava izbor PDF fajla nad kojim zelimo da izvrsimo split funkciju.
        private void btnSelectPDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF|*.pdf";
            ofd.ValidateNames = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxSelectPDF.Text = ofd.FileName;
            }
        }

        // Metoda koja omogucava izbor destinacionog foldera u koji smjestamo rezultat funkcije split.
        private void btnSelectDestFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); // Kreiranje dialoga za izbor foldera.
            fbd.RootFolder = Environment.SpecialFolder.Desktop;  // Postavljanje Desktopa kao root folder - nije neophodno ali olaksava rad korisnika
            fbd.Description = "Please select destination folder";

            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) // Provjera da li je izabran postojeci folder
            {
                textBoxSelectDestFolder.Text = fbd.SelectedPath;
            }
        }

        // Metoda koja opsluzuje dogadjaj klika na Split dugme. Provjerava koji od radio buttona je selektovan te na osnovu njega poziva odgovarajuce funkcije.
        private void btnSplit_Click(object sender, EventArgs e)
        {
            if (textBoxSelectPDF.Text.Length != 0 && textBoxSelectDestFolder.Text.Length != 0) // Provjera da li su svi podaci potrebni za rad uneseni.
            {
                string pdfFileName = Path.GetFileNameWithoutExtension(textBoxSelectPDF.Text);
                PdfReader reader = new PdfReader(textBoxSelectPDF.Text);

                if (radioButtonSequential.Checked == true) // Izbor opcije koja omogucava sekvencijalno izvrsavanje metode split.
                {
                    var watch = new System.Diagnostics.Stopwatch(); // Kreiranje instance watch za potrebe mjerenja vremena potrebnog za izvrsenje split funkcije.
                    int numOfPages = 0;

                    btnResetFields.Enabled = false; // Reset fields dugme onemogucavamo dok se ne izvrsi funkcija split.
                    watch.Start(); // Pokretanje tajmera
                    numOfPages = splitSequential(textBoxSelectPDF.Text, textBoxSelectDestFolder.Text, pdfFileName, reader.NumberOfPages); // Pozivanje funkcije splitSequential kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                    watch.Stop(); // Zaustavljanje tajmera
                    MessageBox.Show("Splitting Done!", "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    richTextBoxSplitResult.Text += "\n\t- Number of splitted pages: " + numOfPages.ToString(); // Ispisivanje ukupnog broja obradjenih stranica u result richTextBox-u.
                    richTextBoxSplitResult.Text += "\n\t- Elapsed time during splitting process: " + watch.ElapsedMilliseconds + " ms"; // Ispisivanje ukupnog vremena potrebnog za izvrsenje split funkcije u result richTextBox-u.
                    richTextBoxSplitResult.Text += "\n\t- Method used: Sequential"; // Ispisivanje koristenog metoda za split.
                    btnResetFields.Enabled = true; // Ponovno omogucavanje Reset fields dugmeta nakon izvrsetka split funkcije.
                }
                else if (radioButtonParallel.Checked == true) // Opcija split u slucaju da zelimo split koristenjem tredova.
                {
                    var watch = new System.Diagnostics.Stopwatch(); // Kreiranje instance watch za potrebe mjerenja vremena potrebnog izvrsenje split funkcije.
                    int numOfPages = 0;

                    btnResetFields.Enabled = false; // Reset fields dugme onemogucavamo dok se ne izvrsi funkcija split.
                    watch.Start(); // Pokretanje tajmera
                    numOfPages = splitParallel(textBoxSelectPDF.Text, textBoxSelectDestFolder.Text, pdfFileName, reader.NumberOfPages); // Pozivanje funkcije split parallel kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                    watch.Stop(); // Zaustavljanje tajmera
                    MessageBox.Show("Splitting Done!", "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    richTextBoxSplitResult.Text += "\n\t- Number of splitted pages: " + numOfPages.ToString(); // Ispisivanje ukupnog broja obradjenih stranica u result richTextBox-u.
                    richTextBoxSplitResult.Text += "\n\t- Elapsed time during splitting process: " + watch.ElapsedMilliseconds + " ms"; // Ispisivanje ukupnog vremena potrebnog za izvrsenje split funkcije u result richTextBox-u.
                    richTextBoxSplitResult.Text += "\n\t- Method used: Parallel"; // Ispisivanje koristenog metoda za split.
                    btnResetFields.Enabled = true; // Ponovno omogucavanje Reset fields dugmeta nakon izvrsetka split funkcije.
                }
                else // Dio koda koji omogucava automatski izbor nacina na koji se split vrsi tj. izbor sekvencijalnog ili paralelnog izvrsenja opcije split u zavisnosti od performansi nacina split-a za dati pdf fajl.
                {
                    int methodForSplit = 0;

                    methodForSplit = automaticSplit(reader.NumberOfPages); // methodForSplit od metode automaticSplit dobija povratnu informaciju o tome koja metoda treba da se koristi za split u datom slucaju.

                    if (methodForSplit == 1) // Ukoliko je methodForSplit jednak 1, tada se izvrsava sequential split.
                    {
                        var watch = new System.Diagnostics.Stopwatch(); // Kreiranje instance watch za potrebe mjerenja vremena potrebnog za izvrsenje split funkcije.
                        int numOfPages = 0;

                        btnResetFields.Enabled = false; // Reset fields dugme onemogucavamo dok se ne izvrsi funkcija split.
                        watch.Start(); // Pokretanje tajmera
                        numOfPages = splitSequential(textBoxSelectPDF.Text, textBoxSelectDestFolder.Text, pdfFileName, reader.NumberOfPages); // Pozivanje funkcije splitSequential kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                        watch.Stop(); // Zaustavljanje tajmera
                        MessageBox.Show("Splitting Done!", "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        richTextBoxSplitResult.Text += "\n\t- Number of splitted pages: " + numOfPages.ToString(); // Ispisivanje ukupnog broja obradjenih stranica u result richTextBox-u.
                        richTextBoxSplitResult.Text += "\n\t- Elapsed time during splitting process: " + watch.ElapsedMilliseconds + " ms"; // Ispisivanje ukupnog vremena potrebnog za izvrsenje split funkcije u result richTextBox-u.
                        richTextBoxSplitResult.Text += "\n\t- Method used: Sequential"; // Ispisivanje koristenog metoda za split.
                        btnResetFields.Enabled = true; // Ponovno omogucavanje Reset fields dugmeta nakon izvrsetka split funkcije.
                    }
                    else if (methodForSplit == 2) // Ukoliko je methodForSplit jednak 2, tada se izvrsava parallel split.
                    {
                        var watch = new System.Diagnostics.Stopwatch(); // Kreiranje instance watch za potrebe mjerenja vremena potrebnog za izvrsenje split funkcije.
                        int numOfPages = 0;

                        btnResetFields.Enabled = false; // Reset fields dugme onemogucavamo dok se ne izvrsi funkcija split.
                        watch.Start(); // Pokretanje tajmera
                        numOfPages = splitParallel(textBoxSelectPDF.Text, textBoxSelectDestFolder.Text, pdfFileName, reader.NumberOfPages); // Pozivanje funkcije split parallel kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                        watch.Stop(); // Zaustavljanje tajmera
                        MessageBox.Show("Splitting Done!", "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        richTextBoxSplitResult.Text += "\n\t- Number of splitted pages: " + numOfPages.ToString(); // Ispisivanje ukupnog broja obradjenih stranica u result richTextBox-u.
                        richTextBoxSplitResult.Text += "\n\t- Elapsed time during splitting process: " + watch.ElapsedMilliseconds + " ms"; // Ispisivanje ukupnog vremena potrebnog za izvrsenje split funkcije u result richTextBox-u.
                        richTextBoxSplitResult.Text += "\n\t- Method used: Parallel"; // Ispisivanje koristenog metoda za split.
                        btnResetFields.Enabled = true; // Ponovno omogucavanje Reset fields dugmeta nakon izvrsetka split funkcije.
                    }

                }
            }
            else // Dio koda koji se aktivira u slucaju da nisu uneseni svi potrebni podaci za rad programa.
            {
                MessageBox.Show("Please insert all data!", "PDFSplitter",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Metoda koja omogucava sekvencijalno izvrsavanje.
        private int splitSequential(string sourcePdfPath, string outputPdfPath, string pdfFileName, int numOfPgs)
        {
            Thread thread = null;
            int retNum = 0;
            thread = new Thread(() => splitSequentialMethod(sourcePdfPath, outputPdfPath, pdfFileName, out retNum));
            thread.Start();
            thread.Join();
            return retNum;
        }


        // Metoda koja omogucava split funkciju.
        private int splitSequentialMethod(string sourcePdfPath, string outputPdfPath, string pdfFileName, out int retNum)
        {
            // Inicijalizacija potrebnih objekata.
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            // Postavljanje trenutne stranice na 1 sto je ujedno i pocetna stranica dokumenta.
            int currentPageNumber = 1;

            // Poruka koja oznacava da je operacija split zapoceta.

            try
            {
                // Inicijalizacija instance PDFReader-a sa sadrzajem izvorisnog PDF fajla. 
                reader = new PdfReader(sourcePdfPath);

                // Prolazak kroz svaku stranicu PDF fajla i izvrsavanje split funkcije.
                while (currentPageNumber <= reader.NumberOfPages)
                {
                    // Pribavljanje trenutne stranice koja se obradjuje odnosno njena velicina i rotacija.
                    sourceDocument = new Document(reader.GetPageSizeWithRotation(currentPageNumber));

                    // Pripremanje stringa koji predstavlja novo ime za trenutno obradjenu stranicu sa odgovarajucim brojem stranice u nazivu.
                    string newOutputPdfPath = outputPdfPath + "\\" + pdfFileName + " - Page " + currentPageNumber + ".pdf";

                    // Inicijalizacija objekta PDFCopyClass sa izvorisnim dokumentom i modom za kreiranje fajla.
                    pdfCopyProvider = new PdfCopy(sourceDocument,
                        new System.IO.FileStream(newOutputPdfPath, System.IO.FileMode.Create));

                    sourceDocument.Open(); // Otvaranje izvorisnog dokumenta.

                    // Popunjavanje sadrzaja stranice koju kreiramo i kreiranje nove posebne stranice.
                    importedPage = pdfCopyProvider.GetImportedPage(reader, currentPageNumber);
                    pdfCopyProvider.AddPage(importedPage);
                    currentPageNumber++;

                    sourceDocument.Close(); // Zatvaranje dokumenta nakon uspjesno upisanog sadrzaja u dokument.

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Error); // Obradjivanje situacije u slucaju da je doslo do greske u radu sa PDF fajlom.
            }

            retNum = currentPageNumber - 1;

            return retNum;
        }

        // Metoda koja omogucava parralelno izvrsavanje.
        private int splitParallel(string sourcePdfPath, string outputPdfPath, string pdfFileName, int NumberOfPages)
        {
            int workerThreads = 0;
            int completionPortThreads = 0;

            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads); // Dohvatanje broja tredova za dati procesor.

            // Odredjivanje broja koraka kroz koje je potrebno koristiti sve aktivne tredove.
            int totalNumberOfPages = NumberOfPages;

            int step = totalNumberOfPages / workerThreads;

            // Odredjivanje ostatka potrebno je kako bi za stranice koje su preostale za split ne bi koristili vise tredova nego sto nam je potrebno.
            int remainder = totalNumberOfPages % workerThreads;


            int countSplittedPages = 0; // Brojac zavrsenih stranica.

            try
            {

                Thread[] threadArray = new Thread[workerThreads]; // Kreiranje niza tredova.

                if (remainder == 0) // Izvrsavanje split funkcije ukoliko nemamo ostatka.
                {

                    Parallel.For(0, workerThreads, i =>
                        {
                            threadArray[i] = new Thread(() => splitSegmentUsingThreads(((i * step) + 1), ((i + 1) * step) + 1, sourcePdfPath, outputPdfPath, pdfFileName, out countSplittedPages));
                            threadArray[i].Start();
                        });

                    for (int i = 0; i < workerThreads; i++)
                    {
                        threadArray[i].Join();
                    }
                }
                else // Izvrsavanje split funkcije ukoliko imamo ostatka.
                {
                    Parallel.For(0, workerThreads, i =>
                    {
                        if (i == (workerThreads - 1))
                        {
                            threadArray[i] = new Thread(() => splitSegmentUsingThreads(((i * step) + 1), ((i + 1) * step) + 1 + remainder, sourcePdfPath, outputPdfPath, pdfFileName, out countSplittedPages));

                        }
                        else
                        {
                            threadArray[i] = new Thread(() => splitSegmentUsingThreads(((i * step) + 1), ((i + 1) * step) + 1, sourcePdfPath, outputPdfPath, pdfFileName, out countSplittedPages));
                        }
                        threadArray[i].Start();


                    });

                    for (int i = 0; i < workerThreads; i++)
                    {
                        threadArray[i].Join();
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Obradjivanje situacije u slucaju da je doslo do greske u radu sa PDF fajlom.
            }

            return countSplittedPages;
        }


        // Metoda splitSegmentUsingThreads nam omogucava parallel split funkciju i izvrsava split jednog segmenta stranica. Prosledjuju joj se pocetak i kraj segmenta. Svaki tred imace razliciti segment za obradu.
        private void splitSegmentUsingThreads(int startPage, int endPage, string sourcePdfPath, string outputPdfPath, string pdfFileName, out int countSplittedPages)
        {

            // Inicijalizacija potrebnih objekata.
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            int finishedPages = endPage - startPage;

            countSplittedPages = 0;

            try
            {
                // Inicijalizacija instance PDFReader-a sa sadrzajem izvorisnog PDF fajla. 
                reader = new PdfReader(sourcePdfPath);

                // Prolazak kroz svaku stranicu PDF fajla i izvrsavanje split funkcije.
                while (startPage < endPage)
                {
                    // Pribavljanje trenutne stranice koja se obradjuje odnosno njena velicina i rotacija.
                    sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));

                    // Pripremanje stringa koji predstavlja novo ime za trenutno obradjenu stranicu sa odgovarajucim brojem stranice u nazivu.
                    string newOutputPdfPath = outputPdfPath + "\\" + pdfFileName + " - Page " + startPage + ".pdf";

                    // Inicijalizacija objekta PDFCopyClass sa izvorisnim dokumentom i modom za kreiranje fajla.
                    pdfCopyProvider = new PdfCopy(sourceDocument,
                        new System.IO.FileStream(newOutputPdfPath, System.IO.FileMode.Create));

                    sourceDocument.Open(); // Otvaranje izvorisnog dokumenta.

                    // Popunjavanje sadrzaja stranice koju kreiramo i kreiranje nove posebne stranice.
                    importedPage = pdfCopyProvider.GetImportedPage(reader, startPage);
                    pdfCopyProvider.AddPage(importedPage);
                    startPage++;

                    sourceDocument.Close(); // Zatvaranje dokumenta nakon uspjesno upisanog sadrzaja u dokument.
                    
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Error); // Obradjivanje situacije u slucaju da je doslo do greske u radu sa PDF fajlom.
            }

            countSplittedPages += finishedPages;
        }

        // Metoda automatic split odredjuje koji metod ce se koristiti na osnovu proslijedjenog broja stranica i odradjenog testiranja pomocu metode runTest().
        private int automaticSplit(int numberOfPages)
        {
            int methodForSplit = 0;

            if (numberOfPages < 10)
            {
                methodForSplit = 1; // Ako je broj stranica manji od 10 koristiciemo sekvencijalno izvrsenje!
            }
            else if (numberOfPages >= 10 && numberOfPages < 51)
            {
                methodForSplit = Properties.Settings.Default.methodPage50; // Metodu kojom ce split da se obavi biramo iz kreiranog niza dobijenog na osnovu testiranja.
            }
            else if (numberOfPages > 50 && numberOfPages < 151)
            {
                methodForSplit = Properties.Settings.Default.methodPage150; // Metodu kojom ce split da se obavi biramo iz kreiranog niza dobijenog na osnovu testiranja.
            }
            else if (numberOfPages > 150 && numberOfPages < 301)
            {
                methodForSplit = Properties.Settings.Default.methodPage300; // Metodu kojom ce split da se obavi biramo iz kreiranog niza dobijenog na osnovu testiranja.
            }
            else 
            {
                methodForSplit = 2; // Ukoliko je broj stranica veci od 300 split ce se izvrsavati paralelno.
            }

            return methodForSplit;
        }

        // Test potreban za odredjivanje metoda koji ce se koristiti za split na osnovu broja stranica dokumenta.
        private void runTest()
        {
            // Provjera da li je test vec izvrsen.
            if (Properties.Settings.Default.testDone == false)
            {
                try
                {


                    MessageBox.Show("Pricekajte trenutak!", "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int numOfPages = 0;

                    string temporaryFolder = GetTemporaryDirectory(); // Kreiranje foldera u koji smjestamo testne fajlove.

                    System.IO.Directory.CreateDirectory(temporaryFolder); // Kreiranje foldera Temp u koji ce se privremeno smjestiti fajlovi potrebni za testiranje.




                    // Testiranje pdf fajlova do 50 strana paralelno izvrsenje operacije split.
                    var watchPar = new System.Diagnostics.Stopwatch(); // Kreiranje instance watch za potrebe mjerenja vremena potrebnog izvrsenje split funkcije.
                    watchPar.Start(); // Pokretanje tajmera
                    numOfPages = splitParallel(Application.StartupPath + @"\Test\Lorem_50.pdf", temporaryFolder, "Lorem_50_p", 50); // Pozivanje funkcije splitParallel kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                    watchPar.Stop(); // Zaustavljanje tajmera
                    Properties.Settings.Default.methodPage50 = 2;
                    Properties.Settings.Default.Save();


                    // Testiranje pdf fajlova do 50 strana sekvencijalno izvrsenje operacije split.
                    var watchSeq = new System.Diagnostics.Stopwatch(); // Kreiranje instance watch za potrebe mjerenja vremena potrebnog izvrsenje split funkcije.
                    watchSeq.Start(); // Pokretanje tajmera
                    numOfPages = splitSequential(Application.StartupPath + @"\Test\Lorem_50.pdf", temporaryFolder, "Lorem_50_s", 50); // Pozivanje funkcije splitSequential kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                    watchSeq.Stop(); // Zaustavljanje tajmera


                    // Provjera koji metod se bolje pokazao za dati broj stranica.
                    if (watchSeq.ElapsedMilliseconds < watchPar.ElapsedMilliseconds)
                    {
                        Properties.Settings.Default.methodPage50 = 1;
                        Properties.Settings.Default.Save();
                    }

                    // Testiranje pdf fajlova do 150 strana sekvencijalno izvrsenje operacije split
                    watchSeq.Start(); // Pokretanje tajmera
                    numOfPages = splitSequential(Application.StartupPath + @"\Test\Lorem_150.pdf", temporaryFolder, "Lorem_150_s", 150); // Pozivanje funkcije splitSequential kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                    watchSeq.Stop(); // Zaustavljanje tajmera
                    Properties.Settings.Default.methodPage150 = 1;
                    Properties.Settings.Default.Save();


                    // Testiranje pdf fajlova do 150 strana paralelno izvrsenje operacije split
                    watchPar = new System.Diagnostics.Stopwatch(); // Kreiranje instance watch za potrebe mjerenja vremena potrebnog izvrsenje split funkcije.
                    watchPar.Start(); // Pokretanje tajmera
                    numOfPages = splitParallel(Application.StartupPath + @"\Test\Lorem_150.pdf", temporaryFolder, "Lorem_150_p", 150); // Pozivanje funkcije splitParallel kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                    watchPar.Stop(); // Zaustavljanje tajmera

                    // Provjera koji metod se bolje pokazao za dati broj stranica.
                    if (watchSeq.ElapsedMilliseconds > watchPar.ElapsedMilliseconds)
                    {
                        Properties.Settings.Default.methodPage150 = 2;
                        Properties.Settings.Default.Save();
                    }

                    // Testiranje pdf fajlova do 300 strana sekvencijalno izvrsenje operacije split
                    watchSeq.Start(); // Pokretanje tajmera
                    numOfPages = splitSequential(Application.StartupPath + @"\Test\Lorem_300.pdf", temporaryFolder, "Lorem_300_s", 300); // Pozivanje funkcije splitSequential kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                    watchSeq.Stop(); // Zaustavljanje tajmera
                    Properties.Settings.Default.methodPage300 = 1;
                    Properties.Settings.Default.Save();

                    // Testiranje pdf fajlova do 300 strana paralelno izvrsenje operacije split
                    watchPar = new System.Diagnostics.Stopwatch(); // Kreiranje instance watch za potrebe mjerenja vremena potrebnog izvrsenje split funkcije.
                    watchPar.Start(); // Pokretanje tajmera
                    numOfPages = splitParallel(Application.StartupPath + @"\Test\Lorem_300.pdf", temporaryFolder, "Lorem_300_p", 300); // Pozivanje funkcije splitParallel kojoj se prosledjuju uneseni pdf fajl i destinacioni folder
                    watchPar.Stop(); // Zaustavljanje tajmera

                    // Provjera koji metod se bolje pokazao za dati broj stranica.
                    if (watchSeq.ElapsedMilliseconds > watchPar.ElapsedMilliseconds)
                    {
                        Properties.Settings.Default.methodPage300 = 2;
                        Properties.Settings.Default.Save();
                    }

                    Properties.Settings.Default.testDone = true;
                    Properties.Settings.Default.Save(); // Nakon sto je test gotov, postavljamo testDone na true i tako se vise test nece ponavljati pri sljedecim pokretanjima aplikacije.
                    
                    // Brisanje foldera Temp nakon zavrsetka testiranja.
                    if (Directory.Exists(temporaryFolder))
                    {
                        Directory.Delete(temporaryFolder, true);
                    }

                    MessageBox.Show("Testiranje gotovo! Program je spreman za upotrebu.", "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                                
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "PDFSplitter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        // Funkcija koja kreira folder u %temp% folderu u koji cemo smjestiti testne fajlove potrebne za automatic split opciju.
        public string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
    }
}
