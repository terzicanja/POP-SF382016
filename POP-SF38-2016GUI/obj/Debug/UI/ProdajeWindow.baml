   M S B A M L   `   `   `  ����K  GPOP-SF38-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF38_2016GUI.UIPOP_SF38_2016GUI.UI  5   	   '    !POP_SF38_2016GUI.UI.ProdajeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF38_2016GUI.UI     5   	     � Title$  ProdajeWindow��5   	   $��759.08��6   $��609.15��6/    � WindowStartupLocation$ CenterScreen=�6>   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��95* �6   �� 5      $
��212* �6   �� 5      $
��163* �6   �� 5      $
��180* �6   �� 5      $	��79* �6    � ColumnDefinitions 5   
   �� 5      $	��78* �6   �� 5      $
��223* �6   .+�5   
   �� $��0��6   $��0��6   $��Kupac:��6-   $��15(�6>   $��36,54,10,8.2q�6L   �� 5   
   -   5        $��tbKupac��5   ;   $��0��6   $
��Auto��6    �� 	MaxLength$ 50��6,   $��11,48,80.4,8.2q�6J   $��1��6b   .��6r   ��5      �� 5       �� Path$ Kupac�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5      *   $POP_SF38_2016GUI.UI.StringValidation  5      5      .��5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgProdajaNamestaj��5   x   $��11,10.8,31.4,6.2q�6      AutoGenerateColumns .  	   SelectionMode$	 Single=�6�   
   
IsReadOnly
 . $��1��6�   $��1��6�    � DataContext 6I   �� $ SelektovanaStavka�   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� $ Namestaj.Naziv�  5"      $
 Cena��6%   $ * 63    6=   �� $ Namestaj.Cena�  5#      $ Kolicina��6%   $ * 67    6A   �� $ Kolicina�5%        5'   
   -   5        $��dgProdajaUsluga��5'   J   $��11,10.8,31.4,31.4q�6    .  $��1��6�   $��2��6�   $	 Single=�6�   
 .  6a   �� $  SelektovanaUslugaZaProdaju� 5(        5)      $ Naziv��6%   $ * 64    6>   �� $ DodatnaUsluga.Usluga�  5*      $
 Cena��6%   $ * 63    6=   �� $ DodatnaUsluga.Cena�5,      �� 5.   
   -   5        $��Dodaj Namestaj��5.      $��36,31.8,10,121.2q�6*   $��1��6b   �� 5/   
   -   5        $��Ukloni Namestaj��5/      $��36,95.8,10,57.2q�6+   $��1��6[   �� 50   
   -   5        $��Dodaj uslugu��50      $��36,23.8,10,92.4q�6(   $��2��6\   �� 51   
   -   5        $��Ukloni uslugu��51      $��36,75.8,10,28.4q�6)   $��2��6W   �� 53   
   -   5        $��Sacuvaj��53      $��11,23.4,320.4,21.6q�6#   $��4��6U   $��1��6b   ��54      �� 55       �� 
TargetType" ��6      MetroButton �� BasedOn# [  6,   .�56      ��  �� Property � {� �� Value .  62    �� Triggers 57      ^� 58       ^� 
Conditions 59      �� 5:   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ tbKupac�� �� Value	 False6o   .0�5<      ��  � {� . 6:   5=      5?      5A      �� 5B   
   -	   5        $��Izadji��5B      $��252,23.4,63.4,21.6q�6"   $��1��6[   $��4��6k   5C      5D      