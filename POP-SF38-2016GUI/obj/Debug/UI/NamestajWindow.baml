   M S B A M L   `   `   `  ����K  GPOP-SF38-2016GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_SF38_2016GUI.UIPOP_SF38_2016GUI.UI  5   	   (    "POP_SF38_2016GUI.UI.NamestajWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_SF38_2016GUI.UI     5   	     � Title$  NamestajWindow��5   	   $��467.17��6    $��447.786��60    � WindowStartupLocation$ CenterScreen=�6@   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��62* �6   �� 5      $	��74* �6   �� 5      $	��85* �6    � RowDefinitions 5   
   �� 5      $	��75* �6   �� 5      $	��46* �6   �� 5      $	��46* �6   �� 5      $	��70* �6   �� 5      $
��122* �6   �� 5      $	��78* �6   .+�5   
   �� $��0��6   $��0��6   $��Naziv:��6-   $��15(�6>   $��10,34,6,6.2q�6L   �� 5   
   -   5        $��tbNaziv��5   ,   $��0��6   $
��Auto��6   $��17,34,15.6,6.2q�6;   $��2��6S   $��1��6g    �� 	MaxLength$	 100��6w   .��6�   ��5      �� 5       �� Path$ Naziv�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5      *   $POP_SF38_2016GUI.UI.StringValidation  5      5      .��5      5       �� 5!   
   $��1��6   $��0��6   $��Cena:��6-   $��15(�6=   $��10,4.933,6,6.8q�6K   �� 5"   
   -   5        $��tbCena��5"   ,   $��1��6   $
��Auto��6   $��17,4.933,15.6,6.8q�6:   $��2��6U   $��1��6i   .��6y   ��5#      �� 5$      $
 Cena�6   $ PropertyChanged=�6&    5%      *   $POP_SF38_2016GUI.UI.DoubleValidation  5&      5(      .��5)      5*      �� 5+   
   $��2��6   $��0��6   $��	Kolicina:��6-   $��15(�6A   $��10,4.2,6,8.4q�6O   �� 5,   
   -   5        $��
tbKolicina��5,   ,   $��2��6   $
��Auto��6   $��17,4.2,15.6,8.4q�6>   $��2��6W   $��1��6k   .��6{   ��5-      �� 5.      $ KolicinaUMagacinu�6   $ PropertyChanged=�63    5/      '   !POP_SF38_2016GUI.UI.IntValidation  50      52      .��53      54      �� 55   
   $��3��6   $��0��6   $��Tip namestaja:��6-   $��15(�6F   $��10,2.6,6,26.8q�6T   �� 56   
   -   5        $��cbTipNamestaja��56       �� SelectedIndex$ 1��6)   $
��Left=�6;   $��
17,7.6,0,0q�6V   $	��Top=�6j   $	��185��6�   $��35��6�   $	 �� IsSynchronizedWithCurrentItem$
	 TrueY�6�   $��2��6�   $��1��6�   $��3��6  
 �� SelectedItem
 6�   �� $ TipNamestaja�6  �� 58   
   -   5        $��Sacuvaj��58      $��17,24.8,12,21.6q�6#   $��5��6R   $��1��6_   ��59      �� 5:       �� 
TargetType" ��6      MetroButton �� BasedOn# [  6,   .�5;      ��  �� Property � {� �� Value .  62    �� Triggers 5<      ^� 5=       ^� 
Conditions 5>      �� 5?   "    �� Binding 6,   �� $ (Validation.HasError)� �� ElementName$ tbNaziv�� �� Value	 False6o   �� 5@   "    6,   �� $ (Validation.HasError)�$ tbCena��	 False6n   �� 5A   "    6,   �� $ (Validation.HasError)�$ 
tbKolicina��	 False6r   .0�5C      ��  � {� . 6:   5D      5F      5H      �� 5I   
   -   5        $��Izadji��5I      $��2��6"   $��9,24.8,46.6,21.6q�62   $��5��6j   5K      5L      