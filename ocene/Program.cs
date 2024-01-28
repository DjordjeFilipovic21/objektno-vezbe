 using System; 

 using System.IO;  

enum uspeh{Nedovoljan, Dovoljan, Dobar, Vrlo_dobar, Odlican} // uvodjenje nabrojivog tipa 

namespace Zadatak 

 { 

     class Program 

     { 

         struct ucenik    //uvodjene strukture 

         { 

             public string ime; 

             public string prezime; 

             public double ocena1; 

             public double ocena2; 

             public double ocena3; 

             public double ocena4; 

             public static double Prosek(double ocena1, double ocena2, double ocena3, double ocena4) 

             { 

                 double prosek=(ocena1+ocena2+ocena3+ocena4)/4; 

                 return prosek; 

             } 

         } 

          

           public static void Main(string[] args) 

         { 

             StreamReader UlaznaDatoteka;  

              try{  

                  UlaznaDatoteka=new StreamReader("ulaz.txt");        //čitanje txt fajla  

              }catch (Exception e){  

                  Console.WriteLine(e.Message);                  

                  Console.ReadKey(true);  

                  return;  

             } 

              StreamWriter Upisivac;  

                    try{  

                Upisivac  =new StreamWriter("izlaz.txt");     //deklarisanje izlazne datoteke   

              }catch (Exception e){  

                  Console.WriteLine(e.Message);                  

                  Console.ReadKey(true);  

                  return;  

              } 

  

             int n=int.Parse(UlaznaDatoteka.ReadLine()); //broj ucenika 

           double n1=0; // takodje broj ucenika ali double, zbog proseka. nakon petlje ova promenljiva dobija vrednost n 

             ucenik[] niz=new ucenik[n]; // niz struktura za svakog ucenika 

             double[] prosek=new double[n]; // niz proseka svakog ucenika 

             double zbir=0; //zbir proseka za prosek odeljenja 

             

      for(int i=0;i<n;i++) 

             { 

                 niz[i].ime=UlaznaDatoteka.ReadLine(); 

                 niz[i].prezime=UlaznaDatoteka.ReadLine(); 

                 niz[i].ocena1=double.Parse(UlaznaDatoteka.ReadLine()); 

                 niz[i].ocena2=double.Parse(UlaznaDatoteka.ReadLine()); 

                 niz[i].ocena3=double.Parse(UlaznaDatoteka.ReadLine()); 

                 niz[i].ocena4=double.Parse(UlaznaDatoteka.ReadLine()); //ubacivanje vrednosti u parametre 

                 prosek[i]=(niz[i].ocena1+niz[i].ocena2+niz[i].ocena3+niz[i].ocena4)/4;  

                 uspeh Uspeh;    //racunanje proseka  

                 if(prosek[i]>=4.5){Uspeh=uspeh.Odlican;} 

                 else if(prosek[i]>=3.5){Uspeh=uspeh.Vrlo_dobar;} 

                 else if(prosek[i]>=2.5){Uspeh=uspeh.Dobar;} 

                 else if(prosek[i]>=1.5){Uspeh=uspeh.Dovoljan;} 

                 else Uspeh=uspeh.Nedovoljan; //nalazenje uspeha u nabrojivom tipu 

                 Upisivac.WriteLine("Ucenik "+niz[i].ime+" "+niz[i].prezime+" sa ocenama "+niz[i].ocena1+", "+ niz[i].ocena2+", "+niz[i].ocena3+", "+niz[i].ocena4+" i prosekom "+prosek[i]+" ima "+Uspeh+" uspeh."); 

                 zbir+=prosek[i]; // izlaz u konzolu 

                 n1++; 

             } 

             double ProsekO=zbir/n1; //racunanje proseka odeljenja 

             Upisivac.WriteLine("Prosek odeljenja je "+ProsekO); 

             int brojucenika=0;    //broj ucenika sa prosekom vecim od proseka odeljenja 

             for(int i=0;i<n;i++) 

             { 

                 if(prosek[i]>ProsekO) {brojucenika++; 

                     Upisivac.WriteLine(niz[i].ime+" "+niz[i].prezime);}    //izbacivanje u datoteku 

             } 

             Upisivac.WriteLine(brojucenika); //izbacivanje broja ucenika sa prosekom vecim od proseka odeljenja 

              

                                 Upisivac.Close();  

  

            Console.Write("Press any key to continue . . . "); 

            Console.ReadKey(true); 

         } 

     } 

 } 