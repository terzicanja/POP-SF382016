   M S B A M L   `   `   `  ����K  GPOP-SF38-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF38_2016GUI.UIPOP_SF38_2016GUI.UI  5   	   &     POP_SF38_2016GUI.UI.AkcijeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF38_2016GUI.UI     5   	     � Title$  AkcijeWindow��5   	   $��577.305��6   $��615.562��6/    � WindowStartupLocation$ CenterScreen=�6?   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��82* �6   �� 5      $	��55* �6   �� 5      $	��52* �6   �� 5      $	��56* �6   �� 5      $	��71* �6   �� 5      $	��60* �6   �� 5      $	��89* �6   �� 5      $	��82* �6    � ColumnDefinitions 5   
   �� 5      $
��179* �6   �� 5      $
��219* �6   �� 5      $
��210* �6   .+�5   
   �� $��Naziv:��6   $��15(�6!   $��92,26,28.2,12.4q�6/   �� 5   
   -   5        $��tbNaziv��5      $��42.8,26,33.8,7.4q�6!   $��1��6;   $��2��6K    �� 	MaxLength$ 70��6_   .��6n   ��5      �� 5       �� Path$ Naziv�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5      *   $POP_SF38_2016GUI.UI.StringValidation  5      5       .��5!      5"      �� 5#   
   $��1��6   $��0��6   $��Popust:��6-   $��15(�6?   $��78,6.6,28.2,6.6q�6M   �� 5$   
   -   5        $��tbPopust��5$   ,   $��1��6   $
��Auto��6   $��42.8,6.6,15.4,6.6q�6<   $��1��6W   .��6h   ��5%      �� 5&      $ Popust�6   $ PropertyChanged=�6(    5'      *   $POP_SF38_2016GUI.UI.PopustValidation  5(      5*      .��5+      5,      �� 5-   
   $��2��6   $��0��6   $��Datum pocetka:��6-   $��15(�6F   $��25,8.4,28.2,1.6q�6T   (  "System.Windows.Controls.DatePicker  5.   
   -   5        $��	dtPocetka��5.   H   $
��Left=�6   $��42.8,8.4,0,9.6q�60   $��1��6�   $��2��6�   $	��161��6�      SelectedDate 6Y   �� $ PocetakAkcije�6�   �� 5/   
   $��3��6   $��0��6   $��Datum zavrsetka:��6-   $��15(�6H   $��25,10.4,28.2,70.8q�6V   $��2��6q     50   
   -   5        $��dtKraj��50   J   $
��Left=�6   $��42.8,10.4,0,11.6q�60   $��1��6�   $��3��6�   $	��161��6�    6X   �� $ 
KrajAkcije�6�   �� 51   
   $��4��6   $��0��6   $��Namestaji na popustu:��6-   $��15(�6M   $��10,27.4,5.2,7.8q�6[   &   System.Windows.Controls.DataGrid  52   
   -   5        $��dgPopustNamestaj��52   p   	   AutoGenerateColumns	 .  $��8.8,27.4,9.8,19.4q�6/   
   SelectionMode$
 Extended=�6�      
IsReadOnly . $��1��6�   $��4��6�   $��2��6�   $��3��6�    � DataContext 6J   �� $ Namestaj�   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Id+  55      $ Naziv��6%   $ * 64    6>   �� $ Namestaj.Naziv�  56      $
 Cena��6%   $ * 63    6=   �� $ Namestaj.Cena�58      �� 59   
   -   5        $��Dodaj Namestaj��59      $��33,8.2,19.2,5.2q�6*   $��5��6X   �� 5:   
   -   5        $��Ukloni Namestaj��5:      $��33,8.8,19.2,33.4q�6+   $��6��6\   �� 5=   
   -   5        $��Sacuvaj��5=      $��42.8,16.6,35.4,21q�6#   $��7��6T   $��1��6a   ��5>      �� 5?       �� 
TargetType" ��6      MetroButton �� BasedOn# [  6,   .�5@      ��  �� Property � {� �� Value .  62    �� Triggers 5A      ^� 5B       ^� 
Conditions 5C      �� 5D   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ tbPopust�� �� Value	 False6p   �� 5E   "    6,   �� $ (Validation.HasError)�$ tbNaziv��	 False6o   .0�5G      ��  � {� . 6:   5H      5J      5L      �� 5N   
   -	   5        $��Izadji��5N      $��35.6,16.6,33.8,21q�6"   $��2��6Y   $��7��6i   5O      5P      