﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using UtogovuiP.PitomnikDataSetTableAdapters;
namespace UtogovuiP
{
    /// <summary>
    /// Логика взаимодействия для Kassa.xaml
    /// </summary>
    
    internal class Model
    {
        public int Care_PetID { get; set; }
        public string TYPУ_CARE { get; set; }
        public int COST { get; set; }
    }
    public partial class Kassa : Window
    {
        public int cost = 0;
        public string clos;
        public int namber = 0;
        int ChekNamber = 0;
        

        List<Model> selected = new List<Model>();      
        Сare_PetTableAdapter k = new Сare_PetTableAdapter();
        public Kassa()
        {
            InitializeComponent();
            GridK.ItemsSource = k.GetData();
       
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            clos = "Закрыть";
            DialogResult = true;
        }

        private void pluse_Click(object sender, RoutedEventArgs e)
        {
            
            DataRowView row = GridK.SelectedItem as DataRowView;

            int a = Convert.ToInt16(row.Row.ItemArray[2]);
            cost += a;
            Model model = new Model();
            model.Care_PetID = Convert.ToInt16(row.Row.ItemArray[0]);
            model.TYPУ_CARE = row.Row.ItemArray[1].ToString();
            model.COST = Convert.ToInt16(row.Row.ItemArray[2]);
            selected.Add(model);
            GridPokypok.ItemsSource = new ObservableCollection<Model>(selected);
            Cost.Text = cost.ToString();

        }

        private void munes_Click(object sender, RoutedEventArgs e)
        {
            var prod = new ObservableCollection<Model>(selected);
            GridPokypok.ItemsSource = prod;
            Model user = GridPokypok.SelectedItem as Model;
            if (user != null)
            {
                prod.Remove(user);
                selected.Remove(user);

                cost -= user.COST;
                Cost.Text = cost.ToString();

            }
        }

        private void DownloadChek_Click(object sender, RoutedEventArgs e)
        {
                ChekNamber += 1;
                namber += 1;
                NameChek.Text = "Chek" + namber.ToString();
                string newFile = NameChek.Text;
                string path = "C:\\Users\\Savva\\OneDrive\\Рабочий стол\\" + newFile + ".txt";
                int pris = Convert.ToInt16(introduced.Text);
                int resylt = 0;
                resylt = pris - cost;
                
                if (File.Exists(path))
                {
                    MessageBox.Show("Такой чек есть");
                }
                else
                {
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(string.Format(  $"               Pitomnik \n"    
                                    +$"          Кассовый чек №{ChekNamber}\n")
                                                                      +"\n");
                                                         
                        foreach (var item in selected)
                        {
                            tw.WriteLine(string.Format($"          {item.TYPУ_CARE}   -   {item.COST}"));
                          
                        }                  
                        tw.WriteLine(string.Format(   "\n"
                                                     + $"Итого к оплате:{cost} \n"
                                                     + $"Внесено:{pris} \n"
                                                        + $"Сдача:{resylt}\n"));
                    }
                }   
          
        }

       
    }
}








