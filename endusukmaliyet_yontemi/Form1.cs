namespace endusukmaliyet_yontemi
{
    public partial class Form1_Panel : Form
    {


        public int Fabrika_Sayisi;
        public int Sehir_Sayisi;
        private int tempx = 0;
        private int tempy = 0;

        private int ToplamArz = 0;
        private int ToplamTalep = 0;
        private int[,] Veriler_Matrisi;
        private int[,] Suni_Veriler_Matrisi;
        private int sonucsayisal = 0;
        private int clickcounter = 0;
        private String sonuc = "";

        //Olu�turulan Dinamik Textboxlara yaln�zca n�merik ifadeler girilmesine izin veren keypress fonksiyonu 
        private void inputnum_tb_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        //Arz ve Talebin kesi�en fazlal�k bir textbox� temizlendi.
        public void KesisimTemizle(int tempx, int tempy)
        {

            foreach (Control item in this.Controls)
            {
                if (item.Location.X == tempx && item.Location.Y == tempy)
                {
                    this.Controls.Remove(item);
                    break; //important step
                }
            }
        }
        //Textboxlar�n bo� olup olmad���n� kontrol eden fonk. 
        public bool EmptyCheck()
        {


            int empty_counter = 0;
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Name == "inputnum_tb")
                    {

                        if (((TextBox)c).Text == "")
                        {
                            empty_counter++;


                        }
                    }
                }
            }
            if (empty_counter > 0)
            {
                MessageBox.Show("L�tfen Bo� Index B�rakmay�n�z!");
                return true;

            }

            return false;
        }
        //Indexlerin i�inde 0 olup olmad���n� kontrol eden fonk.
        public bool ZeroCheck()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Name == "inputnum_tb")
                    {

                        if (((TextBox)c).Text == "0")
                        {
                            MessageBox.Show("L�tfen 0 index girmeyiniz!");
                            return true;


                        }
                    }
                }
            }

            return false;


        }
        //Yeniden ba�lat butonunun dinamik olarak olu�turuldu�u fonk . 
        public void YenidenBaslatButton()
        {
            Button YenidenBaslat = new Button();
            YenidenBaslat.Location = new Point(this.Width - 1150, this.Height - 100);

            YenidenBaslat.BackColor = Color.White;
            YenidenBaslat.FlatStyle = FlatStyle.Popup;
            YenidenBaslat.Width = 175;
            YenidenBaslat.Height = 40;
            YenidenBaslat.Text = "Yeniden Ba�lat";
            YenidenBaslat.Click += (sender, args) =>
            {
                this.Hide();
                clickcounter = 0;
                input i1 = new input();
                i1.Show();
               
            };
            this.Controls.Add(YenidenBaslat);
        }
        //Matris olu�turan ve textboxlara girilen de�erlerin olu�turulan matristeki ilgili indexlere atand��� fonk.
        public void MatrisOlusturVeAta()
        {
            Veriler_Matrisi = new int[Fabrika_Sayisi + 1, Sehir_Sayisi + 1];
            List<int> primeNumbers = new List<int>();
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Text != "")
                    {
                        primeNumbers.Add(Convert.ToInt32(((TextBox)c).Text));
                    }
                }
            }

            int k = 0;
            for (int i = 0; i < Fabrika_Sayisi + 1; i++)
            {
                for (int j = 0; j < Sehir_Sayisi + 1; j++)
                {
                    if (k < primeNumbers.Count)
                    {
                        //Silinen bir adet index oldu�undan ve bu indexe Matriste bo� atama yap�lmas� istenmedi�inden o index s�n�r d��� b�rak�larak ona atama yap�lmad�.                         if(i==fabrika_sayisi && j==sehir_sayisi)
                        if (i == Fabrika_Sayisi && j == Sehir_Sayisi)
                        {
                            Veriler_Matrisi[i, j] = int.MaxValue;
                        }
                        else
                        {
                            Veriler_Matrisi[i, j] = primeNumbers[k];
                        }
                    }
                    k++;
                }
            }
        }
        //Arz>Talep durumunda minimum elemana arz ya da talep atayan fonk. 
        public void SuniArzTalepAta(int[,] matris, int koord_minx, int koord_miny, int mineleman)
        {

            //Arz�n talepten b�y�k ya da e�it olma durumu
            if (matris[koord_minx, Sehir_Sayisi + 1] >= matris[Fabrika_Sayisi, koord_miny])
            {

                //Arz talepten ��kart�ld�. 
                //Talep 0'a e�itlendi
                matris[koord_minx, Sehir_Sayisi + 1] = matris[koord_minx, Sehir_Sayisi + 1] - matris[Fabrika_Sayisi, koord_miny];
                SonucYazdir(matris[Fabrika_Sayisi, koord_miny], mineleman);
                matris[Fabrika_Sayisi, koord_miny] = 0;
                //S�tun silindi.Minimum atamadan ��kar�ld�. 
                for (int i = 0; i < Fabrika_Sayisi; i++)
                {
                    matris[i, koord_miny] = int.MaxValue;
                }


            }
            //Talebin Arzdan b�y�k olma durumu 
            else if (matris[koord_minx, Sehir_Sayisi + 1] < matris[Fabrika_Sayisi, koord_miny])
            {
                //Talepten arz ��kart�ld�. 
                //Arz 0'a e�itlendi.

                matris[Fabrika_Sayisi, koord_miny] = matris[Fabrika_Sayisi, koord_miny] - matris[koord_minx, Sehir_Sayisi + 1];
                SonucYazdir(matris[koord_minx, Sehir_Sayisi + 1], mineleman);
                matris[koord_minx, Sehir_Sayisi + 1] = 0;
                //Sat�r silindi.Minimum atamadan ��kar�ld�. 
                for (int i = 0; i < Sehir_Sayisi + 1; i++)
                {
                    matris[koord_minx, i] = int.MaxValue;
                }

            }
        }
        //minimum elemana arz ya da talep atayan fonk. 
        public void ArzTalepAta(int[,] matris, int koord_minx, int koord_miny, int mineleman)
        {


            //Arz�n talepten b�y�k ya da e�it olma durumu
            if (matris[koord_minx, Sehir_Sayisi] >= matris[Fabrika_Sayisi, koord_miny])
            {

                //Arz talepten ��kart�ld�. 
                //Talep 0'a e�itlendi
                matris[koord_minx, Sehir_Sayisi] = matris[koord_minx, Sehir_Sayisi] - matris[Fabrika_Sayisi, koord_miny];
                SonucYazdir(matris[Fabrika_Sayisi, koord_miny], mineleman);
                matris[Fabrika_Sayisi, koord_miny] = 0;
                //S�tun silindi.Minimum atamadan ��kar�ld�. 
                for (int i = 0; i < Fabrika_Sayisi; i++)
                {
                    matris[i, koord_miny] = int.MaxValue;
                }


            }
            //Talebin Arzdan b�y�k olma durumu 
            else if (matris[koord_minx, Sehir_Sayisi] < matris[Fabrika_Sayisi, koord_miny])
            {
                //Talepten arz ��kart�ld�. 
                //Arz 0'a e�itlendi.

                matris[Fabrika_Sayisi, koord_miny] = matris[Fabrika_Sayisi, koord_miny] - matris[koord_minx, Sehir_Sayisi];
                SonucYazdir(matris[koord_minx, Sehir_Sayisi], mineleman);
                matris[koord_minx, Sehir_Sayisi] = 0;
                //Sat�r silindi.Minimum atamadan ��kar�ld�. 
                for (int i = 0; i < Sehir_Sayisi; i++)
                {
                    matris[koord_minx, i] = int.MaxValue;
                }

            }

        }
        //Arz>Talep durumuna g�re matrislerin olu�turuldu�u ve ekrana �izdirildi�i fonk.
        public void SuniSutunOlustur(int ToplamArz, int ToplamTalep)
        {

            //�kinci olu�turulan suni matrise boyut atamas� yap�ld�. 
            Suni_Veriler_Matrisi = new int[Fabrika_Sayisi + 1, Sehir_Sayisi + 2];
            int SuniTalep = ToplamArz - ToplamTalep;
            for (int i = 0; i < Fabrika_Sayisi + 1; i++)
            {
                Label YeniFabrika = new Label();
                YeniFabrika.Width = 40;
                YeniFabrika.Location = new Point(250, 75 + 50 * i);
                if (i == Fabrika_Sayisi)
                {
                    YeniFabrika.Text = "Talep";
                }
                else
                {
                    YeniFabrika.Text = "F" + (i + 1);
                }



                for (int j = 0; j < Sehir_Sayisi + 2; j++)
                {
                    Label YeniSehir = new Label();
                    YeniSehir.Name = "YeniSehir";

                    YeniFabrika.Name = "YeniFabrika";

                    //Suni S�tunun Olu�turuldu�u yeni dinamik textboxlar olu�turuldu.
                    TextBox Sunitb = new TextBox();
                    Sunitb.ReadOnly = true;
                    Sunitb.Enabled = false;
                    Sunitb.Name = "Sunitb";
                    Sunitb.Location = new Point(300 + 50 * j, 75 + 50 * i);
                    Sunitb.Width = 30;
                    //Yeni bir s�tun eklenmesi s�tuna 0 atanmas� ve yeni bir talebin eklenmesi gibi istisna durumlar d�zenlendi. 
                    if (j < Sehir_Sayisi)
                    {
                        Sunitb.Text = Veriler_Matrisi[i, j].ToString();
                        Suni_Veriler_Matrisi[i, j] = Convert.ToInt32(Sunitb.Text);

                    }
                    else if (j == Sehir_Sayisi && i < Fabrika_Sayisi)
                    {
                        Sunitb.Text = 0.ToString();
                        Suni_Veriler_Matrisi[i, j] = Convert.ToInt32(Sunitb.Text);
                    }
                    else if (j == Sehir_Sayisi && i == Fabrika_Sayisi)
                    {
                        Sunitb.Text = (ToplamArz - ToplamTalep).ToString();
                        Suni_Veriler_Matrisi[Fabrika_Sayisi - 1, Sehir_Sayisi + 1] -= Convert.ToInt32(Sunitb.Text);

                        Suni_Veriler_Matrisi[i, j] = 0;
                    }
                    else if (i == Fabrika_Sayisi && j == Sehir_Sayisi + 2)
                    {
                        break;
                    }
                    else if (j == Sehir_Sayisi + 1)
                    {
                        Sunitb.Text = Veriler_Matrisi[i, Sehir_Sayisi].ToString();
                        Suni_Veriler_Matrisi[i, j] = Convert.ToInt32(Sunitb.Text);
                    }



                    tempx = 300 + 50 * j;
                    tempy = 75 + 50 * i;
                    YeniSehir.Width = 40;
                    if (j == Sehir_Sayisi)
                    {
                        YeniSehir.Text = "� Suni";
                    }
                    else if (j == Sehir_Sayisi + 1)
                    {
                        YeniSehir.Text = "Arz";
                    }
                    else
                    {
                        YeniSehir.Text = "�" + (j + 1);
                    }
                    YeniSehir.Location = new Point(300 + 50 * j, 50);
                    this.Controls.Add(YeniSehir);
                    this.Controls.Add(Sunitb);
                }

                //Suni S�tunun olu�turuldu�u k�s�ma Ad�m2 Dendi.
                Label Adim2 = new Label();
                Adim2.Name = "Adim2";
                Adim2.Text = "Ad�m 2 ";
                Adim2.Location = new Point(300, 15);

                this.Controls.Add(Adim2);
                this.Controls.Add(YeniFabrika);
            }

            KesisimTemizle(tempx, tempy);
        }

        public void AdimYazdir()
        {
            //Ba�taki Ad�m1 yaz�s�n�n yazd�r�ld��� Alan
            Label adimcounter = new Label();
            adimcounter.Text = "Ad�m 1 ";
            adimcounter.Location = new Point(50, 15);
            this.Controls.Add(adimcounter);
        }
        //Girilen matris boyutuna g�re dinamik olarak textboxlar�n olu�turulup ekrana �izdirildi�i fonksiyon
        public void DynamicTbOlustur()
        {
            //Fabrika ve �ehir say�s� adedince dinamik textboxlar�n olu�turuldu�u fonksiyon 
            for (int i = 0; i < Fabrika_Sayisi + 1; i++)
            {
                Label fabrikalar = new Label();
                if (i != Fabrika_Sayisi)
                {
                    fabrikalar.Text = "F" + (i + 1);
                }
                else
                {
                    fabrikalar.Text = "Talep";
                }
                fabrikalar.Location = new Point(5, (80 + (50 * i)));
                fabrikalar.Width = 40;
                this.Controls.Add(fabrikalar);
                for (int j = 0; j < Sehir_Sayisi + 1; j++)
                {
                    //�1 �2 ba�l�klar�n�n olu�turuldu�u alan 
                    Label sehirler = new Label();
                    if (j != Sehir_Sayisi)
                    {
                        sehirler.Text = "�" + (j + 1);
                    }
                    else
                    {
                        sehirler.Text = "Arz";
                    }
                    sehirler.Location = new Point(45 + (45 * j), 50);
                    sehirler.Width = 35;
                    this.Controls.Add(sehirler);
                    TextBox inputnum_tb = new TextBox();
                    inputnum_tb.Width = 30;
                    inputnum_tb.Name = "inputnum_tb";
                    inputnum_tb.Location = new Point(44 + 45 * j, 75 + 50 * i);
#pragma warning disable CS8622 // Muhtemelen null atanabilirlik �znitelikleri nedeniyle, parametre t�r�ndeki ba�vuru t�rlerinin null atanabilirli�i hedef temsilciyle e�le�miyor.
                    inputnum_tb.KeyPress += new KeyPressEventHandler(inputnum_tb_KeyPress);
#pragma warning restore CS8622 // Muhtemelen null atanabilirlik �znitelikleri nedeniyle, parametre t�r�ndeki ba�vuru t�rlerinin null atanabilirli�i hedef temsilciyle e�le�miyor.
                    tempy = 75 + (50 * i);
                    tempx = 44 + (45 * j);
                    this.Controls.Add(inputnum_tb);
                }
            }

            KesisimTemizle(tempx, tempy);


        }
        //Temizle fonksiyonu
        public void Fonk_Temizle()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    //�lk olu�turulan textboxlar�n i�i temizlendi.
                    ((TextBox)c).Text = String.Empty;
                    //Suni Tb Temizlendi 

                    if (((TextBox)c).Name == "Sunitb")
                    {
                        this.Controls.Remove(((TextBox)c));
                    }
                }

            }

            foreach (var c in this.Controls)
            {
                if (c is Label)
                {

                    //Suni Tb Temizlendi 

                    if (((Label)c).Name == "Sonuc_Label")
                    {
                        this.Controls.Remove(((Label)c));
                    }
                }

            }

            foreach (var c in this.Controls)
            {
                if (c is Label)
                {

                    if (((Label)c).Name == "YeniFabrika")
                    {
                        this.Controls.Remove(((Label)c));
                    }
                }

            }
            foreach (var c in this.Controls)
            {
                if (c is Label)
                {

                    if (((Label)c).Name == "YeniSehir")
                    {
                        this.Controls.Remove(((Label)c));
                    }
                }

            }
            foreach (var c in this.Controls)
            {
                if (c is Label)
                {

                    if (((Label)c).Name == "Adim2")
                    {
                        this.Controls.Remove(((Label)c));
                    }
                }

            }
        }
        //Dinamik Temizle butonunun olu�turuldu�u ve button click eventini i�eren fonksiyon
        public void TemizleButtonOlustur()
        {
            Button Temizle_Buttton = new Button();
            Temizle_Buttton.Location = new Point(this.Width - 750, this.Height - 100);
            Temizle_Buttton.BackColor = Color.White;
            Temizle_Buttton.FlatStyle = FlatStyle.Popup;
            Temizle_Buttton.Width = 175;
            Temizle_Buttton.Height = 40;
            Temizle_Buttton.Text = "Temizle";

            //Button Click event
            Temizle_Buttton.Click += (sender, args) =>
            {
                clickcounter = 0;
                Fonk_Temizle();
            };
            this.Controls.Add(Temizle_Buttton);
        }
        //Toplam arz� ve talebi hesaplayan fonksiyon
        public void ToplamArzTalepHesapla(int[,] matris, int boyuty)
        {
            ToplamArz = 0;
            ToplamTalep = 0;
            //Toplam Talep Hesapland�.
            for (int j = 0; j < boyuty; j++)
            {
                ToplamTalep += matris[Fabrika_Sayisi, j];
            }
            //Toplam Arz Hesapland�
            for (int i = 0; i < Fabrika_Sayisi; i++)
            {

                ToplamArz += matris[i, boyuty];
            }

        }
        public void dbTextYazdir()
        {
            Label Sonuc_Label = new Label();
            Sonuc_Label.Name = "Sonuc_Label";
            Sonuc_Label.Text = "Sonu�=" + sonuc;
            Sonuc_Label.Width = Fabrika_Sayisi * 250;
            Sonuc_Label.Location = new Point(5, tempy + 50);
            this.Controls.Add(Sonuc_Label);
            this.Controls.Add(Sonuc_Label);
        }
        //Dinamik Olarak Hesapla Butonunun olu�turuldu�u ve hesapla button click eventinin bulundu�u fonksiyon
        public void HesaplaButtonOlustur()
        {

            Button Hesapla = new Button();
            Hesapla.Location = new Point(this.Width - 350, this.Height - 100);
            Hesapla.BackColor = Color.White;
            Hesapla.FlatStyle = FlatStyle.Popup;

            Hesapla.Width = 175;
            Hesapla.Height = 40;
            Hesapla.Text = "Hesapla";

            Hesapla.Click += (sender, args) =>
            {
                
                if (EmptyCheck() == false && ZeroCheck()==false)
                {
                    clickcounter++;
                    if (clickcounter == 1)
                    {
                        MatrisOlusturVeAta();

                    }

                    ToplamArzTalepHesapla(Veriler_Matrisi, Sehir_Sayisi);
                    if (ToplamArz == ToplamTalep)
                    {
                        while (ToplamArz != 0 && ToplamTalep != 0)
                        {
                            ToplamArzTalepHesapla(Veriler_Matrisi, Sehir_Sayisi);
                            MinElemanBul(Veriler_Matrisi);

                        }
                    }
                    else if (ToplamArz > ToplamTalep)
                    {
                        SuniSutunOlustur(ToplamArz, ToplamTalep);

                        while (ToplamArz + ToplamTalep != 0)
                        {

                            ToplamArzTalepHesapla(Suni_Veriler_Matrisi, Sehir_Sayisi + 1);
                            SuniMinElemanBul(Suni_Veriler_Matrisi);

                        }

                    }

                    if (clickcounter == 1)
                    {
                        sonuc = sonuc.Remove(sonuc.Length - 1);
                        sonuc = sonuc + "=" + sonucsayisal.ToString();
                        dbTextYazdir();
                    }


                }









            };
            this.Controls.Add(Hesapla);



        }

        //Sonucu Hesaplay�p Stringe yazd�ran fonksiyon
        public void SonucYazdir(int ArzVeyaTalep, int mineleman)
        {

            if (mineleman != int.MaxValue)
            {
                sonuc += "(" + mineleman.ToString() + "*" + ArzVeyaTalep.ToString() + ")+";
            }
            sonucsayisal += mineleman * ArzVeyaTalep;





        }
        //Arz>Talep durumuna uygun minimum eleman bulan fonksiyon
        public void SuniMinElemanBul(int[,] matris)
        {
            int tempi = 0;
            int tempj = 0;

            int mineleman = matris[0, 0];


            for (int i = 0; i < Fabrika_Sayisi; i++)
            {
                for (int j = 0; j < Sehir_Sayisi + 1; j++)
                {
                    if (matris[i, j] < mineleman && matris[i, j] > 0)
                    {

                        mineleman = matris[i, j];


                        tempi = i;
                        tempj = j;

                    }

                }
            }
            SuniArzTalepAta(Suni_Veriler_Matrisi, tempi, tempj, mineleman);
            matris[tempi, tempj] = int.MaxValue;


        }
        //Arz=Talep durumuna uygun minimum eleman bulan fonksiyon
        public void MinElemanBul(int[,] matris)
        {

            int tempi = 0;
            int tempj = 0;

            int mineleman = matris[0, 0];

            for (int i = 0; i < Fabrika_Sayisi; i++)
            {
                for (int j = 0; j < Sehir_Sayisi; j++)
                {
                    if (matris[i, j] < mineleman)
                    {

                        mineleman = matris[i, j];


                        tempi = i;
                        tempj = j;

                    }

                }
            }
            ArzTalepAta(Veriler_Matrisi, tempi, tempj, mineleman);
            matris[tempi, tempj] = int.MaxValue;





        }
        public Form1_Panel()
        {

            InitializeComponent();
            EmptyCheck();


        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }


        private void button1_Click_1(object sender, EventArgs e)
        {


        }
        //Form1 kapan�nca uygulamay� kapamay� sa�layan fonk 
        private void Form1_Panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }
    }
}