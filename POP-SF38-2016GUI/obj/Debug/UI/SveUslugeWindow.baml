   M S B A M L   `   `   `  ����K  GPOP-SF38-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF38_2016GUI.UIPOP_SF38_2016GUI.UI  5   	   )    #POP_SF38_2016GUI.UI.SveUslugeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF38_2016GUI.UI     5   	     � Title$  SveUslugeWindow��5   	   $��344.131��6!   $��375.915��62    � WindowStartupLocation$ CenterScreen=�6B   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��257* �6   �� 5      $	��58* �6    � ColumnDefinitions 5   
   �� 5      $
��163* �6   �� 5      $
��207* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgSveUsluge��5      $��10,10,10.6,10.547q�6&      AutoGenerateColumns .     CanUserAddRows .  $��2��6t      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 64   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6>   �� 
 �� Path$
 Usluga�  5      $
 Cena��6%   $ * 63   	 6=   �� $

 Cena�5      �� 5   
   -   5        $��PickSave��5   @   $��Sacuvaj��6   $��46,11.453,48.2,10.4q�6#   $��1��6c   �� 5   
   $��Izadji��6   $��35.8,11.453,90.6,10.4q�6"   $��1��6A   $��1��6Q   5      5      