   M S B A M L   `   `   `  ����K  GPOP-SF38-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF38_2016GUI.UIPOP_SF38_2016GUI.UI  5   	   ,    &POP_SF38_2016GUI.UI.SviNamestajiWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF38_2016GUI.UI     5   	     � Title$  SviNamestajiWindow��5   	   $��504.613��6$   $��492.858��65    � WindowStartupLocation$ CenterScreen=�6E   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��49* �6   �� 5      $
��302* �6   �� 5      $	��52* �6   �� 5      $	��72* �6    � ColumnDefinitions 5   
   �� 5      $
��217* �6   �� 5      $
��270* �6   .+�5   
   �� -   5        $��tbSearch��5      $��72,13,10.8,9.8q�6"   �� 5   
   -   5        $��Search��5      $��1��6"   $��14.2,13,192.4,10.8q�62   6N   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgSviNamestaji��5      $��10,7.8,10.4,2.2q�6)    �� SelectedIndex$ 0��6B      AutoGenerateColumns .     CanUserAddRows .  $��2��6�   $��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 64   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6>   ��  �� Path$ Naziv�  5      $
 Cena��6%   $	 * 63   
 6=   �� $
 Cena�  5      $ 	Na stanju��6%   $	 * 68   
 6B   �� $ KolicinaUMagacinu�5      �� 5   
   -   5        $��lbKoliko��5      $��Koliko:��6    $��119,2.8,23.8,11.2q�62   $��2��6M   �� 5   
   -   5        $��tbKoliko��5   ,   $��2��6   $
��Auto��6   $��14.2,2.8,45.4,11.2q�6<   $��1��6X   ��6h   �� $ Kolicina��� 5"   
   -   5        $��PickSave��5"   =   $��Sacuvaj��6   $��98,7.8,23.8,28.2q�6#   $��3��6M   ��5#      �� 5$       �� 
TargetType" ��6      MetroButton �� BasedOn# [  6,   .�5%      ��  �� Property � {� �� Value .  62    �� Triggers 5&      ^� 5'       ^� 
Conditions 5(      �� 5)   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ tbKoliko�� �� Value	 False6p   .0�5+      ��  � {� . 6:   5,      5.      50      �� 51   
   -   5        $��Izadji��51      $��122.2,7.8,45.4,22.2q�6"   $��1��6?   $��3��6O   6\   52      53      